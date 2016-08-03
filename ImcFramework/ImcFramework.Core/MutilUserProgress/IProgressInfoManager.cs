using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.ProgressInfos;

namespace ImcFramework.Core.MutilUserProgress
{
    /// <summary>
    /// The progressinfo manager for all servicetypes's progress.
    /// </summary>
    public interface IProgressInfoManager
    {
        /// <summary>
        /// Set total info for the given servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype</param>
        /// <param name="total">The total number</param>
        /// <param name="totalType">The total type</param>
        void SetTotal(EServiceType serviceType, int total, TotalType totalType);

        /// <summary>
        /// Clear all servicetypes's progress.
        /// </summary>
        /// <param name="serviceType">The given servicetype</param>
        void Clear(EServiceType serviceType);

        /// <summary>
        /// Get progress info of a user.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user</param>
        /// <returns>return the <see cref="ProgressItem"/> object. </returns>
        ProgressItem GetUserProgressInfo(EServiceType serviceType, string user);

        /// <summary>
        /// Get total info for the given servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the <see cref="ProgressSummary"/> objects. </returns>
        ProgressSummary GetTotal(EServiceType serviceType);

        /// <summary>
        /// Set user's total info.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user.</param>
        /// <param name="total">The total number.</param>
        void SetItemTotal(EServiceType serviceType, string user, int total);

        /// <summary>
        /// Set user's progress value.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user.</param>
        /// <param name="value">The value.</param>
        /// <param name="accumulate">If true ,accumulated the value,otherwise ,cover origin with the value.</param>
        void SetItemValue(EServiceType serviceType, string user, int value, bool accumulate = true);

        /// <summary>
        /// Set user's progress value as finished. 
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user">The user.</param>
        void SetItemValueFinish(EServiceType serviceType, string user);
    }
}