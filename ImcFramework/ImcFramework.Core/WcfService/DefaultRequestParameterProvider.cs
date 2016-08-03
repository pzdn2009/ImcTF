using ImcFramework.WcfInterface;

namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// The default request parameter provider.
    /// </summary>
    public class DefaultRequestParameterProvider : IRequestParameterProvider
    {
        public RequestParameterList GetRequestParameter(EServiceType serviceType)
        {
            return new RequestParameterList();
        }
    }
}
