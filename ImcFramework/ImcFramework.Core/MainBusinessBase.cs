using Common.Logging;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Threading;
using System.Diagnostics;
using ImcFramework.Core.MutilUserProgress;
using ImcFramework.Core.Distribution;
using ImcFramework.WcfInterface.TransferMessage;
using ImcFramework.WcfInterface.Enums;

namespace ImcFramework.Core
{
    /// <summary>
    /// The base class for a servicetype ,which run in an isolated appdomain.
    /// </summary>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainBusinessBase()
        {
            multiUser = new Lazy<IMutilUserProgress>(() => { return new DefaultMutilUserProgress(ServiceType); });
            CancellationTokenSource = new CancellationTokenSource();

            distributionFacility = DistributionFacilityFactory.GetDistributionFacility<MessageEntity>();
        }

        /// <summary>
        /// The servicetype , override in sub-class.
        /// </summary>
        public abstract EServiceType ServiceType { get; }

        /// <summary>
        /// The cancellation token source for cancellation invoke.
        /// </summary>
        protected CancellationTokenSource CancellationTokenSource { get; set; }

        /// <summary>
        /// The template execute method with captures exceptions .
        /// </summary>
        /// <param name="context">The job-context.</param>
        public virtual void Execute(IJobExecutionContext context)
        {
            try
            {
                ExecuteCore(context);
            }
            catch (ImcFrameworkException ex)
            {
                var msg = ServiceType.GetFullString() + ex.Message + ex.StackTrace;
                NotifyAndLog(msg, LogLevel.Error);
            }
            catch (AggregateException ex)
            {
                foreach (var exItem in ex.InnerExceptions)
                {
                    var msg = ServiceType.GetFullString() + exItem.Message + exItem.GetType().ToString() + exItem.StackTrace;
                    NotifyAndLog(msg, LogLevel.Error);
                }
            }
            catch (Exception ex)
            {
                var msg = ServiceType.GetFullString() + ex.Message + ex.StackTrace;
                NotifyAndLog(msg, LogLevel.Error);
            }
        }

        /// <summary>
        /// The executecore method without captures exceptions ,which needs implement caputuring exceptions.
        /// </summary>
        /// <param name="context">The job-context.</param>
        public virtual void ExecuteCore(IJobExecutionContext context)
        {

        }

        /// <summary>
        /// Get a new guid.
        /// </summary>
        /// <returns>retun guid string.</returns>
        protected string GetTraceId()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Noitify mesasge to clients and log it.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="logLevel">The logLevel</param>
        protected void NotifyAndLog(string message, LogLevel logLevel)
        {
            NotifyAndLog(message, logLevel, null);
        }

        /// <summary>
        /// Noitify mesasge to clients and log it.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="logLevel">The logLevel.</param>
        /// <param name="user">The user.</param>
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

        /// <summary>
        /// Cancel a servicetype(job).
        /// </summary>
        public virtual void Cancel()
        {
            CancellationTokenSource.Cancel();
            NotifyAndLog("Cancel called", LogLevel.Info);
        }

        /// <summary>
        /// Check is cancellation requested whether or not. 
        /// </summary>
        /// <returns>return true if cancellation requested.</returns>
        protected bool IsCanceled()
        {
            return CancellationTokenSource.IsCancellationRequested;
        }

        /// <summary>
        /// Interrupt a servicetype(job).
        /// </summary>
        public virtual void Interrupt()
        {
            NotifyAndLog("Interrupt called.", LogLevel.Info);
        }
    }
}
