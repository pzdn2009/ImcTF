namespace ImcFramework.Core.WcfService
{
    /// <summary>
    /// The default login.
    /// </summary>
    public class DefaultLogin : ILogin
    {
        public bool Login(string userName, string password)
        {
            return true;
        }
    }
}
