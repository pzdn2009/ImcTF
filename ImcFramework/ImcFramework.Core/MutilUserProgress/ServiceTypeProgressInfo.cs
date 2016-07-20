using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Core.MutilUserProgress
{
    public class ServiceTypeProgressInfo : Dictionary<EServiceType, UserProgressItem>
    {

        public ProgressSummary GetTotal(EServiceType serviceType)
        {
            if (ContainsKey(serviceType))
            {
                var info = this[serviceType];
                if (info.ProgressSummarySpecific)
                {
                    return info.ProgressSummary;
                }
            }

            return null;
        }

        public ProgressItem GetUserProgressInfo(EServiceType serviceType, string user)
        {
            if (ContainsKey(serviceType))
            {
                var info = this[serviceType];
                if (info.ContainsKey(user))
                {
                    var progress = new ProgressItem();
                    progress.Total = info[user].Total;
                    progress.Value = info[user].Value;
                    return progress;
                }
            }

            return null;
        }

        public void SetTotal(EServiceType serviceType, int total, TotalType totalType)
        {
            if (!ContainsKey(serviceType))
            {
                Add(serviceType, new UserProgressItem());
            }

            this[serviceType].ProgressSummary = new ProgressSummary(0, total, totalType);
        }

        public void SetItemValue(EServiceType serviceType, string user, int value, bool accumulate = true)
        {
            if (ContainsKey(serviceType))
            {
                var dict = this[serviceType];
                if (dict.ContainsKey(user))
                {
                    if (!accumulate)
                        dict[user].Value = value;
                    else
                        dict[user].Value += value;

                    if (this[serviceType].ProgressSummary.TotalType == TotalType.User)
                    {
                        if (dict[user].Value == dict[user].Total)
                        {
                            this[serviceType].ProgressSummary.Value++;
                        }
                    }
                    else
                    {
                        this[serviceType].ProgressSummary.Value++;
                    }
                }
            }
        }
    }
}
