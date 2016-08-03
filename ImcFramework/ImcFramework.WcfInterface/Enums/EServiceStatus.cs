using System.ComponentModel;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.Enums
{
    /// <summary>
    /// Servicetype status.
    /// </summary>
    [Description("服务状态")]
    [DataContract]
    public enum EServiceStatus
    {
        [Description("正在运行")]
        [EnumMember]
        Running,

        [Description("正常")]
        [EnumMember]
        Normal,

        [Description("暂停")]
        [EnumMember]
        Pause
    }
}
