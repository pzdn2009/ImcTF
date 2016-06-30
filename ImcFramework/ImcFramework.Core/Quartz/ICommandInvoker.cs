using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Quartz
{
    public interface ICommandInvoker
    {
        TOutput Invoke<TOutput>(FunctionSwitch functionSwitch);
    }
}
