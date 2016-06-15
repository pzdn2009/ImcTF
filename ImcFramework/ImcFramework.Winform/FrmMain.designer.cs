namespace ImcFramework.Winform
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSample = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabWinServiceMgr = new System.Windows.Forms.TabPage();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripForTabpage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCloseAllButThis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.window服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getServiceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListServiceStatus = new System.Windows.Forms.ImageList(this.components);
            this.grbServiceStatus = new System.Windows.Forms.GroupBox();
            this.labUserName = new System.Windows.Forms.LinkLabel();
            this.rdbInvalid = new System.Windows.Forms.RadioButton();
            this.rdbPause = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbNormal = new System.Windows.Forms.RadioButton();
            this.rdbRun = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.contextMenuStripForTabpage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grbServiceStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.btnSample);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1155, 583);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnSample
            // 
            this.btnSample.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSample.Image = ((System.Drawing.Image)(resources.GetObject("btnSample.Image")));
            this.btnSample.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSample.Location = new System.Drawing.Point(0, 0);
            this.btnSample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(244, 51);
            this.btnSample.TabIndex = 2;
            this.btnSample.Text = "样例按钮";
            this.btnSample.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabWinServiceMgr);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(907, 583);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabWinServiceMgr
            // 
            this.tabWinServiceMgr.Location = new System.Drawing.Point(4, 25);
            this.tabWinServiceMgr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabWinServiceMgr.Name = "tabWinServiceMgr";
            this.tabWinServiceMgr.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabWinServiceMgr.Size = new System.Drawing.Size(899, 554);
            this.tabWinServiceMgr.TabIndex = 2;
            this.tabWinServiceMgr.Text = "window 服务管理";
            this.tabWinServiceMgr.UseVisualStyleBackColor = true;
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "EbayAPI 管理";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
            // 
            // contextMenuStripForTabpage
            // 
            this.contextMenuStripForTabpage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripForTabpage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClose,
            this.tsmCloseAllButThis,
            this.tsmCloseAll});
            this.contextMenuStripForTabpage.Name = "tabCtrContextMenuStrip";
            this.contextMenuStripForTabpage.Size = new System.Drawing.Size(205, 82);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(204, 26);
            this.tsmClose.Text = "关闭";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // tsmCloseAllButThis
            // 
            this.tsmCloseAllButThis.Name = "tsmCloseAllButThis";
            this.tsmCloseAllButThis.Size = new System.Drawing.Size(204, 26);
            this.tsmCloseAllButThis.Text = "除此之外全部关闭";
            this.tsmCloseAllButThis.Click += new System.EventHandler(this.tsmCloseAllButThis_Click);
            // 
            // tsmCloseAll
            // 
            this.tsmCloseAll.Name = "tsmCloseAll";
            this.tsmCloseAll.Size = new System.Drawing.Size(204, 26);
            this.tsmCloseAll.Text = "全部关闭";
            this.tsmCloseAll.Click += new System.EventHandler(this.tsmCloseAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.window服务ToolStripMenuItem,
            this.getServiceListToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // window服务ToolStripMenuItem
            // 
            this.window服务ToolStripMenuItem.Name = "window服务ToolStripMenuItem";
            this.window服务ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.window服务ToolStripMenuItem.Text = "Window 服务";
            this.window服务ToolStripMenuItem.Click += new System.EventHandler(this.window服务ToolStripMenuItem_Click);
            // 
            // getServiceListToolStripMenuItem
            // 
            this.getServiceListToolStripMenuItem.Name = "getServiceListToolStripMenuItem";
            this.getServiceListToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.getServiceListToolStripMenuItem.Text = "获取服务列表";
            this.getServiceListToolStripMenuItem.Click += new System.EventHandler(this.获取服务列表ToolStripMenuItem_Click);
            // 
            // imgListServiceStatus
            // 
            this.imgListServiceStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListServiceStatus.ImageStream")));
            this.imgListServiceStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListServiceStatus.Images.SetKeyName(0, "Normal.png");
            this.imgListServiceStatus.Images.SetKeyName(1, "Running.gif");
            this.imgListServiceStatus.Images.SetKeyName(2, "Pause.gif");
            this.imgListServiceStatus.Images.SetKeyName(3, "invalid.png");
            // 
            // grbServiceStatus
            // 
            this.grbServiceStatus.Controls.Add(this.labUserName);
            this.grbServiceStatus.Controls.Add(this.rdbInvalid);
            this.grbServiceStatus.Controls.Add(this.rdbPause);
            this.grbServiceStatus.Controls.Add(this.rdbAll);
            this.grbServiceStatus.Controls.Add(this.rdbNormal);
            this.grbServiceStatus.Controls.Add(this.rdbRun);
            this.grbServiceStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbServiceStatus.Location = new System.Drawing.Point(0, 28);
            this.grbServiceStatus.Name = "grbServiceStatus";
            this.grbServiceStatus.Size = new System.Drawing.Size(1155, 46);
            this.grbServiceStatus.TabIndex = 4;
            this.grbServiceStatus.TabStop = false;
            // 
            // labUserName
            // 
            this.labUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(1036, 17);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(47, 15);
            this.labUserName.TabIndex = 5;
            this.labUserName.TabStop = true;
            this.labUserName.Text = "Login";
            // 
            // rdbInvalid
            // 
            this.rdbInvalid.AutoSize = true;
            this.rdbInvalid.Location = new System.Drawing.Point(351, 15);
            this.rdbInvalid.Name = "rdbInvalid";
            this.rdbInvalid.Size = new System.Drawing.Size(84, 19);
            this.rdbInvalid.TabIndex = 4;
            this.rdbInvalid.Text = "Invalid";
            this.rdbInvalid.UseVisualStyleBackColor = true;
            this.rdbInvalid.CheckedChanged += new System.EventHandler(this.rdbServiceGroupStatus_CheckedChanged);
            // 
            // rdbPause
            // 
            this.rdbPause.AutoSize = true;
            this.rdbPause.Location = new System.Drawing.Point(176, 15);
            this.rdbPause.Name = "rdbPause";
            this.rdbPause.Size = new System.Drawing.Size(68, 19);
            this.rdbPause.TabIndex = 1;
            this.rdbPause.Text = "Pause";
            this.rdbPause.UseVisualStyleBackColor = true;
            this.rdbPause.CheckedChanged += new System.EventHandler(this.rdbServiceGroupStatus_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(22, 15);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(52, 19);
            this.rdbAll.TabIndex = 3;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbServiceGroupStatus_CheckedChanged);
            // 
            // rdbNormal
            // 
            this.rdbNormal.AutoSize = true;
            this.rdbNormal.Location = new System.Drawing.Point(260, 15);
            this.rdbNormal.Name = "rdbNormal";
            this.rdbNormal.Size = new System.Drawing.Size(76, 19);
            this.rdbNormal.TabIndex = 2;
            this.rdbNormal.Text = "Normal";
            this.rdbNormal.UseVisualStyleBackColor = true;
            this.rdbNormal.CheckedChanged += new System.EventHandler(this.rdbServiceGroupStatus_CheckedChanged);
            // 
            // rdbRun
            // 
            this.rdbRun.AutoSize = true;
            this.rdbRun.Location = new System.Drawing.Point(104, 15);
            this.rdbRun.Name = "rdbRun";
            this.rdbRun.Size = new System.Drawing.Size(52, 19);
            this.rdbRun.TabIndex = 0;
            this.rdbRun.Text = "Run";
            this.rdbRun.UseVisualStyleBackColor = true;
            this.rdbRun.CheckedChanged += new System.EventHandler(this.rdbServiceGroupStatus_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 657);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.grbServiceStatus);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公共定时服务";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.contextMenuStripForTabpage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbServiceStatus.ResumeLayout(false);
            this.grbServiceStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabWinServiceMgr;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForTabpage;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ToolStripMenuItem tsmCloseAllButThis;
        private System.Windows.Forms.ToolStripMenuItem tsmCloseAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem window服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getServiceListToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListServiceStatus;
        private System.Windows.Forms.GroupBox grbServiceStatus;
        private System.Windows.Forms.LinkLabel labUserName;
        private System.Windows.Forms.RadioButton rdbInvalid;
        private System.Windows.Forms.RadioButton rdbPause;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbNormal;
        private System.Windows.Forms.RadioButton rdbRun;
        private System.Windows.Forms.Button btnSample;


    }
}

