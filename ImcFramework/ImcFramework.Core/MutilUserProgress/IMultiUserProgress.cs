using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.ProgressInfos;

namespace ImcFramework.Core.MutilUserProgress
{
    /// <summary>
    /// Indicates mutil-user progress.
    /// </summary>
    public interface IMutilUserProgress
    {
        /// <summary>
        /// Send the progress's total info.
        /// </summary>
        /// <param name="count">The total number</param>
        /// <param name="totalType">The totalType of the progress ,<see cref="TotalType"/> .</param>
        void SendTaskProgressTotal(int count, TotalType totalType);

        /// <summary>
        /// Send the user's total info.
        /// </summary>
        /// <param name="user">The user</param>
        /// <param name="total">The total</param>
        void SendTaskProgressItemTotal(string user, int total);

        /// <summary>
        /// Increase one for the user progress 
        /// </summary>
        /// <param name="user">The user</param>
        void SendTaskProgressIncrease(string user);

        /// <summary>
        /// Force finish the progress of the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void ForceFinish(string user);

        /// <summary>
        /// Finish all the (user's) progress info.
        /// </summary>
        void FinishAll();
    }
}
