using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface.TransferMessage
{
    [DataContract]
    public class MessageEntity : ITransferMessage
    {
        /// <summary>
        /// 业务服务类型
        /// </summary>
        [DataMember]
        public EServiceType ServiceType { get; set; }

        #region 客户端消息

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember]
        public string MsgContent { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [DataMember]
        public EMessageType MessageType { get; set; }

        #endregion

        #region　日志消息

        public string User { get; set; }

        public string LogLevel { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        #endregion

        /// <summary>
        /// 回调方法名
        /// </summary>
        public string CallbackMethodName { get; set; }

        public static MessageEntity NormalInfo(EServiceType serviceType, string msgContent = "")
        {
            return new MessageEntity()
            {
                MessageType = EMessageType.Info,
                Timestamp = DateTime.Now,
                ServiceType = serviceType,
                MsgContent = msgContent,
                LogLevel = "Info"
            };
        }

        public static MessageEntity ErrorInfo(EServiceType serviceType, string msgContent = "")
        {
            return new MessageEntity()
            {
                MessageType = EMessageType.Error,
                Timestamp = DateTime.Now,
                ServiceType = serviceType,
                MsgContent = msgContent,
                LogLevel = "Error"
            };
        }
    }
}
