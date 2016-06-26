using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class DefaultMutilUserProgress : IMutilUserProgress
    {
        private EServiceType serviceType;

        public DefaultMutilUserProgress(EServiceType serviceType)
        {
            this.serviceType = serviceType;
        }

        //设置总数
        public void SendTaskProgressTotal(int count, TotalType totalType)
        {
            Observers.SendTaskProgressTotal(serviceType, count, totalType);
        }

        //设置单个账号的总数
        public void SendTaskProgressItemTotal(string user, int total)
        {
            Observers.SendTaskProgressItemTotal(serviceType, user, total);
        }

        //设置单个账号+1
        public void SendTaskProgressIncrease(string user)
        {
            Observers.SendTaskProgressIncrease(serviceType, user, 1);
        }

        //设置单个账号强制完成
        public void ForceFinish(string user)
        {
            Observers.SendTaskProgressForceFinish(serviceType, user);
        }

        //结束
        public void FinishAll()
        {
            Observers.SendTaskProgressFinishAll(serviceType);
        }
    }
}
