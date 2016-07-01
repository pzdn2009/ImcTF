using ImcFramework.Core.Distribution;
using ImcFramework.WcfInterface.TransferMessage;
using System.Collections.Generic;
using System.Linq;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// 基于MQ的消息交换
    /// </summary>
    public abstract class MqDistributionBase<T> : IDistributionFacility<T> where T : ITransferMessage
    {
        public MqDistributionBase()
        {

        }

        public abstract string MQPathFormat { get; set; }

        public virtual void Push(object message)
        {
        }

        public virtual IEnumerable<T> ReadMessages(int messageCount = 100)
        {
            return Enumerable.Empty<T>();
        }
    }
}
