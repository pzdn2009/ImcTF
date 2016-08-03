using System;
using System.Runtime.Serialization;

namespace ImcFramework
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
