using ImcFramework.LogPool;
using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// Callback for the MessageEntity.
    /// </summary>
    public class MessageEntityCallback : ITransferMessageCallback
    {
        private ILoggerPoolFactory loggerPoolFactory;
        public MessageEntityCallback(ILoggerPoolFactory loggerPoolFactory)
        {
            this.TranferMessageType = typeof(MessageEntity);
            this.loggerPoolFactory = loggerPoolFactory;
        }

        /// <summary>
        /// <code>typeof(MessageEntity)</code>
        /// </summary>
        public Type TranferMessageType
        {
            get;
            set;
        }

        /// <summary>
        /// Transfer MessageEntity object.
        /// </summary>
        /// <param name="transferMsg">the MessageEntity.</param>
        public void Call(ITransferMessage transferMsg)
        {
            var messageEntity = transferMsg as MessageEntity;

            #region records the logcontent entity

            var logger = loggerPoolFactory.GetLoggerPool(messageEntity.ServiceType.ServiceType);

            logger.Log(messageEntity.User, new LogContentEntity()
            {
                Class = messageEntity.ClassName,
                Method = messageEntity.MethodName,
                Message = messageEntity.MsgContent,
                Level = messageEntity.LogLevel
            });

            #endregion

            //notify the clients 
            Observers. CommonCallbackAction(messageEntity.ServiceType, (clientCallback) =>
            {
                clientCallback.Notify(messageEntity);
            });
        }
    }
}
