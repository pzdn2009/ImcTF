using ImcFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Core
{
    public class Defaults
    {
        //日志存放目录
        public static string RootDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\";

        //日志文件分隔符
        public const string BusinessLogFileSplitChar = "__";

        private static string _processName = string.Empty;
        /// <summary>
        /// 当前进程名
        /// </summary>
        public static string ProcessName
        {
            get
            {
                if (_processName == string.Empty)
                {
                    _processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                }
                return _processName;
            }
        }

        private static bool? _isolatedJob = null;
        /// <summary>
        /// 是否为隔离的Job
        /// </summary>
        public static bool IsIsolatedJob
        {
            get
            {
                try
                {
                    if (!_isolatedJob.HasValue)
                    {
                        _isolatedJob = ConfigReader.GetAppSetting<bool>("IsIsolatedJob");
                    }
                }
                catch (Exception ex)
                {
                    _isolatedJob = false;
                }

                return _isolatedJob.Value;
            }
        }

        private static string _signalRUrl = null;
        /// <summary>
        /// SignalR 网址
        /// </summary>
        public static string SignalRUrl
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_signalRUrl))
                    {
                        _signalRUrl = ConfigReader.GetAppSetting<string>("SignalRUrl");
                    }
                }
                catch (Exception ex)
                {
                    _signalRUrl = string.Empty;
                }

                return _signalRUrl;
            }
        }

        private static string _hubName = null;
        /// <summary>
        /// SignalR 网址
        /// </summary>
        public static string HubName
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(_hubName))
                    {
                        _hubName = ConfigReader.GetAppSetting<string>("HubName");
                    }
                }
                catch (Exception ex)
                {
                    _hubName = string.Empty;
                }

                return _hubName;
            }
        }
    }
}
