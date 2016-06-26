using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace ImcFramework.Core.Quartz
{
    public class DefaultScheduleProvider : IScheduleProvider
    {
        public DefaultScheduleProvider(IScheduler schedule)
        {
            Schedule = schedule;
        }

        public IScheduler Schedule { get; private set; }
    }
}
