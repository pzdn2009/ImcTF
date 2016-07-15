using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Core.WcfService
{
    public interface IServiceTypeReader
    {
        IEnumerable<EServiceType> GetEServiceTypes();
    }
}
