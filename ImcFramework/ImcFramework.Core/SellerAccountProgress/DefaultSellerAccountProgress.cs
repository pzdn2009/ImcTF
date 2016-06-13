using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class DefaultSellerAccountProgress : ISellerAccountProgress
    {
        private EServiceType serviceType;

        public DefaultSellerAccountProgress(EServiceType serviceType)
        {
            this.serviceType = serviceType;
        }

        //设置总数
        public void SendTaskProgressTotal(int count, TotalType totalType)
        {
            Observers.SendTaskProgressTotal(serviceType, count, totalType);
        }

        //设置单个账号的总数
        public void SendTaskProgressItemTotal(string sellerAccount, int total)
        {
            Observers.SendTaskProgressItemTotal(serviceType, sellerAccount, total);
        }

        //设置单个账号+1
        public void SendTaskProgressIncrease(string sellerAccount)
        {
            Observers.SendTaskProgressIncrease(serviceType, sellerAccount, 1);
        }

        //设置单个账号强制完成
        public void ForceFinish(string sellerAccount)
        {
            Observers.SendTaskProgressForceFinish(serviceType, sellerAccount);
        }

        //结束
        public void FinishAll()
        {
            Observers.SendTaskProgressFinishAll(serviceType);
        }
    }
}
