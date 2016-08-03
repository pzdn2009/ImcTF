using ImcFramework.Reflection;
using ImcFramework.WcfInterface;
using Quartz;
using System;
using System.Collections.Generic;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// Default servicetype reader.
    /// </summary>
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

        /// <summary>
        /// Get all servicetypes.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Check if the type is IJob.
        /// </summary>
        /// <param name="type">the input type.</param>
        /// <returns>return true if the type is IJob,otherwise,return false.</returns>
        private static bool IsJobType(Type type)
        {
            return
                type.IsClass &&
                !type.IsAbstract &&
                typeof(IJob).IsAssignableFrom(type);
        }
    }
}
