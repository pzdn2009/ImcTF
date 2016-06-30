using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Ioc
{
    public class IocManager : IIocManager
    {
        private ContainerBuilder builder;
        private IContainer container;

        private static readonly IocManager instance;
        public static IocManager Instance { get { return instance; } }

        static IocManager()
        {
            instance = new IocManager();
        }

        private IocManager()
        {
            builder = new ContainerBuilder();

            builder.RegisterInstance(this).As<IIocManager>().ExternallyOwned();
            container = builder.Build();
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            var builder2 = new ContainerBuilder();

            switch (lifeStyle)
            {
                case DependencyLifeStyle.Singleton:
                    builder2.RegisterType<TImpl>().As<TType>().SingleInstance();
                    break;
                case DependencyLifeStyle.Transient:
                    builder2.RegisterType<TImpl>().As<TType>().InstancePerDependency();
                    break;
            }

            builder2.Update(container);
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            var builder2 = new ContainerBuilder();

            switch (lifeStyle)
            {
                case DependencyLifeStyle.Singleton:
                    builder2.RegisterType<TType>().As<TType>().SingleInstance();
                    break;
                case DependencyLifeStyle.Transient:
                    builder2.RegisterType<TType>().As<TType>().InstancePerDependency();
                    break;
            }

            builder2.Update(container);
        }

        public TType Resolve<TType>()
        {
            return container.Resolve<TType>();
        }
    }
}
