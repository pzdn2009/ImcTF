using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
    [DataContract]
    public class MessageEntity
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

        public string SellerAccount { get; set; }

        public string LogLevel { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        #endregion

        #region 进度消息

        /// <summary>
        /// 是否为进度消息
        /// </summary>
        public bool IsProgressMsg { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 总数类型
        /// </summary>
        public TotalType TotalType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 回调方法名
        /// </summary>
        public string CallbackMethodName { get; set; }

        #endregion

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
