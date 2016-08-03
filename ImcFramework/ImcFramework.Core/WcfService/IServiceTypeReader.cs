using ImcFramework.WcfInterface;
using System.Collections.Generic;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// Read the servicetype.
    /// </summary>
    public interface IServiceTypeReader
    {
        /// <summary>
        /// Get all servicetypes.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EServiceType> GetEServiceTypes();
    }
}
