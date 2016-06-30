using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Ioc
{
    public interface IIocManager
    {
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton, bool coverExistingDefaults = true)
            where TType : class
            where TImpl : class, TType;

        void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        TType Resolve<TType>();
    }
}
