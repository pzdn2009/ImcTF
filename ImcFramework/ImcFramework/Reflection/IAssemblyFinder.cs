using System.Collections.Generic;
using System.Reflection;

namespace ImcFramework.Reflection
{
    public interface IAssemblyFinder
    {
        List<Assembly> GetAllAssemblies();

        List<Assembly> GetAllBinDirectoryAssemblies();
    }
}
