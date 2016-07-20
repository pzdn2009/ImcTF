using ImcFramework.Infrastructure;

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
                catch
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
                catch
                {
                    _hubName = string.Empty;
                }

                return _hubName;
            }
        }
    }
}
