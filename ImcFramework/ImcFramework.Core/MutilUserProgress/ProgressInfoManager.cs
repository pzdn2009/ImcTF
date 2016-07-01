using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.MutilUserProgress
{
    public interface IProgressInfoManager
    {

    }

    public class ProgressInfoManager
    {
        private ProgressInfoManager() { }

        private static ProgressInfoManager instance = new ProgressInfoManager();
        private static object lockObject = new object();
        private static Dictionary<string, ProgressInfoEntity> dictProgressInfo = new Dictionary<string, ProgressInfoEntity>();

        public static ProgressInfoManager Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ProgressInfoManager();
                    }
                    return instance;
                }
            }
        }

        #region Query

        public ProgressInfoEntity GetProgressInfo(string serviceType)
        {
            lock (lockObject)
            {
                if (dictProgressInfo.ContainsKey(serviceType))
                {
                    return dictProgressInfo[serviceType];
                }
                return new ProgressInfoEntity();
            }
        }

        public ProgressSummary GetTotal(EServiceType serviceType)
        {
            lock (lockObject)
            {
                if (dictProgressInfo.ContainsKey(serviceType.ServiceType))
                {
                    var info = dictProgressInfo[serviceType.ServiceType];
                    if (info.ProgressSummarySpecific)
                    {
                        return info.ProgressSummary;
                    }
                }
            }

            return null;
        }

        public ProgressItem GetSellerAccountProgressInfo(EServiceType serviceType, string sellerAccount)
        {
            lock (lockObject)
            {
                if (dictProgressInfo.ContainsKey(serviceType.ServiceType))
                {
                    var info = dictProgressInfo[serviceType.ServiceType];
                    if (info.DictUserProgressCount.ContainsKey(sellerAccount))
                    {
                        var progress = new ProgressItem();
                        progress.Total = info.DictUserProgressCount[sellerAccount].Total;
                        progress.Value = info.DictUserProgressCount[sellerAccount].Value;
                        return progress;
                    }
                }
            }

            return null;
        }

        #endregion

        #region Set

        public void SetTotal(string serviceType, int total, TotalType totalType)
        {
            lock (lockObject)
            {
                dictProgressInfo[serviceType] = new ProgressInfoEntity() { ProgressSummary = new ProgressSummary(0, total, totalType) };
            }
        }

        public void SetItemTotal(string serviceType, string user, int total)
        {
            lock (lockObject)
            {
                dictProgressInfo[serviceType].SetProgressItem(user, total, 0);
            }
        }

        public void SetItemValue(string serviceType, string user, int value, bool accumulate = true)
        {
            lock (lockObject)
            {
                if (dictProgressInfo.ContainsKey(serviceType))
                {
                    var dict = dictProgressInfo[serviceType].DictUserProgressCount;
                    if (dict.ContainsKey(user))
                    {
                        if (!accumulate)
                            dict[user].Value = value;
                        else
                            dict[user].Value += value;

                        if (dictProgressInfo[serviceType].ProgressSummary.TotalType == TotalType.User)
                        {
                            if (dict[user].Value == dict[user].Total)
                            {
                                dictProgressInfo[serviceType].ProgressSummary.Value++;
                            }
                        }
                        else
                        {
                            dictProgressInfo[serviceType].ProgressSummary.Value++;
                        }
                    }
                }
            }
        }

        public void SetItemValueFinish(string serviceType, string user)
        {
            lock (lockObject)
            {
                dictProgressInfo[serviceType].SetItemValueFinish(user);
            }
        }

        public void Clear(string serviceType)
        {
            lock (lockObject)
            {
                dictProgressInfo.Remove(serviceType);
            }
        }

        #endregion
    }

    /// <summary>
    /// 进度信息
    /// </summary>
    public class ProgressInfoEntity
    {
        public ProgressInfoEntity()
        {
            DictUserProgressCount = new Dictionary<string, ProgressItem>();
        }

        public bool ProgressSummarySpecific { get; private set; }

        private ProgressSummary progressSummary;
        public ProgressSummary ProgressSummary
        {
            get { return progressSummary; }
            set
            {
                progressSummary = value;
                ProgressSummarySpecific = true;
            }
        }

        /// <summary>
        /// 销售账号|进度|总数
        /// </summary>
        public Dictionary<string, ProgressItem> DictUserProgressCount { get; set; }

        public int Count()
        {
            return DictUserProgressCount.Count;
        }

        public void SetProgressItem(string user, int total, int value, bool accumulate = true)
        {
            var dict = DictUserProgressCount;
            if (dict.ContainsKey(user))
            {
                dict[user].Total = total;
            }
            else
            {
                dict[user] = new ProgressItem(0, total);
            }
        }

        public void SetItemValueFinish(string user)
        {
            var dict = DictUserProgressCount;
            if (dict.ContainsKey(user))
            {
                dict[user].Value = dict[user].Total;
            }
        }
    }
}
