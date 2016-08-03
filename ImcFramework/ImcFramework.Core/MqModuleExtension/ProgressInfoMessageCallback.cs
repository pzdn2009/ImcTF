using ImcFramework.Core.MutilUserProgress;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.ProgressInfos;
using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// Callback for the ProgressInfoMessage.
    /// </summary>
    public class ProgressInfoMessageCallback : ITransferMessageCallback
    {
        private IProgressInfoManager progressInfoManager;
        public ProgressInfoMessageCallback(IProgressInfoManager progressInfoManager)
        {
            this.progressInfoManager = progressInfoManager;
            TranferMessageType = typeof(ProgressInfoMessage);
        }

        /// <summary>
        /// <code>typeof(ProgressInfoMessage)</code>
        /// </summary>
        public Type TranferMessageType
        {
            get; set;
        }

        /// <summary>
        /// Transfer ProgressInfoMessage object.
        /// </summary>
        /// <param name="transferMsg">the ProgressInfoMessage.</param>
        public void Call(ITransferMessage transferMsg)
        {
            var msg = transferMsg as ProgressInfoMessage;
            var serviceType = msg.ServiceType;
            var total = msg.Total;
            var totalType = msg.TotalType;
            var sellerAccount = msg.User;
            var value = msg.Value;

            switch (msg.CallbackMethodName)
            {
                case "SendTaskProgressTotal":
                    progressInfoManager.SetTotal(serviceType, total, totalType);

                    Observers.CommonCallbackAction(serviceType, (clientCallback) =>
                    {
                        clientCallback.NotifyTaskProgressTotal(new ProgressSummary(0, total, totalType));
                    });
                    break;
                case "SendTaskProgressItemTotal":
                    progressInfoManager.SetItemTotal(serviceType, sellerAccount, total);

                    Observers.CommonCallbackAction(serviceType, (clientCallback) =>
                    {
                        clientCallback.NotifyTaskProgressItemTotal(sellerAccount, total);
                    });
                    break;
                case "SendTaskProgressIncrease":
                    progressInfoManager.SetItemValue(serviceType, sellerAccount, value);

                    var progressInfoItem = progressInfoManager.GetUserProgressInfo(serviceType, sellerAccount);

                    Observers.CommonCallbackAction(serviceType, (clientCallback) =>
                    {
                        clientCallback.NotifyTaskProgressItemValueAndTotal(sellerAccount, new ProgressItem(progressInfoItem.Value, progressInfoItem.Total));
                    });
                    break;
                case "ForceFinish":
                    progressInfoManager.SetItemValueFinish(serviceType, sellerAccount);

                    Observers.CommonCallbackAction(serviceType, (clientCallback) =>
                    {
                        clientCallback.NotifyTaskProgressForceFinish(sellerAccount);
                    });

                    break;
                case "FinishAll":
                    progressInfoManager.Clear(serviceType);

                    Observers.CommonCallbackAction(serviceType, (clientCallback) =>
                    {
                        clientCallback.NotifyTaskProgressFinishAll();
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
