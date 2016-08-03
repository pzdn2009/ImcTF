using ImcFramework.WcfInterface;
using Quartz;
using System.Linq;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Extension for <see cref="EServiceType"/> to <see cref="JobKey"/>, & <see cref="TriggerKey"/>.
    /// </summary>
    internal static class KeyCreator
    {
        /// <summary>
        /// The const string of default group.
        /// </summary>
        public static string MAIN_BUSINESS = "MainBusiness";

        /// <summary>
        /// Map <see cref="EServiceType"/> to <see cref="JobKey"/>.
        /// </summary>
        /// <param name="serviceType">The given serviceType.</param>
        /// <returns>return the mapped <see cref="JobKey"/> object.</returns>
        public static JobKey ToJobKey(this EServiceType serviceType)
        {
            return ToJobKey(serviceType.ServiceType, serviceType.GroupName);
        }

        /// <summary>
        /// <see cref="JobKey"/> extension.
        /// </summary>
        /// <param name="serviceType">The serviceType string name.</param>
        /// <param name="groupName">The groupname.</param>
        /// <returns></returns>
        public static JobKey ToJobKey(string serviceType, string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                groupName = MAIN_BUSINESS;
            }
            return new JobKey(serviceType, groupName);
        }

        /// <summary>
        /// Get trigger of the <see cref="IScheduler"/> .
        /// </summary>
        /// <param name="scheduler">The scheduler.</param>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the current trigger of the scheduler.</returns>
        public static ITrigger GetTrigger(this IScheduler scheduler, EServiceType serviceType)
        {
            return scheduler.GetTriggersOfJob(serviceType.ToJobKey()).FirstOrDefault();
        }
    }
}
