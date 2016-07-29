using ImcFramework.Core.MutilUserProgress;
using Quartz;
using System.ServiceModel;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务上下文
    /// </summary>
    public class ServiceContext
    {
        /// <summary>
        /// Wcf服务
        /// </summary>
        public ServiceHost WcfHost { get; set; }

        /// <summary>
        /// 定时器
        /// </summary>
        public IScheduler Scheduler { get; set; }

        /// <summary>
        /// 进度管理
        /// </summary>
        public IProgressInfoManager ProgressInfoManager { get; set; }
    }
}
