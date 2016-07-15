using ImcFramework.WcfInterface;

namespace ImcFramework.Core.MutilUserProgress
{
    public interface IProgressInfoManager
    {
        void SetTotal(string serviceType, int total, TotalType totalType);

        void Clear(string serviceType);

        ProgressItem GetSellerAccountProgressInfo(EServiceType serviceType, string user);

        ProgressSummary GetTotal(EServiceType serviceType);

        void SetItemTotal(string serviceType, string user, int total);

        void SetItemValue(string serviceType, string user, int value, bool accumulate = true);

        void SetItemValueFinish(string serviceType, string user);
    }
}