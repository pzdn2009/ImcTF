using ImcFramework.Commands;
using ImcFramework.Data;
using ImcFramework.Reflection;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.Quartz
{
    public class CommandInvoker
    {
        private static Dictionary<ECommand, dynamic> dict = new Dictionary<ECommand, dynamic>();

        public static TOutput Invoke<TOutput>(FunctionSwitch functionSwitch)
        {
            if (!dict.ContainsKey(functionSwitch.Command))
            {
                var type = GetCommandClass(functionSwitch.Command);
                dynamic instance = Activator.CreateInstance(dict[functionSwitch.Command], new object[] { ServiceManager.ServiceContext.Scheduler });
                dict[functionSwitch.Command] = instance;
            }

            dynamic ret = dict[functionSwitch.Command].Execute(functionSwitch);

            return (TOutput)ret;
        }

        public static Type GetCommandClass(ECommand command)
        {
            ITypeFinder typeFinder = new TypeFinder();

            var types = typeFinder.FindAll().Where(zw => zw.Name == command.ToString() + "Command");
            return types.FirstOrDefault();
        }
    }
}
