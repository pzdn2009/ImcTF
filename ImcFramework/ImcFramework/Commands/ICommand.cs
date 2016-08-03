namespace ImcFramework.Commands
{
    /// <summary>
    /// Indicates a command pattern , it provides Execute function.
    /// </summary>
    /// <typeparam name="TInput">the input parameter for the command execution</typeparam>
    public interface ICommand<in TInput>
    {
        /// <summary>
        /// Execute a command.
        /// </summary>
        /// <param name="input">the input parameter for the command execution</param>
        /// <returns>return the execute result for the current command.</returns>
        object Execute(TInput input);
    }
}
