using System.Runtime.Serialization;
namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// The servicetype for a job which run in a isolated appdoamin.
    /// At first, EServiceType is designed as a enum , but now, it's a class.
    /// </summary>
    [DataContract]
    public class EServiceType
    {
        public EServiceType() : this(null, null)
        {

        }
        public EServiceType(string serviceType) : this(serviceType, null)
        {

        }
        public EServiceType(string serviceType, string serviceName, bool showInClientMenu = true)
        {
            ServiceType = serviceType;
            ServiceName = serviceName;

            ShowInClientMenu = showInClientMenu;
        }

        public EServiceType(string serviceType, string serviceName, string groupName, bool showInClientMenu = true)
        {
            ServiceType = serviceType;
            ServiceName = serviceName;
            GroupName = groupName;

            ShowInClientMenu = showInClientMenu;
        }

        [DataMember]
        public string ServiceType { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string ServiceName { get; set; }

        /// <summary>
        /// show in client menu
        /// </summary>
        [IgnoreDataMember]
        public bool ShowInClientMenu { get; set; }

        public override string ToString()
        {
            return ServiceType;
        }

        public string GetFullString()
        {
            return ServiceType + "_" + GroupName + "_";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((EServiceType)obj);
        }

        private bool Equals(EServiceType serviceType)
        {
            return (ServiceType == serviceType.ServiceType) && (GroupName == serviceType.GroupName);
        }

        public override int GetHashCode()
        {
            return GetFullString().GetHashCode();
        }
    }
}
