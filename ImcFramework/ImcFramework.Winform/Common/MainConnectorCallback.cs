using ImcFramework.WcfInterface;
using ImcFramework.Winform.WcfClientConnector;
using System;
namespace ImcFramework.Winform
{
    public class MainConnectorCallback : IMessageCallback
    {
        public void Notify(WcfInterface.MessageEntity msgEntity)
        {
            Console.WriteLine(msgEntity.ServiceType.ServiceType);
        }

        public void NotifyLogInfo(string message)
        {
            Console.WriteLine();
        }

        public void NotifyTaskProgressTotal(WcfInterface.ProgressSummary totalInfo)
        {
            Console.WriteLine();
        }

        public void NotifyTaskProgressItemTotal(string sellerAccount, int total)
        {
            Console.WriteLine();
        }

        public void NotifyTaskProgressItemValueAndTotal(string sellerAccount, WcfInterface.ProgressItem sellerAccountProgress)
        {
            Console.WriteLine();
        }

        public void NotifyTaskProgressForceFinish(string sellerAccount)
        {
            Console.WriteLine();
        }

        public void NotifyTaskProgressFinishAll()
        {
            Console.WriteLine();
        }
    }
}
