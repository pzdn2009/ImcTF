using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    public class MessageEntityCallback : ITransferMessageCallback
    {
        public MessageEntityCallback()
        {
            this.TranferMessageType = typeof(MessageEntity);
        }

        public Type TranferMessageType
        {
            get;
            set;
        }

        public void Call(ITransferMessage transferMsg)
        {
            Observers.BroadCastMessage(transferMsg as MessageEntity);
        }
    }
}
