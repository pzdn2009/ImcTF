using Quartz;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// The schedule provider interface.
    /// </summary>
    public interface IScheduleProvider
    {
        IScheduler Schedule { get; }
    }
}
