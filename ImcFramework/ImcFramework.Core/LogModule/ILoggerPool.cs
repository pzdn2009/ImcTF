using Common.Logging;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 业务日志池
    /// </summary>
    public interface ILoggerPool
    {
        /// <summary>
        /// 服务类型
        /// </summary>
        EServiceType ServiceType { get; }

        /// <summary>
        /// 获得AppenderName，用做查询
        /// </summary>
        /// <param name="sellerAccount"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        string GetAppenderName(string sellerAccount, global::Common.Logging.LogLevel logLevel);

        /// <summary>
        /// 返回当前服务的所有日志
        /// </summary>
        /// <returns></returns>
        ILog GetMainBusinessLogger();

        /// <summary>
        /// 根据账号返回当前服务的日志
        /// </summary>
        /// <param name="sellerAccount">账号</param>
        /// <param name="logLevel">级别</param>
        /// <returns></returns>
        ILog GetMainBusinessLogger(string sellerAccount, LogLevel logLevel = LogLevel.Info);
    }
}
