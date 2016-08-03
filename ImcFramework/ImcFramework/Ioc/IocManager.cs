using Autofac;
using Autofac.Builder;
using System;
using System.Linq;
using System.Reflection;

namespace ImcFramework.Ioc
{
    /// <summary>
    /// The implementation of the IIocManager
    /// </summary>
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
            //register as singleton
            builder.RegisterInstance(this).As<IIocManager>().ExternallyOwned();
            container = builder.Build();
        }

        public void RegisterAssemblyModules(params Assembly[] assemblies)
        {
            var builder2 = new ContainerBuilder();

            builder2.RegisterAssemblyModules(assemblies);

            builder2.Update(container);
        }

        #region register Assemblies

        public void RegisterAssemblyAsInterfaces(params Assembly[] assemblies)
        {
            var builder2 = new ContainerBuilder();

            builder2.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().Except<IocManager>();

            builder2.Update(container);
        }

        public void RegisterAssemblyOfType<TType>(params Assembly[] assemblies)
        {
            var builder2 = new ContainerBuilder();

            builder2.RegisterAssemblyTypes(assemblies).As<TType>();

            builder2.Update(container);
        }

        #endregion

        #region normal register

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

        public void Register<TType>(object instance = null, string key = null, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            var builder2 = new ContainerBuilder();

            if (instance == null)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    ApplyLifeStyle(builder2.RegisterType<TType>().Named<TType>(key), lifeStyle);
                }
                else
                {
                    ApplyLifeStyle(builder2.RegisterType<TType>(), lifeStyle);
                }
                
            }
            else
            {
                if (!string.IsNullOrEmpty(key))
                {
                    ApplyLifeStyle(builder2.RegisterInstance(instance).Named<TType>(key).As<TType>(), lifeStyle);
                }
                else
                {
                    ApplyLifeStyle(builder2.RegisterInstance(instance).As<TType>(), lifeStyle);
                }
            }
            

            builder2.Update(container);
        }

        public void RegisterGeneric(Type type, Type target, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            var builder2 = new ContainerBuilder();

            ApplyLifeStyle(builder2.RegisterGeneric(type).As(target), lifeStyle);

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

        #endregion

        #region container check & resolve

        public bool IsRegister<TType>()
        {
            return container.IsRegistered<TType>();
        }

        public TType Resolve<TType>(string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                return container.Resolve<TType>();
            }

            return container.ResolveKeyed<TType>(key);
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        #endregion
    }
}
