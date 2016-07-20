using ImcFramework.LogPool;
using ImcFramework.WcfInterface.TransferMessage;
using System;

namespace ImcFramework.Core.MqModuleExtension
{
    public class MessageEntityCallback : ITransferMessageCallback
    {
        private ILoggerPoolFactory loggerPoolFactory;
        public MessageEntityCallback(ILoggerPoolFactory loggerPoolFactory)
        {
            this.TranferMessageType = typeof(MessageEntity);
            this.loggerPoolFactory = loggerPoolFactory;
        }

        public Type TranferMessageType
        {
            get;
            set;
        }

        public void Call(ITransferMessage transferMsg)
        {
            var messageEntity = transferMsg as MessageEntity;

            #region 记录日志

            var logger = loggerPoolFactory.GetLoggerPool(messageEntity.ServiceType.ServiceType);

            logger.Log(messageEntity.User, new LogContentEntity()
            {
                Class = messageEntity.ClassName,
                Method = messageEntity.MethodName,
                Message = messageEntity.MsgContent,
                Level = messageEntity.LogLevel
            });

            #endregion

            Observers. CommonCallbackAction(messageEntity.ServiceType, (clientCallback) =>
            {
                clientCallback.Notify(messageEntity);
            });
        }
    }
}
