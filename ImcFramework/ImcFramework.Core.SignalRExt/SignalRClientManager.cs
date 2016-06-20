using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Core.SignalRExt
{
    public class SignalRClientManager
    {
        private static Dictionary<string, SignalRClient> dicts = new Dictionary<string, SignalRClient>();
        private static object lockObject = new object();

        public static void RegisterAll()
        {
            foreach (var serviceType in EServiceTypeReader.GetEServiceTypes())
            {
                Resolve(serviceType);
            }
        }

        public static SignalRClient Resolve(EServiceType serviceType)
        {
            lock (lockObject)
            {
                if (!dicts.ContainsKey(serviceType.ServiceType))
                {
                    dicts[serviceType.ServiceType] = new SignalRClient(Define.SignalRUrl, Define.HubName, serviceType.ServiceType);
                    dicts[serviceType.ServiceType].Connect();
                }

                return dicts[serviceType.ServiceType];
            }
        }

        public static void Recuperation(EServiceType serviceType)
        {
            lock (lockObject)
            {
                if (dicts.ContainsKey(serviceType.ServiceType))
                {
                    dicts[serviceType.ServiceType].Dispose();
                    dicts.Remove(serviceType.ServiceType);
                }
            }
        }

        public static void UnRegisterAll()
        {
            lock (lockObject)
            {
                foreach (var item in dicts)
                {
                    item.Value.Dispose();
                }
                dicts.Clear();
            }
        }
    }
}
