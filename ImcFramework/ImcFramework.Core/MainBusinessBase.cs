using Common.Logging;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Threading;
using System.Diagnostics;
using ImcFramework.Core.MutilUserProgress;
using ImcFramework.Core.Distribution;
using ImcFramework.WcfInterface.TransferMessage;

namespace ImcFramework.Core
{
    [DisallowConcurrentExecution]
    public abstract class MainBusinessBase : IInterruptableJob, ICancel
    {
        private Lazy<IMutilUserProgress> multiUser;
        public IMutilUserProgress MutilUserProgress
        {
            get { return multiUser.Value; }
            set { multiUser = new Lazy<IMutilUserProgress>(() => { return value; }); }
        }

        private IDistributionFacility<MessageEntity> distributionFacility;

        public MainBusinessBase()
        {
            multiUser = new Lazy<IMutilUserProgress>(() => { return new DefaultMutilUserProgress(ServiceType); });
            CancellationTokenSource = new CancellationTokenSource();

            distributionFacility = DistributionFacilityFactory.GetDistributionFacility<MessageEntity>();
        }

        public abstract EServiceType ServiceType { get; }

        protected CancellationTokenSource CancellationTokenSource { get; set; }

        public virtual void Execute(IJobExecutionContext context)
        {
            try
            {
                ExecuteCore(context);
            }
            catch (ImcFrameworkException ex)
            {
                var msg = ServiceType.ToString() + ex.Message + ex.StackTrace;
                NotifyAndLog(msg, LogLevel.Error);
            }
            catch (AggregateException ex)
            {
                foreach (var exItem in ex.InnerExceptions)
                {
                    var msg = ServiceType.ToString() + exItem.Message + ex.GetType().ToString() + ex.StackTrace;
                    NotifyAndLog(msg, LogLevel.Error);
                }
            }
            catch (Exception ex)
            {
                var msg = ServiceType.ToString() + ex.Message + ex.StackTrace;
                NotifyAndLog(msg, LogLevel.Error);
            }
        }

        public virtual void ExecuteCore(IJobExecutionContext context)
        {

        }

        protected string GetTraceId()
        {
            return Guid.NewGuid().ToString();
        }

        protected void NotifyAndLog(string message, LogLevel logLevel)
        {
            NotifyAndLog(message, logLevel, null);
        }

        protected void NotifyAndLog(string message, LogLevel logLevel, string user)
        {
            var sf = new StackFrame(2);
            var method = sf.GetMethod();
            var className = method.DeclaringType.Name;

            var messageEntity = MessageEntityBuilder.Create()
                       .WithServiceType(ServiceType)
                       .WithMsgContent(message)
                       .WithMessageType(EMessageType.Info)
                       .WithUser(user)
                       .WithLogLevel(logLevel.ToString())
                       .WithClassName(className)
                       .WithMethodName(method.Name)
                       .Build();

            distributionFacility.Push(messageEntity);
        }

        public virtual void Cancel()
        {
            CancellationTokenSource.Cancel();
            NotifyAndLog("Cancel called", LogLevel.Info);
        }

        protected bool IsCanceled()
        {
            return CancellationTokenSource.IsCancellationRequested;
        }

        public virtual void Interrupt()
        {
            NotifyAndLog("中断", LogLevel.Info);
        }
    }
}
