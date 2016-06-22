using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.WcfInterface
{
    public interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void Notify(MessageEntity msgEntity);

        [OperationContract(IsOneWay = true)]
        void NotifyLogInfo(string message);

        #region 通知任务进度

        /// <summary>
        /// 总量
        /// </summary>
        /// <param name="totalInfo">总量及其类型</param>
        [OperationContract(IsOneWay = true)]
        void NotifyTaskProgressTotal(ProgressSummary totalInfo);

        /// <summary>
        /// 销售账号及其总量
        /// </summary>
        /// <param name="sellerAccount">销售账号</param>
        /// <param name="total">总量</param>
        [OperationContract(IsOneWay = true)]
        void NotifyTaskProgressItemTotal(string sellerAccount, int total);

        /// <summary>
        /// 销售账号、进度值、总量
        /// </summary>
        /// <param name="sellerAccount">销售账号</param>
        /// <param name="sellerAccountProgress">进度值，总量</param>
        [OperationContract(IsOneWay = true)]
        void NotifyTaskProgressItemValueAndTotal(string sellerAccount, ProgressItem sellerAccountProgress);

        /// <summary>
        /// 强制完成
        /// </summary>
        /// <param name="sellerAccount">销售账号</param>
        [OperationContract(IsOneWay = true)]
        void NotifyTaskProgressForceFinish(string sellerAccount);

        /// <summary>
        /// 全部完成
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void NotifyTaskProgressFinishAll();

        #endregion
    }
}
