using Quartz;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// The default schedule provider.
    /// </summary>
    public class DefaultScheduleProvider : IScheduleProvider
    {
        public DefaultScheduleProvider(IScheduler schedule)
        {
            Schedule = schedule;
        }

        public IScheduler Schedule { get; private set; }
    }
}
