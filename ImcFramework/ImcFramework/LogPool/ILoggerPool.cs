using Common.Logging;

namespace ImcFramework.LogPool
{
    /// <summary>
    /// 业务日志池
    /// </summary>
    public interface ILoggerPool
    {
        /// <summary>
        /// 名称
        /// </summary>
        string LoggerPoolName { get; }

        /// <summary>
        /// 根据账号返回当前服务的日志
        /// </summary>
        /// <param name="user">账号</param>
        /// <param name="logLevel">级别</param>
        /// <returns></returns>
        ILog GetLogger(string user, LogLevel logLevel = LogLevel.Info);

        /// <summary>
        /// 直接记录日志
        /// </summary>
        /// <param name="logContentEntity">日志实体</param>
        void Log(string user, LogContentEntity logContentEntity);
    }
}
