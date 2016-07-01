using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    public class ImcFrameworkException : ApplicationException
    {
        public ImcFrameworkException()
        {

        }
        public ImcFrameworkException(string message)
            : base(message)
        {

        }
        public ImcFrameworkException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
        public ImcFrameworkException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
