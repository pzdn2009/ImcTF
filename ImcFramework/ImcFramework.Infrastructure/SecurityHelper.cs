using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class SecurityHelper
    {
        public static string MD5(string password, bool campatiblePhp = false)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
            cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(textBytes);
            string ret = "";
            foreach (byte a in hash)
            {
                if (campatiblePhp && a < 16)
                {
                    ret += "0" + a.ToString("x");
                }
                else
                {
                    ret += a.ToString("x");
                }
            }
            return ret;
        }
    }
}
