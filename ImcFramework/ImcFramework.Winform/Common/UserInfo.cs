using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Winform.Common
{
    /// <summary>
    /// 用户
    /// </summary>
    public static class UserHelper
    {
        public static UserInfo CurrentUser { get; set; }
    }

    public class UserInfo
    {
        public string DisplayName { get; set; }
    }
}
