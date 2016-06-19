using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class MsmqHelper
    {
        private string m_mqPath = string.Empty;
        private MessageQueue m_mq;

        public MsmqHelper(string mqPath)
        {
            if (string.IsNullOrEmpty(mqPath))
            {
                throw new ArgumentNullException("mqPath");
            }

            this.m_mqPath = mqPath;

            EnsureMsmq();

            this.m_mq = new MessageQueue(m_mqPath);
        }

        private void EnsureMsmq()
        {
            if (!Exist(this.m_mqPath))
            {
                CreateMQ(this.m_mqPath);
            }
        }

        #region 简单消息操作
        public void SendSimpleMessage(string mesage)
        {
            System.Messaging.Message message = new System.Messaging.Message();
            message.Body = mesage;
            message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });

            m_mq.Send(message, new MessageQueueTransaction());
        }
        public string ReceiveSimpleMessage()
        {
            if (m_mq.GetAllMessages().Length > 0)
            {
                var message = m_mq.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });
                    return message.Body.ToString();
                }
            }

            return string.Empty;
        }
        public List<string> ReceiveSimpleMsg(int count = 10)
        {
            int cnt = Math.Min(count, m_mq.GetAllMessages().Length);

            var result = new List<string>();
            for (int i = 0; i < cnt; i++)
            {
                var message = m_mq.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });
                    result.Add(message.Body.ToString());
                }
            }

            return result;
        }

        #endregion

        #region 复杂消息

        public void SendMessage<T>(T obj)
        {
            var message = new Message();
            message.Body = obj;

            m_mq.Send(message);
        }

        public T ReceiveMessage<T>() where T : class
        {
            T msg = null;
            if (m_mq.GetAllMessages().Length > 0)
            {
                var message = m_mq.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });//消息类型转换  
                    msg = (T)message.Body;
                }
            }

            return msg;
        }

        public List<T> ReceiveMessages<T>(int count = 10) where T : class
        {
            var result = new List<T>();

            int cnt = Math.Min(count, m_mq.GetAllMessages().Length);
            for (int i = 0; i < cnt; i++)
            {
                var message = m_mq.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });//消息类型转换  
                    T msg = (T)message.Body;
                    result.Add(msg);
                }
            }

            return result;
        }

        #endregion

        public static void CreateMQ(string mqPath)
        {
            var mq = System.Messaging.MessageQueue.Create(mqPath, false);

            var list = new AccessControlList() { };
            list.Add(new AccessControlEntry()
            {
                EntryType = AccessControlEntryType.Allow,
                GenericAccessRights = GenericAccessRights.All,
                StandardAccessRights = StandardAccessRights.All,
                Trustee = new Trustee("ANONYMOUS LOGON")
            });
            list.Add(new AccessControlEntry()
            {
                EntryType = AccessControlEntryType.Allow,
                GenericAccessRights = GenericAccessRights.All,
                StandardAccessRights = StandardAccessRights.All,
                Trustee = new Trustee("Everyone")
            });

            mq.SetPermissions(list);

            mq.Label = mqPath;
        }

        public static bool Exist(string mqPath)
        {
            return MessageQueue.Exists(mqPath);
        }
    }
}
