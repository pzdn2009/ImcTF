using ImcFramework.WcfInterface.TransferMessage;
using System.Collections.Generic;

namespace ImcFramework.Core.Distribution
{
    /// <summary>
    /// 分布式设施
    /// </summary>
    public interface IDistributionFacility<out T>  where T :ITransferMessage
    {
        /// <summary>
        /// store a message
        /// </summary>
        /// <param name="message"></param>
        void Push(object message);

        /// <summary>
        /// retrive some messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ReadMessages(int messageCount = 100);
    }
}
