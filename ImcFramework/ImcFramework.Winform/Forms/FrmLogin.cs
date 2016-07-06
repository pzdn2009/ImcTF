using ImcFramework.Winform.Common;
using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class FrmLogin : FormBase
    {
        private WsDualClient m_Client;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginInner();
        }

        private void LoginInner()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            m_Client = new WsDualClient(MyClients.CurrentBinding);

            bool success = m_Client.Login(txtUserName.Text, txtPassword.Text);
            if (!success)
            {
                MessageBox.Show("登录不成功！请检查用户名和密码！");
                return;
            }

            UserHelper.CurrentUser = new UserInfo() { DisplayName = txtUserName.Text };

            IsSave = true;
            this.Close();
        }



        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginInner();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginInner();
            }
        }
    }
}
