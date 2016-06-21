using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Core
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogContentEntity
    {
        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 自定义消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息级别
        /// </summary>
        public string Level { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append("ClassName:" + Class + "\r\n");
            sb.Append("MethodName:" + Method + "\r\n");
            sb.Append("Message:" + Message + "\r\n");
            return sb.ToString();
        }
    }
}
