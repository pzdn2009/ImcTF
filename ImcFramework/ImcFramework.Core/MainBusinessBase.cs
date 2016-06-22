using Common.Logging;
using ImcFramework.Infrastructure;
using ImcFramework.Core;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ImcFramework.Core
{
    [DisallowConcurrentExecution]
    public abstract class MainBusinessBase : IJob, ITaskCancel
    {
        private Lazy<IMutilUserProgress> multiUser;
        public IMutilUserProgress MutilUserProgress
        {
            get { return multiUser.Value; }
            set { multiUser = new Lazy<IMutilUserProgress>(() => { return value; }); }
        }

        public MainBusinessBase()
        {
            multiUser = new Lazy<IMutilUserProgress>(() => { return new DefaultMutilUserProgress(ServiceType); });
            CancellationTokenSource = new CancellationTokenSource();
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
                throw ex;
            }
            catch (AggregateException ex)
            {

            }
            catch (Exception ex)
            {

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
            Observers.BroadCastMessage(ServiceType, logLevel, user, message, className, method.Name);
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
    }
}
