
using ImcFramework.Data;
using System;
namespace ImcFramework.Commands
{
	public abstract class AbstractCommand<TInput, TOutput> : ICommand<TInput> where TOutput : ExecuteResult, new()
	{
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

		protected virtual void HandleError(Exception exception, TInput input, TOutput output)
		{
		}

		protected abstract void ExecuteCore(TInput input, TOutput output);
	}
}
