using ImcFramework.Infrastructure;
using System;

namespace ImcFramework.Core
{
    /// <summary>
    /// Define values.
    /// </summary>
    public class Defaults
    {
        /// <summary>
        /// The log path.
        /// </summary>
        public static string RootDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\";

        /// <summary>
        /// The underline char.
        /// </summary>
        public const string BusinessLogFileSplitChar = "__";

        private static string _processName = string.Empty;
        /// <summary>
        /// The process name.
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
        /// Is isolated job.
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
                catch
                {
                    _isolatedJob = false;
                }

                return _isolatedJob.Value;
            }
        }
    }
}
