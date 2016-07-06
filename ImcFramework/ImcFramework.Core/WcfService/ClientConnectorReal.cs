using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImcFramework.WcfInterface.TransferMessage;
using ImcFramework.Core.Quartz.Commands;
using ImcFramework.Data;
using ImcFramework.Core.Quartz;
using ImcFramework.Ioc;
using ImcFramework.Core.MutilUserProgress;
using ImcFramework.LogPool;
using ImcFramework.Core.WcfService;

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

        public ClientConnectorReal(ICommandInvoker commandInvoker, IServiceTypeReader serviceTypeReader, IIocManager iocManager,ILogin login)
        {
            OperationContext.Current.Channel.Closing += Channel_Closing;
            OperationContext.Current.Channel.Faulted += Channel_Faulted;

            this.commandInvoker = commandInvoker;
            this.serviceTypeReader = serviceTypeReader;
            this.login = login;
            this.loggerPool = iocManager.Resolve<ILoggerPool>(WcfService.WcfServiceModule.MODUEL_NAME);
        }

        #region Events

        private void Channel_Faulted(object sender, EventArgs e)
        {
        }

        private void Channel_Closing(object sender, EventArgs e)
        {
        }

        #endregion

        public void Register(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();

            loggerPool.Log(serviceType.ServiceType, new LogContentEntity("Register！"));
            callback.Notify(MessageEntity.NormalInfo(serviceType, " Register"));

            Observers.Add(serviceType, callback);
        }

        public void UnRegister(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();

            loggerPool.Log(serviceType.ServiceType, new LogContentEntity("Unregister！"));
            callback.Notify(MessageEntity.NormalInfo(serviceType, " Unregister"));

            Observers.Remove(serviceType, callback);
        }

        public void RequestSwitchs(IEnumerable<FunctionSwitch> switchs)
        {
            foreach (var sw in switchs)
            {
                RequestSwitch(sw);
            }
        }

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
                    var sellerAccountLogLevel = new SellerAccountLogLevel()
                    {
                        SellerAccount = fileNameSpliteItems[0],
                        LogLevel = fileNameSpliteItems[1]
                    };

                    var date = list.FirstOrDefault(zw => zw.DateString == fileNameSpliteItems[2]);
                    if (date == null)  //日期
                    {
                        list.Add(new LogInfo()
                        {
                            DateString = fileNameSpliteItems[2],
                            SellerAccountLogLevels = new List<SellerAccountLogLevel>()
                        {
                            sellerAccountLogLevel
                        }
                        });
                    }
                    else
                    {
                        date.SellerAccountLogLevels.Add(sellerAccountLogLevel);
                    }
                }
            }
            return list.OrderByDescending(zw => zw.DateString).ToList();
        }

        public void GetLogInfos(EServiceType serviceType, string date, string sellerAccount, string logLevel)
        {
            var name = sellerAccount + Defaults.BusinessLogFileSplitChar + logLevel + Defaults.BusinessLogFileSplitChar + date;
            var directoryInfo = new DirectoryInfo(Defaults.RootDirectory + serviceType.ToString());
            var file = directoryInfo.GetFiles().FirstOrDefault(zw => zw.Name.StartsWith(name));

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

        public ProgressSummary GetProgressTotal(EServiceType serviceType)
        {
            return ProgressInfoManager.Instance.GetTotal(serviceType);
        }

        public ProgressItem GetProgressSellerAccountTotal(EServiceType serviceType, string sellerAccount)
        {
            return ProgressInfoManager.Instance.GetSellerAccountProgressInfo(serviceType, sellerAccount);
        }

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

        public bool Login(string userName, string password)
        {
            return login.Login(userName, password);
        }
    }
}
