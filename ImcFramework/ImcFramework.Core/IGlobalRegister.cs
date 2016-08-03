using ImcFramework.Ioc;

namespace ImcFramework.Core
{
    /// <summary>
    /// The extension entry for the replacement of the framework.
    /// </summary>
    public interface IGlobalRegister
    {
        /// <summary>
        /// Register the iocmanager.
        /// </summary>
        /// <param name="iocManager">The ioc manager.</param>
        void Register(IIocManager iocManager);
    }
}
