namespace ImcFramework.Core.WcfService
{
    public class DefaultLogin : ILogin
    {
        public bool Login(string userName, string password)
        {
            return true;
        }
    }
}
