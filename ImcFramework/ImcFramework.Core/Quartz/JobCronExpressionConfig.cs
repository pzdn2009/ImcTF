using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ImcFramework.Core.Quartz
{
    public class JobCronExpressionConfig
    {
        private static readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\quartz_jobs.xml";
        private static readonly string ns = "{http://quartznet.sourceforge.net/JobSchedulingData}";

        private static object lockObject = new object();

        /// <summary>
        /// 从指定的配置文件读取服务配置
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>列表集合</returns>
        public static string GetCronExpression(string triggerName)
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("找不到服务配置文件quartz_jobs！");
                }

                XDocument doc = XDocument.Load(fileName);

                var cron = doc.Document.Descendants(ns + "cron")
                .FirstOrDefault(zw => zw.Element(ns + "name").Value == triggerName)
                .Element(ns + "cron-expression");

                return cron.Value;
            }
        }

        public static string SetCronExpression(string triggerName, string cronExpr)
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("找不到服务配置文件quartz_jobs！");
                }

                XDocument doc = XDocument.Load(fileName);

                var query = doc.Document.Descendants(ns + "cron")
                .FirstOrDefault(zw => zw.Element(ns + "name").Value == triggerName)
                .Element(ns + "cron-expression");
                query.Value = cronExpr;
                doc.Save(fileName);

                return query.Value;
            }
        }
    }
}
