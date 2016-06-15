using ImcFramework.Winform.WcfClientConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Winform
{
    public class FrmMainConnector : IClientConnectorCallback
    {
        public void Notify(WcfInterface.MessageEntity msgEntity)
        {
            Console.WriteLine(msgEntity.ServiceType.ServiceType);
        }

        public void NotifyLogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void NotifyTaskProgressTotal(WcfInterface.ProgressSummary totalInfo)
        {
            throw new NotImplementedException();
        }

        public void NotifyTaskProgressItemTotal(string sellerAccount, int total)
        {
            throw new NotImplementedException();
        }

        public void NotifyTaskProgressItemValueAndTotal(string sellerAccount, WcfInterface.ProgressItem sellerAccountProgress)
        {
            throw new NotImplementedException();
        }

        public void NotifyTaskProgressForceFinish(string sellerAccount)
        {
            throw new NotImplementedException();
        }

        public void NotifyTaskProgressFinishAll()
        {
            throw new NotImplementedException();
        }
    }
}
