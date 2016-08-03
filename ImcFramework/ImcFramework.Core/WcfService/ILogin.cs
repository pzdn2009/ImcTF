namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// The login interface for the future.
    /// </summary>
    public interface ILogin
    {
        bool Login(string userName, string password);
    }
}
