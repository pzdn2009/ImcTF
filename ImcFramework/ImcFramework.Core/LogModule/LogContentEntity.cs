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
        /// 线程ID
        /// </summary>
        public string ThreadId { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 自定义消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息级别
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 服务类型
        /// </summary>
        public EServiceType ServiceType { get; set; }
    }
}
