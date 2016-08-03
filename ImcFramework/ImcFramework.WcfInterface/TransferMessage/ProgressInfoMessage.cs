using ImcFramework.WcfInterface.ProgressInfos;

namespace ImcFramework.WcfInterface.TransferMessage
{
    public class ProgressInfoMessage : ITransferMessage
    {
        public int Total { get; set; }

        public TotalType TotalType { get; set; }

        public int Value { get; set; }

        public string CallbackMethodName { get; set; }

        public EServiceType ServiceType { get; set; }

        public string User { get; set; }
    }
}
