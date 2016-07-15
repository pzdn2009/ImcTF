namespace ImcFramework.Winform
{
    partial class AutoCloseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtxMessgae = new System.Windows.Forms.RichTextBox();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.labMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.rtxMessgae.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxMessgae.Location = new System.Drawing.Point(12, 44);
            this.rtxMessgae.Name = "richTextBox1";
            this.rtxMessgae.ReadOnly = true;
            this.rtxMessgae.Size = new System.Drawing.Size(252, 92);
            this.rtxMessgae.TabIndex = 0;
            this.rtxMessgae.Text = "";
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(158, 142);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 1;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(36, 142);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label1
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(23, 15);
            this.labMessage.Name = "label1";
            this.labMessage.Size = new System.Drawing.Size(0, 15);
            this.labMessage.TabIndex = 3;
            // 
            // AutoCloseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 177);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.rtxMessgae);
            this.Name = "AutoCloseForm";
            this.Text = "提示";
            this.Load += new System.EventHandler(this.AutoCloseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxMessgae;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label labMessage;


    }
}