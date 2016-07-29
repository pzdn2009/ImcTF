using ImcFramework.Ioc;
using ImcFramework.LogPool;
using System.Collections.Generic;

namespace ImcFramework
{
    /// <summary>
    /// Define the module for the ImcFramework 
    /// </summary>
    public interface IServiceModule
    {
        /// <summary>
        /// Name of the module
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Indicates whether to enable
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        /// Initial the module
        /// </summary>
        void Initialize();

        /// <summary>
        /// Start the module
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the module
        /// </summary>
        void Stop();

        /// <summary>
        /// LoggerPool for the module , <see cref="ILoggerPool"/>
        /// </summary>
        ILoggerPool LoggerPool { get; set; }

        /// <summary>
        /// Ioc container for the module
        /// </summary>
        IIocManager IocManager { get; set; }

        /// <summary>
        /// The dependency modules of the current module
        /// </summary>
        IEnumerable<IServiceModule> DependencyModules { get; set; }
    }
}
