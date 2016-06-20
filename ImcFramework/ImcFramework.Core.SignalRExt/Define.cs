using ImcFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.SignalRExt
{
    public class Define
    {
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
