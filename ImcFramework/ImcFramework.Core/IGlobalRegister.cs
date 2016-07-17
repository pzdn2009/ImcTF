using ImcFramework.Ioc;

namespace ImcFramework.Core
{
    public interface IGlobalRegister
    {
        void Register(IIocManager iocManager);
    }
}
