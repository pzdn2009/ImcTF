using Autofac;
using System;
using System.Reflection;

namespace ImcFramework.Ioc
{
    /// <summary>
    /// The Invention of control manager interface.
    /// </summary>
    public interface IIocManager
    {
        /// <summary>
        /// The autofac ioc container, <see cref="Autofac.IContainer"/> .
        /// </summary>
        IContainer Container { get; }

        /// <summary>
        ///  Register modules from the assemblies.
        /// </summary>
        /// <param name="assemblies"></param>
        void RegisterAssemblyModules(params Assembly[] assemblies);

        /// <summary>
        /// The encapsulation of the RegisterAssemblyTypes.AsImplementedInterfaces
        /// ,register all interfaces and implementions in the assemblies.
        /// </summary>
        /// <param name="assemblies">the assmeblies for registering interfaces</param>
        void RegisterAssemblyAsInterfaces(params Assembly[] assemblies);

        /// <summary>
        /// Register the given TType from the assemblies.
        /// </summary>
        /// <typeparam name="TType">The type to be registered.</typeparam>
        /// <param name="assemblies">the assmeblies for registering TType</param>
        void RegisterAssemblyOfType<TType>(params Assembly[] assemblies);

        /// <summary>
        /// Register the interface TType and the implemention TImpl
        /// </summary>
        /// <typeparam name="TType">the interface</typeparam>
        /// <typeparam name="TImpl">the implemention</typeparam>
        /// <param name="lifeStyle">life style which indicates the instance 's lifetime ,<see cref="DependencyLifeStyle"/> .</param>
        /// <param name="coverExistingDefaults"></param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton, bool coverExistingDefaults = true)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// Register the instance or TType.
        /// </summary>
        /// <typeparam name="TType">the target type to be resolved.</typeparam>
        /// <param name="instance">the instance to be registerd.</param>
        /// <param name="key">the keyed name of the instance or the TType.</param>
        /// <param name="lifeStyle">life style which indicates the instance 's lifetime ,<see cref="DependencyLifeStyle"/> .</param>
        void Register<TType>(object instance = null, string key = null, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class;

        /// <summary>
        /// Register as open generic.
        /// </summary>
        /// <param name="tImpl">the Implemented class type. eg: <code>typeof(OrderRepostiory<>)</code> </param>
        /// <param name="tType">the open interface type. eg: <code>typeof(IRepostiory<>)</code> </param>
        /// <param name="lifeStyle">life style which indicates the instance 's lifetime ,<see cref="DependencyLifeStyle"/> .</param>
        void RegisterGeneric(Type tImpl, Type tType, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// Check if it registered the TType.
        /// </summary>
        /// <typeparam name="TType">the type to be checked.</typeparam>
        /// <returns>if the TType is registered ,return true , else return false.</returns>
        bool IsRegister<TType>();

        /// <summary>
        /// Resolve the given type , the keyed name is optional.
        /// </summary>
        /// <typeparam name="TType">the type to be resolved.</typeparam>
        /// <param name="key">the name of the given type ,which is based Keyed registration.</param>
        /// <returns>return the TType instance .</returns>
        TType Resolve<TType>(string key = null);

        /// <summary>
        /// Resolve the given type
        /// </summary>
        /// <param name="type">Object's type</param>
        /// <returns>return the object as obejct type.</returns>
        object Resolve(Type type);
    }
}
