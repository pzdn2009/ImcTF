using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace ImcFramework.WcfInterface
{
    [DataContract]
    public class EServiceType
    {
        public EServiceType()
        {

        }
        public EServiceType(string serviceType)
        {
            this.ServiceType = serviceType;
        }
        public EServiceType(string serviceType,string serviceName)
        {
            this.ServiceType = serviceType;
            this.ServiceName = serviceName;
        }
        [DataMember]
        public string ServiceType { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        public override string ToString()
        {
            return ServiceType;
        }
    }
}
