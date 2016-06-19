using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImcFramework.WcfInterface
{
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
