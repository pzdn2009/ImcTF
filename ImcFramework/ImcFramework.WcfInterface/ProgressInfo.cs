using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
    [DataContract]
    public class ProgressItem
    {
        public ProgressItem()
        {

        }
        public ProgressItem(int value, int total, string user = "")
        {
            this.Value = value;
            this.Total = total;
            this.User = user;
        }

        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public string User { get; set; }
    }

    [DataContract]
    public class ProgressSummary : ProgressItem
    {
        public ProgressSummary()
        {

        }
        public ProgressSummary(int value, int total, TotalType totalType, string summaryName = "")
        {
            this.Value = value;
            this.Total = total;
            this.TotalType = totalType;

            this.SummaryName = summaryName;
        }

        public string SummaryName { get; set; }

        [DataMember]
        public TotalType TotalType { get; set; }
    }

    [DataContract]
    public enum TotalType
    {
        /// <summary>
        /// 用户总数（不能计算RecordCount时，用此表示）
        /// </summary>
        [EnumMember]
        User,

        /// <summary>
        /// 记录总数（如果能够计算的话，建议用此表示）
        /// </summary>
        [EnumMember]
        RecordCount
    }
}
