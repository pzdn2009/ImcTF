using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// Msmq实现消息交换
    /// </summary>
    public class MsmqDistribution<T> : MqModuleExtension.MqDistributionBase<T> where T : class, ITransferMessage
    {
        protected string m_MQPathFormat = @".\private$\{0}_{1}";

        private string m_TypeName;
        private MsmqHelper m_MsmqHelper;


        public MsmqDistribution(string typeName = null)
        {
            if (!string.IsNullOrEmpty(typeName))
            {
                m_TypeName = typeName;
            }
            else
            {
                m_TypeName = typeof(T).FullName.Replace(".", "_");
            }

            m_MsmqHelper = new MsmqHelper(string.Format(MQPathFormat, Defaults.ProcessName, m_TypeName));
        }

        public override string MQPathFormat
        {
            get { return m_MQPathFormat; }
            set { m_MQPathFormat = value; }
        }

        #region IDistributionFacility

        public override void Push(object message)
        {
            m_MsmqHelper.SendMessage(message);
        }

        public override IEnumerable<T> ReadMessages(int messageCount = 100)
        {
            try
            {
                return m_MsmqHelper.ReceiveMessages<T>(messageCount);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ex.StackTrace);
                return new List<T>();
            }
        }

        #endregion
    }
}