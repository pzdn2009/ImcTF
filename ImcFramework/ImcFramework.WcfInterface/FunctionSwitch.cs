using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// 功能开关
    /// </summary>
    [DataContract]
    public class FunctionSwitch
    {
        /// <summary>
        /// 服务类型
        /// </summary>
        [DataMember]
        public EServiceType ServiceType { get; set; }

        /// <summary>
        /// 计划格式
        /// </summary>
        [DataMember]
        public string ScheduleFormat { get; set; }

        /// <summary>
        /// 命令类型
        /// </summary>
        [DataMember]
        public ECommand Command { get; set; }
    }

    [DataContract]
    [Description("命令")]
    public enum ECommand
    {
        [EnumMember]
        [Description("暂停")]
        Pause,

        [EnumMember]
        [Description("立即执行")]
        RunImmediately,

        [EnumMember]
        [Description("继续")]
        Continue,

        [EnumMember]
        [Description("更改计划")]
        ModifySchedule,

        [EnumMember]
        [Description("取消")]
        Cancle
    }
}
