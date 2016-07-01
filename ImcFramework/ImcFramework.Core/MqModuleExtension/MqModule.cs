using ImcFramework.Core.Distribution;
using ImcFramework.Core.LogModule;
using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImcFramework.Core.MqModuleExtension
{
    public class MqModule : ServiceModuleBase, IModuleExtension
    {
        public const string MODUEL_NAME = "MQ_MODULE";

        private IList<IDistributionFacility<ITransferMessage>> m_MqDistributions;

        private ILoggerPool loggerPool;
        private IDistributionFacilityProvider distributionFacilityProvider;

        public MqModule(ILoggerPoolFactory loggerPoolFactory,IDistributionFacilityProvider distributionFacilityProvider)
        {
            m_MqDistributions = new List<IDistributionFacility<ITransferMessage>>();

            this.loggerPool = loggerPoolFactory.GetLoggerPool(MODUEL_NAME);

            Logger = loggerPool.GetLogger("");

            this.distributionFacilityProvider = distributionFacilityProvider;
        }

        public override string Name
        {
            get
            {
                return MODUEL_NAME;
            }
        }

        public ServiceContext ServiceContext
        {
            get; set;
        }

        public override void Initialize()
        {
            m_MqDistributions.Add(distributionFacilityProvider.GetDistributionFacility<MessageEntity>());
            m_MqDistributions.Add(distributionFacilityProvider.GetDistributionFacility<ProgressInfoMessage>());
        }

        public override void Start()
        {
            var fisrt = m_MqDistributions.First();
            var last = m_MqDistributions.Last();

            Task.Factory.StartNew(() =>
            {
                while (Defaults.IsIsolatedJob)
                {
                    System.Threading.Thread.Sleep(1);

                    var msgs = fisrt.ReadMessages() as IEnumerable<MessageEntity>;
                    foreach (var msg in msgs.OrderBy(zw => zw.Timestamp))
                    {
                        Observers.BroadCastMessageWithMQ(msg);
                    }

                    var msgs2 = last.ReadMessages() as IEnumerable<ProgressInfoMessage>;
                    foreach (var msg in msgs2)
                    {
                        try
                        {
                            switch (msg.CallbackMethodName)
                            {
                                case "SendTaskProgressTotal":
                                    Observers.SendTaskProgressTotal(msg.ServiceType, msg.Total, msg.TotalType, true);
                                    break;
                                case "SendTaskProgressItemTotal":
                                    Observers.SendTaskProgressItemTotal(msg.ServiceType, msg.User, msg.Total, true);
                                    break;
                                case "SendTaskProgressIncrease":
                                    Observers.SendTaskProgressIncrease(msg.ServiceType, msg.User, msg.Value, true);
                                    break;
                                case "SendTaskProgressForceFinish":
                                    Observers.SendTaskProgressForceFinish(msg.ServiceType, msg.User, true);
                                    break;
                                case "SendTaskProgressFinishAll":
                                    Observers.SendTaskProgressFinishAll(msg.ServiceType, true);
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Error("我去，出大事了:" + ex.Message + ex.StackTrace);
                        }
                    }
                }
            });
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
