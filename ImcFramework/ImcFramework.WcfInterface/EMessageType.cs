using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// 消息类型
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
