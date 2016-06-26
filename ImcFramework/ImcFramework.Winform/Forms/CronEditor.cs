using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public partial class CronEditor : Form
    {
        private Dictionary<string, int> dicWeek = new Dictionary<string, int>();

        public CronEditor()
        {
            InitializeComponent();

            this.btnCopy.Visible = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCron.Text))
            {
                Clipboard.SetDataObject(this.txtCron.Text);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Clipboard.SetDataObject(this.txtCron.Text);
            base.OnFormClosing(e);
        }

        private void chk_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.rbWeekNumIn.Checked || this.rbWeekLast.Checked)
            {
                for (int i = 0; i < this.chkWeek.Items.Count; i++)
                {
                    this.chkWeek.SetItemCheckState(i, CheckState.Unchecked);
                }
                if (this.chkWeek.SelectedIndex > -1)
                {
                    this.chkWeek.SetItemCheckState(this.chkWeek.SelectedIndex, CheckState.Checked);
                }
            }
            CheckedListBox box = sender as CheckedListBox;
            ArrayList list = new ArrayList();
            foreach (string str in box.CheckedItems)
            {
                if (box.Name == "chkWeek")
                {
                    list.Add(Convert.ToInt32(this.dicWeek[str]));
                }
                else
                {
                    list.Add(Convert.ToInt32(str));
                }
            }
            if ((list != null) && (list.Count > 0))
            {
                list.Sort();
                string str2 = string.Join<int>(",", (int[])list.ToArray(typeof(int)));
                string name = box.Name;
                if (name != null)
                {
                    if (!(name == "chkSec"))
                    {
                        if (name == "chkMin")
                        {
                            this.txtMinite.Text = str2;
                        }
                        else if (name == "chkHour")
                        {
                            this.txtHour.Text = str2;
                        }
                        else if (name == "chkDay")
                        {
                            this.txtDay.Text = str2;
                        }
                        else if (name == "chkMouth")
                        {
                            this.txtMonth.Text = str2;
                        }
                        else if (name == "chkWeek")
                        {
                            if (this.rbWeekNumIn.Checked)
                            {
                                this.txtWeek.Text = str2 + "#" + this.numWeek.Value;
                            }
                            else if (this.rbWeekLast.Checked)
                            {
                                this.txtWeek.Text = str2 + "L";
                            }
                            else
                            {
                                this.txtWeek.Text = str2;
                            }
                        }
                    }
                    else
                    {
                        this.txtSecond.Text = str2;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.numYearCS.Minimum = DateTime.Now.Year;
            this.numYearCO.Minimum = DateTime.Now.Year;
            this.numYearCS.Maximum = 2050M;
            this.numYearCO.Maximum = 2050M;
            this.txtWeek.Text = "?";
            this.txtYear.Text = string.Empty;
            this.dicWeek.Add("SUN", 1);
            this.dicWeek.Add("MON", 2);
            this.dicWeek.Add("TUES", 3);
            this.dicWeek.Add("WED", 4);
            this.dicWeek.Add("THUR", 5);
            this.dicWeek.Add("FRI", 6);
            this.dicWeek.Add("SAT", 7);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;
            new Process { StartInfo = { FileName = "iexplore.exe", Arguments = label.Text } }.Start();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown down = sender as NumericUpDown;
            switch (down.Tag.ToString())
            {
                case "numSec":
                    this.txtSecond.Text = this.numSecStart.Value + "/" + this.numSecEvery.Value;
                    break;

                case "numSecC":
                    this.txtSecond.Text = this.numSecCS.Value + "-" + this.numSecCO.Value;
                    break;

                case "numMin":
                    this.txtMinite.Text = this.numMinStart.Value + "/" + this.numMinEvery.Value;
                    break;

                case "numMinC":
                    this.txtMinite.Text = this.numMinCS.Value + "-" + this.numMinCO.Value;
                    break;

                case "numHour":
                    this.txtHour.Text = this.numHourStart.Value + "/" + this.numHourEvery.Value;
                    break;

                case "numHourC":
                    this.txtHour.Text = this.numHourCS.Value + "-" + this.numHourCO.Value;
                    break;

                case "numDay":
                    this.txtDay.Text = this.numDayStart.Value + "/" + this.numDayEvery.Value;
                    break;

                case "numDayC":
                    this.txtDay.Text = this.numDayCS.Value + "-" + this.numDayCO.Value;
                    break;

                case "numDayW":
                    this.txtDay.Text = this.numDayW.Value + "W";
                    break;

                case "numMouth":
                    this.txtMonth.Text = this.numMouthStart.Value + "/" + this.numMouthEvery.Value;
                    break;

                case "numMouthC":
                    this.txtMonth.Text = this.numMouthCS.Value + "-" + this.numMouthCO.Value;
                    break;

                case "numWeekC":
                    this.txtWeek.Text = this.numWeekCS.Value + "/" + this.numWeekCO.Value;
                    break;

                case "numYearC":
                    this.txtYear.Text = this.numYearCS.Value + "-" + this.numYearCO.Value;
                    break;
            }
        }

        private void rbClick(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            switch (button.Name)
            {
                case "rbSecEvery":
                    this.txtSecond.Text = "*";
                    this.chkSec.Enabled = false;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    break;

                case "rbSecCycle":
                    this.txtSecond.Text = this.numSecCS.Value + "-" + this.numSecCO.Value;
                    this.chkSec.Enabled = false;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = true;
                    this.numSecCO.Enabled = true;
                    break;

                case "rbSec":
                    this.txtSecond.Text = this.numSecStart.Value + "/" + this.numSecEvery.Value;
                    this.numSecStart.Enabled = true;
                    this.numSecEvery.Enabled = true;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    this.chkSec.Enabled = false;
                    break;

                case "rbSecAppoint":
                    this.txtSecond.Text = "*";
                    this.chkSec.Enabled = true;
                    this.numSecStart.Enabled = false;
                    this.numSecEvery.Enabled = false;
                    this.numSecCS.Enabled = false;
                    this.numSecCO.Enabled = false;
                    break;

                case "rbMinEvery":
                    this.txtMinite.Text = "*";
                    this.chkMin.Enabled = false;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    break;

                case "rbMinCycle":
                    this.txtMinite.Text = this.numMinCS.Value + "-" + this.numMinCO.Value;
                    this.chkMin.Enabled = false;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = true;
                    this.numMinCO.Enabled = true;
                    break;

                case "rbMin":
                    this.txtMinite.Text = this.numMinStart.Value + "/" + this.numMinEvery.Value;
                    this.numMinStart.Enabled = true;
                    this.numMinEvery.Enabled = true;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    this.chkMin.Enabled = false;
                    break;

                case "rbMinAppoint":
                    this.txtMinite.Text = "*";
                    this.chkMin.Enabled = true;
                    this.numMinStart.Enabled = false;
                    this.numMinEvery.Enabled = false;
                    this.numMinCS.Enabled = false;
                    this.numMinCO.Enabled = false;
                    break;

                case "rbHourEvery":
                    this.txtHour.Text = "*";
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;

                case "rbHour":
                    this.txtHour.Text = this.numHourStart.Value + "/" + this.numHourEvery.Value;
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = true;
                    this.numHourEvery.Enabled = true;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;

                case "rbHourCycle":
                    this.txtHour.Text = this.numHourCS.Value + "-" + this.numHourCO.Value;
                    this.chkHour.Enabled = false;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = true;
                    this.numHourCO.Enabled = true;
                    break;

                case "rbHourAppoint":
                    this.txtHour.Text = "*";
                    this.chkHour.Enabled = true;
                    this.numHourStart.Enabled = false;
                    this.numHourEvery.Enabled = false;
                    this.numHourCS.Enabled = false;
                    this.numHourCO.Enabled = false;
                    break;

                case "rbDayEvery":
                case "rbDayNoAppoint":
                    this.txtDay.Text = (button.Name == "rbDayEvery") ? "*" : "?";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;

                case "rbDayCycle":
                    this.chkDay.Enabled = false;
                    this.txtDay.Text = this.numDayCS.Value + "-" + this.numDayCO.Value;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = true;
                    this.numDayCO.Enabled = true;
                    this.numDayW.Enabled = false;
                    break;

                case "rbDay":
                    this.chkDay.Enabled = false;
                    this.txtDay.Text = this.numDayStart.Value + "/" + this.numDayEvery.Value;
                    this.numDayStart.Enabled = true;
                    this.numDayEvery.Enabled = true;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    break;

                case "rbDayAppoint":
                    this.txtDay.Text = "*";
                    this.chkDay.Enabled = true;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;

                case "rbDayW":
                    this.txtDay.Text = this.numDayW.Value + "W";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = true;
                    break;

                case "rbDayL":
                    this.txtDay.Text = "L";
                    this.chkDay.Enabled = false;
                    this.numDayStart.Enabled = false;
                    this.numDayEvery.Enabled = false;
                    this.numDayCS.Enabled = false;
                    this.numDayCO.Enabled = false;
                    this.numDayW.Enabled = false;
                    break;

                case "rbMouthEvery":
                case "rbMouthNoAppoint":
                    this.txtMonth.Text = this.rbMouthEvery.Checked ? "*" : "?";
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;

                case "rbMouth":
                    this.txtMonth.Text = this.numMouthStart.Value + "/" + this.numMouthEvery.Value;
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = true;
                    this.numMouthStart.Enabled = true;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;

                case "rbMouthAppoint":
                    this.chkMouth.Enabled = true;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = false;
                    this.numMouthCS.Enabled = false;
                    break;

                case "rbMouthCycle":
                    this.txtMonth.Text = this.numMouthCS.Value + "-" + this.numMouthCO.Value;
                    this.chkMouth.Enabled = false;
                    this.numMouthEvery.Enabled = false;
                    this.numMouthStart.Enabled = false;
                    this.numMouthCO.Enabled = true;
                    this.numMouthCS.Enabled = true;
                    break;

                case "rbWeek":
                case "rbWeekNoAppoint":
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.txtWeek.Text = (button.Name == "rbWeek") ? "*" : "?";
                    this.chkWeek.Enabled = false;
                    break;

                case "rbWeekAppoint":
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.txtWeek.Text = "*";
                    this.chkWeek.Enabled = true;
                    break;

                case "rbWeekNumIn":
                case "rbWeekLast":
                    this.numWeek.Enabled = true;
                    this.numWeekCS.Enabled = false;
                    this.numWeekCO.Enabled = false;
                    this.chkWeek.Enabled = true;
                    this.chkWeek.ClearSelected();
                    this.chkWeek.SelectedIndex = 0;
                    break;

                case "rbWeekCycle":
                    this.txtWeek.Text = this.numWeekCS.Value + "/" + this.numWeekCO.Value;
                    this.numWeek.Enabled = false;
                    this.numWeekCS.Enabled = true;
                    this.numWeekCO.Enabled = true;
                    this.chkWeek.Enabled = false;
                    break;

                case "rbYear":
                case "rbYearNoAppoint":
                    this.txtYear.Text = this.rbYear.Checked ? "*" : "";
                    this.numYearCS.Enabled = false;
                    this.numYearCO.Enabled = false;
                    break;

                case "rbYearAppoint":
                    this.txtYear.Text = this.numYearCS.Value + "-" + this.numYearCO.Value;
                    this.numYearCS.Enabled = true;
                    this.numYearCO.Enabled = true;
                    break;
            }
        }

        private void tabTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabTime.SelectedTab.Name == "tabIntro")
            {
                this.tabTime.Dock = DockStyle.Fill;
                this.gb1.Visible = false;
            }
            else
            {
                this.tabTime.Dock = DockStyle.Top;
                this.gb1.Visible = true;
            }
        }

        private void txtChanged(object sender, EventArgs e)
        {
            string str = this.txtSecond.Text.Trim();
            string str2 = this.txtMinite.Text.Trim();
            string str3 = this.txtHour.Text.Trim();
            string str4 = this.txtDay.Text.Trim();
            string str5 = this.txtMonth.Text.Trim();
            string str6 = this.txtWeek.Text.Trim();
            string str7 = this.txtYear.Text.Trim();
            this.txtCron.Text = string.Format("{0} {1} {2} {3} {4} {5} {6}", new object[] { string.IsNullOrEmpty(str) ? "*" : str, string.IsNullOrEmpty(str2) ? "*" : str2, string.IsNullOrEmpty(str3) ? "*" : str3, string.IsNullOrEmpty(str4) ? "*" : str4, string.IsNullOrEmpty(str5) ? "*" : str5, string.IsNullOrEmpty(str6) ? "?" : str6, string.IsNullOrEmpty(str7) ? "" : str7 });
        }
    }
}
