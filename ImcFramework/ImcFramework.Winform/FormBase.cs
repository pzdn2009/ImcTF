using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();

            IsSave = false;
        }

        public bool IsSave { get; set; }
    }
}
