using ImcFramework.Reflection;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Collections.Generic;

namespace ImcFramework.Core.WcfService
{
    public class DefaultServiceTypeReader : IServiceTypeReader
    {
        private static List<EServiceType> serviceTypes;

        private IServiceTypeFilter serviceTypeFilter;
        private ITypeFinder typeFinder;
        public DefaultServiceTypeReader(IServiceTypeFilter serviceTypeFilter, ITypeFinder typeFinder)
        {
            this.serviceTypeFilter = serviceTypeFilter;
            this.typeFinder = typeFinder;
        }

        public IEnumerable<EServiceType> GetEServiceTypes()
        {
            if (serviceTypes == null)
            {
                serviceTypes = new List<EServiceType>();

                var types = typeFinder.Find(zw => IsJobType(zw));

                foreach (var type in types)
                {
                    var property = type.GetProperty("ServiceType");
                    if (property != null)
                    {
                        var val = property.GetValue(Activator.CreateInstance(type), null) as EServiceType;
                        if (!serviceTypeFilter.Filter(val))
                        {
                            continue;
                        }

                        if (val != null && val.ShowInClientMenu)
                        {
                            serviceTypes.Add(val);
                        }
                    }
                }
            }

            return serviceTypes;
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
