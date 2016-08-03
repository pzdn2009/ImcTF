using System.ComponentModel;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.Enums
{
    /// <summary>
    /// Command enum.
    /// </summary>
    [DataContract]
    [Description("Command Enums.")]
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
        Cancel,

        [EnumMember]
        [Description("中断")]
        Interrupt,

        [EnumMember]
        [Description("获取服务信息")]
        GetServiceInfo
    }
}
