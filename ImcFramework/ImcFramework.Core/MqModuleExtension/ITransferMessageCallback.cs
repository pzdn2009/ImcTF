using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// Callbak for ITransferMessage
    /// </summary>
    public interface ITransferMessageCallback
    {
        /// <summary>
        /// The concrete message type.
        /// </summary>
        Type TranferMessageType { get; set; }

        /// <summary>
        /// The call method which transfers the message
        /// </summary>
        /// <param name="transferMsg">the message</param>
        void Call(ITransferMessage transferMsg);
    }
}
