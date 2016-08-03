using ImcFramework.WcfInterface.ProgressInfos;

namespace ImcFramework.WcfInterface.TransferMessage
{
    public class ProgressInfoMessageBuilder
    {
        private EServiceType serviceType;
        private string user;

        private int total;
        private TotalType totalType;
        private int value;
        private string callbackMethodName;

        protected ProgressInfoMessageBuilder() { }

        public static ProgressInfoMessageBuilder Create()
        {
            return new ProgressInfoMessageBuilder();
        }

        public ProgressInfoMessageBuilder WithServiceType(EServiceType serviceType)
        {
            this.serviceType = serviceType;
            return this;
        }

        public ProgressInfoMessageBuilder WithUser(string user)
        {
            this.user = user;
            return this;
        }

        public ProgressInfoMessageBuilder WithTotal(int total)
        {
            this.total = total;
            return this;
        }
        public ProgressInfoMessageBuilder WithTotalType(TotalType totalType)
        {
            this.totalType = totalType;
            return this;
        }
        public ProgressInfoMessageBuilder WithValue(int value)
        {
            this.value = value;
            return this;
        }
        public ProgressInfoMessageBuilder WithCallbackMethodName(string callbackMethodName)
        {
            this.callbackMethodName = callbackMethodName;
            return this;
        }

        public ProgressInfoMessage Build()
        {
            var entity = new ProgressInfoMessage();
            entity.ServiceType = serviceType;
            entity.User = user;
            entity.Total = total;
            entity.TotalType = totalType;
            entity.Value = value;
            entity.CallbackMethodName = callbackMethodName;

            return entity;
        }
    }
}
