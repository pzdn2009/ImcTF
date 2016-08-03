using ImcFramework.WcfInterface.Enums;
using System;

namespace ImcFramework.WcfInterface.TransferMessage
{
    public class MessageEntityBuilder
    {
        private EServiceType serviceType;
        private string msgContent;
        private EMessageType messageType;
        private string user;
        private string logLevel;
        private string className;
        private string methodName;

        private string callbackMethodName;

        protected MessageEntityBuilder() { }

        public static MessageEntityBuilder Create()
        {
            return new MessageEntityBuilder();
        }

        public MessageEntityBuilder WithMessageType(EMessageType messageType)
        {
            this.messageType = messageType;
            return this;
        }

        public MessageEntityBuilder WithMsgContent(string msgContent)
        {
            this.msgContent = msgContent;
            return this;
        }

        public MessageEntityBuilder WithServiceType(EServiceType serviceType)
        {
            this.serviceType = serviceType;
            return this;
        }

        public MessageEntityBuilder WithUser(string user)
        {
            this.user = user;
            return this;
        }

        public MessageEntityBuilder WithLogLevel(string logLevel)
        {
            this.logLevel = logLevel;
            return this;
        }

        public MessageEntityBuilder WithClassName(string className)
        {
            this.className = className;
            return this;
        }

        public MessageEntityBuilder WithMethodName(string methodName)
        {
            this.methodName = methodName;
            return this;
        }
        
        public MessageEntityBuilder WithCallbackMethodName(string callbackMethodName)
        {
            this.callbackMethodName = callbackMethodName;
            return this;
        }

        public MessageEntity Build()
        {
            var entity = new MessageEntity();
            entity.MessageType = messageType;
            entity.MsgContent = msgContent;
            entity.ServiceType = serviceType;
            entity.Timestamp = DateTime.Now;
            entity.User = user;
            entity.LogLevel = logLevel;
            entity.ClassName = className;
            entity.MethodName = methodName;

            entity.CallbackMethodName = callbackMethodName;

            return entity;
        }
    }
}
