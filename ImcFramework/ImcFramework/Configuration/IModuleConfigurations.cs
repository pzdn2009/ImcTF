using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Configuration
{
    public interface IModuleConfigurations
    {
        IImcStartupConfiguration Configuration { get; }
    }
}
