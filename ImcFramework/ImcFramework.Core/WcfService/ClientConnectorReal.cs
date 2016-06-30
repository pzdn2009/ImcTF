using ImcFramework.WcfInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ImcFramework.Infrastructure;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImcFramework.WcfInterface.TransferMessage;
using ImcFramework.Core.Quartz.Commands;
using ImcFramework.Data;
using ImcFramework.Core.Quartz;

namespace ImcFramework.Core
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession,
        AutomaticSessionShutdown = false)]
    public class ClientConnectorReal : IClientConnector
    {
        private IMessageCallback callback;
        private ICommandInvoker commandInvoker;

        public ClientConnectorReal(ICommandInvoker commandInvoker)
        {
            OperationContext.Current.Channel.Closing += Channel_Closing;
            OperationContext.Current.Channel.Faulted += Channel_Faulted;

            this.commandInvoker = commandInvoker;
        }

        void Channel_Faulted(object sender, EventArgs e)
        {
        }

        void Channel_Closing(object sender, EventArgs e)
        {
        }

        public void Register(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();

            LogHelper.Info(serviceType.ToString() + " register！");
            callback.Notify(MessageEntity.NormalInfo(serviceType, " register"));

            Observers.Add(serviceType, callback);
        }

        public void UnRegister(EServiceType serviceType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            LogHelper.Info(serviceType.ToString() + " unregister！");
            callback.Notify(MessageEntity.NormalInfo(serviceType, " unregister"));

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
                commandInvoker.Invoke<ExecuteResult>(singleSwitch);

                callback.Notify(MessageEntity.NormalInfo(singleSwitch.ServiceType, " " + singleSwitch.Command.ToString()));
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("002"), "RequestSwitch");
                LogHelper.Error(fex);
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
                    return new ServiceInfo() { Enable = obj.Enable, EServiceStatus = obj.EServiceStatus, ScheduleInfo = obj.ScheduleInfo };
                }

                return null;
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("003"), "GetServiceInfo");
                LogHelper.Error(fex);
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
                return EServiceTypeReader.GetEServiceTypes();
            }
            catch (Exception ex)
            {
                var fex = new FaultException(new FaultReason(ex.Message), new FaultCode("001"), "GetServiceList");
                LogHelper.Error(fex);
                throw fex;
            }
        }
    }
}
