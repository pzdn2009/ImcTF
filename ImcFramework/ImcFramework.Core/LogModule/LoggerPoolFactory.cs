using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.LogModule
{
    public class LoggerPoolFactory
    {
        private static Dictionary<string, ILoggerPool> m_LoggerDict = new Dictionary<string, ILoggerPool>();
        private static object lockObject = new object();
        public static ILoggerPool GetLoggerPool(string loggerPoolName)
        {
            lock (lockObject)
            {
                if(!m_LoggerDict.ContainsKey(loggerPoolName))
                {
                    m_LoggerDict[loggerPoolName] = new DefaultLoggerPool(loggerPoolName);
                }

                return m_LoggerDict[loggerPoolName];
            }
        }
    }
}
