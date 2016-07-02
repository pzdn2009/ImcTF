using Autofac;
using Autofac.Builder;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ImcFramework.Ioc
{
    public class IocManager : IIocManager
    {
        private ContainerBuilder builder;
        private IContainer container;

        private static readonly IocManager instance;
        public static IocManager Instance { get { return instance; } }

        public IContainer Container
        {
            get
            {
                return container;
            }
        }

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

        public TType Resolve<TType>(string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                return container.Resolve<TType>();
            }

            return container.ResolveKeyed<TType>(key);
        }

        public void RegisterAssemblyAsInterfaces(Assembly assembly)
        {
            var builder2 = new ContainerBuilder();

            builder2.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().Except<IocManager>();

            builder2.Update(container);
        }

        public void RegisterAssembly<TType>(Assembly assembly)
        {
            var builder2 = new ContainerBuilder();

            builder2.RegisterAssemblyTypes(assembly).As<TType>();

            builder2.Update(container);
        }

        public bool IsRegister<TType>()
        {
            return container.IsRegistered<TType>();
        }

        public void Register<TType>(object instance, string key = null, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            var builder2 = new ContainerBuilder();

            if (!string.IsNullOrEmpty(key))
            {
                ApplyLifeStyle(builder2.RegisterInstance(instance).Named<TType>(key).As<TType>(), lifeStyle);
            }
            else
            {
                ApplyLifeStyle(builder2.RegisterInstance(instance).As<TType>(), lifeStyle);
            }

            builder2.Update(container);
        }
    }
}
