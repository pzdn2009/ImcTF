using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    public class ProgressInfoMessageCallback : ITransferMessageCallback
    {
        public ProgressInfoMessageCallback()
        {
            this.TranferMessageType = typeof(ProgressInfoMessage);
        }

        public Type TranferMessageType
        {
            get; set;
        }

        public void Call(ITransferMessage transferMsg)
        {
            var msg = transferMsg as ProgressInfoMessage;
            switch (msg.CallbackMethodName)
            {
                case "SendTaskProgressTotal":
                    Observers.SendTaskProgressTotal(msg.ServiceType, msg.Total, msg.TotalType);
                    break;
                case "SendTaskProgressItemTotal":
                    Observers.SendTaskProgressItemTotal(msg.ServiceType, msg.User, msg.Total);
                    break;
                case "SendTaskProgressIncrease":
                    Observers.SendTaskProgressIncrease(msg.ServiceType, msg.User, msg.Value);
                    break;
                case "ForceFinish":
                    Observers.SendTaskProgressForceFinish(msg.ServiceType, msg.User);
                    break;
                case "FinishAll":
                    Observers.SendTaskProgressFinishAll(msg.ServiceType);
                    break;
                default:
                    break;
            }
        }
    }
}
