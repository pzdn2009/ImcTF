using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Commands
{
    public interface ICommand<in TInput>
    {
        object Execute(TInput input);
    }
}
