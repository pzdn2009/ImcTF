using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class LogHelper
    {
        //private static ILog log = LogManager.GetLogger(typeof(LogHelper));

        //public static ILog Instance { get { return log; } }

        //public static void Configure()
        //{
        //    log4net.Config.XmlConfigurator.Configure();
        //}

        public static ILog GetLogger(Type type)
        {
            ILog log = LogManager.GetLogger(type);
            return log;
        }
        public static ILog GetLogger(string key)
        {
            ILog log = LogManager.GetLogger(key);
            return log;
        }

        public static void Debug(string message, string key = null, int stackDeep = 1)
        {
            var sf = new System.Diagnostics.StackFrame(stackDeep);
            var method = sf.GetMethod();

            Debug(method.DeclaringType.Name, method.Name, message, key);
        }
        public static void Debug(string className, string methodName, string message, string key = null)
        {
            ILog log = null;
            if (!string.IsNullOrEmpty(key))
            {
                log = LogManager.GetLogger(key);
            }
            else
            {
                log = LogManager.GetLogger(typeof(LogHelper));
            }

            if (log.IsDebugEnabled)
            {
                string strText = GetMessage("DEBUG", className, methodName, message);
                log.Debug(strText);
            }
            log = null;
        }

        public static void Error(Exception e, string key = null, int stackDeep = 1)
        {
            var sf = new System.Diagnostics.StackFrame(stackDeep);
            var method = sf.GetMethod();

            Error(method.DeclaringType.Name, method.Name, e, key);
        }
        public static void Error(string className, string methodName, Exception e, string key = null)
        {
            ILog log = null;
            if (!string.IsNullOrEmpty(key))
            {
                log = LogManager.GetLogger(key);
            }
            else
            {
                log = LogManager.GetLogger(typeof(LogHelper));
            }

            if (log.IsErrorEnabled)
            {
                string strText = GetMessage("ERROR", className, methodName, e.Message + e.StackTrace);
                log.Error(strText);
            }
            log = null;
        }

        public static void Error(string message, string key = null, int stackDeep = 1)
        {
            var sf = new System.Diagnostics.StackFrame(stackDeep);
            var method = sf.GetMethod();

            Console.WriteLine(method.DeclaringType.Name);
            Console.WriteLine(method.Name);

            Error(method.DeclaringType.Name, method.Name, message, key);
        }
        public static void Error(string className, string methodName, string message, string key = null)
        {
            ILog log = null;
            if (!string.IsNullOrEmpty(key))
            {
                log = LogManager.GetLogger(key);
            }
            else
            {
                log = LogManager.GetLogger(typeof(LogHelper));
            }

            if (log.IsErrorEnabled)
            {
                string strText = GetMessage("ERROR", className, methodName, message);
                log.Error(strText);
            }
            log = null;
        }

        public static void Info(string message, string key = null, int stackDeep = 1)
        {
            var sf = new System.Diagnostics.StackFrame(stackDeep);
            var method = sf.GetMethod();

            Console.WriteLine(method.DeclaringType.Name);
            Console.WriteLine(method.Name);

            Info(method.DeclaringType.Name, method.Name, message, key);
        }
        public static void Info(string className, string methodName, string message, string key = null)
        {
            ILog log = null;
            if (!string.IsNullOrEmpty(key))
            {
                log = LogManager.GetLogger(key);
            }
            else
            {
                log = LogManager.GetLogger(typeof(LogHelper));
            }
            if (log.IsInfoEnabled)
            {
                string strText = GetMessage("INFO", className, methodName, message);
                log.Info(strText);
            }
            log = null;
        }

        public static void Warn(string message, string key = null, int stackDeep = 1)
        {
            var sf = new System.Diagnostics.StackFrame(stackDeep);
            var method = sf.GetMethod();

            Console.WriteLine(method.DeclaringType.Name);
            Console.WriteLine(method.Name);

            Warn(method.DeclaringType.Name, method.Name, message, key);
        }
        public static void Warn(string className, string methodName, string message, string key = null)
        {
            ILog log = null;
            if (!string.IsNullOrEmpty(key))
            {
                log = LogManager.GetLogger(key);
            }
            else
            {
                log = LogManager.GetLogger(typeof(LogHelper));
            }
            if (log.IsWarnEnabled)
            {
                string strText = GetMessage("INFO", className, methodName, message);
                log.Warn(strText);
            }
            log = null;
        }

        #region GetMessage
        private static string GetMessage(
            string level,
            string className,
            string methodName,
            string message
            )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append("ClassName:" + className + "\r\n");
            sb.Append("MethodName:" + methodName + "\r\n");
            sb.Append("Message:" + message + "\r\n");
            return sb.ToString();
        }
        #endregion
    }
}
