using ImcFramework.Core.MutilUserProgress;
using ImcFramework.LogPool;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ImcFramework.Core
{
    public class Client
    {
        public EServiceType ServiceType { get; set; }
        public List<IMessageCallback> Callbacks { get; set; }
    }

    /// <summary>
    /// 存放客户端
    /// </summary>
    public class Observers
    {
        private static object lockObject = new object();
        private static List<Client> clientList;

        static Observers()
        {
            clientList = new List<Client>();
        }

        public static bool Exist(EServiceType serviceType, IMessageCallback callback)
        {
            lock (lockObject)
            {
                var client = clientList.Find(zw => zw.ServiceType.Equals(serviceType));
                if (client != null)
                {
                    return client.Callbacks.Contains(callback);
                }
                return false;
            }
        }

        public static void Add(EServiceType serviceType, IMessageCallback callback)
        {
            lock (lockObject)
            {
                var tmp = clientList.Find(zw => zw.ServiceType.Equals(serviceType));
                if (tmp != null)
                {
                    tmp.Callbacks.Add(callback);
                }
                else
                {
                    clientList.Add(new Client() { ServiceType = serviceType, Callbacks = new List<IMessageCallback>() { callback } });
                }
            }
        }

        public static void Remove(EServiceType serviceType, IMessageCallback callback)
        {
            if (Exist(serviceType, callback))
            {
                lock (lockObject)
                {
                    var tmp = clientList.Find(zw => zw.ServiceType.Equals(serviceType));
                    tmp.Callbacks.Remove(callback);
                }
            }
        }

        /// <summary>
        /// 客户端回调
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="action"></param>
        public static void CommonCallbackAction(EServiceType serviceType, Action<IMessageCallback> action)
        {
            CheckCallbackChannels();

            var client = clientList.Find(zw => zw.ServiceType.Equals(serviceType));
            if (client == null) return;

            for (int i = 0; i < client.Callbacks.Count; i++)
            {
                try
                {
                    action(client.Callbacks[i]);
                }
                catch
                {
                    client.Callbacks.Remove(client.Callbacks[i]);
                    i--;
                }
            }
        }

        public static void CheckCallbackChannels()
        {
            lock (lockObject)
            {
                foreach (var eachClient in clientList)
                {
                    var needRemove = new List<IMessageCallback>();
                    foreach (var callback in eachClient.Callbacks)
                    {
                        var callbackChannel = callback as ICommunicationObject;

                        if (callbackChannel.State == CommunicationState.Closed || callbackChannel.State == CommunicationState.Faulted)
                        {
                            needRemove.Add(callback);
                        }
                    }
                    foreach (var item in needRemove)
                    {
                        eachClient.Callbacks.Remove(item);
                    }
                }
            }
        }
    }
}
