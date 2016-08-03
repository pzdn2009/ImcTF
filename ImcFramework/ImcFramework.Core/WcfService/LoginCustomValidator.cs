using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace ImcFramework.Core.WcfService
{
    public class LoginCustomValidator : UserNamePasswordValidator
    {
        public LoginCustomValidator()
        {
        }

        public override void Validate(string userName, string password)
        {
            if (userName != "pzdn2009" && password != "pzdn2009")
            {
                throw new SecurityTokenException("wcf validate failure.");
            }
        }
    }
}
