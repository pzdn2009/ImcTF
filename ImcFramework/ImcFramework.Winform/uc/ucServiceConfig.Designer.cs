namespace ImcFramework.Winform
{
    partial class ucServiceConfig
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labServiceStatus = new System.Windows.Forms.Label();
            this.txtScheduleInfo = new System.Windows.Forms.TextBox();
            this.grpServiceName = new System.Windows.Forms.GroupBox();
            this.labRefreshTip = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnEditorCron = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInterrupt = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnRunRightNow = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtxRealTimeLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.taskProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.taskProgressRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucLog1 = new ImcFramework.Winform.ucLog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rtxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.labPrevFiredTime = new System.Windows.Forms.Label();
            this.labNextFiredTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpServiceName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.rtxContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "计划信息：";
            // 
            // labServiceStatus
            // 
            this.labServiceStatus.AutoSize = true;
            this.labServiceStatus.Location = new System.Drawing.Point(147, 28);
            this.labServiceStatus.Name = "labServiceStatus";
            this.labServiceStatus.Size = new System.Drawing.Size(95, 15);
            this.labServiceStatus.TabIndex = 4;
            this.labServiceStatus.Text = "some status";
            // 
            // txtScheduleInfo
            // 
            this.txtScheduleInfo.Location = new System.Drawing.Point(149, 68);
            this.txtScheduleInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtScheduleInfo.Name = "txtScheduleInfo";
            this.txtScheduleInfo.Size = new System.Drawing.Size(351, 25);
            this.txtScheduleInfo.TabIndex = 6;
            // 
            // grpServiceName
            // 
            this.grpServiceName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpServiceName.Controls.Add(this.labNextFiredTime);
            this.grpServiceName.Controls.Add(this.label6);
            this.grpServiceName.Controls.Add(this.labPrevFiredTime);
            this.grpServiceName.Controls.Add(this.label1);
            this.grpServiceName.Controls.Add(this.labRefreshTip);
            this.grpServiceName.Controls.Add(this.numericUpDown1);
            this.grpServiceName.Controls.Add(this.chkAutoRefresh);
            this.grpServiceName.Controls.Add(this.btnEditorCron);
            this.grpServiceName.Controls.Add(this.btnUpdate);
            this.grpServiceName.Controls.Add(this.txtScheduleInfo);
            this.grpServiceName.Controls.Add(this.label2);
            this.grpServiceName.Controls.Add(this.labServiceStatus);
            this.grpServiceName.Controls.Add(this.label3);
            this.grpServiceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpServiceName.Location = new System.Drawing.Point(0, 0);
            this.grpServiceName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpServiceName.Name = "grpServiceName";
            this.grpServiceName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpServiceName.Size = new System.Drawing.Size(885, 149);
            this.grpServiceName.TabIndex = 7;
            this.grpServiceName.TabStop = false;
            this.grpServiceName.Text = "服务名";
            // 
            // labRefreshTip
            // 
            this.labRefreshTip.AutoSize = true;
            this.labRefreshTip.ForeColor = System.Drawing.Color.Red;
            this.labRefreshTip.Location = new System.Drawing.Point(683, 28);
            this.labRefreshTip.Name = "labRefreshTip";
            this.labRefreshTip.Size = new System.Drawing.Size(55, 15);
            this.labRefreshTip.TabIndex = 10;
            this.labRefreshTip.Text = "label1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(632, 22);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(35, 25);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Location = new System.Drawing.Point(507, 25);
            this.chkAutoRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(119, 19);
            this.chkAutoRefresh.TabIndex = 8;
            this.chkAutoRefresh.Text = "状态自动刷新";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // btnEditorCron
            // 
            this.btnEditorCron.Location = new System.Drawing.Point(507, 62);
            this.btnEditorCron.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditorCron.Name = "btnEditorCron";
            this.btnEditorCron.Size = new System.Drawing.Size(52, 31);
            this.btnEditorCron.TabIndex = 7;
            this.btnEditorCron.Text = "编辑";
            this.btnEditorCron.UseVisualStyleBackColor = true;
            this.btnEditorCron.Click += new System.EventHandler(this.btnEditorCron_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(564, 62);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(52, 31);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInterrupt);
            this.groupBox2.Controls.Add(this.btnCancle);
            this.groupBox2.Controls.Add(this.btnRunRightNow);
            this.groupBox2.Controls.Add(this.btnContinue);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 149);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(885, 51);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // btnInterrupt
            // 
            this.btnInterrupt.Location = new System.Drawing.Point(576, 6);
            this.btnInterrupt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInterrupt.Name = "btnInterrupt";
            this.btnInterrupt.Size = new System.Drawing.Size(93, 34);
            this.btnInterrupt.TabIndex = 4;
            this.btnInterrupt.Text = "中断";
            this.btnInterrupt.UseVisualStyleBackColor = true;
            this.btnInterrupt.Click += new System.EventHandler(this.btnInterrupt_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(448, 6);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(93, 34);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnRunRightNow
            // 
            this.btnRunRightNow.Location = new System.Drawing.Point(312, 6);
            this.btnRunRightNow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunRightNow.Name = "btnRunRightNow";
            this.btnRunRightNow.Size = new System.Drawing.Size(93, 34);
            this.btnRunRightNow.TabIndex = 2;
            this.btnRunRightNow.Text = "执行";
            this.btnRunRightNow.UseVisualStyleBackColor = true;
            this.btnRunRightNow.Click += new System.EventHandler(this.btnRunRightNow_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(184, 6);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(93, 34);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(52, 6);
            this.btnPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(93, 34);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "挂起";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 223);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 366);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtxRealTimeLog);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(877, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当前日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtxRealTimeLog
            // 
            this.rtxRealTimeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxRealTimeLog.Location = new System.Drawing.Point(3, 2);
            this.rtxRealTimeLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxRealTimeLog.Name = "rtxRealTimeLog";
            this.rtxRealTimeLog.Size = new System.Drawing.Size(871, 303);
            this.rtxRealTimeLog.TabIndex = 1;
            this.rtxRealTimeLog.Text = "";
            this.rtxRealTimeLog.ZoomFactor = 1.101F;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.taskProgressBar,
            this.taskProgressRate});
            this.statusStrip1.Location = new System.Drawing.Point(3, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(871, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 25);
            this.toolStripStatusLabel1.Text = "任务总进度：";
            // 
            // taskProgressBar
            // 
            this.taskProgressBar.Name = "taskProgressBar";
            this.taskProgressBar.Size = new System.Drawing.Size(300, 24);
            // 
            // taskProgressRate
            // 
            this.taskProgressRate.Name = "taskProgressRate";
            this.taskProgressRate.Size = new System.Drawing.Size(38, 25);
            this.taskProgressRate.Text = "rate";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucLog1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(877, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucLog1
            // 
            this.ucLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLog1.Location = new System.Drawing.Point(3, 2);
            this.ucLog1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLog1.Name = "ucLog1";
            this.ucLog1.Size = new System.Drawing.Size(871, 362);
            this.ucLog1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 200);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(885, 23);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 2);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rtxContextMenuStrip
            // 
            this.rtxContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rtxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.rtxContextMenuStrip.Name = "rtxContextMenuStrip";
            this.rtxContextMenuStrip.Size = new System.Drawing.Size(122, 30);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "上次执行时间：";
            // 
            // labPrevFiredTime
            // 
            this.labPrevFiredTime.AutoSize = true;
            this.labPrevFiredTime.Location = new System.Drawing.Point(165, 113);
            this.labPrevFiredTime.Name = "labPrevFiredTime";
            this.labPrevFiredTime.Size = new System.Drawing.Size(113, 15);
            this.labPrevFiredTime.TabIndex = 12;
            this.labPrevFiredTime.Text = "{上次执行时间}";
            // 
            // labNextFiredTime
            // 
            this.labNextFiredTime.AutoSize = true;
            this.labNextFiredTime.Location = new System.Drawing.Point(629, 113);
            this.labNextFiredTime.Name = "labNextFiredTime";
            this.labNextFiredTime.Size = new System.Drawing.Size(113, 15);
            this.labNextFiredTime.TabIndex = 14;
            this.labNextFiredTime.Text = "{下次执行时间}";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(504, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "下次执行时间：";
            // 
            // ucServiceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpServiceName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucServiceConfig";
            this.Size = new System.Drawing.Size(885, 589);
            this.Load += new System.EventHandler(this.ucServiceConfig_Load);
            this.grpServiceName.ResumeLayout(false);
            this.grpServiceName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.rtxContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labServiceStatus;
        private System.Windows.Forms.TextBox txtScheduleInfo;
        private System.Windows.Forms.GroupBox grpServiceName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRunRightNow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtxRealTimeLog;
        private System.Windows.Forms.Button btnEditorCron;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar taskProgressBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip rtxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private ucLog ucLog1;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labRefreshTip;
        private System.Windows.Forms.ToolStripStatusLabel taskProgressRate;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnInterrupt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPrevFiredTime;
        private System.Windows.Forms.Label labNextFiredTime;
        private System.Windows.Forms.Label label6;
    }
}
