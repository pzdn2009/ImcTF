using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public class WinformRunHelper
    {
        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
