using Quartz;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Job cron-expression config
    /// </summary>
    public class JobCronExpressionConfig
    {
        private static readonly string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\quartz_jobs.xml";
        private static readonly string ns = "{http://quartznet.sourceforge.net/JobSchedulingData}";

        private static object lockObject = new object();

        /// <summary>
        /// Get cron-config from quartz-job file.
        /// </summary>
        /// <param name="fileName">The quartz-job filename.</param>
        /// <returns>return the cron-config.</returns>
        public static string GetCronExpression(ITrigger trigger)
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("Can't find the quartz_jobs.xml file！");
                }

                XDocument doc = XDocument.Load(fileName);

                var cron = doc.Document.Descendants(ns + "cron")
                .FirstOrDefault(zw =>
                zw.Element(ns + "name").Value == trigger.Key.Name &&
                zw.Element(ns + "group").Value == trigger.Key.Group &&
                zw.Element(ns + "job-name").Value == trigger.JobKey.Name &&
                zw.Element(ns + "job-group").Value == trigger.JobKey.Group)
                .Element(ns + "cron-expression");

                return cron.Value;
            }
        }

        /// <summary>
        /// Set the cron-config to quartz-job file.
        /// </summary>
        /// <param name="trigger">Trigger info.</param>
        /// <param name="cronExpr">cron-expression.</param>
        /// <returns>return the setted value.</returns>
        public static string SetCronExpression(ITrigger trigger, string cronExpr)
        {
            lock (lockObject)
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("Can't find the quartz_jobs.xml file！");
                }

                XDocument doc = XDocument.Load(fileName);

                var query = doc.Document.Descendants(ns + "cron")
                .FirstOrDefault(zw =>
                zw.Element(ns + "name").Value == trigger.Key.Name &&
                zw.Element(ns + "group").Value == trigger.Key.Group &&
                zw.Element(ns + "job-name").Value == trigger.JobKey.Name &&
                zw.Element(ns + "job-group").Value == trigger.JobKey.Group)
                .Element(ns + "cron-expression");
                query.Value = cronExpr;
                doc.Save(fileName);

                return query.Value;
            }
        }
    }
}
