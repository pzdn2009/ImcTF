using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// 隔离的Job工厂
    /// </summary>
    public class IsolatedJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return NewJob(bundle.JobDetail.JobType);
        }

        private IJob NewJob(Type jobType)
        {
            return new IsolatedJob(jobType);
        }

        public void ReturnJob(Quartz.IJob job)
        {
            IDisposable disposable = job as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
