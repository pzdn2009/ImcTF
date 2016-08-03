using System.Runtime.Serialization;

namespace ImcFramework.WcfInterface.ProgressInfos
{
    /// <summary>
    /// Progress's total type.
    /// </summary>
    [DataContract]
    public enum TotalType
    {
        /// <summary>
        /// Compute sum by user count.
        /// </summary>
        [EnumMember]
        User,

        /// <summary>
        /// Compute sum by record count.
        /// </summary>
        [EnumMember]
        RecordCount
    }
}
