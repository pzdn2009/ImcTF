using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class AutoCloseForm : FormBase
    {
        private SynchronizationContext m_SyncContext = null;
        private AutoCloseForm(string message)
        {
            InitializeComponent();

            rtxMessgae.Text = message;
            m_SyncContext = SynchronizationContext.Current;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.rtxMessgae.Text);
        }

        public static void Show(string message, int defaultSeconds = 3)
        {
            seconds = defaultSeconds;
            new AutoCloseForm(message).ShowDialog();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static int seconds = 3;

        private void AutoCloseForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                do
                {
                    labMessage.SetValue(m_SyncContext, lab => lab.Text, string.Format("Closed in {0}s.", seconds));
                    seconds--;
                    Thread.Sleep(1000);
                } while (seconds >= 0);

                Close();
            });
        }
    }
}
