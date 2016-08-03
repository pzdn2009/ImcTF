using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.ProgressInfos
{
    [DataContract]
    public class ProgressItem
    {
        public ProgressItem()
        {

        }
        public ProgressItem(int value, int total, string user = "")
        {
            Value = value;
            Total = total;
            User = user;
        }

        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public string User { get; set; }
    }
}
