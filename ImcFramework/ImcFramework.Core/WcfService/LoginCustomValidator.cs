using ImcFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;

namespace ImcFramework.Core
{
    public class LoginCustomValidator : UserNamePasswordValidator
    {
        public LoginCustomValidator()
        {
            LogHelper.Error("LoginCustomValidator!");
        }

        public override void Validate(string userName, string password)
        {
            LogHelper.Error("username:" + userName);
            LogHelper.Error("password:" + password);

            if (userName != "pzdn2009" && password != "pzdn2009")
            {
                throw new SecurityTokenException("用户名和密码不正确");
            }
        }
    }
}
