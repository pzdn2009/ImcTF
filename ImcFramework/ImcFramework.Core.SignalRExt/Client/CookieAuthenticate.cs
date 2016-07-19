using System.Net;

namespace ImcFramework.Core.SignalRExt.Client
{
    public class CookieAuthenticate
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FormsCookieName { get; set; }

        public string LoginUrl { get; set; }

        public bool AuthenticateUser(out Cookie authCookie)
        {
            var request = WebRequest.Create(LoginUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            var authCredentials = "UserName=" + UserName + "&Password=" + Password;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
            request.ContentLength = bytes.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                authCookie = response.Cookies[FormsCookieName];
            }

            if (authCookie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
