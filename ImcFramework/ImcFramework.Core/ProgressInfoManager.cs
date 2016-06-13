using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
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
                    if (info.DictSellerAccountProgressCount.ContainsKey(sellerAccount))
                    {
                        var progress = new ProgressItem();
                        progress.Total = info.DictSellerAccountProgressCount[sellerAccount].Total;
                        progress.Value = info.DictSellerAccountProgressCount[sellerAccount].Value;
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

        public void SetItemTotal(string serviceType, string sellerAccount, int total)
        {
            lock (lockObject)
            {
                var dict = dictProgressInfo[serviceType].DictSellerAccountProgressCount;
                if (dict.ContainsKey(sellerAccount))
                {
                    dict[sellerAccount].Total = total;
                }
                else
                {
                    dict[sellerAccount] = new ProgressItem(0, total);
                }
            }
        }

        public void SetItemValue(string serviceType, string sellerAccount, int value, bool accumulate = true)
        {
            lock (lockObject)
            {
                if (dictProgressInfo.ContainsKey(serviceType))
                {
                    var dict = dictProgressInfo[serviceType].DictSellerAccountProgressCount;
                    if (dict.ContainsKey(sellerAccount))
                    {
                        if (!accumulate)
                            dict[sellerAccount].Value = value;
                        else
                            dict[sellerAccount].Value += value;

                        if (dictProgressInfo[serviceType].ProgressSummary.TotalType == TotalType.SellerAccountCount)
                        {
                            if (dict[sellerAccount].Value == dict[sellerAccount].Total)
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

        public void SetItemValueFinish(string serviceType, string sellerAccount)
        {
            lock (lockObject)
            {
                var dict = dictProgressInfo[serviceType].DictSellerAccountProgressCount;
                if (dict.ContainsKey(sellerAccount))
                {
                    dict[sellerAccount].Value = dict[sellerAccount].Total;
                }
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
            DictSellerAccountProgressCount = new Dictionary<string, ProgressItem>();
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
        public Dictionary<string, ProgressItem> DictSellerAccountProgressCount { get; set; }
    }
}
