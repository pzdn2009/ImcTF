using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Ioc
{
    public interface IIocManager
    {
        void Register(Type baseType, Type subType);

        object Resolve(Type type);
    }
}
