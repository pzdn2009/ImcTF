using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ImcFramework.Core.IsolatedAd;
using ImcFramework.Core.Quartz;

namespace ImcFramework.Core
{
    /// <summary>
    /// 服务启动
    /// </summary>
    public static class ServiceManager
    {
        private static string TRIGGER = "Trigger";

        private static ServiceHost hostStub;
        private static IEnumerable<IModuleExtension> modules;
        private static IEnumerable<IServiceModule> buildInModules;
        private static StdQuartzModule stdQuartzModule;

        public static void StopWcfHost()
        {
            if (hostStub != null)
                Host.Close(hostStub);
        }

        public static void StartWcfHost()
        {
            hostStub = Host.HostService(typeof(ClientConnectorReal)); //寄宿
        }

        /// <summary>
        /// 启动所有的任务
        /// </summary>
        public static void StartAll()
        {
            StartWcfHost();

            stdQuartzModule = new StdQuartzModule();
            stdQuartzModule.Start();

            ServiceContext serviceContext = new ServiceContext();
            serviceContext.Scheduler = null;// scheduler;
            serviceContext.WcfHost = hostStub;
            serviceContext.ProgressInfoManager = ProgressInfoManager.Instance;

            modules = ModuleConfiguration.ReadConfig(serviceContext);
            foreach (var item in modules)
            {
                item.Start();
            }
        }

        public static void StopAll()
        {
            if (modules != null)
            {
                foreach (var item in modules)
                {
                    item.Stop();
                }
            }

            stdQuartzModule.Stop();

            StopWcfHost();
        }


        #region Command

        public static void Continue(string serviceName)
        {
            if (stdQuartzModule.Scheduler != null && stdQuartzModule.Scheduler.IsStarted)
            {
                stdQuartzModule.Scheduler.ResumeTrigger(serviceName.GetTriggerKey());
            }
        }

        public static void Cancel(string serviceName)
        {
            if (GetStatus(serviceName) != EServiceStatus.Running)
                return;

            var job = stdQuartzModule.Scheduler.GetCurrentlyExecutingJobs().FirstOrDefault(zw => zw.JobDetail.Key.Name == serviceName);
            if (job == null)
            {
                return;
            }

            if (!Defaults.IsIsolatedJob)
            {
                var cancel = job.JobInstance as ITaskCancel;
                cancel.Cancel();
            }
            else
            {
                var cancel = job.JobInstance as IsolatedJob;
                cancel.Cancel();
            }
        }

        public static void RunRightNow(string serviceName)
        {
            if (GetStatus(serviceName) == EServiceStatus.Running)
                return;

            if (RunOnce.Exist(serviceName))
                return;

            RunOnce.Add(serviceName);

            var job = stdQuartzModule.Scheduler.GetJobDetail(serviceName.GetJobKey());
            if (job != null)
            {
                stdQuartzModule.Scheduler.TriggerJob(job.Key);
                //var trigger = TriggerBuilder.Create()
                //    .WithIdentity(serviceName, serviceName)
                //    .StartNow()
                //    .WithSchedule(
                //    SimpleScheduleBuilder.Create()
                //    .WithIntervalInSeconds(1)
                //    .WithRepeatCount(1)).Build();

                //scheduler.ScheduleJob(job, trigger);
            }

            RunOnce.Remove(serviceName);
        }

        public static EServiceStatus GetStatus(string serviceName)
        {
            var state = stdQuartzModule.Scheduler.GetTriggerState(serviceName.GetTriggerKey());
            if (state == TriggerState.Paused)
                return EServiceStatus.Pause;  //暂停

            foreach (var item in stdQuartzModule.Scheduler.GetCurrentlyExecutingJobs())
            {
                if (item.JobDetail.Key.Name == serviceName)
                    return EServiceStatus.Running;  //运行
            }

            return EServiceStatus.Normal;
        }

        public static string GetSchedule(string serviceName)
        {
            var trigger = stdQuartzModule.Scheduler.GetTrigger(serviceName.GetTriggerKey());
            if (trigger != null)
            {
                var cronBuilder = trigger as ICronTrigger;
                return JobCronExpressionConfig.GetCronExpression(serviceName + TRIGGER);
            }
            return string.Empty;
        }

        public static void Pause(string serviceName)
        {
            stdQuartzModule.Scheduler.PauseTrigger(serviceName.GetTriggerKey());
            bool yes = stdQuartzModule.Scheduler.IsJobGroupPaused(serviceName + TRIGGER);
            Console.WriteLine(serviceName + "ispuase:" + yes);
        }

        public static void ModifySchedule(string serviceName, string cronExpresion)
        {
            var triggerKey = serviceName.GetTriggerKey();
            var triggerName = serviceName + TRIGGER;
            var trigger = stdQuartzModule.Scheduler.GetTrigger(triggerKey);
            if (trigger != null)
            {
                var cronBuilder = trigger as ICronTrigger;
                JobCronExpressionConfig.SetCronExpression(triggerName, cronExpresion);
                cronBuilder.CronExpressionString = cronExpresion;
                //cronBuilder.GetTriggerBuilder().WithCronSchedule(cronExpresion, (zw) => { zw.WithMisfireHandlingInstructionDoNothing(); }).Build();
                var newTrigger = cronBuilder.GetTriggerBuilder().Build();
                stdQuartzModule.Scheduler.PauseTrigger(triggerKey);
                stdQuartzModule.Scheduler.RescheduleJob(triggerKey, newTrigger);
                stdQuartzModule.Scheduler.ResumeTrigger(triggerKey);
            }
        }

        #endregion
    }
}
