using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ImcFramework.Winform
{
    /// <summary>
    /// Win服务配置
    /// </summary>
    public class WinServiceConfig
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// 配置的绑定
        /// </summary>
        public string Binding { get; set; }

        public string ShowText { get { return this.ToString(); } }

        public override string ToString()
        {
            return Service + " (" + Binding + ")";
        }
    }


    public class WinServiceConfigReader
    {
        private static readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\WinService.xml";
        private static readonly string SERVICE_ROOT = "services";
        public static readonly string SERVICE = "service";
        private static readonly string BINDING = "binding";

        private static object lockObject = new object();

        /// <summary>
        /// 读取服务列表
        /// </summary>
        /// <returns></returns>
        public static List<WinServiceConfig> GetWinServices()
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("找不到服务配置文件WinService！");
                }

                XDocument doc = XDocument.Load(fileName);

                var svcList = new List<WinServiceConfig>();
                var services = doc.Document.Descendants(SERVICE);
                foreach (var item in services)
                {
                    svcList.Add(new WinServiceConfig()
                    {
                        Service = item.Value,
                        Binding = item.FirstAttribute.Value
                    });
                }

                return svcList;
            }
        }

        /// <summary>
        /// 设置服务列表
        /// </summary>
        /// <param name="svcList">列表</param>
        /// <param name="append">true：追加，false：覆盖</param>
        public static void SetWinServices(List<WinServiceConfig> svcList, bool append = true)
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("找不到服务配置文件WinService！");
                }

                XDocument doc = XDocument.Load(fileName);

                var query = doc.Document.Element(SERVICE_ROOT);

                if (!append)
                {
                    query.RemoveAll();
                }

                svcList.ForEach(zw =>
                {
                    var ele = new XElement(SERVICE) { Value = zw.Service };
                    ele.SetAttributeValue(BINDING, zw.Binding);
                    query.Add(ele);
                });

                doc.Save(fileName);
            }
        }
    }
}
