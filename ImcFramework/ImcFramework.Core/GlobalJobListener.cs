using ImcFramework.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class GlobalJobListener : IJobListener
    {
        public virtual void JobExecutionVetoed(IJobExecutionContext context)
        {

        }

        public virtual void JobToBeExecuted(IJobExecutionContext context)
        {

        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (jobException != null)
            {
                LogHelper.Error(string.Format("Job:{0} 执行出错：", context.JobDetail.Key.Name) + jobException);
            }
        }

        public virtual string Name
        {
            get { return "MainJobListener"; }
        }
    }
}
