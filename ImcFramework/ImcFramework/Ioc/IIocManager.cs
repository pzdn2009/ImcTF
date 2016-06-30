using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Ioc
{
    public interface IIocManager
    {
        IContainer Container { get; }

        void RegisterAssembly(Assembly assembly);

        void RegisterAssembly<TType>(Assembly assembly);

        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton, bool coverExistingDefaults = true)
            where TType : class
            where TImpl : class, TType;

        void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        void Register<TType>(TType instance, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class;

        TType Resolve<TType>();

        bool IsRegister<TType>();
    }
}
