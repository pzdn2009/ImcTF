using Common.Logging;
using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Core.LogModule
{

    internal struct AppenderKey
    {
        public AppenderKey(string sellerAccount, LogLevel logLevel)
        {
            SellerAccount = sellerAccount;
            LogLevel = logLevel;
        }

        public string SellerAccount { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class DefaultFileAppender : IFileAppender
    {
        private string serviceType;
        private Dictionary<AppenderKey, string> appendNameDict;

        public DefaultFileAppender(string serviceType)
        {
            Guard.IsNull(serviceType);

            this.serviceType = serviceType;

            appendNameDict = new Dictionary<AppenderKey, string>();
        }

        private void EnsureAppendName(AppenderKey key)
        {
            if (!appendNameDict.ContainsKey(key))
            {
                string f = serviceType.ToString() + "/" + "{0}__{1}";
                var appenderName = string.Empty;

                if (string.IsNullOrEmpty(key.SellerAccount))
                {
                    appenderName = string.Format(f, "AllLog", key.LogLevel.ToString());
                }
                else
                {
                    appenderName = string.Format(f, key.SellerAccount, key.LogLevel.ToString());
                }

                appendNameDict[key] = appenderName;
            }
        }

        public string GetFileName(string sellerAccount, LogLevel logLevel)
        {
            var key = new AppenderKey(sellerAccount, logLevel);
            EnsureAppendName(key);

            var logFileName = "Log/" + string.Format("{0}__.txt", appendNameDict[key]);
            return logFileName;
        }

        public string GetAppenderName(string sellerAccount, LogLevel logLevel)
        {
            var key = new AppenderKey(sellerAccount, logLevel);
            EnsureAppendName(key);

            return appendNameDict[key];
        }
    }
}