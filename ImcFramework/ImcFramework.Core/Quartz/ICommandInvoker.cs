using ImcFramework.WcfInterface;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// The command invoker interface.
    /// </summary>
    public interface ICommandInvoker
    {
        /// <summary>
        /// Execute the invoke.
        /// </summary>
        /// <typeparam name="TOutput">The execute result.</typeparam>
        /// <param name="functionSwitch">The command.</param>
        /// <returns>return the execute result.</returns>
        TOutput Invoke<TOutput>(FunctionSwitch functionSwitch);
    }
}
