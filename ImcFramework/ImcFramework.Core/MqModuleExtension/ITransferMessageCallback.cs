using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    public interface ITransferMessageCallback
    {
        Type TranferMessageType { get; set; }

        void Call(ITransferMessage transferMsg);
    }
}
