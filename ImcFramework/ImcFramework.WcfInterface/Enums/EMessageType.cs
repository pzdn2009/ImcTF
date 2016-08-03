using System.ComponentModel;

namespace ImcFramework.WcfInterface.Enums
{
    /// <summary>
    /// Message type.
    /// </summary>
    [Description("消息类型")]
    public enum EMessageType
    {
        [Description("信息")]
        Info,

        [Description("警告")]
        Warn,

        [Description("出错")]
        Error
    }
}
