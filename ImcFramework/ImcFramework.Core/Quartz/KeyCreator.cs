using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Quartz
{
    internal static class KeyCreator
    {
        private static string TRIGGER = "Trigger";
        private static string MAIN_BUSINESS = "MainBusiness";

        public static JobKey GetJobKey(this string serviceName)
        {
            return GetJobKey(serviceName, MAIN_BUSINESS);
        }

        public static JobKey GetJobKey(this string serviceName, string group)
        {
            return new JobKey(serviceName, group);
        }

        public static TriggerKey GetTriggerKey(this string serviceName)
        {
            return GetTriggerKey(serviceName + TRIGGER, serviceName + TRIGGER);
        }

        public static TriggerKey GetTriggerKey(this string serviceName, string group)
        {
            return new TriggerKey(serviceName, serviceName);
        }
    }
}
