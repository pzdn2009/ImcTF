using ImcFramework.WcfInterface;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// Request parameter provider.
    /// </summary>
    public interface IRequestParameterProvider
    {
        /// <summary>
        /// Get the request paramter of the given servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return request parameter list.</returns>
        RequestParameterList GetRequestParameter(EServiceType serviceType);
    }
}
