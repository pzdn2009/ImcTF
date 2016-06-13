using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// 隔离域加载器
    /// </summary>
    public class IsolateDomainLoader : IDisposable
    {
        private string m_TypeFullName;
        private AppDomain m_AppDomain;

        /// <summary>
        /// 名称限定
        /// </summary>
        /// <param name="appDomainName">类型名称用作Ad名</param>
        /// <param name="adPath">路径</param>
        /// <param name="parentPath">应用程序exe路径</param>
        /// <param name="configFileName">配置文件名称</param>
        public IsolateDomainLoader(string appDomainName, string adPath, string parentPath, string configFileName)
        {
            this.m_TypeFullName = appDomainName;

            var setup = new AppDomainSetup();
            setup.ApplicationName = "IsolateDomainLoader";
            setup.ApplicationBase = parentPath;
            setup.PrivateBinPath = parentPath;

            setup.DynamicBase = adPath;
            setup.CachePath = adPath; //setup.ApplicationBase;
            setup.ShadowCopyFiles = "true";
            setup.ShadowCopyDirectories = adPath; //setup.ApplicationBase;

            setup.ConfigurationFile = Path.Combine(parentPath, System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe.config");

            this.m_AppDomain = AppDomain.CreateDomain(appDomainName, null, setup);
        }

        /// <summary>
        /// 获取远程对象
        /// </summary>
        /// <param name="assemblyFile">程序集文件</param>
        /// <param name="typeFullName"></param>
        /// <returns></returns>
        public RemoteObject GetObject(string assemblyFile)
        {
            String name = Assembly.GetExecutingAssembly().FullName;
            //如果用 CreateInstanceAndUnwrap 只能把 ApplicationBas 设为主程充的 BaseDirectory, 这样子域就不能有自己的 ApplicationBase 了.
            //var obj = (RemoteObject)this.Domain.CreateInstanceAndUnwrap(name, typeof(RemoteObject).FullName);

            var obj = (RemoteObject)this.m_AppDomain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(RemoteObject).FullName);
            obj.Init(assemblyFile, m_TypeFullName);

            ILease lease = (ILease)obj.GetLifetimeService();
            lease.Register(obj);

            return obj;
        }

        public void Unload()
        {
            if (m_AppDomain == null)
                return;

            try
            {
                AppDomain.Unload(this.m_AppDomain);
                this.m_AppDomain = null;
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
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Unload();
#if DEBUG
                Console.WriteLine("Domain Unloaded");
#endif
            }
        }
    }
}
