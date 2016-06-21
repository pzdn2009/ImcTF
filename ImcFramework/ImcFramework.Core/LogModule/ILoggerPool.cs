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
        string ServiceType { get; }

        /// <summary>
        /// 获得AppenderName，用做查询
        /// </summary>
        /// <param name="sellerAccount"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        string GetAppenderName(string sellerAccount, global::Common.Logging.LogLevel logLevel);

        /// <summary>
        /// 根据账号返回当前服务的日志
        /// </summary>
        /// <param name="sellerAccount">账号</param>
        /// <param name="logLevel">级别</param>
        /// <returns></returns>
        ILog GetLogger(string sellerAccount, LogLevel logLevel = LogLevel.Info);

        /// <summary>
        /// 直接记录日志
        /// </summary>
        /// <param name="logContentEntity">日志实体</param>
        void Log(string sellerAccount, LogContentEntity logContentEntity);
    }
}
