using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// Isolate Domain Loader
    /// </summary>
    public class IsolateDomainLoader : IDisposable
    {
        private string m_TypeFullName;
        private AppDomain m_AppDomain;

        /// <summary>
        /// 名称限定
        /// </summary>
        /// <param name="appDomainName">the app domain name of for the isolated job.</param>
        /// <param name="adPath">the shadow dll's path</param>
        /// <param name="parentPath">the path of the process</param>
        /// <param name="configFileName">the config file for the isolated job.</param>
        public IsolateDomainLoader(string appDomainName, string adPath, string parentPath, string configFileName)
        {
            m_TypeFullName = appDomainName;

            var setup = new AppDomainSetup();
            setup.ApplicationName = "IsolateDomainLoader";
            setup.ApplicationBase = parentPath;
            setup.PrivateBinPath = parentPath;

            setup.DynamicBase = adPath;
            setup.CachePath = adPath;
            setup.ShadowCopyFiles = "true";
            setup.ShadowCopyDirectories = adPath;

            setup.ConfigurationFile = Path.Combine(parentPath, Process.GetCurrentProcess().ProcessName + ".exe.config");

            m_AppDomain = AppDomain.CreateDomain(appDomainName, null, setup);
        }

        /// <summary>
        /// Get a <see cref="RemoteObject"/> for remote invoke.
        /// </summary>
        /// <param name="assemblyFile">the assembly file for the job,which in AdDlls directory.</param>
        /// <returns>return a <see cref="RemoteObject"/>.</returns>
        public RemoteObject GetObject(string assemblyFile)
        {
            var obj = (RemoteObject)m_AppDomain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(RemoteObject).FullName);
            obj.Init(assemblyFile, m_TypeFullName);

            ILease lease = (ILease)obj.GetLifetimeService();
            lease.Register(obj);

            return obj;
        }

        /// <summary>
        /// Unload the appdomain.
        /// </summary>
        public void Unload()
        {
            if (m_AppDomain == null)
            {
                return;
            }

            try
            {
                AppDomain.Unload(m_AppDomain);
                m_AppDomain = null;
            }
            catch
            {
            }
        }

        ~IsolateDomainLoader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Unload();
#if DEBUG
                Console.WriteLine("Domain Unloaded");
#endif
            }
        }
    }
}
