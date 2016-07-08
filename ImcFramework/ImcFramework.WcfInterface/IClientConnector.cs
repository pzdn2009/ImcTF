using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ImcFramework.WcfInterface
{
    /// <summary>
    /// 供客户端使用的服务契约
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IMessageCallback))]
    public interface IClientConnector
    {
        [OperationContract]
        bool Login(string userName, string password);

        /// <summary>
        /// 注册（登陆）
        /// </summary>
        /// <param name="serviceType">（业务）服务类型</param>
        [OperationContract]
        void Register(EServiceType serviceType);

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="serviceType">（业务）服务类型</param>
        [OperationContract]
        void UnRegister(EServiceType serviceType);

        /// <summary>
        /// 获取所有的服务列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EServiceType> GetServiceList();

        /// <summary>
        /// 请求指令（开关）
        /// </summary>
        /// <param name="singleSwitch">单个指令</param>
        [OperationContract]
        void RequestSwitch(FunctionSwitch singleSwitch);

        /// <summary>
        /// 请求指令
        /// </summary>
        /// <param name="switchs">指令集合</param>
        [OperationContract]
        void RequestSwitchs(IEnumerable<FunctionSwitch> switchs);

        /// <summary>
        /// 查询服务状态
        /// </summary>
        /// <param name="serviceType">（业务）服务类型</param>
        /// <returns>服务状态信息</returns>
        [OperationContract]
        ServiceInfo GetServiceInfo(EServiceType serviceType);

        /// <summary>
        /// 查询所有的日期和所有账号
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<LogInfo> GetLogInfoDates(EServiceType serviceType);

        /// <summary>
        /// 按照日期和服务类型查询
        /// </summary>
        /// <param name="date">保持yyyy-MM-dd的格式</param>
        /// <param name="serviceType"></param>
        /// <param name="sellerAccount"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        [OperationContract]
        void GetLogInfos(EServiceType serviceType, string date, string sellerAccount, string logLevel);

        /// <summary>
        /// 获取进度总数
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        [OperationContract]
        ProgressSummary GetProgressTotal(EServiceType serviceType);

        /// <summary>
        /// 获取单个账号的进度与总量
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="sellerAccount"></param>
        [OperationContract]
        ProgressItem GetProgressSellerAccountTotal(EServiceType serviceType, string sellerAccount);
        
        /// <summary>
        /// Get the Job Parameters about the serviceType
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        [OperationContract]
        RequestParameterList GetRequestParameter(EServiceType serviceType);
    }
}
