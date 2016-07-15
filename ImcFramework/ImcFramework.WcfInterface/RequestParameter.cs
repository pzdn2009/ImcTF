using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface
{
    [DataContract]
    public class RequestParameter
    {
        public RequestParameter()
        {

        }
        public RequestParameter(string name, string commaValue)
        {
            Name = name;
            CommaValue = commaValue;
        }

        /// <summary>
        /// Parameter Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Parameter Value，if has many, then with Comma split
        /// </summary>
        [DataMember]
        public string CommaValue { get; set; }
    }

    [DataContract]
    public class RequestParameterList 
    {
        [DataMember]
        public IEnumerable<RequestParameter> RequestParameters { get; set; }
    }
}
