using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
