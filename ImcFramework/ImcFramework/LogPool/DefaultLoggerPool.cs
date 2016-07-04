using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using ComonLog = global::Common.Logging;

namespace ImcFramework.LogPool
{
    public class DefaultLoggerPool : ILoggerPool
    {
        private object lockObject = new object();
        private HashSet<Tuple<string, ComonLog.LogLevel>> hashLogFile = new HashSet<Tuple<string, ComonLog.LogLevel>>();

        private IFileAppender fileAppender;

        public DefaultLoggerPool(string loggerPoolName)
        {
            LoggerPoolName = loggerPoolName;
            fileAppender = new DefaultFileAppender(loggerPoolName);
        }

        public string LoggerPoolName
        {
            get;
            private set;
        }

        #region interfaces

        public ComonLog.ILog GetLogger(string user, ComonLog.LogLevel logLevel = ComonLog.LogLevel.Info)
        {
            var appenderName = GetAppenderName(user, logLevel);
            return ComonLog.LogManager.GetLogger(appenderName);
        }

        public void Log(string user, LogContentEntity logContentEntity)
        {
            var appenderName = GetAppenderName(user, FileAppenderHelper.ConvertLogLevel(logContentEntity.Level));
            Common.Logging.ILog log = Common.Logging.LogManager.GetLogger(appenderName);

            if (log.IsDebugEnabled)
            {
                log.Debug(logContentEntity.ToString());
            }
            if (log.IsInfoEnabled)
            {
                log.Info(logContentEntity.ToString());
            }
            if (log.IsErrorEnabled)
            {
                log.Error(logContentEntity.ToString());
            }
        }

        #endregion

        #region 初始化

        //LoggerPoolName/AllLog__Level__Date.txt
        //LoggerPoolName/SellerAccount__Level__Date.txt
        private string GetAppenderName(string user, ComonLog.LogLevel logLevel)
        {
            var appenderName = fileAppender.GetAppenderName(user, logLevel);

            lock (lockObject)
            {
                var tuple = Tuple.Create(user, logLevel);
                if (!hashLogFile.Contains(tuple))
                {
                    InitMainBusinessLogger(appenderName, logLevel);
                    hashLogFile.Add(tuple);
                }
            }

            return appenderName;
        }

        private void InitMainBusinessLogger(string appenderName, ComonLog.LogLevel logLevel)
        {
            var logForSpecialAppender = (Logger)LogManager.GetLogger(appenderName).Logger;
            if (logForSpecialAppender.Appenders.Count > 0) return;   //避免重复生成日志文件

            var logFileName = "Log/" + GetLogFileName(appenderName);
            var appender = CreateAppender(appenderName, logFileName, logLevel);
            logForSpecialAppender.AddAppender(appender);
        }

        private string GetLogFileName(string appenderName)
        {
            var logFileName = string.Format("{0}__.txt", appenderName);
            return logFileName;
        }

        private bool LogFileExist(string fileName)
        {
            var fullName = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + fileName.Replace('/', '\\').Replace(".txt", DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            return File.Exists(fullName);
        }

        #endregion

        #region Privates

        private RollingFileAppender CreateAppender(string appenderName, string fileName, ComonLog.LogLevel logLevel)
        {
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%d %-5p  %m%n";
            layout.ActivateOptions();

            RollingFileAppender appender = new RollingFileAppender();
            appender.Layout = layout;

            appender.Name = appenderName;
            appender.File = fileName;

            appender.RollingStyle = RollingFileAppender.RollingMode.Composite;
            //appender.Encoding = Encoding.Unicode;
            appender.AppendToFile = true;
            appender.MaximumFileSize = "4MB";
            appender.MaxSizeRollBackups = 100;
            appender.DatePattern = "yyyy-MM-dd";
            appender.PreserveLogFileNameExtension = true;
            appender.StaticLogFileName = false;
            appender.Threshold = FileAppenderHelper.ConvertLogLevel(logLevel);

            log4net.Filter.LevelRangeFilter levfilter = new log4net.Filter.LevelRangeFilter();
            levfilter.LevelMax = appender.Threshold;
            levfilter.LevelMin = appender.Threshold;
            levfilter.ActivateOptions();

            appender.AddFilter(levfilter);

            appender.ActivateOptions();

            return appender;
        }

        private SmtpAppender CreateSmtpAppender(string appenderName, string subject, string mailFrom, string mailTo, string userName, string password)
        {
            var appender = new SmtpAppender();
            appender.Name = appenderName;

            appender.Authentication = SmtpAppender.SmtpAuthentication.Basic;
            appender.To = mailFrom;
            appender.From = mailTo;
            appender.Username = userName;
            appender.Password = password;
            appender.Subject = subject;
            appender.SmtpHost = "smtp.qq.com";
            appender.BufferSize = 4;
            appender.Lossy = true;
            appender.Evaluator = new LevelEvaluator() { Threshold = Level.Error };

            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%newline%date [%thread] %-5level %logger [%property{NDC}] - %message%newline%newline%newline";
            layout.ActivateOptions();

            appender.Layout = layout;

            appender.ActivateOptions();

            return appender;
        }

        #endregion
    }
}

