using ImcFramework.WcfInterface;
using ImcFramework.Winform.Common;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class FrmMain : Form
    {
        private WsDualClient m_WsDualClient;

        /// <summary>
        /// 是否需要刷新
        /// </summary>
        public bool NeedRefresh { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            this.notifyIconMain.Icon = this.Icon;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            MyClients.TabControlMain = this.tabControlMain;
            MyClients.FrmMain = this;

            UserControl ctr = new ucWinServiceMgr();
            tabWinServiceMgr.Controls.Add(ctr);

            Task.Factory.StartNew(LoopToReadServiceStatus);
        }

        public void GetServiceList()
        {
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer1.Panel1.Controls.Clear();

            try
            {
                EnsureClientConnector();

                var serviceList = m_WsDualClient.ClientConnector.GetServiceList();

                int cnt = 0;
                foreach (var en in serviceList)
                {
                    var btn = new Button();
                    btn.Size = btnSample.Size;
                    btn.Width = this.splitContainer1.Panel1.Width - 2;
                    btn.Click += btnSample_Click;
                    btn.Text = en.ServiceName;
                    btn.Tag = en;
                    btn.Dock = DockStyle.Top;
                    btn.TabIndex = 1000 - cnt;
                    btn.Location = new Point(0, 20 + btnSample.Height * (cnt++) + 8);
                    btn.Name = string.Format("btn{0}", en.ToString());
                    btn.ImageList = imgListServiceStatus;
                    btn.ImageIndex = 0;
                    btn.ImageAlign = ContentAlignment.MiddleRight;
                    this.splitContainer1.Panel1.Controls.Add(btn);

                    this.splitContainer1.Panel1.Controls.Add(btn);
                }
                this.splitContainer1.Panel1.Controls.Remove(btnSample);

                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);

                this.tabControlMain.ContextMenuStrip = this.contextMenuStripForTabpage;
            }
            catch (FaultException fex)
            {
                MessageBox.Show(fex.Code.Name + ":" + fex.Action + ":" + fex.Reason.ToString());
            }
            catch (Exception ex)
            {
                var connectionMsg = "Win服务没安装或未启动，或者WCF配置不正确！\n\nError详情：" + ex.Message;
                MessageBox.Show(connectionMsg);
            }
        }
        private void EnsureClientConnector()
        {
            if (NeedRefresh || m_WsDualClient == null || m_WsDualClient.Factory.State != CommunicationState.Opened)
            {
                NeedRefresh = false;
                m_WsDualClient = new WsDualClient(MyClients.CurrentBinding);
            }
        }

        #region 外部状态刷新

        public void LoopToReadServiceStatus()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);

                EnsureClientConnector();

                foreach (Button btn in this.splitContainer1.Panel1.Controls)
                {
                    try
                    {
                        var serviceInfo = m_WsDualClient.ClientConnector.GetServiceInfo(((EServiceType)btn.Tag));
                        switch (serviceInfo.EServiceStatus)
                        {
                            case EServiceStatus.Normal:
                                if (string.IsNullOrEmpty(serviceInfo.ScheduleInfo))
                                {
                                    btn.ImageIndex = 4;
                                    btn.Visible = rdbAll.Checked || rdbInvalid.Checked;
                                }
                                else
                                {
                                    btn.ImageIndex = 0;
                                    btn.Visible = rdbAll.Checked || rdbNormal.Checked;
                                }
                                break;
                            case EServiceStatus.Running:
                                btn.ImageIndex = 1;
                                btn.Visible = rdbAll.Checked || rdbRun.Checked;
                                break;
                            case EServiceStatus.Pause:
                                btn.ImageIndex = 2;
                                btn.Visible = rdbAll.Checked || rdbPause.Checked;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        btn.ImageIndex = 4;
                        btn.Visible = rdbAll.Checked || rdbInvalid.Checked;
                    }
                }

                this.splitContainer1.Panel1.Controls.OfType<Button>().OrderBy(zw => zw.Tag.ToString());
            }
        }

        private void rdbServiceGroupStatus_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            foreach (var btn in this.splitContainer1.Panel1.Controls.OfType<Button>())
            {
                switch (rdb.Text)
                {
                    case "All":
                        btn.Visible = true;
                        break;
                    case "Run":
                        btn.Visible = btn.ImageIndex == 1;
                        break;
                    case "Pause":
                        btn.Visible = btn.ImageIndex == 2;
                        break;
                    case "Normal":
                        btn.Visible = btn.ImageIndex == 0;
                        break;
                    case "Invalid":
                        btn.Visible = btn.ImageIndex == 4;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MyClients.CloseTabPage(null);
            base.OnFormClosing(e);
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;

            var serviceType = ((EServiceType)btn.Tag);
            if (!MyClients.HasAddTagPage(serviceType))
            {
                var service = new ucServiceConfig(serviceType);

                service.Dock = DockStyle.Fill;
                var newTabPage = new TabPage();
                newTabPage.Text = serviceType.ServiceName;
                newTabPage.Controls.Add(service);
                tabControlMain.TabPages.Add(newTabPage);

                if (!service.InitialSuccess)
                {
                    tabControlMain.TabPages.Remove(newTabPage);
                    return;
                }

                MyClients.Add(serviceType, newTabPage);
                tabControlMain.SelectedTab = newTabPage;
            }
            else
            {
                tabControlMain.SelectedTab = MyClients.GetTabPage(serviceType);
            }
        }

        #region Notify Icon

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.notifyIconMain.Visible = false;
            }
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIconMain.Visible = true;
            }
        }

        #endregion

        #region Context Menu Strip For TabPage

        private ECloseType closeType = ECloseType.Current;

        private void tsmClose_Click(object sender, EventArgs e)
        {
            closeType = ECloseType.Current;
            CloseTabPage(contextMenuStripForTabpage.SourceControl);
        }

        private void tsmCloseAllButThis_Click(object sender, EventArgs e)
        {
            closeType = ECloseType.AllButThis;
            CloseTabPage(contextMenuStripForTabpage.SourceControl);
        }

        private void tsmCloseAll_Click(object sender, EventArgs e)
        {
            closeType = ECloseType.All;
            CloseTabPage(contextMenuStripForTabpage.SourceControl);
        }
        public const string WINSERVIER_MGR = "window 服务管理";
        private void CloseTabPage(Control sourceControl)
        {
            var tabPage = sourceControl as TabPage;
            switch (closeType)
            {
                case ECloseType.Current:
                    MyClients.CloseTabPage(tabControlMain.SelectedTab);
                    break;
                case ECloseType.AllButThis:
                    MyClients.CloseTabPages(exceptTabPage: tabControlMain.SelectedTab);
                    break;
                case ECloseType.All:
                    MyClients.CloseTabPages(null);
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void 获取服务列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetServiceList();
        }

        private void window服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in tabWinServiceMgr.Controls)
            {
                if (item is ucWinServiceMgr)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                UserControl ctr = new ucWinServiceMgr();
                tabWinServiceMgr.Controls.Add(ctr);
            }
        }
    }

    public enum ECloseType
    {
        Current,
        AllButThis,
        All,
    }
}
