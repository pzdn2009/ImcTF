using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Core
{
    public class MessageEntityBuilder
    {
        private EServiceType serviceType;
        private string msgContent;
        private EMessageType messageType;
        private string sellerAccount;
        private string logLevel;
        private string className;
        private string methodName;

        private bool isProgressMsg;
        private int total;
        private TotalType totalType;
        private int value;
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

        public MessageEntityBuilder WithSellerAccount(string sellerAccount)
        {
            this.sellerAccount = sellerAccount;
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


        public MessageEntityBuilder WithIsProgressMsg(bool isProgressMsg)
        {
            this.isProgressMsg = isProgressMsg;
            return this;
        }
        public MessageEntityBuilder WithTotal(int total)
        {
            this.total = total;
            return this;
        }
        public MessageEntityBuilder WithTotalType(TotalType totalType)
        {
            this.totalType = totalType;
            return this;
        }
        public MessageEntityBuilder WithValue(int value)
        {
            this.value = value;
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
            entity.SellerAccount = sellerAccount;
            entity.LogLevel = logLevel;
            entity.ClassName = className;
            entity.MethodName = methodName;

            entity.IsProgressMsg = isProgressMsg;
            entity.Total = total;
            entity.TotalType = totalType;
            entity.Value = value;
            entity.CallbackMethodName = callbackMethodName;

            return entity;
        }
    }
}
