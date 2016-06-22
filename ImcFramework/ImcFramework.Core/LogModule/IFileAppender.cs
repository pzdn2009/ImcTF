using Common.Logging;
using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.LogModule
{
    public interface IFileAppender
    {
        string GetFileName(string sellerAccount, LogLevel LogLevel);

        string GetAppenderName(string sellerAccount, LogLevel LogLevel);
    }
}
