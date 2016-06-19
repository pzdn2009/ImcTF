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
    public abstract class MainBusinessBase : IJob, ITaskCancle
    {
        private Lazy<ISellerAccountProgress> sellerAccountProgressLazy;
        public ISellerAccountProgress SellerAccountProgress
        {
            get { return sellerAccountProgressLazy.Value; }
            set { sellerAccountProgressLazy = new Lazy<ISellerAccountProgress>(() => { return value; }); }
        }

        public MainBusinessBase()
        {
            sellerAccountProgressLazy = new Lazy<ISellerAccountProgress>(() => { return new DefaultSellerAccountProgress(this.ServiceType); });
        }


        public abstract EServiceType ServiceType { get; }

        public virtual void Execute(IJobExecutionContext context)
        {
            try
            {
                ExecuteCore(context);
            }
            catch(ImcFrameworkException ex)
            {
                throw ex;
            }
            catch(AggregateException ex)
            {

            }
            catch (Exception ex)
            {
                
            }
        }

        public virtual void ExecuteCore(IJobExecutionContext context)
        {

        }

        public virtual void ControlTaskConcurrent(List<Task> tasks, int maxRunTasks = 5)
        {
            MutilTaskPaging.RunBySimplePaging(tasks, maxRunTasks);
        }

        private string message = null;
        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
            }
        }

        protected string GetTraceId()
        {
            return Guid.NewGuid().ToString();
        }

        protected void NotifyAndLog(string message, LogLevel logLevel)
        {
            NotifyAndLog(message, logLevel, null);
        }
        protected void NotifyAndLog(string message, LogLevel logLevel, string sellerAccount)
        {
            var sf = new StackFrame(2);
            var method = sf.GetMethod();
            var className = method.DeclaringType.Name;
            Observers.BroadCastMessage(ServiceType, logLevel, sellerAccount, message, className, method.Name);
        }
        //取消标记
        protected CancellationTokenSource m_cts = new CancellationTokenSource();
        public virtual void Cancel()
        {
            m_cts.Cancel();
            NotifyAndLog("Cancel called", LogLevel.Info);
        }

        protected void CheckIsCanceled()
        {
            if (m_cts.IsCancellationRequested)
            {
                SellerAccountProgress.FinishAll();
            }
        }
    }
}
