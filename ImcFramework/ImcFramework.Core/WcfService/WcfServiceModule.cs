﻿using ImcFramework.WcfInterface;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using Autofac.Integration.Wcf;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// Wcf service module.
    /// </summary>
    public class WcfServiceModule : ServiceModuleBase
    {
        public const string MODUEL_NAME = "WcfService_Module";

        public WcfServiceModule()
        {

        }

        public ServiceHost ServiceHost { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// The module name.
        /// </summary>
        public override string Name
        {
            get
            {
                return MODUEL_NAME;
            }
        }

        /// <summary>
        /// Start the module.
        /// </summary>
        public override void Start()
        {
            base.Start();
            try
            {
                ServiceHost = new ServiceHost(typeof(ClientConnectorReal));

                //autofac DI
                ServiceHost.AddDependencyInjectionBehavior<IClientConnector>(IocManager.Container);

                //绑定服务行为
                ServiceMetadataBehavior behavior = ServiceHost.Description.Behaviors.
                    Find<ServiceMetadataBehavior>();

                if (behavior == null)
                {
                    behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    ServiceHost.Description.Behaviors.Add(behavior);
                }
                else
                {
                    behavior.HttpGetEnabled = true;
                }

                //启动事件
                ServiceHost.Opened += delegate
                {
                    var Logger = LoggerPool.GetLogger("");
                    Logger.Info("Host-->Endpoint：" + ServiceHost.Description.Endpoints.FirstOrDefault().Address);
                    Logger.Info("Host-->Service started：" + ServiceHost.Description.ConfigurationName);
                };

                ServiceHost.Closed += delegate
                {
                    var Logger = LoggerPool.GetLogger("");
                    Logger.Info("Host-->Endpoint：" + ServiceHost.Description.Endpoints.FirstOrDefault().Address);
                    Logger.Info("Host-->Service closed：" + ServiceHost.Description.ConfigurationName);
                };

                Thread th = new Thread(ServiceHost.Open);
                th.Start();

                IocManager.Register<IServiceHostProvider>(new DefaultServiceHostProvider(ServiceHost));
            }
            catch (Exception ex)
            {
                var Logger = LoggerPool.GetLogger("");
                Logger.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Stop the module.
        /// </summary>
        public override void Stop()
        {
            if (ServiceHost != null)
            {
                try
                {
                    ServiceHost.Close();
                }
                catch (Exception ex)
                {
                    var Logger = LoggerPool.GetLogger("");
                    Logger.Error(ex.Message, ex);
                }
                finally
                {
                    ServiceHost.Abort();
                }
            }
        }
    }
}
