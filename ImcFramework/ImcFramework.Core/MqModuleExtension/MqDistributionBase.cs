using ImcFramework.Core.Distribution;
using ImcFramework.WcfInterface.TransferMessage;
using System.Collections.Generic;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// Transfer messages based message queue
    /// </summary>
    public abstract class MqDistributionBase<T> : IDistributionFacility<T> where T : ITransferMessage
    {
        public MqDistributionBase()
        {

        }

        /// <summary>
        /// The message queue path
        /// </summary>
        public abstract string MQPathFormat { get; set; }

        /// <summary>
        /// Push a message
        /// </summary>
        /// <param name="message">message</param>
        public virtual void Push(object message)
        {
        }

        /// <summary>
        /// Pop messages from message queue.
        /// </summary>
        /// <param name="messageCount">messages count</param>
        /// <returns>return reads messages.</returns>
        public virtual IEnumerable<T> ReadMessages(int messageCount = 100)
        {
            return new List<T>();
        }
    }
}
