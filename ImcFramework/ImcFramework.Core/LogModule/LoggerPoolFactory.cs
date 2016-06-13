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
        private static Dictionary<EServiceType, ILoggerPool> m_LoggerDict = new Dictionary<EServiceType, ILoggerPool>();
        private static object lockObject = new object();
        public static ILoggerPool GetLoggerPool(EServiceType serviceType)
        {
            lock (lockObject)
            {
                if(!m_LoggerDict.ContainsKey(serviceType))
                {
                    m_LoggerDict[serviceType] = new DefaultLoggerPool(serviceType);
                }

                return m_LoggerDict[serviceType];
            }
        }
    }
}
