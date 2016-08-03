using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.LogInfos
{
    /// <summary>
    /// User LogLevel
    /// </summary>
    [DataContract]
    public class UserLogLevel
    {
        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string LogLevel { get; set; }
    }
}
