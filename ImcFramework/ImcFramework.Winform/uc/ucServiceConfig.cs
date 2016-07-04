using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface;
using ImcFramework.WcfInterface.TransferMessage;
using ImcFramework.Winform.Common;
using System;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    [CallbackBehavior(UseSynchronizationContext = false, AutomaticSessionShutdown = false)]
    public partial class ucServiceConfig : UserControl, IView, IMessageCallback
    {
        private EServiceType serviceType;
        public EServiceType ServiceType
        {
            get { return serviceType; }
        }

        private SynchronizationContext uiSyncContext = null;

        WsDualClient m_WsDualClient;
        IClientConnector client = null;

        private ProgressSynchronous progressSynchronous;

        public ucServiceConfig(EServiceType serviceType)
        {
            InitializeComponent();
            this.serviceType = serviceType;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);
        }

        private void ucServiceConfig_Load(object sender, EventArgs e)
        {
            if (InitialSuccess)   //最小化的时候会重复加载，避免
            {
                return;
            }

            InitialSuccess = false;

            uiSyncContext = SynchronizationContext.Current;

            Connect();

            var listLogDays = client.GetLogInfoDates(serviceType);
            this.ucLog1.AddLogDateNode(listLogDays.ToArray());

            this.flowLayoutPanel1.Controls.Clear();
            this.taskProgressBar.Maximum = 0;

            this.rtxRealTimeLog.ContextMenuStrip = rtxContextMenuStrip;

            this.ucLog1.GetLogDetailClick += ucLog1_GetLogDetailClick;

            progressSynchronous = ProgressSynchronous.Create();
        }

        private void ucLog1_GetLogDetailClick(object sender, RequestLogArgs e)
        {
            client.GetLogInfos(serviceType, e.Date, e.SellerAccount, e.LogLevel);
        }

        private void EnsureClient()
        {
            if (m_WsDualClient == null || m_WsDualClient.Factory.State != CommunicationState.Opened)
            {
                m_WsDualClient = new WsDualClient(MyClients.CurrentBinding, this);
                client = m_WsDualClient.ClientConnector;
            }
        }

        private void InnerChannel_Faulted(object sender, EventArgs e)
        {
            //Connect();
        }

        private void Connect()
        {
            try
            {
                Retry.Execute(() =>
                {
                    EnsureClient();

                    MyClients.Add(serviceType, m_WsDualClient);
                    client.Register(serviceType);

                    Initialize();

                }, TimeSpan.FromSeconds(2), 1);
                InitialSuccess = true;
            }
            catch (AggregateException ex)
            {
                var msg = "连接不上服务器:" + ex.InnerExceptions.First().Message;
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void Initialize()
        {
            this.ServiceName = EnumHelper.GetDescription(serviceType);

            Task task = new Task(() =>
            {
                while (true)
                {
                    while (chkAutoRefresh.Checked)
                    {
                        EnsureClient();

                        var serviceInfo = client.GetServiceInfo(serviceType);
                        this.ServiceStatus = serviceInfo.EServiceStatus;
                        this.ScheduleInfo = serviceInfo.ScheduleInfo;

                        labPrevFiredTime.SetValue(uiSyncContext, lab => lab.Text, serviceInfo.PrevFiredTime.HasValue ? serviceInfo.PrevFiredTime.Value.ToString() : string.Empty);
                        labNextFiredTime.SetValue(uiSyncContext, lab => lab.Text, serviceInfo.NextFiredTime.HasValue ? serviceInfo.NextFiredTime.Value.ToString() : string.Empty);
                        btnPause.SetValue(uiSyncContext, btn => btn.Enabled, serviceInfo.EServiceStatus != EServiceStatus.Pause);
                        btnContinue.SetValue(uiSyncContext, btn => btn.Enabled, !btnPause.Enabled);

                        int num = (int)numericUpDown1.Value;
                        while (num-- != 0)
                        {
                            labRefreshTip.SetValue(uiSyncContext, lab => lab.Text, string.Format("update status in {0} seconds...... ", num));
                            //labRefreshTip.Text = string.Format("update status in {0} seconds...... ", num);
                            System.Threading.Thread.Sleep(1000);
                        }

                        Thread.Sleep(1000);
                    }

                    Thread.Sleep(1000);

                    labRefreshTip.Text = "";
                }
            });
            task.Start();
        }

        public bool InitialSuccess
        {
            get;
            private set;
        }

        #region 基本信息

        public string ServiceName
        {
            get
            {
                return grpServiceName.Text;
            }
            set
            {
                grpServiceName.Text = value;
            }
        }

        public EServiceStatus ServiceStatus
        {
            get
            {
                return (EServiceStatus)Enum.Parse(typeof(EServiceStatus), EnumHelper.GetName(typeof(EServiceStatus), labServiceStatus.Text));
            }
            set
            {
                uiSyncContext.Post((obj) =>
                {
                    labServiceStatus.Text = obj.ToString();
                }, value.GetDescription());
            }
        }

        public string ScheduleInfo
        {
            get
            {
                return txtScheduleInfo.Text;
            }
            set
            {
                uiSyncContext.Post((obj) =>
                {
                    this.txtScheduleInfo.Text = value;
                }, null);

            }
        }

        #endregion

        #region Control Buttons

        //暂停
        private void btnPause_Click(object sender, EventArgs e)
        {
            EnsureClient();
            client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.Pause, ScheduleFormat = "" });
            Pause(true);
        }

        //继续
        private void btnContinue_Click(object sender, EventArgs e)
        {
            EnsureClient();
            client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.Continue, ScheduleFormat = "" });
            Pause(false);
        }

        private void Pause(bool enable)
        {
            btnPause.Enabled = !enable;
            btnContinue.Enabled = enable;
        }

        //更新
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要更新计划吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EnsureClient();
                client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.ModifySchedule, ScheduleFormat = ScheduleInfo });
            }
        }

        //取消
        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EnsureClient();
                client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.Cancel, ScheduleFormat = "" });
            }
        }

        //编辑Cron表达式
        private void btnEditorCron_Click(object sender, EventArgs e)
        {
            CronEditor cronEditor = new CronEditor();
            cronEditor.ShowDialog();
            txtScheduleInfo.Text = Clipboard.GetText();
        }

        //立即运行
        private void btnRunRightNow_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureClient();
                client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.RunImmediately, ScheduleFormat = "" });
            }
            catch (FaultException fex)
            {
                MessageBox.Show(fex.Code.Name + ":" + fex.Action + ":" + fex.Reason.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnInterrupt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要中断吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EnsureClient();
                    client.RequestSwitch(new FunctionSwitch() { ServiceType = serviceType, Command = ECommand.Interrupt });
                }
                catch (FaultException fex)
                {
                    MessageBox.Show(fex.Code.Name + ":" + fex.Action + ":" + fex.Reason.ToString());
                }
            }
        }

        //自动刷新状态
        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            labRefreshTip.Text = "";
        }

        //清除文本
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rtx = this.rtxContextMenuStrip.SourceControl as RichTextBox;
            rtx.Text = "";
        }

        #endregion

        #region Notify

        public void Notify(MessageEntity msgEntity)
        {
            SendOrPostCallback callback =
             delegate (object state)
             {
                 if (this.rtxRealTimeLog != null && !this.rtxRealTimeLog.IsDisposed)
                 {
                     var msg = string.Format(">> {0}:{1}:{2}\n", msgEntity.Timestamp, msgEntity.MsgContent, msgEntity.ServiceType);

                     int len1 = rtxRealTimeLog.TextLength;
                     rtxRealTimeLog.AppendText(msg);
                     int len2 = msg.Length;
                     rtxRealTimeLog.Select(len1, len2);
                     //设置颜色
                     switch (msgEntity.MessageType)
                     {
                         case EMessageType.Info:
                             rtxRealTimeLog.SelectionColor = Color.Black;
                             break;
                         case EMessageType.Warn:
                             rtxRealTimeLog.SelectionColor = Color.Yellow;
                             break;
                         case EMessageType.Error:
                             rtxRealTimeLog.SelectionColor = Color.Red;
                             break;
                         default:
                             break;
                     }

                     rtxRealTimeLog.ScrollToCaret();
                 }
             };

            uiSyncContext.Post(callback, null);
        }

        public void NotifyLogInfo(string message)
        {
            SendOrPostCallback callback =
             delegate (object state)
             {
                 message = ">> " + message + "\n";
                 this.ucLog1.AppendRtxLog(message);
             };

            uiSyncContext.Post(callback, null);
        }

        #endregion

        #region 进度通知

        private object lockObject = new object();

        public void NotifyTaskProgressTotal(ProgressSummary summary)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                setTotalCount(summary);
            };

            uiSyncContext.Post(callback, null);
        }

        private void setTotalCount(ProgressSummary summary)
        {
            this.taskProgressBar.Value = 0;
            this.taskProgressBar.Maximum = summary.Total;

            this.taskProgressRate.Text = "...";

            this.flowLayoutPanel1.Controls.Clear();

            progressSynchronous.SetTotal(summary.Value, summary.Total, summary.TotalType);
        }

        public void NotifyTaskProgressItemTotal(string sellerAccount, int total)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                lock (lockObject)
                {
                    if (!progressSynchronous.IsTotalCountSet)
                    {
                        var totalInfo = client.GetProgressTotal(serviceType);
                        setTotalCount(totalInfo);
                    }

                    setSellerAccountCount(sellerAccount, new ProgressItem() { Value = 0, Total = total });
                }
            };

            uiSyncContext.Post(callback, null);
        }

        public void NotifyTaskProgressItemValueAndTotal(string sellerAccount, ProgressItem sellerAccountProgress)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                lock (lockObject)
                {
                    if (!progressSynchronous.IsTotalCountSet)
                    {
                        var totalInfo = client.GetProgressTotal(serviceType);
                        setTotalCount(totalInfo);
                    }

                    setSellerAccountCount(sellerAccount, sellerAccountProgress);

                    if (progressSynchronous.TotalType == TotalType.User)  //按照账号
                    {
                        if (progressSynchronous.IsSellerAccountFinished(sellerAccount))
                        {
                            progressSynchronous.TotalValue++;
                        }
                    }
                    else
                    {
                        progressSynchronous.TotalValue++;
                    }

                    ShowSumTaskBar();
                }
            };

            uiSyncContext.Post(callback, null);
        }

        private void setSellerAccountCount(string sellerAccount, ProgressItem progress)
        {
            progressSynchronous.SetSellerAccountValueAndTotal(sellerAccount, progress.Value, progress.Total, () =>
            {
                var uc = new ucSellerProgressBar(sellerAccount, 0, progress.Total);
                uc.Name = sellerAccount;
                uc.Value = progress.Value;

                this.flowLayoutPanel1.Controls.Add(uc);

                return uc;
            });
        }

        public void NotifyTaskProgressForceFinish(string sellerAccount)
        {
            SendOrPostCallback callback = delegate (object state)
            {
                lock (lockObject)
                {
                    progressSynchronous.SetSellerAccountFinish(sellerAccount);

                    if (progressSynchronous.TotalType == TotalType.User)  //按照账号
                    {
                        progressSynchronous.TotalValue++;
                    }
                    else
                    {
                        progressSynchronous.TotalValue++;
                    }

                    ShowSumTaskBar();
                }
            };
            uiSyncContext.Post(callback, null);
        }

        private void ShowSumTaskBar()
        {
            taskProgressRate.Text = ((double)progressSynchronous.TotalValue / (double)progressSynchronous.TotalCount).ToString("P");
            if (progressSynchronous.TotalValue == progressSynchronous.TotalCount)
            {
                this.taskProgressBar.Value = 0;
                this.flowLayoutPanel1.Controls.Clear();
            }
        }

        public void NotifyTaskProgressFinishAll()
        {
            SendOrPostCallback callback = delegate (object state)
            {
                MessageBox.Show("运行完成！");
                this.taskProgressBar.Value = 0;
                this.flowLayoutPanel1.Controls.Clear();
            };
            uiSyncContext.Post(callback, null);
        }

        #endregion
    }
}
