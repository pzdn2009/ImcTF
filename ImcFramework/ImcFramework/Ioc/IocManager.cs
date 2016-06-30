using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Ioc
{
    public class IocManager : IIocManager
    {
        private static readonly IocManager instance;
        public static IocManager Instance { get { return instance; } }

        static IocManager()
        {
            instance = new IocManager();
        }

        public IocManager()
        {
            
        }

        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle) 
            where TType : class
            where TImpl : class, TType
        {
            throw new NotImplementedException();
        }

        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public TType Resolve<TType>()
        {
            throw new NotImplementedException();
        }
    }
}
