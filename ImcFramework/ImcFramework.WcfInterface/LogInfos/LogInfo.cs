using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.LogInfos
{
    /// <summary>
    /// Log info
    /// </summary>
    [DataContract]
    public class LogInfo
    {
        /// <summary>
        /// Data string
        /// </summary>
        [DataMember]
        public string DateString { get; set; }
        
        /// <summary>
        /// user info
        /// </summary>
        [DataMember]
        public List<UserLogLevel> UserLogLevels { get; set; }
    }
}
