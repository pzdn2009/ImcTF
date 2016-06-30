using Autofac;
using Autofac.Builder;
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

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton, bool coverExistingDefaults = true)
            where TType : class
            where TImpl : class, TType
        {
            var builder2 = new ContainerBuilder();

            if (!coverExistingDefaults)
            {
                ApplyLifeStyle(builder2.RegisterType<TImpl>().As<TType>().PreserveExistingDefaults(), lifeStyle);
            }
            else
            {
                ApplyLifeStyle(builder2.RegisterType<TImpl>().As<TType>(), lifeStyle);
            }

            builder2.Update(container);
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            var builder2 = new ContainerBuilder();

            ApplyLifeStyle(builder2.RegisterType<TType>().As<TType>(), lifeStyle);

            builder2.Update(container);
        }

        private IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> ApplyLifeStyle<TLimit, TActivatorData, TRegistrationStyle>(IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> chain, DependencyLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Singleton:
                    chain = chain.SingleInstance();
                    break;
                case DependencyLifeStyle.Transient:
                    chain = chain.InstancePerDependency();
                    break;
                default:
                    throw new NotSupportedException("not support the style" + lifeStyle.ToString());
            }

            return chain;
        }

        public TType Resolve<TType>()
        {
            return container.Resolve<TType>();
        }
    }
}
