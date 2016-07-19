using ImcFramework.Core.SignalRExt.Client;
using ImcFramework.Ioc;

namespace ImcFramework.Core.SignalRExt
{
    public class ImcSignalR : SignalRClientBase
    {
        public ImcSignalR(IIocManager iocManager) :
            base(iocManager)
        {

        }

        public override AuthenticationType AuthenticationType
        {
            get { return AuthenticationType.None; }
        }

        public override void RegisterServerMethod()
        {

        }
    }
}
