using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ImcFramework.WinServiceLib
{
    [RunInstaller(true)]
    public partial class ImcSvcInstallerBase : System.Configuration.Install.Installer
    {
        public ImcSvcInstallerBase()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;

            InitialServiceConfigInfo();

            // 
            // ImcSvcInstallerBase
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});

        }

        private void InitialServiceConfigInfo()
        {
            this.serviceInstaller1.ServiceName = GetSerivceName();
            this.serviceInstaller1.Description = GetDescription();
            this.serviceInstaller1.StartType = GetServiceStartMode();
        }

        /// <summary>
        /// 子类重写服务名称
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSerivceName()
        {
            return "ImcFramework.WinService";
        }

        /// <summary>
        /// 子类重写 服务描述
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDescription()
        {
            return string.Empty;
        }

        /// <summary>
        /// 子类重写启动模式
        /// </summary>
        /// <returns></returns>
        protected virtual ServiceStartMode GetServiceStartMode()
        {
            return ServiceStartMode.Automatic;
        }
    }
}
