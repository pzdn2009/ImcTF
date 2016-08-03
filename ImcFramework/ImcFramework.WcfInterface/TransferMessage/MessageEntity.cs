using ImcFramework.WcfInterface.Enums;
using System;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.TransferMessage
{
    /// <summary>
    /// MessageEntity.
    /// </summary>
    [DataContract]
    public class MessageEntity : ITransferMessage
    {
        /// <summary>
        /// The Servicetype.
        /// </summary>
        [DataMember]
        public EServiceType ServiceType { get; set; }

        #region Clients

        /// <summary>
        /// Timestamp
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The message .
        /// </summary>
        [DataMember]
        public string MsgContent { get; set; }

        /// <summary>
        /// The message type.
        /// </summary>
        [DataMember]
        public EMessageType MessageType { get; set; }

        #endregion

        #region　Logs

        public string User { get; set; }

        public string LogLevel { get; set; }

        public string ClassName { get; set; }

        public string MethodName { get; set; }

        #endregion

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
