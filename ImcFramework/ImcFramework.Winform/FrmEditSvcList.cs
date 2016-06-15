using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class FrmEditSvcList : Form
    {
        public FrmEditSvcList()
        {
            InitializeComponent();
        }

        private void FrmEditSvcList_Load(object sender, EventArgs e)
        {
            foreach (var item in WinServiceConfigReader.GetWinServices())
            {
                lsbServices.Items.Add(item);
            }

            lsbServices.DisplayMember = "ShowText";
            lsbServices.ValueMember = "Service";

            lsbServices.ContextMenuStrip = this.contextMenuStrip1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var list = new List<WinServiceConfig>();
            foreach (var item in lsbServices.Items)
            {
                var t = item as WinServiceConfig;
                if (t != null)
                {
                    list.Add(t);
                }
            }

            WinServiceConfigReader.SetWinServices(list, false);
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var svc = txtServiceName.Text.Trim();
            var binding = txtBinding.Text.Trim();
            if (!string.IsNullOrEmpty(svc) && !string.IsNullOrEmpty(binding))
            {
                lsbServices.Items.Add(new WinServiceConfig()
                {
                    Service = txtServiceName.Text.Trim(),
                    Binding = txtBinding.Text.Trim()
                });
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sl = lsbServices.SelectedItem;
            lsbServices.Items.Remove(sl);
        }

        private void lsbServices_DoubleClick(object sender, EventArgs e)
        {
            if (lsbServices.SelectedItems != null)
            {
                var c = lsbServices.SelectedItem as WinServiceConfig;
                txtServiceName.Text = c.Service;
                txtBinding.Text = c.Binding;
            }
        }
    }
}
