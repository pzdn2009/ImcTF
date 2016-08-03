using Quartz;
using System;
using System.IO;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// Isolated Job,which runs in a new appdomain.
    /// </summary>
    public class IsolatedJob : IInterruptableJob, IDisposable
    {
        private readonly Type m_JobType;

        private IsolateDomainLoader m_IDL = null;
        private RemoteObject m_RemoteObj = null;

        /// <summary>
        /// Input the job Type , and construct a isolated job.
        /// </summary>
        /// <param name="jobType">the job type.</param>
        public IsolatedJob(Type jobType)
        {
            if (jobType == null)
            {
                throw new ArgumentNullException("jobType");
            }
            m_JobType = jobType;

            // get the assembly name of the job type.
            var asmName = m_JobType.Assembly.Location.Substring(m_JobType.Assembly.Location.LastIndexOf("\\") + 1);
            // compute the fullpath of the AdDlls.
            var adDllPath = Path.Combine(Path.GetDirectoryName(m_JobType.Assembly.Location), "AdDlls");
            if (!Directory.Exists(adDllPath))
            {
                Directory.CreateDirectory(adDllPath);
            }
            var adDllFullName = Path.Combine(adDllPath, asmName);
            if (!File.Exists(adDllFullName))
            {
                File.Copy(m_JobType.Assembly.Location, adDllFullName);
            }

            m_IDL = new IsolateDomainLoader(m_JobType.FullName, adDllPath, Path.GetDirectoryName(m_JobType.Assembly.Location), "");
            m_RemoteObj = m_IDL.GetObject(adDllFullName);
        }

        /// <summary>
        /// Call the job's Execute(IJobExecutionContext)" method.
        /// </summary>
        /// <param name="context">the job context</param>
        public void Execute(IJobExecutionContext context)
        {
            m_RemoteObj.ExecuteMethod("Execute", context);
        }

        /// <summary>
        /// Call the job's Interrupt()" method.
        /// </summary>
        public void Interrupt()
        {
            m_RemoteObj.ExecuteMethod("Interrupt");
        }

        /// <summary>
        /// Call the job's Cancel method which inherits ICancel interface.
        /// </summary>
        public void Cancel()
        {
            m_RemoteObj.ExecuteMethod("Cancel");
        }

        /// <summary>
        /// Release the appdomain on the destructor.
        /// </summary>
        ~IsolatedJob()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release the appdomain.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the objects.
        /// </summary>
        /// <param name="disposing">if disposing is true,then release the remoteObject and loader.</param>
        protected virtual void Dispose(bool disposing)
        {
            m_RemoteObj?.Dispose();

            if (disposing)
            {
                m_IDL?.Dispose();
            }
        }
    }
}
