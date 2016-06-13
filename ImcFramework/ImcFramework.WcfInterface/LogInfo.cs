using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
    //主要以日期和服务类型两个字段排序
    [DataContract]
    public class LogInfo
    {
        /// <summary>
        /// 日期
        /// </summary>
        [DataMember]
        public string DateString { get; set; }
        
        /// <summary>
        /// 账号信息
        /// </summary>
        [DataMember]
        public List<SellerAccountLogLevel> SellerAccountLogLevels { get; set; }
    }

    [DataContract]
    public class SellerAccountLogLevel
    {
        [DataMember]
        public string SellerAccount { get; set; }

        [DataMember]
        public string LogLevel { get; set; }
    }
}
