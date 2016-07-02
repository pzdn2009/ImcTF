using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;

namespace ImcFramework.LogPool
{
    public class FileAppenderHelper
    {
        public static bool ExistFileAppender(string appenderName)
        {
            var logger = (Logger)log4net.LogManager.GetLogger(appenderName).Logger;
            return logger.Appenders.Count > 0;
        }

        public static void AddAppender(RollingFileAppender appender)
        {
            var logger = (Logger)log4net.LogManager.GetLogger(appender.Name).Logger;
            logger.AddAppender(appender);
        }

        public static Common.Logging.LogLevel ConvertLogLevel(string level)
        {
            switch (level)
            {
                case "Error":
                    return Common.Logging.LogLevel.Error;
                case "Warn":
                    return Common.Logging.LogLevel.Warn;
                case "Info":
                    return Common.Logging.LogLevel.Info;
                case "Debug":
                    return Common.Logging.LogLevel.Debug;
                default:
                    throw new NotSupportedException("Not Supported evel:" + level);
            }
        }

        public static Level ConvertLogLevel(Common.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Common.Logging.LogLevel.All:
                    return Level.All;
                case Common.Logging.LogLevel.Debug:
                    return Level.Debug;
                case Common.Logging.LogLevel.Error:
                    return Level.Error;
                case Common.Logging.LogLevel.Fatal:
                    return Level.Fatal;
                case Common.Logging.LogLevel.Info:
                    return Level.Info;
                case Common.Logging.LogLevel.Off:
                    return Level.Off;
                case Common.Logging.LogLevel.Trace:
                    return Level.Trace;
                case Common.Logging.LogLevel.Warn:
                    return Level.Warn;
                default:
                    throw new NotSupportedException("Not Supported logLevel:" + logLevel.ToString());
            }
        }
    }
}