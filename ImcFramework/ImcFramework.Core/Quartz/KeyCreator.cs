using Quartz;

namespace ImcFramework.Core.Quartz
{
    internal static class KeyCreator
    {
        public static string TRIGGER = "Trigger";
        public static string MAIN_BUSINESS = "MainBusiness";

        public static JobKey GetJobKey(this string serviceType)
        {
            return GetJobKey(serviceType, MAIN_BUSINESS);
        }

        public static JobKey GetJobKey(this string serviceType, string group)
        {
            return new JobKey(serviceType, group);
        }

        public static TriggerKey GetTriggerKey(this string serviceType)
        {
            return GetTriggerKey(serviceType + TRIGGER, serviceType + TRIGGER);
        }

        public static TriggerKey GetTriggerKey(this string serviceType, string group)
        {
            return new TriggerKey(serviceType, serviceType);
        }
    }
}
