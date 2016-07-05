using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;
using ImcFramework.Winform.Forms;

namespace ImcFramework.Winform
{
    public partial class ucWinServiceMgr : UserControl
    {
        private SynchronizationContext m_SyncContext = null;
        public ucWinServiceMgr()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);
            m_SyncContext = SynchronizationContext.Current;
        }

        #region Thread Safe Control Visit

        public string ServiceName
        {
            get
            {
                var str = string.Empty;
                m_SyncContext.Send((obj) =>
                {
                    str = cmbServiceList.SelectedValue.ToString();
                }, null);

                return str;
            }
        }

        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            GetLastestStatus();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            InstallOrUnInstallService(ServiceName, true);
            GetLastestStatus();
        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要卸载服务吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                InstallOrUnInstallService(ServiceName, false);
                GetLastestStatus();
            }
        }

        private void InstallOrUnInstallService(string serviceName, bool install)
        {
            if (install)
            {
                var ofd = new OpenFileDialog();
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                string exeFileName = ofd.FileName;
                WinServiceControl.InstallmyService(null, exeFileName);
                if (WinServiceControl.Existed(serviceName))
                {
                    labMsg.Text = "服务【" + serviceName + "】安装成功！";
                    labStatus.Text = GetStaus();
                }
                else
                {
                    labMsg.Text = "服务【" + serviceName + "】安装失败，请检查日志！";
                }
            }
            else
            {
                WinServiceControl.UnInstallByServiceName(ServiceName);
                if (!WinServiceControl.Existed(serviceName))
                {
                    labMsg.Text = "服务【" + serviceName + "】卸载成功！";
                }
                else
                {
                    labMsg.Text = "服务【" + serviceName + "】卸载失败，请检查日志！";
                }
            }
        }

        private string GetStaus()
        {
            btnStart.SetValue(m_SyncContext, btn => btn.Enabled, false);
            btnStop.SetValue(m_SyncContext, btn => btn.Enabled, false);

            string staStr = "";
            var status = WinServiceControl.GetServiceStatus(ServiceName);
            switch (status)
            {
                case ServiceControllerStatus.ContinuePending:
                    staStr = "服务即将继续！";
                    break;
                case ServiceControllerStatus.PausePending:
                    staStr = "服务即将暂停！";
                    break;
                case ServiceControllerStatus.Paused:
                    staStr = "服务已暂停！";
                    btnStart.SetValue(m_SyncContext, btn => btn.Enabled, true);
                    btnStop.SetValue(m_SyncContext, btn => btn.Enabled, true);
                    break;
                case ServiceControllerStatus.Running:
                    staStr = "服务正在运行！";
                    btnStop.SetValue(m_SyncContext, btn => btn.Enabled, true);
                    break;
                case ServiceControllerStatus.StartPending:
                    staStr = "服务正在启动！";
                    break;
                case ServiceControllerStatus.StopPending:
                    staStr = "服务正在停止！";
                    break;
                case ServiceControllerStatus.Stopped:
                    staStr = "服务未运行！";
                    btnStart.SetValue(m_SyncContext, btn => btn.Enabled, true);
                    break;
                default:
                    staStr = "未知状态！";
                    break;
            }
            return staStr;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要启动服务吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WinServiceControl.Run(ServiceName);
                GetLastestStatus();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要停止服务吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                WinServiceControl.Stop(ServiceName);
                GetLastestStatus();
            }
        }

        public bool HasLoad { get; private set; }
        private void ucWinServiceMgr_Load(object sender, EventArgs e)
        {
            if (HasLoad) return;

            RefreshServiceList();

            WinServiceControl.MachineName = MyClients.Host ?? "127.0.0.1";

            GetLastestStatus();

            Task task = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    do
                    {
                        int num = (int)numericUpDown1.Value;
                        while (num-- != 0)
                        {
                            labStatus.SetValue(m_SyncContext, lab => lab.Text, string.Format("update status in {0} seconds...... ", num));
                            Thread.Sleep(1000);
                        }

                        GetLastestStatus();

                        Thread.Sleep(3000);

                        labStatus.SetValue(m_SyncContext, lab => lab.Text, string.Empty);

                    } while (chkAutoRefresh.Checked);
                }
            });
            task.Start();

            labStatus.Text = GetStaus();
            HasLoad = true;
        }



        private void RefreshServiceList()
        {
            cmbServiceList.DataSource = WinServiceConfigReader.GetWinServices();
            cmbServiceList.DisplayMember = WinServiceConfigReader.SERVICE;
            cmbServiceList.ValueMember = WinServiceConfigReader.SERVICE;
            cmbServiceList.SelectedIndex = 0;
        }

        private void GetLastestStatus()
        {
            if (WinServiceControl.Existed(ServiceName))
            {
                btnInstall.SetValue(m_SyncContext, zw => zw.Enabled, false);
                btnUnInstall.SetValue(m_SyncContext, zw => zw.Enabled, true);

                labMsg.SetValue(m_SyncContext, zw => zw.Text, "");

                labStatus.SetValue(m_SyncContext, lab => lab.Text, GetStaus());
            }
            else
            {
                btnInstall.SetValue(m_SyncContext, zw => zw.Enabled, true);
                btnUnInstall.SetValue(m_SyncContext, zw => zw.Enabled, false);

                if (this.Visible)
                {
                    labMsg.SetValue(m_SyncContext, zw => zw.Text, string.Format("{0}不存在", ServiceName));
                    labMsg.SetValue(m_SyncContext, zw => zw.ForeColor, Color.Red);
                }
            }
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
            }
        }

        private void btnOpenServicePath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(WinServiceControl.GetWindowsServiceInstallPath(ServiceName));
        }

        private void btnEditServiceList_Click(object sender, EventArgs e)
        {
            FrmEditSvcList f = new FrmEditSvcList();
            f.ShowDialog();

            RefreshServiceList();
        }

        private void cmbServiceList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbServiceList.SelectedIndex >= 0)
            {
                var val = cmbServiceList.SelectedItem as WinServiceConfig;
                MyClients.SetCurrentBinding(val.Binding);
                GetLastestStatus();
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventLogViewer eventLogViewer = new EventLogViewer(ServiceName);
            eventLogViewer.ShowDialog();
        }
    }
}
