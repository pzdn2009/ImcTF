using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 消息转发器：当前进程名的消息队列
    /// </summary>
    public class MessageQueueTransfer
    {
        private const string MQ_FORMAT = @".\private$\{0}";

        private MsmqHelper m_msmqHelper;

        private readonly static Lazy<MessageQueueTransfer> m_Instance = new Lazy<MessageQueueTransfer>(() => new MessageQueueTransfer());

        private MessageQueueTransfer()
        {
            m_msmqHelper = new MsmqHelper(string.Format(MQ_FORMAT, Defaults.ProcessName));
        }

        public static MessageQueueTransfer Instance
        {
            get
            {
                return m_Instance.Value;
            }
        }

        public void SendMessageEntity(MessageEntity msgMQEntity)
        {
            m_msmqHelper.SendMessage(msgMQEntity);
        }

        public List<MessageEntity> ReceiveMessageEntitys(string processName, int count = 10)
        {
            try
            {
                return m_msmqHelper.ReceiveMessages<MessageEntity>(count);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ex.StackTrace);
                return new List<MessageEntity>();
            }
        }
    }
}