using ImcFramework.WcfInterface;
using Quartz;
using System.Collections.Generic;
using System.Linq;

namespace ImcFramework.Core.Quartz
{
    internal static class KeyCreator
    {
        public static string MAIN_BUSINESS = "MainBusiness";

        public static JobKey ToJobKey(this EServiceType serviceType)
        {
            return ToJobKey(serviceType.ServiceType, serviceType.GroupName);
        }

        public static JobKey ToJobKey(string serviceType, string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                groupName = MAIN_BUSINESS;
            }
            return new JobKey(serviceType, groupName);
        }

        public static ITrigger GetTrigger(this IScheduler scheduler, EServiceType serviceType)
        {
            return scheduler.GetTriggersOfJob(serviceType.ToJobKey()).FirstOrDefault();
        }
    }
}
