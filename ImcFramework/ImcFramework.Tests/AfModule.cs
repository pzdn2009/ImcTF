using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Tests
{
    public class AfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserA>().As<IUser>();
            builder.RegisterType<UserB>().As<IUser>().PreserveExistingDefaults();
        }
    }
}
