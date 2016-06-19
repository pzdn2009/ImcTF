using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 分布式设施
    /// </summary>
    public interface IDistributionFacility<T> where T : ITransferMessage
    {
        /// <summary>
        /// store a message
        /// </summary>
        /// <param name="message"></param>
        void Push(T message);

        /// <summary>
        /// retrive some messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ReadMessages(int messageCount = 100);
    }
}
