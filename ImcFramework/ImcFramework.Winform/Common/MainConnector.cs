using ImcFramework.Winform.WcfClientConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Winform.Common
{
    public class MainConnector : IClientConnectorCallback
    {
        public void Notify(WcfInterface.MessageEntity msgEntity)
        {
            throw new NotImplementedException();
        }

        public void NotifyLogInfo(string message)
        {
            throw new NotImplementedException();
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
