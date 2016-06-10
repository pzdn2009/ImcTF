using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ImcFramework.Infrastructure
{
    public class XmlHelper
    {
        public static string XmlSerialize<T>(T entity)
        {
            Guard.IsNotNull(entity, "entity");

            var serializer = new XmlSerializer(typeof(T));
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, entity);
            }
            return sb.ToString();
        }

        public static string XmlSerialize(object item)
        {
            Guard.IsNotNull(item, "item");

            var type = item.GetType();
            var serializer = new XmlSerializer(type);
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, item);
            }
            return sb.ToString();
        }

        public static T XmlDeserialize<T>(string xmlData)
        {
            Guard.IsNotNull(xmlData, "xmlData");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlData))
            {
                T entity = (T)serializer.Deserialize(reader);
                return entity;
            }
        }

        public static string SerializeXml<T>(T model)
        {
            Guard.IsNotNull(model, "model");

            string resultString = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(memoryStream, model);
                var bt = new byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bt, 0, bt.Length);
                resultString = Encoding.UTF8.GetString(bt);
            }
            return resultString;
        }

        public static string SerializeXml(object model, Type type)
        {
            Guard.IsNotNull(model, "model");

            string resultString = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                xmlSerializer.Serialize(memoryStream, model);
                var bt = new byte[memoryStream.Length];
                memoryStream.Position = 0;
                memoryStream.Read(bt, 0, bt.Length);
                resultString = Encoding.UTF8.GetString(bt);
            }
            return resultString;
        }
    }
}
