using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.ProgressInfos
{
    [DataContract]
    public class ProgressSummary : ProgressItem
    {
        public ProgressSummary()
        {

        }
        public ProgressSummary(int value, int total, TotalType totalType, string summaryName = "")
        {
            Value = value;
            Total = total;
            TotalType = totalType;

            SummaryName = summaryName;
        }

        public string SummaryName { get; set; }

        [DataMember]
        public TotalType TotalType { get; set; }
    }
}
