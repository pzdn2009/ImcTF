using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Infrastructure
{
    public class JsonUtils
    {
        public static string ToJson(object entity)
        {
            return ToJson(entity, DateTimeExtension.FORMAT_yyyy_MM_dd_HH_mm_ss);
        }

        public static string ToJson(object entity, string dateTimeFormat)
        {
            IsoDateTimeConverter converter = new IsoDateTimeConverter();
            converter.DateTimeStyles = DateTimeStyles.AssumeLocal;

            if (!string.IsNullOrEmpty(dateTimeFormat))
            {
                converter.DateTimeFormat = dateTimeFormat;
            }

            string jsonResult = JsonConvert.SerializeObject(entity,
                    converter);

            return jsonResult;
        }

        public static JObject AddProperty<T>(object entity, string propertyName, T propertyValue)
        {
            JValue value = new JValue(propertyValue);
            JObject jEntity = null;
            if (entity is JObject)
            {
                jEntity = entity as JObject;
            }
            else
            {
                jEntity = JObject.FromObject(entity);
            }
            jEntity.Add(propertyName, value);

            return jEntity;
        }

        public static T ToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
