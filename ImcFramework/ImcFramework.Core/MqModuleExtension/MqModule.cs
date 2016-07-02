using ImcFramework.Core.Distribution;
using ImcFramework.Infrastructure;
using ImcFramework.LogPool;
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

        private IDistributionFacilityProvider distributionFacilityProvider;

        public MqModule(IDistributionFacilityProvider distributionFacilityProvider)
        {
            m_MqDistributions = new List<IDistributionFacility<ITransferMessage>>();

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
            base.Initialize();

            m_MqDistributions.Add(distributionFacilityProvider.GetDistributionFacility<MessageEntity>());
            m_MqDistributions.Add(distributionFacilityProvider.GetDistributionFacility<ProgressInfoMessage>());
        }

        public override void Start()
        {
            base.Start();

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
                        Observers.BroadCastMessage(msg);
                    }

                    var msgs2 = last.ReadMessages() as IEnumerable<ProgressInfoMessage>;
                    foreach (var msg in msgs2)
                    {
                        try
                        {
                            switch (msg.CallbackMethodName)
                            {
                                case "SendTaskProgressTotal":
                                    Observers.SendTaskProgressTotal(msg.ServiceType, msg.Total, msg.TotalType);
                                    break;
                                case "SendTaskProgressItemTotal":
                                    Observers.SendTaskProgressItemTotal(msg.ServiceType, msg.User, msg.Total);
                                    break;
                                case "SendTaskProgressIncrease":
                                    Observers.SendTaskProgressIncrease(msg.ServiceType, msg.User, msg.Value);
                                    break;
                                case "ForceFinish":
                                    Observers.SendTaskProgressForceFinish(msg.ServiceType, msg.User);
                                    break;
                                case "FinishAll":
                                    Observers.SendTaskProgressFinishAll(msg.ServiceType);
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
