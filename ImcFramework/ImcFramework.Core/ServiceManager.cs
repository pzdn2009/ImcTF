using ImcFramework.Infrastructure;
using ImcFramework.Core;
using ImcFramework.WcfInterface;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using ImcFramework.Core.IsolatedAd;

namespace ImcFramework.Core
{
    internal static class KeyCreator
    {
        private static string TRIGGER = "Trigger";
        private static string MAIN_BUSINESS = "MainBusiness";

        public static JobKey GetJobKey(this string serviceName)
        {
            return new JobKey(serviceName, MAIN_BUSINESS);
        }

        public static TriggerKey GetTriggerKey(this string serviceName)
        {
            return new TriggerKey(serviceName + TRIGGER, serviceName + TRIGGER);
        }
    }

    /// <summary>
    /// 服务启动
    /// </summary>
    public static class ServiceManager
    {
        private static ISchedulerFactory schedulerFactory;
        private static IScheduler scheduler;
        private static string TRIGGER = "Trigger";

        private static ServiceHost hostStub;
        private static IEnumerable<IModuleExtension> modules;

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
        /// <param name="isolatedJob">是否使用隔离的Job,如果是，则每个Job均运行在一个唯一的AppDomain中</param>
        public static void StartAll()
        {
            StartWcfHost();

            var isolatedJob = Defaults.IsIsolatedJob;

            if (schedulerFactory == null)
            {
                schedulerFactory = new StdSchedulerFactory();
                if (scheduler == null || !scheduler.IsStarted)
                {
                    scheduler = schedulerFactory.GetScheduler();
                    if (isolatedJob)
                    {
                        scheduler.JobFactory = new IsolatedJobFactory();
                    }

                    scheduler.Start();
                }

            }

            MQWapper.StartRead();

            return;
            //
            //ServiceContext serviceContext = new ServiceContext();
            //serviceContext.Scheduler = scheduler;
            //serviceContext.WcfHost = hostStub;
            //serviceContext.ProgressInfoManager = ProgressInfoManager.Instance;

            //modules = ModuleConfiguration.ReadConfig(serviceContext);
            //foreach (var item in modules)
            //{
            //    item.Start();
            //}
        }

        public static void Continue(string serviceName)
        {
            if (scheduler != null && scheduler.IsStarted)
            {
                scheduler.ResumeTrigger(serviceName.GetTriggerKey());
            }
        }

        public static void Cancle(string serviceName)
        {
            if (GetStatus(serviceName) != EServiceStatus.Running)
                return;

            var job = scheduler.GetCurrentlyExecutingJobs().FirstOrDefault(zw => zw.JobDetail.Key.Name == serviceName);
            if (job == null)
            {
                return;
            }

            if (!Defaults.IsIsolatedJob)
            {
                var cancel = job.JobInstance as ITaskCancle;
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

            var job = scheduler.GetJobDetail(serviceName.GetJobKey());
            if (job != null)
            {
                scheduler.TriggerJob(job.Key);
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
            var state = scheduler.GetTriggerState(serviceName.GetTriggerKey());
            if (state == TriggerState.Paused)
                return EServiceStatus.Pause;  //暂停

            foreach (var item in scheduler.GetCurrentlyExecutingJobs())
            {
                if (item.JobDetail.Key.Name == serviceName)
                    return EServiceStatus.Running;  //运行
            }

            return EServiceStatus.Normal;
        }

        public static string GetSchedule(string serviceName)
        {
            var trigger = scheduler.GetTrigger(serviceName.GetTriggerKey());
            if (trigger != null)
            {
                var cronBuilder = trigger as ICronTrigger;
                return JobCronExpressionConfig.GetCronExpression(serviceName + TRIGGER);
            }
            return string.Empty;
        }

        public static void Pause(string serviceName)
        {
            scheduler.PauseTrigger(serviceName.GetTriggerKey());
            bool yes = scheduler.IsJobGroupPaused(serviceName + TRIGGER);
            Console.WriteLine(serviceName + "ispuase:" + yes);
        }

        public static void ModifySchedule(string serviceName, string cronExpresion)
        {
            var triggerKey = serviceName.GetTriggerKey();
            var triggerName = serviceName + TRIGGER;
            var trigger = scheduler.GetTrigger(triggerKey);
            if (trigger != null)
            {
                var cronBuilder = trigger as ICronTrigger;
                JobCronExpressionConfig.SetCronExpression(triggerName, cronExpresion);
                cronBuilder.CronExpressionString = cronExpresion;
                //cronBuilder.GetTriggerBuilder().WithCronSchedule(cronExpresion, (zw) => { zw.WithMisfireHandlingInstructionDoNothing(); }).Build();
                var newTrigger = cronBuilder.GetTriggerBuilder().Build();
                scheduler.PauseTrigger(triggerKey);
                scheduler.RescheduleJob(triggerKey, newTrigger);
                scheduler.ResumeTrigger(triggerKey);
            }
        }

        public static void StopAll()
        {
            if (scheduler != null)
            {
                scheduler.Shutdown(true);
            }

            StopWcfHost();

            MQWapper.WaitForMQClear();

            return;

            //if (modules != null)
            //{
            //    foreach (var item in modules)
            //    {
            //        item.Stop();
            //    }
            //}
        }
    }
}
