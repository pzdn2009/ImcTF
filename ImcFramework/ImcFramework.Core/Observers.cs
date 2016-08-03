using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ImcFramework.Core
{
    /// <summary>
    /// Wcf client object.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// ServiceType.
        /// </summary>
        public EServiceType ServiceType { get; set; }

        /// <summary>
        /// The Callback instances.
        /// </summary>
        public List<IMessageCallback> Callbacks { get; set; }
    }

    /// <summary>
    /// Manage the <see cref="Client"/>s .
    /// </summary>
    public class Observers
    {
        private static object lockObject = new object();
        private static List<Client> clientList;

        static Observers()
        {
            clientList = new List<Client>();
        }

        /// <summary>
        /// Check the given servicetype and callback exists whether or not.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="callback">The callback instance.</param>
        /// <returns>return true if exists,otherwise return false.</returns>
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

        /// <summary>
        /// Add a servicetype & callback.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="callback">The callback instance.</param>
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

        /// <summary>
        /// Remove a servicetype & callback.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="callback">The callback instance.</param>
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
        /// Common callback for all clients.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="action">The action body.</param>
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

        /// <summary>
        /// Ensure the client is connecting.
        /// </summary>
        private static void CheckCallbackChannels()
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
