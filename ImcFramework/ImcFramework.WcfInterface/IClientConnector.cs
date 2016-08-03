using ImcFramework.WcfInterface.LogInfos;
using ImcFramework.WcfInterface.ProgressInfos;
using System.Collections.Generic;
using System.ServiceModel;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// Wcf interface for the clients.
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IMessageCallback))]
    public interface IClientConnector
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns></returns>
        [OperationContract]
        bool Login(string userName, string password);

        /// <summary>
        /// Reigster to the framework.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        [OperationContract]
        void Register(EServiceType serviceType);

        /// <summary>
        /// UnResiter from the framework.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        [OperationContract]
        void UnRegister(EServiceType serviceType);

        /// <summary>
        /// Get all servicetype list.
        /// </summary>
        /// <returns>return the servicetypes.</returns>
        [OperationContract]
        List<EServiceType> GetServiceList();

        /// <summary>
        /// Request switch
        /// </summary>
        /// <param name="singleSwitch">singleSwitch</param>
        [OperationContract]
        void RequestSwitch(FunctionSwitch singleSwitch);

        /// <summary>
        /// Request switchs
        /// </summary>
        /// <param name="switchs">switchs</param>
        [OperationContract]
        void RequestSwitchs(IEnumerable<FunctionSwitch> switchs);

        /// <summary>
        /// Get service info
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the serviceinfo instance.</returns>
        [OperationContract]
        ServiceInfo GetServiceInfo(EServiceType serviceType);

        /// <summary>
        /// Get loginfo
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<LogInfo> GetLogInfoDates(EServiceType serviceType);

        [OperationContract]
        void GetLogInfos(EServiceType serviceType, string date, string user, string logLevel);

        /// <summary>
        /// Get ProgressTotal 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        [OperationContract]
        ProgressSummary GetProgressTotal(EServiceType serviceType);

        /// <summary>
        /// GetProgress user total
        /// </summary>
        /// <param name="serviceType">The servicetype.</param>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [OperationContract]
        ProgressItem GetProgressUserTotal(EServiceType serviceType, string user);
        
        /// <summary>
        /// Get the Job Parameters about the serviceType
        /// </summary>
        /// <param name="serviceType">The </param>
        /// <returns></returns>
        [OperationContract]
        RequestParameterList GetRequestParameter(EServiceType serviceType);
    }
}
