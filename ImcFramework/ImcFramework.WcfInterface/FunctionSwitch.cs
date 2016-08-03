using ImcFramework.WcfInterface.Enums;
using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// Function switch for control servicetype.
    /// </summary>
    [DataContract]
    public class FunctionSwitch
    {
        /// <summary>
        /// The servicetype.
        /// </summary>
        [DataMember]
        public EServiceType ServiceType { get; set; }

        /// <summary>
        /// The cron-expression
        /// </summary>
        [DataMember]
        public string ScheduleFormat { get; set; }

        /// <summary>
        /// The command.
        /// </summary>
        [DataMember]
        public ECommand Command { get; set; }
        
        /// <summary>
        /// The request parameter list.
        /// </summary>
        [DataMember]
        public RequestParameterList RequestParameterList { get; set; }
    }
}
