using ImcFramework.Core.MqModuleExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 全局的配置
    /// </summary>
    public class ModuleConfiguration
    {
        public static IEnumerable<IModuleExtension> ReadConfig(ServiceContext serviceContext)
        {
            var moduleExtensionList = new List<IModuleExtension>();

            if (Defaults.IsIsolatedJob)
            {
                moduleExtensionList.Add(new MqModule() { ServiceContext = serviceContext });
            }

            return moduleExtensionList;
        }
    }
}
