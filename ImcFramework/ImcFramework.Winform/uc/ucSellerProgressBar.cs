using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class ucSellerProgressBar : UserControl
    {
        public ucSellerProgressBar(string keyName, int minValue, int maxValue)
        {
            InitializeComponent();

            this.KeyName = keyName;
            this.Minimum = minValue;
            this.Maximum = maxValue;

            ShowLinkLableProgress();
            ShowBlack();
        }

        private string numberProgress = "{0}/{1}";

        private string m_KeyName = string.Empty;
        public string KeyName
        {
            get { return m_KeyName; }
            set { m_KeyName = value; }
        }

        public int Minimum
        {
            get { return this.progressBarObject.Minimum; }
            set { this.progressBarObject.Minimum = value; }
        }

        public int Maximum
        {
            get { return this.progressBarObject.Maximum; }
            set { this.progressBarObject.Maximum = value; }
        }

        public int Value
        {
            get { return this.progressBarObject.Value; }
            set
            {
                this.progressBarObject.Value = value;
                ShowLinkLableProgress();
            }
        }

        private void ShowBlack()
        {
            new Task(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(2000);
                    this.linkLabelKeyName.LinkColor = Color.Blue;
                }
            }).Start();
        }

        private void ShowLinkLableProgress()
        {
            this.linkLabelKeyName.Text = this.KeyName + " " + string.Format(numberProgress, Value, Maximum);
            this.linkLabelKeyName.LinkColor = Color.Red;
        }
    }
}
