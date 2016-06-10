using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class WebRequestUtility
    {
        public static WebRequest CreateUrl(string url, string data, Action<HttpWebRequest> webRequestAction = null)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            if(webRequestAction!=null)
            {
                //request.ContentType = requestEntity.ContentType;
                //request.Accept = requestEntity.Accept;
                //request.Method = requestEntity.Method.ToString();

                //request.Headers.Add("Authorization", requestEntity.Authorization);
                //request.Headers.Add("Secretkey", requestEntity.Secretkey);
                webRequestAction(request);
            }

            byte[] byteStr = Encoding.UTF8.GetBytes(data);
            request.ContentLength = byteStr.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(byteStr, 0, byteStr.Length);
            }

            return request;
        }

        public static string GetResponse(WebRequest request)
        {
            Func<WebResponse, string> getResponseContent = wr =>
            {
                if (wr == null)
                    return string.Empty;

                using (var reader = new StreamReader(wr.GetResponseStream(), Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            };

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return getResponseContent(response);
                }
            }
            catch (WebException ex)
            {
                return getResponseContent(ex.Response);
            }
        }
    }
}
