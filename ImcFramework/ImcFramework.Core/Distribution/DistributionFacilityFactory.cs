using ImcFramework.Core.MqModuleExtension;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;

namespace ImcFramework.Core.Distribution
{
    public interface IDistributionFacilityProvider
    {
        IDistributionFacility<T> GetDistributionFacility<T>() where T : class, ITransferMessage;

        IDistributionFacility<T> GetDistributionFacility<T>(T messageEntity) where T : class, ITransferMessage;
    }

    public class DistributionFacilityProvider : IDistributionFacilityProvider
    {
        private static object lockObject = new object();
        private static Dictionary<Type, object> dict = new Dictionary<Type, object>();

        public IDistributionFacility<T> GetDistributionFacility<T>() where T : class, ITransferMessage
        {
            lock (lockObject)
            {
                var type = typeof(T);
                if (!dict.ContainsKey(type))
                {
                    dict[type] = new MsmqDistribution<T>();
                }

                return dict[type] as IDistributionFacility<T>;
            }
        }

        public IDistributionFacility<T> GetDistributionFacility<T>(T messageEntity) where T : class, ITransferMessage
        {
            lock (lockObject)
            {
                var type = messageEntity.GetType();
                if (!dict.ContainsKey(type))
                {
                    dict[type] = new MsmqDistribution<T>();
                }

                return dict[type] as IDistributionFacility<T>;
            }
        }
    }

    public static class DistributionFacilityFactory
    {
        private static object lockObject = new object();
        private static Dictionary<Type, object> dict = new Dictionary<Type, object>();

        public static IDistributionFacility<T> GetDistributionFacility<T>() where T : class, ITransferMessage
        {
            lock (lockObject)
            {
                var type = typeof(T);
                if (!dict.ContainsKey(type))
                {
                    dict[type] = new MsmqDistribution<T>();
                }

                return dict[type] as IDistributionFacility<T>;
            }
        }
        public static IDistributionFacility<T> GetDistributionFacility<T>(T messageEntity) where T : class, ITransferMessage
        {
            lock (lockObject)
            {
                var type = messageEntity.GetType();
                if (!dict.ContainsKey(type))
                {
                    dict[type] = new MsmqDistribution<T>();
                }

                return dict[type] as IDistributionFacility<T>;
            }
        }
    }
}
