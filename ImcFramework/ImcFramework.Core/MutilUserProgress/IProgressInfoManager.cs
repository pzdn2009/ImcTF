using ImcFramework.WcfInterface;

namespace ImcFramework.Core.MutilUserProgress
{
    public interface IProgressInfoManager
    {
        void SetTotal(EServiceType serviceType, int total, TotalType totalType);

        void Clear(EServiceType serviceType);

        ProgressItem GetUserProgressInfo(EServiceType serviceType, string user);

        ProgressSummary GetTotal(EServiceType serviceType);

        void SetItemTotal(EServiceType serviceType, string user, int total);

        void SetItemValue(EServiceType serviceType, string user, int value, bool accumulate = true);

        void SetItemValueFinish(EServiceType serviceType, string user);
    }
}