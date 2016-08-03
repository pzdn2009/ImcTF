using ImcFramework.Reflection;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Command invoker for the clients.
    /// </summary>
    public class CommandInvoker: ICommandInvoker
    {
        private IScheduleProvider scheduleProvider;
        public CommandInvoker(IScheduleProvider scheduleProvider)
        {
            this.scheduleProvider = scheduleProvider;
        }

        private static Dictionary<ECommand, dynamic> dict = new Dictionary<ECommand, dynamic>();

        /// <summary>
        /// Execute the invoke.
        /// </summary>
        /// <typeparam name="TOutput">The execute result.</typeparam>
        /// <param name="functionSwitch">The command.</param>
        /// <returns>return the execute result.</returns>
        public TOutput Invoke<TOutput>(FunctionSwitch functionSwitch)
        {
            if (!dict.ContainsKey(functionSwitch.Command))
            {
                var type = GetCommandClass(functionSwitch.Command);
                dynamic instance = Activator.CreateInstance(type, new object[] { scheduleProvider.Schedule });
                dict[functionSwitch.Command] = instance;
            }

            dynamic ret = dict[functionSwitch.Command].Execute(functionSwitch);

            return (TOutput)ret;
        }

        /// <summary>
        /// Get the command class.
        /// </summary>
        /// <param name="command">Command enum.<see cref="ECommand"/>.</param>
        /// <returns>return the type.</returns>
        public static Type GetCommandClass(ECommand command)
        {
            ITypeFinder typeFinder = new TypeFinder();

            var types = typeFinder.FindAll().Where(zw => zw.Name == command.ToString() + "Command");
            return types.FirstOrDefault();
        }
    }
}
