using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ImcFramework.Infrastructure
{
    public class ConfigReader
    {
        public static string GetConnectionString(string name)
        {
            if (ConfigurationManager.ConnectionStrings[name] == null)
            {
                throw new KeyNotFoundException(string.Format("AppSetting中找不到连接字符串：{0}", name));
            }
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetAppSetting(string name)
        {
            if (ConfigurationManager.AppSettings[name] == null)
            {
                throw new KeyNotFoundException(string.Format("AppSetting中找不到键：{0}", name));
            }
            return ConfigurationManager.AppSettings[name];
        }

        public static T GetAppSetting<T>(string name)
        {
            if (ConfigurationManager.AppSettings[name] == null)
            {
                throw new KeyNotFoundException(string.Format("AppSetting中找不到键：{0}", name));
            }
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[name], typeof(T));
        }

        public static bool HasAppSetting(string name)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(name);
        }
    }
}
