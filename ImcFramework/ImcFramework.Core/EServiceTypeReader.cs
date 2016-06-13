using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImcFramework.Core
{
    public class EServiceTypeReader
    {
        private static readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\ServiceTypeConfig.xml";
        private static object lockObject = new object();

        /// <summary>
        /// 从指定的配置文件读取服务配置
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>列表集合</returns>
        public static List<EServiceType> GetEServiceTypes()
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("找不到服务配置文件ServiceTypeConfig！");
                }

                var xmlParentElements = XElement.Load(fileName).Descendants("EServiceType");
                
                var list = new List<EServiceType>();

                foreach (var element in xmlParentElements)
                {
                    var svcType = new EServiceType();
                    svcType.ServiceType = element.Element("ServiceType").Value;
                    svcType.ServiceName = element.Element("ServiceName").Value;

                    list.Add(svcType);
                }

                return list;
            }
        }


    }
}
