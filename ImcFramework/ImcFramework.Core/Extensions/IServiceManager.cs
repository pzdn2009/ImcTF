using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务管理器
    /// </summary>
    public interface IServiceManager
    {
        void RunRightNow(string serviceType);
        void Cancel(string serviceType);
        void Pause(string serviceType);
        void Resume(string serviceType);
        void ModifySchedule(string serviceType, string cronExpression);
        string GetServiceStatus(string serviceType);

        void Enable(string serviceType);
        void Disable(string serviceType);
        void Add(string serviceType);
    }
}
