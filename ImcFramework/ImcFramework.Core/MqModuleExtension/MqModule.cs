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

        public MqModule()
        {
            m_MqDistributions = new List<IDistributionFacility<ITransferMessage>>();
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

            IocManager.RegisterGeneric(typeof(MsmqDistribution<>), typeof(IDistributionFacility<>));

            var list = IocManager.Resolve<IEnumerable<ITransferMessage>>();
            foreach (var item in list)
            {
                Type generic = typeof(IDistributionFacility<>);
                generic = generic.MakeGenericType(new Type[] { item.GetType() });

                var obj = IocManager.Resolve(generic);
                m_MqDistributions.Add((IDistributionFacility<ITransferMessage>)obj);

                LoggerPool.Log(Name, new LogContentEntity()
                {
                    Level = "Debug",
                    Message = obj.GetType().ToString()
                });
            }
        }

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

                    //foreach (var dis in m_MqDistributions)
                    //{
                    //    foreach (var msg in dis.ReadMessages())
                    //    {
                    //        if (msg is MessageEntity)
                    //        {
                    //            Observers.BroadCastMessage(msg as MessageEntity);
                    //        }
                    //        else
                    //        {

                    //        }
                    //    }
                    //}

                    //return;
                    var msgs = first.ReadMessages() as IEnumerable<MessageEntity>;
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
                            LoggerPool.Log(Name, new LogContentEntity()
                            {
                                Level = "Error",
                                Message = "Oh,No!:" + ex.Message + ex.StackTrace
                            });
                        }
                    }
                }//while
            });
        }

        public override void Stop()
        {
            base.Stop();
        }
    }
}
