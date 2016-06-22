using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Reflection
{
    public class TypeFinder : ITypeFinder
    {
        public IAssemblyFinder AssemblyFinder { get; set; }

        public TypeFinder()
        {
            AssemblyFinder = CurrentDomainAssemblyFinder.Instance;
        }

        public Type[] Find(Func<Type, bool> predicate)
        {
            return GetAllTypes().Where(predicate).ToArray();
        }

        public Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        private List<Type> GetAllTypes()
        {
            var allTypes = new List<Type>();

            foreach (var assembly in AssemblyFinder.GetAllAssemblies().Distinct())
            {
                try
                {
                    Type[] typesInThisAssembly;

                    try
                    {
                        typesInThisAssembly = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        typesInThisAssembly = ex.Types;
                    }

                    if (typesInThisAssembly == null)
                    {
                        continue;
                    }

                    allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
                catch (Exception ex)
                {
                    //Logger.Warn(ex.ToString(), ex);
                }
            }

            return allTypes;
        }
    }
}
