using ImcFramework.WcfInterface.Enums;
using System;
using System.Runtime.Serialization;

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

        [DataMember]
        public DateTime? PrevFiredTime { get; set; }

        [DataMember]
        public DateTime? NextFiredTime { get; set; }
    }
}
