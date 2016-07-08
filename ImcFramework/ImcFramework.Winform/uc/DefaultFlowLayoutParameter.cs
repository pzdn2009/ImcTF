using ImcFramework.WcfInterface;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ImcFramework.Winform.uc
{
    public class DefaultFlowLayoutParameter : IFlowLayoutParameter
    {
        public FlowLayoutPanel GetFlowLayoutPanel(RequestParameter requestParameter)
        {
            if (requestParameter != null && !string.IsNullOrEmpty(requestParameter.CommaValue))
            {
                var flp = new FlowLayoutPanel();
                flp.Name = requestParameter.Name;

                var vals = requestParameter.CommaValue.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                vals.Insert(0, "All");

                for (int i = 0; i < vals.Count; i++)
                {
                    CheckBox chk = new CheckBox();
                    chk.AutoSize = true;
                    chk.Name = vals[i];
                    chk.Text = vals[i];
                    if (chk.Name == "All")
                    {
                        chk.Text = requestParameter.Name + "(All)";
                    }
                    chk.CheckedChanged += Chk_CheckedChanged;

                    flp.Controls.Add(chk);
                }

                flp.AutoSize = true;
                return flp;
            }

            return null;
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk.Name == "All")
            {
                foreach (CheckBox ctr in chk.Parent.Controls)
                {
                    if (ctr.Name == "All") continue;
                    ctr.Checked = chk.Checked;
                }
            }
        }
    }
}
