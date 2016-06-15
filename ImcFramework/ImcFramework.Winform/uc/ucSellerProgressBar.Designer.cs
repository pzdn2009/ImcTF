namespace ImcFramework.Winform
{
    partial class ucSellerProgressBar
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
            this.progressBarObject = new System.Windows.Forms.ProgressBar();
            this.linkLabelKeyName = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // progressBarObject
            // 
            this.progressBarObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarObject.Location = new System.Drawing.Point(0, 15);
            this.progressBarObject.Name = "progressBarObject";
            this.progressBarObject.Size = new System.Drawing.Size(215, 23);
            this.progressBarObject.TabIndex = 0;
            // 
            // linkLabelKeyName
            // 
            this.linkLabelKeyName.AutoSize = true;
            this.linkLabelKeyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelKeyName.Location = new System.Drawing.Point(0, 0);
            this.linkLabelKeyName.Name = "linkLabelKeyName";
            this.linkLabelKeyName.Size = new System.Drawing.Size(142, 15);
            this.linkLabelKeyName.TabIndex = 1;
            this.linkLabelKeyName.TabStop = true;
            this.linkLabelKeyName.Text = "进度对象账号名称：";
            // 
            // ucSellerProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarObject);
            this.Controls.Add(this.linkLabelKeyName);
            this.Name = "ucSellerProgressBar";
            this.Size = new System.Drawing.Size(215, 43);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarObject;
        private System.Windows.Forms.LinkLabel linkLabelKeyName;
    }
}
