using ImcFramework.WcfInterface;

namespace ImcFramework.Core.MutilUserProgress
{
    /// <summary>
    /// 多用户进度管理
    /// </summary>
    public interface IMutilUserProgress
    {
        /// <summary>
        /// 发送总数
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="totalType">SellerAccountCount:为销售账号总数，RecordCount:全部记录数</param>
        void SendTaskProgressTotal(int count, TotalType totalType);

        /// <summary>
        /// 发送账号总数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="total">总数</param>
        void SendTaskProgressItemTotal(string user, int total);

        /// <summary>
        /// 递增1
        /// </summary>
        /// <param name="user">用户</param>
        void SendTaskProgressIncrease(string user);

        /// <summary>
        /// 强制完成
        /// </summary>
        /// <param name="user">用户</param>
        void ForceFinish(string user);

        /// <summary>
        /// 全部完成
        /// </summary>
        void FinishAll();
    }
}
