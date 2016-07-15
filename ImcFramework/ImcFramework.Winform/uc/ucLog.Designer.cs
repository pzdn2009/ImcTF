namespace ImcFramework.Winform
{
    partial class ucLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLog));
            this.rtxLogs = new System.Windows.Forms.RichTextBox();
            this.trvLogDateAndSellerAccount = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.chkWarn = new System.Windows.Forms.CheckBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.rtxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.rtxContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxLogs
            // 
            this.rtxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxLogs.Location = new System.Drawing.Point(176, 38);
            this.rtxLogs.Name = "rtxLogs";
            this.rtxLogs.Size = new System.Drawing.Size(605, 359);
            this.rtxLogs.TabIndex = 1;
            this.rtxLogs.Text = "logs ......";
            // 
            // trvLogDateAndSellerAccount
            // 
            this.trvLogDateAndSellerAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvLogDateAndSellerAccount.ImageIndex = 0;
            this.trvLogDateAndSellerAccount.ImageList = this.imageList1;
            this.trvLogDateAndSellerAccount.Location = new System.Drawing.Point(0, 38);
            this.trvLogDateAndSellerAccount.Name = "trvLogDateAndSellerAccount";
            this.trvLogDateAndSellerAccount.SelectedImageIndex = 0;
            this.trvLogDateAndSellerAccount.Size = new System.Drawing.Size(176, 359);
            this.trvLogDateAndSellerAccount.TabIndex = 2;
            this.trvLogDateAndSellerAccount.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvLogDateAndSellerAccount_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.chkError);
            this.panel1.Controls.Add(this.chkWarn);
            this.panel1.Controls.Add(this.chkInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 38);
            this.panel1.TabIndex = 3;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(330, 13);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(53, 19);
            this.chkAll.TabIndex = 3;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.Checks_CheckedChanged);
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.Location = new System.Drawing.Point(234, 13);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(69, 19);
            this.chkError.TabIndex = 2;
            this.chkError.Text = "Error";
            this.chkError.UseVisualStyleBackColor = true;
            this.chkError.CheckedChanged += new System.EventHandler(this.Checks_CheckedChanged);
            // 
            // chkWarn
            // 
            this.chkWarn.AutoSize = true;
            this.chkWarn.Location = new System.Drawing.Point(147, 13);
            this.chkWarn.Name = "chkWarn";
            this.chkWarn.Size = new System.Drawing.Size(61, 19);
            this.chkWarn.TabIndex = 1;
            this.chkWarn.Text = "Warn";
            this.chkWarn.UseVisualStyleBackColor = true;
            this.chkWarn.CheckedChanged += new System.EventHandler(this.Checks_CheckedChanged);
            // 
            // chkInfo
            // 
            this.chkInfo.AutoSize = true;
            this.chkInfo.Location = new System.Drawing.Point(51, 13);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(61, 19);
            this.chkInfo.TabIndex = 0;
            this.chkInfo.Text = "Info";
            this.chkInfo.UseVisualStyleBackColor = true;
            this.chkInfo.CheckedChanged += new System.EventHandler(this.Checks_CheckedChanged);
            // 
            // rtxContextMenuStrip
            // 
            this.rtxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.rtxContextMenuStrip.Name = "rtxContextMenuStrip";
            this.rtxContextMenuStrip.Size = new System.Drawing.Size(116, 28);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "date.png");
            this.imageList1.Images.SetKeyName(1, "date.gif");
            this.imageList1.Images.SetKeyName(2, "SellerAccount.png");
            this.imageList1.Images.SetKeyName(3, "LogInfo.png");
            this.imageList1.Images.SetKeyName(4, "Error.gif");
            this.imageList1.Images.SetKeyName(5, "Warn.gif");
            // 
            // ucLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtxLogs);
            this.Controls.Add(this.trvLogDateAndSellerAccount);
            this.Controls.Add(this.panel1);
            this.Name = "ucLog";
            this.Size = new System.Drawing.Size(781, 397);
            this.Load += new System.EventHandler(this.ucLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rtxContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxLogs;
        private System.Windows.Forms.TreeView trvLogDateAndSellerAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.CheckBox chkWarn;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.ContextMenuStrip rtxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}
