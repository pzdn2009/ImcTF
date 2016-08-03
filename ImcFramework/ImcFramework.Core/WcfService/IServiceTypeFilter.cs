using ImcFramework.WcfInterface;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// ServiceType filter.
    /// </summary>
    public interface IServiceTypeFilter
    {
        /// <summary>
        /// Filter the servicetype
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return true if the given servicetype is allowed, otherwise, return false.</returns>
        bool Filter(EServiceType serviceType);
    }

    public class DefaultServiceTypeFilter : IServiceTypeFilter
    {
        public bool Filter(EServiceType serviceType)
        {
            return true;
        }
    }
}
