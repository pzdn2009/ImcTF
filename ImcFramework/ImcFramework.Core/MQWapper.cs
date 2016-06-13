using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class MQWapper
    {
        public static void Add(MessageEntity msgMQEntity)
        {
            MessageQueueTransfer.Instance.SendMessageEntity(msgMQEntity);
            System.Threading.Thread.Sleep(1);
        }

        public static void StartRead()
        {
            Task.Factory.StartNew(() =>
            {
                while (Defaults.IsIsolatedJob)
                {
                    System.Threading.Thread.Sleep(1);

                    var msgs = MessageQueueTransfer.Instance.ReceiveMessageEntitys(Defaults.ProcessName, 50);
                    foreach (var msg in msgs.OrderBy(zw => zw.Timestamp))
                    {
                        if (!msg.IsProgressMsg)
                        {
                            Observers.BroadCastMessageWithMQ(msg);
                        }
                        else
                        {
                            try
                            {
                                switch (msg.CallbackMethodName)
                                {
                                    case "SendTaskProgressTotal":
                                        Observers.SendTaskProgressTotal(msg.ServiceType, msg.Total, msg.TotalType, true);
                                        break;
                                    case "SendTaskProgressItemTotal":
                                        Observers.SendTaskProgressItemTotal(msg.ServiceType, msg.SellerAccount, msg.Total, true);
                                        break;
                                    case "SendTaskProgressIncrease":
                                        Observers.SendTaskProgressIncrease(msg.ServiceType, msg.SellerAccount, msg.Value, true);
                                        break;
                                    case "SendTaskProgressForceFinish":
                                        Observers.SendTaskProgressForceFinish(msg.ServiceType, msg.SellerAccount, true);
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
                }
            });
        }

        public static void WaitForMQClear()
        {

        }
    }
}
