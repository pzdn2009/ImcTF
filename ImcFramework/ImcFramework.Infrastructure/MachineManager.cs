using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class MachineManager
    {
        /// <summary>
        /// 获得Mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            string madAddr = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    madAddr = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            return madAddr;
        }

        public static List<string> GetMacs()
        {
            List<string> madAddrs = new List<string>();
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                {
                    madAddrs.Add(mo["MacAddress"].ToString());
                }
                mo.Dispose();
            }

            return madAddrs;
        }

        /// <summary>
        /// 获得IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string hostname = Dns.GetHostName();//得到本机名   
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            IPAddress localaddr = localhost.AddressList[0];
            return localaddr.ToString();
        }

        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            string hostname = Dns.GetHostName();
            return hostname;
        }

        /// <summary>
        /// 根据域名获取到外网IP
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns>外网IP</returns>
        public static string GetIPOuter(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return string.Empty;
            }

            Ping p = new Ping();
            var result = p.Send(domain, 5000);
            return result.Address.ToString();
        }
    }
}
