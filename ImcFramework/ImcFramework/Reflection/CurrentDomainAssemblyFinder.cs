using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ImcFramework.Reflection
{
    public class CurrentDomainAssemblyFinder : IAssemblyFinder
    {
        /// <summary>
        /// Gets Singleton instance of <see cref="CurrentDomainAssemblyFinder"/>.
        /// </summary>
        public static CurrentDomainAssemblyFinder Instance { get { return SingletonInstance; } }
        private static readonly CurrentDomainAssemblyFinder SingletonInstance = new CurrentDomainAssemblyFinder();

        public List<Assembly> GetAllAssemblies()
        {
            foreach (string dll in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
            {
                try
                {
                    var loadedAssembly = Assembly.LoadFile(dll);
                }
                catch { }
            }

            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }

        public List<Assembly> GetAllBinDirectoryAssemblies()
        {
            string binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");

            if (Directory.Exists(binPath))
            {
                foreach (string dll in Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories))
                {
                    try
                    {
                        var loadedAssembly = Assembly.LoadFile(dll);
                    }
                    catch { }
                }
            }

            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
