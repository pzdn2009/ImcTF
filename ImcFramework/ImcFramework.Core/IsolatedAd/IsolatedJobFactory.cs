using Quartz;
using Quartz.Spi;
using System;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// Isolated JobFactory,which creates the <see cref="IsolatedJob"/> object.
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

        public void ReturnJob(IJob job)
        {
            IDisposable disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
}
