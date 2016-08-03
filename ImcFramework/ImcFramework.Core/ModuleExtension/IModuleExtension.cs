namespace ImcFramework.Core
{
    /// <summary>
    /// Module extension interface .
    /// </summary>
    public interface IModuleExtension
    {
        /// <summary>
        /// Service context for module extension.
        /// </summary>
        ServiceContext ServiceContext { get; set; }
    }
}
