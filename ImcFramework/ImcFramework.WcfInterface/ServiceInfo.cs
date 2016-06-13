using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// 单个服务状态信息
    /// </summary>
    [DataContract]
    public class ServiceInfo
    {
        /// <summary>
        /// 服务的状态
        /// </summary>
        [DataMember]
        public EServiceStatus EServiceStatus { get; set; }

        /// <summary>
        /// 计划信息
        /// </summary>
        [DataMember]
        public string ScheduleInfo { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public bool Enable { get; set; }
    }
}
