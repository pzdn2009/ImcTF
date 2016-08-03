using ImcFramework.Core.MutilUserProgress;
using ImcFramework.Core.Quartz;
using ImcFramework.Core.Quartz.Commands;
using ImcFramework.Core.WcfService;
using ImcFramework.Data;
using ImcFramework.Ioc;
using ImcFramework.LogPool;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.Enums;
using ImcFramework.WcfInterface.LogInfos;
using ImcFramework.WcfInterface.ProgressInfos;
using ImcFramework.WcfInterface.TransferMessage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession,
        AutomaticSessionShutdown = false)]
    public class ClientConnectorReal : IClientConnector
    {
        private IMessageCallback callback;
        private ICommandInvoker commandInvoker;
        private ILoggerPool loggerPool;
        private IServiceTypeReader serviceTypeReader;
        private ILogin login;
        private IRequestParameterProvider requestParameterProvider;
        private IProgressInfoManager progressInfoManager;

        public ClientConnectorReal(ICommandInvoker commandInvoker, IServiceTypeReader serviceTypeReader,
            IIocManager iocManager, ILogin login, IRequestParameterProvider requestParameterProvider,
            IProgressInfoManager progressInfoManager)
        {
            OperationContext.Current.Channel.Closing += Channel_Closing;
            OperationContext.Current.Channel.Faulted += Channel_Faulted;

            this.commandInvoker = commandInvoker;
            this.serviceTypeReader = serviceTypeReader;
            this.login = login;
            this.requestParameterProvider = requestParameterProvider;
            this.progressInfoManager = progressInfoManager;
            this.loggerPool = iocManager.Resolve<ILoggerPool>(WcfServiceModule.MODUEL_NAME);
        }

        #region Events

        private void Channel_Faulted(object sender, EventArgs e)
        {
        }

        private void Channel_Closing(object sender, EventArgs e)
        {
        }

        #endregion

        /// <summary>
        /// Register a servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        public void Register(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();

            loggerPool.Log(serviceType.ServiceType, new LogContentEntity("Register！"));
            callback.Notify(MessageEntity.NormalInfo(serviceType, " Register"));

            Observers.Add(serviceType, callback);
        }

        /// <summary>
        /// UnRegister a servicetype.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        public void UnRegister(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();

            loggerPool.Log(serviceType.ServiceType, new LogContentEntity("Unregister！"));
            callback.Notify(MessageEntity.NormalInfo(serviceType, " Unregister"));

            Observers.Remove(serviceType, callback);
        }

        /// <summary>
        /// Request switchs.
        /// </summary>
        /// <param name="switchs">Commands.</param>
        public void RequestSwitchs(IEnumerable<FunctionSwitch> switchs)
        {
            foreach (var sw in switchs)
            {
                RequestSwitch(sw);
            }
        }

        /// <summary>
        /// Request switch.
        /// </summary>
        /// <param name="singleSwitch">Command.</param>
        public void RequestSwitch(FunctionSwitch singleSwitch)
        {
            try
            {
                loggerPool.Log(singleSwitch.ServiceType.ServiceType, new LogContentEntity() { Message = singleSwitch.Command.ToString() });

                commandInvoker.Invoke<ExecuteResult>(singleSwitch);

                callback.Notify(MessageEntity.NormalInfo(singleSwitch.ServiceType, singleSwitch.Command.ToString()));
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("002"), "RequestSwitch");

                loggerPool.Log(singleSwitch.ServiceType.ServiceType, new LogContentEntity(fex.Message + fex.StackTrace) { Level = "Error" });

                throw fex;
            }
        }

        /// <summary>
        /// Get servicetype info
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the serviceinfo of the job.</returns>
        public ServiceInfo GetServiceInfo(EServiceType serviceType)
        {
            try
            {
                var obj = commandInvoker.Invoke<GetServiceInfoOutput>(new FunctionSwitch() { Command = ECommand.GetServiceInfo, ServiceType = serviceType });
                if (obj != null)
                {
                    return obj.ServiceInfo;
                }

                return null;
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("003"), "GetServiceInfo");
                loggerPool.Log(serviceType.ServiceType, new LogContentEntity(fex.Message + fex.StackTrace));
                throw fex;
            }
        }

        /// <summary>
        /// Get loginfo dates.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the loginfo list.</returns>
        public IEnumerable<LogInfo> GetLogInfoDates(EServiceType serviceType)
        {
            var list = new List<LogInfo>();

            string logPath = Path.Combine(Defaults.RootDirectory, serviceType.ToString());
            if (!Directory.Exists(logPath))
            {
                return list;
            }

            foreach (var item in new DirectoryInfo(logPath).GetFiles("*.txt"))
            {
                var fileNameSpliteItems = item.Name.Split(new string[] { Defaults.BusinessLogFileSplitChar, ".txt" }, StringSplitOptions.RemoveEmptyEntries);
                if (fileNameSpliteItems != null && fileNameSpliteItems.Length == 3)
                {
                    var sellerAccountLogLevel = new UserLogLevel()
                    {
                        User = fileNameSpliteItems[0],
                        LogLevel = fileNameSpliteItems[1]
                    };

                    var date = list.FirstOrDefault(zw => zw.DateString == fileNameSpliteItems[2]);
                    if (date == null)  //日期
                    {
                        list.Add(new LogInfo()
                        {
                            DateString = fileNameSpliteItems[2],
                            UserLogLevels = new List<UserLogLevel>()
                        {
                            sellerAccountLogLevel
                        }
                        });
                    }
                    else
                    {
                        date.UserLogLevels.Add(sellerAccountLogLevel);
                    }
                }
            }
            return list.OrderByDescending(zw => zw.DateString).ToList();
        }

        /// <summary>
        /// Get log infos.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="date">The date.</param>
        /// <param name="user">The user</param>
        /// <param name="logLevel">The loglevel</param>
        public void GetLogInfos(EServiceType serviceType, string date, string user, string logLevel)
        {
            var name = user + Defaults.BusinessLogFileSplitChar + logLevel + Defaults.BusinessLogFileSplitChar + date;
            var directoryInfo = new DirectoryInfo(Defaults.RootDirectory + serviceType.ToString());
            var file = directoryInfo.GetFiles().FirstOrDefault(zw => zw.Name.StartsWith(name));
            //for files.
            if (file != null)
            {
                File.Copy(file.FullName, file.FullName + "copy");
                var lines = File.ReadAllLines(file.FullName + "copy", Encoding.Default);
                File.Delete(file.FullName + "copy");

                var thisCallback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
                Task t = new Task(() =>
                {
                    Thread.Sleep(1000);
                    StringBuilder sb = new StringBuilder("");
                    foreach (var line in lines)
                    {
                        if (Regex.Match(line, "^\\d{4}-\\d{2}-\\d{2}").Success)
                        {
                            if (sb.ToString() != string.Empty)
                            {
                                thisCallback.NotifyLogInfo(sb.ToString());
                                sb.Clear();
                            }
                        }
                        sb.Append(line);
                        sb.AppendLine();
                    }

                });
                t.Start();
            }
        }

        /// <summary>
        /// Get progress total info.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the <see cref="ProgressSummary"/> object.</returns>
        public ProgressSummary GetProgressTotal(EServiceType serviceType)
        {
            return progressInfoManager.GetTotal(serviceType);
        }

        /// <summary>
        /// Get progress sellerAccount total.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <param name="user"></param>
        /// <returns></returns>
        public ProgressItem GetProgressUserTotal(EServiceType serviceType, string user)
        {
            return progressInfoManager.GetUserProgressInfo(serviceType, user);
        }

        /// <summary>
        /// Get service list.
        /// </summary>
        /// <returns>return the servicetype list.</returns>
        public List<EServiceType> GetServiceList()
        {
            try
            {
                return serviceTypeReader.GetEServiceTypes().ToList();
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("001"), "GetServiceList");
                loggerPool.Log("", new LogContentEntity(fex.Message + fex.StackTrace));
                throw fex;
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            return login.Login(userName, password);
        }

        /// <summary>
        /// Get requeset paramter.
        /// </summary>
        /// <param name="serviceType">The given servicetype.</param>
        /// <returns>return the parameter list.</returns>
        public RequestParameterList GetRequestParameter(EServiceType serviceType)
        {
            return requestParameterProvider.GetRequestParameter(serviceType);
        }
    }
}
