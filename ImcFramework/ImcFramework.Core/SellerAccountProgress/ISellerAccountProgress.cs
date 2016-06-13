using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 销售账号进度管理
    /// </summary>
    public interface ISellerAccountProgress
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
        /// <param name="sellerAccount">销售账号</param>
        /// <param name="total">总数</param>
        void SendTaskProgressItemTotal(string sellerAccount, int total);

        /// <summary>
        /// 递增1
        /// </summary>
        /// <param name="sellerAccount">销售账号</param>
        void SendTaskProgressIncrease(string sellerAccount);

        /// <summary>
        /// 强制完成
        /// </summary>
        /// <param name="sellerAccount">销售账号</param>
        void ForceFinish(string sellerAccount);

        /// <summary>
        /// 全部完成
        /// </summary>
        void FinishAll();
    }
}
