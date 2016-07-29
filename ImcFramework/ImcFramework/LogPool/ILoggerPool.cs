using Common.Logging;

namespace ImcFramework.LogPool
{
    /// <summary>
    /// Define a pool for loggers
    /// </summary>
    public interface ILoggerPool
    {
        /// <summary>
        /// Name of the logger pool.
        /// </summary>
        string LoggerPoolName { get; }

        /// <summary>
        /// Get the ILog interface for the user and loglevel.
        /// </summary>
        /// <param name="user">Indicates the user of the log</param>
        /// <param name="logLevel">log level</param>
        /// <returns>the ILog object</returns>
        ILog GetLogger(string user, LogLevel logLevel = LogLevel.Info);

        /// <summary>
        /// Log the  object info for special user.
        /// </summary>
        /// <param name="user">Indicates the user of the logContentEntity</param>
        /// <param name="logContentEntity">Log info obejct, <see cref="LogContentEntity"></param>
        void Log(string user, LogContentEntity logContentEntity);
    }
}
