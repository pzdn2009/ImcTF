using ImcFramework.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// 隔离的Job
    /// </summary>
    public class IsolatedJob : IInterruptableJob, IDisposable
    {
        private readonly Type m_JobType;

        private IsolateDomainLoader m_IDL = null;
        private RemoteObject m_RemoteObj = null;

        public IsolatedJob(Type jobType)
        {
            if (jobType == null)
            {
                throw new ArgumentNullException("jobType");
            }
            this.m_JobType = jobType;

            var asmName = this.m_JobType.Assembly.Location.Substring(this.m_JobType.Assembly.Location.LastIndexOf("\\") + 1);
            var adDllPath = Path.Combine(Path.GetDirectoryName(this.m_JobType.Assembly.Location), "AdDlls");
            if(!Directory.Exists(adDllPath))
            {
                Directory.CreateDirectory(adDllPath);
            }
            var adDllFullName = Path.Combine(adDllPath, asmName);
            if (!File.Exists(adDllFullName))
            {
                File.Copy(this.m_JobType.Assembly.Location, adDllFullName);
            }

            this.m_IDL = new IsolateDomainLoader(m_JobType.FullName, adDllPath, Path.GetDirectoryName(this.m_JobType.Assembly.Location), "");
            this.m_RemoteObj = this.m_IDL.GetObject(adDllFullName);
        }

        /// <summary>
        /// 执行的方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            this.m_RemoteObj.ExecuteMethod("Execute", context);
        }


        public void Interrupt()
        {
            this.m_RemoteObj.ExecuteMethod("Interrupt");
        }

        public void Cancel()
        {
            this.m_RemoteObj.ExecuteMethod("Cancel");
        }

        ~IsolatedJob()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.m_RemoteObj != null)
                this.m_RemoteObj.Dispose();


            if (disposing)
            {
                if (this.m_IDL != null)
                    this.m_IDL.Dispose();
            }
        }
    }
}
