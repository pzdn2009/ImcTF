using ImcFramework.Data;
using System;
namespace ImcFramework.Commands
{
    /// <summary>
    /// Abstract command execution. Which the output result is <see cref="ExecuteResult"/> .
    /// This class acts as a TemplateMethod.
    /// </summary>
    /// <typeparam name="TInput">the input parameter for the command execution</typeparam>
    /// <typeparam name="TOutput">the output result for the command execution</typeparam>
	public abstract class AbstractCommand<TInput, TOutput> : ICommand<TInput> where TOutput : ExecuteResult, new()
    {
        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="input"> input parameter for the command execution</param>
        /// <returns>the output result for the command execution</returns>
        public object Execute(TInput input)
        {
            TOutput tOutput = Activator.CreateInstance<TOutput>();
            tOutput.Success = true;

            try
            {
                this.ExecuteCore(input, tOutput);
            }
            catch (Exception exception)
            {
                tOutput.Success = false;
                tOutput.Message = exception.Message;
                this.HandleError(exception, input, tOutput);
            }
            return tOutput;
        }

        /// <summary>
        /// Handle the exception when <see cref="Execute(TInput)"/> throw one. It can be override in sub-class.
        /// </summary>
        /// <param name="exception">the throwed exception</param>
        /// <param name="input">the input parameter</param>
        /// <param name="output">the output parameter</param>
        protected virtual void HandleError(Exception exception, TInput input, TOutput output)
        {
        }

        /// <summary>
        /// The core execute method which needs to be override in sub-class.
        /// </summary>
        /// <param name="input">the input parameter</param>
        /// <param name="output">the output parameter</param>
        protected abstract void ExecuteCore(TInput input, TOutput output);
    }
}
