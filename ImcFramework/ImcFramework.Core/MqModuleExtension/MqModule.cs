using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.MqModuleExtension
{
    public class MqModule : ModuleExtensionBase
    {
        private IList<IDistributionFacility<ITransferMessage>> m_MqDistributions;

        public MqModule(ServiceContext serviceContext)
            : base(serviceContext)
        {
            m_MqDistributions = new List<IDistributionFacility<ITransferMessage>>();
        }

        private readonly string MQ_MODULE = "MQ_MODULE";

        public override string Name
        {
            get
            {
                return MQ_MODULE;
            }
        }

        public override void Start()
        {
            m_MqDistributions.Add(DistributionFacilityFactory.GetDistributionFacility<MessageEntity>());
            m_MqDistributions.Add(DistributionFacilityFactory.GetDistributionFacility<ProgressInfoMessage>());

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
