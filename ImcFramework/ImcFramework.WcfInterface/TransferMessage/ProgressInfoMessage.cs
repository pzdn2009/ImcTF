using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.WcfInterface.TransferMessage
{
    public class ProgressInfoMessage : ITransferMessage
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 总数类型
        /// </summary>
        public TotalType TotalType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 回调方法名
        /// </summary>
        public string CallbackMethodName { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public EServiceType ServiceType { get; set; }

        /// <summary>
        /// 销售账号
        /// </summary>
        public string SellerAccount { get; set; }
    }
}
