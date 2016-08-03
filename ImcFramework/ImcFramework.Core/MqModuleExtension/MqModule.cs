using ImcFramework.Core.Distribution;
using ImcFramework.LogPool;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImcFramework.Core.MqModuleExtension
{
    /// <summary>
    /// The message queue module for message transfer between appdomans.
    /// </summary>
    public class MqModule : ServiceModuleBase, IModuleExtension
    {
        public const string MODUEL_NAME = "MQ_MODULE";

        private IList<IDistributionFacility<ITransferMessage>> m_MqDistributions;
        private List<ITransferMessageCallback> m_TransferMessageCallbacks;

        public MqModule()
        {
            m_MqDistributions = new List<IDistributionFacility<ITransferMessage>>();
            m_TransferMessageCallbacks = new List<ITransferMessageCallback>();
        }

        /// <summary>
        /// The modue name
        /// </summary>
        public override string Name
        {
            get
            {
                return MODUEL_NAME;
            }
        }

        /// <summary>
        /// service context for extension
        /// </summary>
        public ServiceContext ServiceContext
        {
            get; set;
        }

        /// <summary>
        /// Initialize the module.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            //Register the Msmq as base fuoundation of the module.
            IocManager.RegisterGeneric(typeof(MsmqDistribution<>), typeof(IDistributionFacility<>));

            var transferMsgs = IocManager.Resolve<IEnumerable<ITransferMessage>>();
            var resTransferMessageCallbacks = IocManager.Resolve<IEnumerable<ITransferMessageCallback>>();

            foreach (var transferMsg in transferMsgs)
            {
                var distType = typeof(IDistributionFacility<>).MakeGenericType(new Type[] { transferMsg.GetType() });
                var mqForTransferMessage = IocManager.Resolve(distType);

                m_MqDistributions.Add((IDistributionFacility<ITransferMessage>)mqForTransferMessage);

                var callback = resTransferMessageCallbacks.FirstOrDefault(zw => zw.TranferMessageType == transferMsg.GetType());
                m_TransferMessageCallbacks.Add(callback);
            }
        }

        /// <summary>
        /// Start the module.
        /// </summary>
        public override void Start()
        {
            base.Start();

            var first = m_MqDistributions.Last();
            var last = m_MqDistributions.First();

            Task.Factory.StartNew(() =>
            {
                while (Defaults.IsIsolatedJob)
                {
                    System.Threading.Thread.Sleep(1);

                    for (int i = 0; i < m_MqDistributions.Count; i++)
                    {
                        foreach (var msg in m_MqDistributions[i].ReadMessages())
                        {
                            try
                            {
                                m_TransferMessageCallbacks[i]?.Call(msg);
                            }
                            catch (Exception ex)
                            {
                                LoggerPool.Log(Name, new LogContentEntity()
                                {
                                    Level = "Error",
                                    Message = ex.Message + ex.StackTrace
                                });
                            }
                        }
                    }
                }//while
            });
        }

        /// <summary>
        /// Stop the module.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
        }
    }
}
