using ImcFramework.Reflection;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Collections.Generic;

namespace ImcFramework.Core
{
    public class EServiceTypeReader
    {
        public static List<EServiceType> ServiceTypes { get; private set; }

        /// <summary>
        /// 反射读取集合列表
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>列表集合</returns>
        public static List<EServiceType> GetEServiceTypes()
        {
            if (ServiceTypes == null)
            {
                ServiceTypes = new List<EServiceType>();

                ITypeFinder typeFinder = new TypeFinder();
                var types = typeFinder.Find(zw => IsJobType(zw));

                foreach (var type in types)
                {
                    var property = type.GetProperty("ServiceType");
                    if (property != null)
                    {
                        var val = property.GetValue(Activator.CreateInstance(type), null) as EServiceType;
                        if (val != null && val.ShowInClientMenu)
                        {
                            ServiceTypes.Add(val);
                        }
                    }
                }
            }

            return ServiceTypes;
        }

        public static bool IsJobType(Type type)
        {
            return
                type.IsClass &&
                !type.IsAbstract &&
                typeof(IJob).IsAssignableFrom(type);
        }
    }
}
