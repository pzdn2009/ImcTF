using ImcFramework.WcfInterface;

namespace ImcFramework.Core.MutilUserProgress
{
    public class ProgressInfoManager : IProgressInfoManager
    {
        private ProgressInfoManager() { }

        private static ProgressInfoManager instance = new ProgressInfoManager();
        private static object lockObject = new object();

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

        private ServiceTypeProgressInfo serviceTypePrgressInfo = new ServiceTypeProgressInfo();

        #region Query

        public ProgressSummary GetTotal(EServiceType serviceType)
        {
            lock (lockObject)
            {
                return serviceTypePrgressInfo.GetTotal(serviceType);
            }
        }

        public ProgressItem GetUserProgressInfo(EServiceType serviceType, string user)
        {
            lock (lockObject)
            {
                return serviceTypePrgressInfo.GetUserProgressInfo(serviceType, user);
            }
        }

        #endregion

        #region Set

        public void SetTotal(EServiceType serviceType, int total, TotalType totalType)
        {
            lock (lockObject)
            {
                serviceTypePrgressInfo.SetTotal(serviceType, total, totalType);
            }
        }

        public void SetItemTotal(EServiceType serviceType, string user, int total)
        {
            lock (lockObject)
            {
                serviceTypePrgressInfo[serviceType].SetProgressItem(user, total, 0);
            }
        }

        public void SetItemValue(EServiceType serviceType, string user, int value, bool accumulate = true)
        {
            lock (lockObject)
            {
                serviceTypePrgressInfo.SetItemValue(serviceType, user, value, accumulate);
            }
        }

        public void SetItemValueFinish(EServiceType serviceType, string user)
        {
            lock (lockObject)
            {
                serviceTypePrgressInfo[serviceType].SetItemValueFinish(user);
            }
        }

        public void Clear(EServiceType serviceType)
        {
            lock (lockObject)
            {
                serviceTypePrgressInfo.Remove(serviceType);
            }
        }

        #endregion
    }
}
