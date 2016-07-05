namespace ImcFramework.Winform.Forms
{
    partial class EventLogViewer
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.eventlogs = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.Log = "Application";
            this.eventLog1.SynchronizingObject = this;
            // 
            // eventlogs
            // 
            this.eventlogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventlogs.FormattingEnabled = true;
            this.eventlogs.ItemHeight = 15;
            this.eventlogs.Location = new System.Drawing.Point(0, 0);
            this.eventlogs.Name = "eventlogs";
            this.eventlogs.ScrollAlwaysVisible = true;
            this.eventlogs.Size = new System.Drawing.Size(765, 448);
            this.eventlogs.TabIndex = 0;
            // 
            // EventLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 448);
            this.Controls.Add(this.eventlogs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventLogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EventLogViewer";
            this.Load += new System.EventHandler(this.EventLogViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ListBox eventlogs;
    }
}