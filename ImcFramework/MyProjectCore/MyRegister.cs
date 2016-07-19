using System.Collections.Generic;
using ImcFramework.Core;
using ImcFramework.Ioc;
using ImcFramework.Core.WcfService;
using ImcFramework.WcfInterface;

namespace ImcFramework.Register
{
    public class MyRegister : IGlobalRegister
    {
        public void Register(IIocManager iocManager)
        {
            iocManager.Register<IRequestParameterProvider, MyParameter>();
        }
    }

    public class MyParameter : IRequestParameterProvider
    {
        public RequestParameterList GetRequestParameter(EServiceType serviceType)
        {
            if (serviceType.ServiceType == "ImcTFSample")
            {
                return new RequestParameterList()
                {
                    RequestParameters = new List<RequestParameter>()
                {
                    new RequestParameter() { Name = "Site", CommaValue = "MY,ID,SG" },
                    new RequestParameter() { Name = "SellerAccount", CommaValue = "4,5,6" }
                }
                };
            }

            return new RequestParameterList()
            {
                RequestParameters = new List<RequestParameter>()
                {
                    new RequestParameter() { Name = "SellerAccount", CommaValue = "1,2,3" }
                }
            };
        }
    }
}
