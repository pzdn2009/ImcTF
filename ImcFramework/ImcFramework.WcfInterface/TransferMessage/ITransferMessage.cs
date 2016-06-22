using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.WcfInterface.TransferMessage
{
    /// <summary>
    /// 消息交换接口
    /// </summary>
    public interface ITransferMessage
    {
        /// <summary>
        /// 服务类型
        /// </summary>
        EServiceType ServiceType { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// 回调方法名
        /// </summary>
        string CallbackMethodName { get; set; }
    }
}
