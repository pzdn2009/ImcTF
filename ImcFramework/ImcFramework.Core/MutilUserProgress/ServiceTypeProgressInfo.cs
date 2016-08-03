using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.ProgressInfos;
using System.Collections.Generic;

namespace ImcFramework.Core.MutilUserProgress
{
    /// <summary>
    /// The dictionary for the <see cref="EServiceType"/> as key,the <see cref="UserProgressItem"/> as value.
    /// </summary>
    public class ServiceTypeProgressInfo : Dictionary<EServiceType, UserProgressItem>
    {
        /// <summary>
        /// Get Total info for the given servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get user's progressinfo for the given servicetype and the given user.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Set the total info 
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="total">The total number.</param>
        /// <param name="totalType">The totaltype.<see cref="TotalType"/> .</param>
        public void SetTotal(EServiceType serviceType, int total, TotalType totalType)
        {
            if (!ContainsKey(serviceType))
            {
                Add(serviceType, new UserProgressItem());
            }

            this[serviceType].ProgressSummary = new ProgressSummary(0, total, totalType);
        }

        /// <summary>
        /// Set progress info for the given servicetype and the given user.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user.</param>
        /// <param name="value">The value.</param>
        /// <param name="accumulate">If true ,accumulated the value,otherwise ,cover origin with the value.</param>
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
