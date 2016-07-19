namespace ImcFramework.Core.SignalRExt.Client
{
    public class SignalRClientConfig
    {
        public SignalRClientConfig()
        {
        }

        public SignalRClientConfig(string serverUrl, string hubName)
        {
            ServerUrl = serverUrl;
            HubName = hubName;
        }

        public string ServerUrl { get; set; }

        public string HubName { get; set; }

        public TokenData TokenData { get; set; }

        public string CertificateName { get; set; }

        public CookieAuthenticate CookieAuthenticate { get; set; }
    }
}
