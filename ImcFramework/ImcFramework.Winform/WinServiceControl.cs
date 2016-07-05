using ImcFramework.Infrastructure;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace ImcFramework.Winform
{
    class WinServiceControl
    {
        public static string MachineName = "127.0.0.1";

        public static bool Existed(string serviceName)
        {
            return ServiceController.GetServices(MachineName).Where(zw => zw.ServiceName == serviceName).Count() > 0;
        }

        /// <summary>  
        /// 安装Windows服务  
        /// </summary>  
        /// <param name="stateSaver">集合</param>  
        /// <param name="filePath">程序文件路径</param>  
        public static void InstallmyService(IDictionary stateSaver, string filePath)
        {
            var asmInstaller = new AssemblyInstaller();
            asmInstaller.UseNewContext = true;
            asmInstaller.Path = filePath;
            asmInstaller.Install(stateSaver);
            asmInstaller.Commit(stateSaver);
            asmInstaller.Dispose();
        }

        /// <summary>  
        /// 卸载Windows服务  
        /// </summary>  
        /// <param name="filepath">程序文件路径</param>  
        public static void UnInstallByFilePath(string filepath)
        {
            var asmInstaller = new AssemblyInstaller();
            asmInstaller.UseNewContext = true;
            asmInstaller.Path = filepath;
            asmInstaller.Uninstall(null);
            asmInstaller.Dispose();
        }

        public static void UnInstallByServiceName(string serviceName)
        {
            string key = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
            string path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();
            path = path.Replace("\"", string.Empty);
            UnInstallByFilePath(path);
        }

        /// <summary>  
        /// 启动服务  
        /// </summary>  
        /// <param name="serviceName">服务名</param>  
        /// <returns>存在返回 true,否则返回 false;</returns>  
        public static bool Run(string serviceName)
        {
            bool ret = false;
            TryCatchBlock.TrycatchAndLog(() =>
            {
                var sc = new ServiceController(serviceName, MachineName);
                if (sc.Status.Equals(ServiceControllerStatus.Stopped) || sc.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    sc.Start();
                    ret = true;
                }
            });
            return ret;

        }

        public static bool Stop(string serviceName)
        {
            bool ret = false;

            TryCatchBlock.TrycatchAndLog(() =>
            {
                var sc = new ServiceController(serviceName, MachineName);
                if (!sc.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    sc.Stop();
                    ret = true;
                }
            });

            return ret;
        }

        /// <summary>  
        /// 获取服务状态  
        /// </summary>  
        /// <param name="serviceName">服务名</param>  
        /// <returns>返回服务状态</returns>  
        public static ServiceControllerStatus GetServiceStatus(string serviceName)
        {
            ServiceControllerStatus status = ServiceControllerStatus.ContinuePending;

            TryCatchBlock.TrycatchAndLog(() =>
            {
                var sc = new ServiceController(serviceName, MachineName);
                status = sc.Status;
            });

            return status;
        }

        /// <summary>  
        /// 获取服务安装路径  
        /// </summary>  
        /// <param name="serviceName"></param>  
        /// <returns></returns>  
        public static string GetWindowsServiceInstallPath(string serviceName)
        {
            string path = "";

            TryCatchBlock.TrycatchAndLog(() =>
            {
                string key = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
                path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();

                path = path.Replace("\"", string.Empty);//替换掉双引号    

                FileInfo fi = new FileInfo(path);
                path = fi.Directory.ToString();
            });

            return path;
        }

        /// <summary>  
        /// 获取指定服务的版本号  
        /// </summary>  
        /// <param name="serviceName">服务名称</param>  
        /// <returns></returns>  
        public static string GetServiceVersion(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return string.Empty;
            }

            TryCatchBlock.TrycatchAndLog(() =>
            {
                string path = GetWindowsServiceInstallPath(serviceName) + "\\" + serviceName + ".exe";
                Assembly assembly = Assembly.LoadFile(path);
                AssemblyName assemblyName = assembly.GetName();
                Version version = assemblyName.Version;
                return version.ToString();
            });

            return string.Empty;
        }
    }
}
