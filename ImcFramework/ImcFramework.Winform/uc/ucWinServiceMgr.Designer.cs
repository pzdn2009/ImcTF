namespace ImcFramework.Winform
{
    partial class ucWinServiceMgr
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labMsg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.labStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnInstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnOpenServicePath = new System.Windows.Forms.Button();
            this.cmbServiceList = new System.Windows.Forms.ComboBox();
            this.btnEditServiceList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // labMsg
            // 
            this.labMsg.AutoSize = true;
            this.labMsg.Location = new System.Drawing.Point(181, 90);
            this.labMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(63, 15);
            this.labMsg.TabIndex = 23;
            this.labMsg.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Message:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(469, 109);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(131, 80);
            this.btnStop.TabIndex = 21;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(326, 109);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(131, 80);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(181, 59);
            this.labStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(63, 15);
            this.labStatus.TabIndex = 19;
            this.labStatus.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Status:";
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.Location = new System.Drawing.Point(184, 109);
            this.btnUnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(131, 80);
            this.btnUnInstall.TabIndex = 16;
            this.btnUnInstall.Text = "卸载";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(41, 109);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(131, 80);
            this.btnInstall.TabIndex = 15;
            this.btnInstall.Text = "安装";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AutoSize = true;
            this.btnQuery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuery.Location = new System.Drawing.Point(588, 14);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(77, 25);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "刷新状态";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = " 服务名称：";
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Location = new System.Drawing.Point(588, 59);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(104, 19);
            this.chkAutoRefresh.TabIndex = 24;
            this.chkAutoRefresh.Text = "自动刷新：";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(697, 56);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 25);
            this.numericUpDown1.TabIndex = 25;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnOpenServicePath
            // 
            this.btnOpenServicePath.AutoSize = true;
            this.btnOpenServicePath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenServicePath.Location = new System.Drawing.Point(687, 14);
            this.btnOpenServicePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenServicePath.Name = "btnOpenServicePath";
            this.btnOpenServicePath.Size = new System.Drawing.Size(107, 25);
            this.btnOpenServicePath.TabIndex = 26;
            this.btnOpenServicePath.Text = "打开服务路径";
            this.btnOpenServicePath.UseVisualStyleBackColor = true;
            this.btnOpenServicePath.Click += new System.EventHandler(this.btnOpenServicePath_Click);
            // 
            // cmbServiceList
            // 
            this.cmbServiceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceList.FormattingEnabled = true;
            this.cmbServiceList.Location = new System.Drawing.Point(184, 16);
            this.cmbServiceList.Name = "cmbServiceList";
            this.cmbServiceList.Size = new System.Drawing.Size(358, 23);
            this.cmbServiceList.TabIndex = 27;
            this.cmbServiceList.SelectedValueChanged += new System.EventHandler(this.cmbServiceList_SelectedValueChanged);
            // 
            // btnEditServiceList
            // 
            this.btnEditServiceList.AutoSize = true;
            this.btnEditServiceList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditServiceList.Location = new System.Drawing.Point(628, 109);
            this.btnEditServiceList.Name = "btnEditServiceList";
            this.btnEditServiceList.Size = new System.Drawing.Size(107, 25);
            this.btnEditServiceList.TabIndex = 28;
            this.btnEditServiceList.Text = "编辑服务列表";
            this.btnEditServiceList.UseVisualStyleBackColor = true;
            this.btnEditServiceList.Click += new System.EventHandler(this.btnEditServiceList_Click);
            // 
            // ucWinServiceMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditServiceList);
            this.Controls.Add(this.cmbServiceList);
            this.Controls.Add(this.btnOpenServicePath);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnInstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label1);
            this.Name = "ucWinServiceMgr";
            this.Size = new System.Drawing.Size(803, 203);
            this.Load += new System.EventHandler(this.ucWinServiceMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOpenServicePath;
        private System.Windows.Forms.ComboBox cmbServiceList;
        private System.Windows.Forms.Button btnEditServiceList;
    }
}
