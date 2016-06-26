using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    partial class CronEditor
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
        private ComponentResourceManager manager;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CronEditor));
            this.tabTime = new System.Windows.Forms.TabControl();
            this.tabSecond = new System.Windows.Forms.TabPage();
            this.numSecCO = new System.Windows.Forms.NumericUpDown();
            this.numSecCS = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.rbSecCycle = new System.Windows.Forms.RadioButton();
            this.rbSecEvery = new System.Windows.Forms.RadioButton();
            this.chkSec = new System.Windows.Forms.CheckedListBox();
            this.numSecEvery = new System.Windows.Forms.NumericUpDown();
            this.numSecStart = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.rbSecAppoint = new System.Windows.Forms.RadioButton();
            this.rbSec = new System.Windows.Forms.RadioButton();
            this.tabMinite = new System.Windows.Forms.TabPage();
            this.numMinCO = new System.Windows.Forms.NumericUpDown();
            this.numMinCS = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.rbMinCycle = new System.Windows.Forms.RadioButton();
            this.rbMinEvery = new System.Windows.Forms.RadioButton();
            this.chkMin = new System.Windows.Forms.CheckedListBox();
            this.numMinEvery = new System.Windows.Forms.NumericUpDown();
            this.numMinStart = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbMinAppoint = new System.Windows.Forms.RadioButton();
            this.rbMin = new System.Windows.Forms.RadioButton();
            this.tabHour = new System.Windows.Forms.TabPage();
            this.numHourCO = new System.Windows.Forms.NumericUpDown();
            this.numHourCS = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.rbHourCycle = new System.Windows.Forms.RadioButton();
            this.numHourEvery = new System.Windows.Forms.NumericUpDown();
            this.numHourStart = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.rbHour = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkHour = new System.Windows.Forms.CheckedListBox();
            this.rbHourAppoint = new System.Windows.Forms.RadioButton();
            this.rbHourEvery = new System.Windows.Forms.RadioButton();
            this.tabDay = new System.Windows.Forms.TabPage();
            this.rbDayL = new System.Windows.Forms.RadioButton();
            this.label34 = new System.Windows.Forms.Label();
            this.numDayW = new System.Windows.Forms.NumericUpDown();
            this.rbDayW = new System.Windows.Forms.RadioButton();
            this.numDayCO = new System.Windows.Forms.NumericUpDown();
            this.numDayCS = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.rbDayCycle = new System.Windows.Forms.RadioButton();
            this.numDayEvery = new System.Windows.Forms.NumericUpDown();
            this.numDayStart = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.rbDayNoAppoint = new System.Windows.Forms.RadioButton();
            this.chkDay = new System.Windows.Forms.CheckedListBox();
            this.rbDayAppoint = new System.Windows.Forms.RadioButton();
            this.rbDayEvery = new System.Windows.Forms.RadioButton();
            this.tabMouth = new System.Windows.Forms.TabPage();
            this.rbMouthNoAppoint = new System.Windows.Forms.RadioButton();
            this.rbMouthEvery = new System.Windows.Forms.RadioButton();
            this.numMouthEvery = new System.Windows.Forms.NumericUpDown();
            this.numMouthStart = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.rbMouthCycle = new System.Windows.Forms.RadioButton();
            this.numMouthCO = new System.Windows.Forms.NumericUpDown();
            this.numMouthCS = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.chkMouth = new System.Windows.Forms.CheckedListBox();
            this.rbMouthAppoint = new System.Windows.Forms.RadioButton();
            this.rbMouth = new System.Windows.Forms.RadioButton();
            this.tabWeek = new System.Windows.Forms.TabPage();
            this.rbWeekLast = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.numWeek = new System.Windows.Forms.NumericUpDown();
            this.rbWeekNumIn = new System.Windows.Forms.RadioButton();
            this.rbWeekNoAppoint = new System.Windows.Forms.RadioButton();
            this.rbWeekCycle = new System.Windows.Forms.RadioButton();
            this.numWeekCO = new System.Windows.Forms.NumericUpDown();
            this.numWeekCS = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.chkWeek = new System.Windows.Forms.CheckedListBox();
            this.rbWeekAppoint = new System.Windows.Forms.RadioButton();
            this.tabYear = new System.Windows.Forms.TabPage();
            this.rbYearNoAppoint = new System.Windows.Forms.RadioButton();
            this.rbYearAppoint = new System.Windows.Forms.RadioButton();
            this.numYearCO = new System.Windows.Forms.NumericUpDown();
            this.numYearCS = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.tabIntro = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCron = new System.Windows.Forms.TextBox();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMinite = new System.Windows.Forms.TextBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTime.SuspendLayout();
            this.tabSecond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecStart)).BeginInit();
            this.tabMinite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStart)).BeginInit();
            this.tabHour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHourCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourStart)).BeginInit();
            this.tabDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDayW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayStart)).BeginInit();
            this.tabMouth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthCS)).BeginInit();
            this.tabWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekCS)).BeginInit();
            this.tabYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearCO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearCS)).BeginInit();
            this.tabIntro.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTime
            // 
            this.tabTime.Controls.Add(this.tabSecond);
            this.tabTime.Controls.Add(this.tabMinite);
            this.tabTime.Controls.Add(this.tabHour);
            this.tabTime.Controls.Add(this.tabDay);
            this.tabTime.Controls.Add(this.tabMouth);
            this.tabTime.Controls.Add(this.tabWeek);
            this.tabTime.Controls.Add(this.tabYear);
            this.tabTime.Controls.Add(this.tabIntro);
            this.tabTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabTime.Location = new System.Drawing.Point(0, 0);
            this.tabTime.Margin = new System.Windows.Forms.Padding(4);
            this.tabTime.Name = "tabTime";
            this.tabTime.SelectedIndex = 0;
            this.tabTime.Size = new System.Drawing.Size(1085, 326);
            this.tabTime.TabIndex = 0;
            this.tabTime.SelectedIndexChanged += new System.EventHandler(this.tabTime_SelectedIndexChanged);
            // 
            // tabSecond
            // 
            this.tabSecond.Controls.Add(this.numSecCO);
            this.tabSecond.Controls.Add(this.numSecCS);
            this.tabSecond.Controls.Add(this.label35);
            this.tabSecond.Controls.Add(this.label36);
            this.tabSecond.Controls.Add(this.rbSecCycle);
            this.tabSecond.Controls.Add(this.rbSecEvery);
            this.tabSecond.Controls.Add(this.chkSec);
            this.tabSecond.Controls.Add(this.numSecEvery);
            this.tabSecond.Controls.Add(this.numSecStart);
            this.tabSecond.Controls.Add(this.label37);
            this.tabSecond.Controls.Add(this.label38);
            this.tabSecond.Controls.Add(this.rbSecAppoint);
            this.tabSecond.Controls.Add(this.rbSec);
            this.tabSecond.Location = new System.Drawing.Point(4, 25);
            this.tabSecond.Margin = new System.Windows.Forms.Padding(4);
            this.tabSecond.Name = "tabSecond";
            this.tabSecond.Padding = new System.Windows.Forms.Padding(4);
            this.tabSecond.Size = new System.Drawing.Size(1077, 297);
            this.tabSecond.TabIndex = 7;
            this.tabSecond.Text = "秒";
            this.tabSecond.UseVisualStyleBackColor = true;
            // 
            // numSecCO
            // 
            this.numSecCO.Enabled = false;
            this.numSecCO.Location = new System.Drawing.Point(156, 32);
            this.numSecCO.Margin = new System.Windows.Forms.Padding(4);
            this.numSecCO.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numSecCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSecCO.Name = "numSecCO";
            this.numSecCO.Size = new System.Drawing.Size(41, 25);
            this.numSecCO.TabIndex = 69;
            this.numSecCO.Tag = "numSecC";
            this.numSecCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSecCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numSecCS
            // 
            this.numSecCS.Enabled = false;
            this.numSecCS.Location = new System.Drawing.Point(93, 32);
            this.numSecCS.Margin = new System.Windows.Forms.Padding(4);
            this.numSecCS.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numSecCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSecCS.Name = "numSecCS";
            this.numSecCS.Size = new System.Drawing.Size(41, 25);
            this.numSecCS.TabIndex = 68;
            this.numSecCS.Tag = "numSecC";
            this.numSecCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSecCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(137, 38);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(15, 15);
            this.label35.TabIndex = 67;
            this.label35.Text = "-";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(201, 38);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(22, 15);
            this.label36.TabIndex = 66;
            this.label36.Text = "秒";
            // 
            // rbSecCycle
            // 
            this.rbSecCycle.AutoSize = true;
            this.rbSecCycle.Location = new System.Drawing.Point(11, 35);
            this.rbSecCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbSecCycle.Name = "rbSecCycle";
            this.rbSecCycle.Size = new System.Drawing.Size(73, 19);
            this.rbSecCycle.TabIndex = 65;
            this.rbSecCycle.Text = "周期从";
            this.rbSecCycle.UseVisualStyleBackColor = true;
            this.rbSecCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // rbSecEvery
            // 
            this.rbSecEvery.AutoSize = true;
            this.rbSecEvery.Checked = true;
            this.rbSecEvery.Location = new System.Drawing.Point(11, 8);
            this.rbSecEvery.Margin = new System.Windows.Forms.Padding(4);
            this.rbSecEvery.Name = "rbSecEvery";
            this.rbSecEvery.Size = new System.Drawing.Size(228, 19);
            this.rbSecEvery.TabIndex = 64;
            this.rbSecEvery.TabStop = true;
            this.rbSecEvery.Text = "每秒 允许的通配符[, - * /]";
            this.rbSecEvery.UseVisualStyleBackColor = true;
            this.rbSecEvery.Click += new System.EventHandler(this.rbClick);
            // 
            // chkSec
            // 
            this.chkSec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkSec.CheckOnClick = true;
            this.chkSec.ColumnWidth = 40;
            this.chkSec.Enabled = false;
            this.chkSec.FormattingEnabled = true;
            this.chkSec.Items.AddRange(new object[] {
            "1",
            "11",
            "21",
            "31",
            "41",
            "51",
            "2",
            "12",
            "22",
            "32",
            "42",
            "52",
            "3",
            "13",
            "23",
            "33",
            "43",
            "53",
            "4",
            "14",
            "24",
            "34",
            "44",
            "54",
            "5",
            "15",
            "25",
            "35",
            "45",
            "66",
            "6",
            "16",
            "26",
            "36",
            "46",
            "56",
            "7",
            "17",
            "27",
            "37",
            "47",
            "57",
            "8",
            "18",
            "28",
            "38",
            "48",
            "58",
            "9",
            "19",
            "29",
            "39",
            "49",
            "59",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.chkSec.Location = new System.Drawing.Point(35, 122);
            this.chkSec.Margin = new System.Windows.Forms.Padding(4);
            this.chkSec.MultiColumn = true;
            this.chkSec.Name = "chkSec";
            this.chkSec.Size = new System.Drawing.Size(597, 120);
            this.chkSec.TabIndex = 63;
            this.chkSec.TabStop = false;
            this.chkSec.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // numSecEvery
            // 
            this.numSecEvery.Enabled = false;
            this.numSecEvery.Location = new System.Drawing.Point(211, 64);
            this.numSecEvery.Margin = new System.Windows.Forms.Padding(4);
            this.numSecEvery.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numSecEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSecEvery.Name = "numSecEvery";
            this.numSecEvery.Size = new System.Drawing.Size(76, 25);
            this.numSecEvery.TabIndex = 62;
            this.numSecEvery.Tag = "numSec";
            this.numSecEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSecEvery.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numSecStart
            // 
            this.numSecStart.Enabled = false;
            this.numSecStart.Location = new System.Drawing.Point(55, 64);
            this.numSecStart.Margin = new System.Windows.Forms.Padding(4);
            this.numSecStart.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numSecStart.Name = "numSecStart";
            this.numSecStart.Size = new System.Drawing.Size(69, 25);
            this.numSecStart.TabIndex = 61;
            this.numSecStart.Tag = "numSec";
            this.numSecStart.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(289, 69);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(82, 15);
            this.label37.TabIndex = 60;
            this.label37.Text = "秒执行一次";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(129, 69);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(75, 15);
            this.label38.TabIndex = 59;
            this.label38.Text = "秒开始,每";
            // 
            // rbSecAppoint
            // 
            this.rbSecAppoint.AutoSize = true;
            this.rbSecAppoint.Location = new System.Drawing.Point(11, 95);
            this.rbSecAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbSecAppoint.Name = "rbSecAppoint";
            this.rbSecAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbSecAppoint.TabIndex = 58;
            this.rbSecAppoint.Text = "指定";
            this.rbSecAppoint.UseVisualStyleBackColor = true;
            this.rbSecAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbSec
            // 
            this.rbSec.AutoSize = true;
            this.rbSec.Location = new System.Drawing.Point(11, 66);
            this.rbSec.Margin = new System.Windows.Forms.Padding(4);
            this.rbSec.Name = "rbSec";
            this.rbSec.Size = new System.Drawing.Size(43, 19);
            this.rbSec.TabIndex = 57;
            this.rbSec.Text = "从";
            this.rbSec.UseVisualStyleBackColor = true;
            this.rbSec.Click += new System.EventHandler(this.rbClick);
            // 
            // tabMinite
            // 
            this.tabMinite.Controls.Add(this.numMinCO);
            this.tabMinite.Controls.Add(this.numMinCS);
            this.tabMinite.Controls.Add(this.label18);
            this.tabMinite.Controls.Add(this.label25);
            this.tabMinite.Controls.Add(this.rbMinCycle);
            this.tabMinite.Controls.Add(this.rbMinEvery);
            this.tabMinite.Controls.Add(this.chkMin);
            this.tabMinite.Controls.Add(this.numMinEvery);
            this.tabMinite.Controls.Add(this.numMinStart);
            this.tabMinite.Controls.Add(this.label11);
            this.tabMinite.Controls.Add(this.label10);
            this.tabMinite.Controls.Add(this.rbMinAppoint);
            this.tabMinite.Controls.Add(this.rbMin);
            this.tabMinite.Location = new System.Drawing.Point(4, 25);
            this.tabMinite.Margin = new System.Windows.Forms.Padding(4);
            this.tabMinite.Name = "tabMinite";
            this.tabMinite.Padding = new System.Windows.Forms.Padding(4);
            this.tabMinite.Size = new System.Drawing.Size(1077, 297);
            this.tabMinite.TabIndex = 0;
            this.tabMinite.Text = "分钟";
            this.tabMinite.UseVisualStyleBackColor = true;
            // 
            // numMinCO
            // 
            this.numMinCO.Enabled = false;
            this.numMinCO.Location = new System.Drawing.Point(156, 32);
            this.numMinCO.Margin = new System.Windows.Forms.Padding(4);
            this.numMinCO.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinCO.Name = "numMinCO";
            this.numMinCO.Size = new System.Drawing.Size(41, 25);
            this.numMinCO.TabIndex = 43;
            this.numMinCO.Tag = "numMinC";
            this.numMinCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numMinCS
            // 
            this.numMinCS.Enabled = false;
            this.numMinCS.Location = new System.Drawing.Point(93, 32);
            this.numMinCS.Margin = new System.Windows.Forms.Padding(4);
            this.numMinCS.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numMinCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinCS.Name = "numMinCS";
            this.numMinCS.Size = new System.Drawing.Size(41, 25);
            this.numMinCS.TabIndex = 42;
            this.numMinCS.Tag = "numMinC";
            this.numMinCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(137, 38);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 15);
            this.label18.TabIndex = 41;
            this.label18.Text = "-";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(201, 38);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(22, 15);
            this.label25.TabIndex = 40;
            this.label25.Text = "分";
            // 
            // rbMinCycle
            // 
            this.rbMinCycle.AutoSize = true;
            this.rbMinCycle.Location = new System.Drawing.Point(11, 35);
            this.rbMinCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbMinCycle.Name = "rbMinCycle";
            this.rbMinCycle.Size = new System.Drawing.Size(73, 19);
            this.rbMinCycle.TabIndex = 26;
            this.rbMinCycle.Text = "周期从";
            this.rbMinCycle.UseVisualStyleBackColor = true;
            this.rbMinCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // rbMinEvery
            // 
            this.rbMinEvery.AutoSize = true;
            this.rbMinEvery.Checked = true;
            this.rbMinEvery.Location = new System.Drawing.Point(11, 8);
            this.rbMinEvery.Margin = new System.Windows.Forms.Padding(4);
            this.rbMinEvery.Name = "rbMinEvery";
            this.rbMinEvery.Size = new System.Drawing.Size(243, 19);
            this.rbMinEvery.TabIndex = 25;
            this.rbMinEvery.TabStop = true;
            this.rbMinEvery.Text = "每分钟 允许的通配符[, - * /]";
            this.rbMinEvery.UseVisualStyleBackColor = true;
            this.rbMinEvery.Click += new System.EventHandler(this.rbClick);
            // 
            // chkMin
            // 
            this.chkMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkMin.CheckOnClick = true;
            this.chkMin.ColumnWidth = 40;
            this.chkMin.Enabled = false;
            this.chkMin.FormattingEnabled = true;
            this.chkMin.Items.AddRange(new object[] {
            "1",
            "11",
            "21",
            "31",
            "41",
            "51",
            "2",
            "12",
            "22",
            "32",
            "42",
            "52",
            "3",
            "13",
            "23",
            "33",
            "43",
            "53",
            "4",
            "14",
            "24",
            "34",
            "44",
            "54",
            "5",
            "15",
            "25",
            "35",
            "45",
            "66",
            "6",
            "16",
            "26",
            "36",
            "46",
            "56",
            "7",
            "17",
            "27",
            "37",
            "47",
            "57",
            "8",
            "18",
            "28",
            "38",
            "48",
            "58",
            "9",
            "19",
            "29",
            "39",
            "49",
            "59",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.chkMin.Location = new System.Drawing.Point(35, 122);
            this.chkMin.Margin = new System.Windows.Forms.Padding(4);
            this.chkMin.MultiColumn = true;
            this.chkMin.Name = "chkMin";
            this.chkMin.Size = new System.Drawing.Size(597, 120);
            this.chkMin.TabIndex = 18;
            this.chkMin.TabStop = false;
            this.chkMin.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // numMinEvery
            // 
            this.numMinEvery.Enabled = false;
            this.numMinEvery.Location = new System.Drawing.Point(224, 64);
            this.numMinEvery.Margin = new System.Windows.Forms.Padding(4);
            this.numMinEvery.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinEvery.Name = "numMinEvery";
            this.numMinEvery.Size = new System.Drawing.Size(76, 25);
            this.numMinEvery.TabIndex = 17;
            this.numMinEvery.Tag = "numMin";
            this.numMinEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinEvery.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numMinStart
            // 
            this.numMinStart.Enabled = false;
            this.numMinStart.Location = new System.Drawing.Point(55, 64);
            this.numMinStart.Margin = new System.Windows.Forms.Padding(4);
            this.numMinStart.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinStart.Name = "numMinStart";
            this.numMinStart.Size = new System.Drawing.Size(69, 25);
            this.numMinStart.TabIndex = 16;
            this.numMinStart.Tag = "numMin";
            this.numMinStart.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "分钟执行一次";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(129, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "分钟开始,每";
            // 
            // rbMinAppoint
            // 
            this.rbMinAppoint.AutoSize = true;
            this.rbMinAppoint.Location = new System.Drawing.Point(11, 95);
            this.rbMinAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbMinAppoint.Name = "rbMinAppoint";
            this.rbMinAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbMinAppoint.TabIndex = 1;
            this.rbMinAppoint.Text = "指定";
            this.rbMinAppoint.UseVisualStyleBackColor = true;
            this.rbMinAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbMin
            // 
            this.rbMin.AutoSize = true;
            this.rbMin.Location = new System.Drawing.Point(11, 66);
            this.rbMin.Margin = new System.Windows.Forms.Padding(4);
            this.rbMin.Name = "rbMin";
            this.rbMin.Size = new System.Drawing.Size(43, 19);
            this.rbMin.TabIndex = 0;
            this.rbMin.Text = "从";
            this.rbMin.UseVisualStyleBackColor = true;
            this.rbMin.Click += new System.EventHandler(this.rbClick);
            // 
            // tabHour
            // 
            this.tabHour.Controls.Add(this.numHourCO);
            this.tabHour.Controls.Add(this.numHourCS);
            this.tabHour.Controls.Add(this.label26);
            this.tabHour.Controls.Add(this.label27);
            this.tabHour.Controls.Add(this.rbHourCycle);
            this.tabHour.Controls.Add(this.numHourEvery);
            this.tabHour.Controls.Add(this.numHourStart);
            this.tabHour.Controls.Add(this.label28);
            this.tabHour.Controls.Add(this.label29);
            this.tabHour.Controls.Add(this.rbHour);
            this.tabHour.Controls.Add(this.label13);
            this.tabHour.Controls.Add(this.label12);
            this.tabHour.Controls.Add(this.chkHour);
            this.tabHour.Controls.Add(this.rbHourAppoint);
            this.tabHour.Controls.Add(this.rbHourEvery);
            this.tabHour.Location = new System.Drawing.Point(4, 25);
            this.tabHour.Margin = new System.Windows.Forms.Padding(4);
            this.tabHour.Name = "tabHour";
            this.tabHour.Padding = new System.Windows.Forms.Padding(4);
            this.tabHour.Size = new System.Drawing.Size(1077, 297);
            this.tabHour.TabIndex = 1;
            this.tabHour.Text = "小时";
            this.tabHour.UseVisualStyleBackColor = true;
            // 
            // numHourCO
            // 
            this.numHourCO.Enabled = false;
            this.numHourCO.Location = new System.Drawing.Point(156, 34);
            this.numHourCO.Margin = new System.Windows.Forms.Padding(4);
            this.numHourCO.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numHourCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHourCO.Name = "numHourCO";
            this.numHourCO.Size = new System.Drawing.Size(41, 25);
            this.numHourCO.TabIndex = 53;
            this.numHourCO.Tag = "numHourC";
            this.numHourCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHourCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numHourCS
            // 
            this.numHourCS.Enabled = false;
            this.numHourCS.Location = new System.Drawing.Point(93, 34);
            this.numHourCS.Margin = new System.Windows.Forms.Padding(4);
            this.numHourCS.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numHourCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHourCS.Name = "numHourCS";
            this.numHourCS.Size = new System.Drawing.Size(41, 25);
            this.numHourCS.TabIndex = 52;
            this.numHourCS.Tag = "numHourC";
            this.numHourCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHourCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(137, 39);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(15, 15);
            this.label26.TabIndex = 51;
            this.label26.Text = "-";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(201, 39);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 15);
            this.label27.TabIndex = 50;
            this.label27.Text = "小时";
            // 
            // rbHourCycle
            // 
            this.rbHourCycle.AutoSize = true;
            this.rbHourCycle.Location = new System.Drawing.Point(11, 36);
            this.rbHourCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbHourCycle.Name = "rbHourCycle";
            this.rbHourCycle.Size = new System.Drawing.Size(73, 19);
            this.rbHourCycle.TabIndex = 49;
            this.rbHourCycle.Text = "周期从";
            this.rbHourCycle.UseVisualStyleBackColor = true;
            this.rbHourCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // numHourEvery
            // 
            this.numHourEvery.Enabled = false;
            this.numHourEvery.Location = new System.Drawing.Point(224, 65);
            this.numHourEvery.Margin = new System.Windows.Forms.Padding(4);
            this.numHourEvery.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHourEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHourEvery.Name = "numHourEvery";
            this.numHourEvery.Size = new System.Drawing.Size(76, 25);
            this.numHourEvery.TabIndex = 48;
            this.numHourEvery.Tag = "numHour";
            this.numHourEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHourEvery.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numHourStart
            // 
            this.numHourStart.Enabled = false;
            this.numHourStart.Location = new System.Drawing.Point(55, 65);
            this.numHourStart.Margin = new System.Windows.Forms.Padding(4);
            this.numHourStart.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHourStart.Name = "numHourStart";
            this.numHourStart.Size = new System.Drawing.Size(69, 25);
            this.numHourStart.TabIndex = 47;
            this.numHourStart.Tag = "numHour";
            this.numHourStart.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(305, 70);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 15);
            this.label28.TabIndex = 46;
            this.label28.Text = "小时执行一次";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(129, 70);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 15);
            this.label29.TabIndex = 45;
            this.label29.Text = "点开始,每";
            // 
            // rbHour
            // 
            this.rbHour.AutoSize = true;
            this.rbHour.Location = new System.Drawing.Point(11, 68);
            this.rbHour.Margin = new System.Windows.Forms.Padding(4);
            this.rbHour.Name = "rbHour";
            this.rbHour.Size = new System.Drawing.Size(43, 19);
            this.rbHour.TabIndex = 44;
            this.rbHour.Text = "从";
            this.rbHour.UseVisualStyleBackColor = true;
            this.rbHour.Click += new System.EventHandler(this.rbClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 145);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "PM：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 125);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "AM：";
            // 
            // chkHour
            // 
            this.chkHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkHour.CheckOnClick = true;
            this.chkHour.ColumnWidth = 40;
            this.chkHour.Enabled = false;
            this.chkHour.FormattingEnabled = true;
            this.chkHour.Items.AddRange(new object[] {
            "1",
            "13",
            "2",
            "14",
            "3",
            "15",
            "4",
            "16",
            "5",
            "17",
            "6",
            "18",
            "7",
            "19",
            "8",
            "20",
            "9",
            "21",
            "10",
            "22",
            "11",
            "23",
            "12",
            "24"});
            this.chkHour.Location = new System.Drawing.Point(69, 124);
            this.chkHour.Margin = new System.Windows.Forms.Padding(4);
            this.chkHour.MultiColumn = true;
            this.chkHour.Name = "chkHour";
            this.chkHour.Size = new System.Drawing.Size(731, 40);
            this.chkHour.TabIndex = 21;
            this.chkHour.TabStop = false;
            this.chkHour.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // rbHourAppoint
            // 
            this.rbHourAppoint.AutoSize = true;
            this.rbHourAppoint.Location = new System.Drawing.Point(11, 96);
            this.rbHourAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbHourAppoint.Name = "rbHourAppoint";
            this.rbHourAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbHourAppoint.TabIndex = 20;
            this.rbHourAppoint.TabStop = true;
            this.rbHourAppoint.Text = "指定";
            this.rbHourAppoint.UseVisualStyleBackColor = true;
            this.rbHourAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbHourEvery
            // 
            this.rbHourEvery.AutoSize = true;
            this.rbHourEvery.Checked = true;
            this.rbHourEvery.Location = new System.Drawing.Point(11, 8);
            this.rbHourEvery.Margin = new System.Windows.Forms.Padding(4);
            this.rbHourEvery.Name = "rbHourEvery";
            this.rbHourEvery.Size = new System.Drawing.Size(243, 19);
            this.rbHourEvery.TabIndex = 19;
            this.rbHourEvery.TabStop = true;
            this.rbHourEvery.Text = "每小时 允许的通配符[, - * /]";
            this.rbHourEvery.UseVisualStyleBackColor = true;
            this.rbHourEvery.Click += new System.EventHandler(this.rbClick);
            // 
            // tabDay
            // 
            this.tabDay.Controls.Add(this.rbDayL);
            this.tabDay.Controls.Add(this.label34);
            this.tabDay.Controls.Add(this.numDayW);
            this.tabDay.Controls.Add(this.rbDayW);
            this.tabDay.Controls.Add(this.numDayCO);
            this.tabDay.Controls.Add(this.numDayCS);
            this.tabDay.Controls.Add(this.label30);
            this.tabDay.Controls.Add(this.label31);
            this.tabDay.Controls.Add(this.rbDayCycle);
            this.tabDay.Controls.Add(this.numDayEvery);
            this.tabDay.Controls.Add(this.numDayStart);
            this.tabDay.Controls.Add(this.label32);
            this.tabDay.Controls.Add(this.label33);
            this.tabDay.Controls.Add(this.rbDay);
            this.tabDay.Controls.Add(this.rbDayNoAppoint);
            this.tabDay.Controls.Add(this.chkDay);
            this.tabDay.Controls.Add(this.rbDayAppoint);
            this.tabDay.Controls.Add(this.rbDayEvery);
            this.tabDay.Location = new System.Drawing.Point(4, 25);
            this.tabDay.Margin = new System.Windows.Forms.Padding(4);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new System.Windows.Forms.Padding(4);
            this.tabDay.Size = new System.Drawing.Size(1077, 297);
            this.tabDay.TabIndex = 2;
            this.tabDay.Text = "日";
            this.tabDay.UseVisualStyleBackColor = true;
            // 
            // rbDayL
            // 
            this.rbDayL.AutoSize = true;
            this.rbDayL.Location = new System.Drawing.Point(12, 242);
            this.rbDayL.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayL.Name = "rbDayL";
            this.rbDayL.Size = new System.Drawing.Size(118, 19);
            this.rbDayL.TabIndex = 67;
            this.rbDayL.Text = "本月最后一天";
            this.rbDayL.UseVisualStyleBackColor = true;
            this.rbDayL.Click += new System.EventHandler(this.rbClick);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(116, 211);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(142, 15);
            this.label34.TabIndex = 66;
            this.label34.Text = "号最近的那个工作日";
            // 
            // numDayW
            // 
            this.numDayW.Enabled = false;
            this.numDayW.Location = new System.Drawing.Point(72, 206);
            this.numDayW.Margin = new System.Windows.Forms.Padding(4);
            this.numDayW.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numDayW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayW.Name = "numDayW";
            this.numDayW.Size = new System.Drawing.Size(41, 25);
            this.numDayW.TabIndex = 65;
            this.numDayW.Tag = "numDayW";
            this.numDayW.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayW.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // rbDayW
            // 
            this.rbDayW.AutoSize = true;
            this.rbDayW.Location = new System.Drawing.Point(12, 209);
            this.rbDayW.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayW.Name = "rbDayW";
            this.rbDayW.Size = new System.Drawing.Size(58, 19);
            this.rbDayW.TabIndex = 64;
            this.rbDayW.Text = "每月";
            this.rbDayW.UseVisualStyleBackColor = true;
            this.rbDayW.Click += new System.EventHandler(this.rbClick);
            // 
            // numDayCO
            // 
            this.numDayCO.Enabled = false;
            this.numDayCO.Location = new System.Drawing.Point(157, 138);
            this.numDayCO.Margin = new System.Windows.Forms.Padding(4);
            this.numDayCO.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numDayCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDayCO.Name = "numDayCO";
            this.numDayCO.Size = new System.Drawing.Size(41, 25);
            this.numDayCO.TabIndex = 63;
            this.numDayCO.Tag = "numDayC";
            this.numDayCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDayCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numDayCS
            // 
            this.numDayCS.Enabled = false;
            this.numDayCS.Location = new System.Drawing.Point(95, 138);
            this.numDayCS.Margin = new System.Windows.Forms.Padding(4);
            this.numDayCS.Maximum = new decimal(new int[] {
            58,
            0,
            0,
            0});
            this.numDayCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayCS.Name = "numDayCS";
            this.numDayCS.Size = new System.Drawing.Size(41, 25);
            this.numDayCS.TabIndex = 62;
            this.numDayCS.Tag = "numDayC";
            this.numDayCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(139, 142);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(15, 15);
            this.label30.TabIndex = 61;
            this.label30.Text = "-";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(203, 142);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(37, 15);
            this.label31.TabIndex = 60;
            this.label31.Text = "小时";
            // 
            // rbDayCycle
            // 
            this.rbDayCycle.AutoSize = true;
            this.rbDayCycle.Location = new System.Drawing.Point(12, 140);
            this.rbDayCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayCycle.Name = "rbDayCycle";
            this.rbDayCycle.Size = new System.Drawing.Size(73, 19);
            this.rbDayCycle.TabIndex = 59;
            this.rbDayCycle.Text = "周期从";
            this.rbDayCycle.UseVisualStyleBackColor = true;
            this.rbDayCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // numDayEvery
            // 
            this.numDayEvery.Enabled = false;
            this.numDayEvery.Location = new System.Drawing.Point(225, 169);
            this.numDayEvery.Margin = new System.Windows.Forms.Padding(4);
            this.numDayEvery.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDayEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayEvery.Name = "numDayEvery";
            this.numDayEvery.Size = new System.Drawing.Size(76, 25);
            this.numDayEvery.TabIndex = 58;
            this.numDayEvery.Tag = "numDay";
            this.numDayEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDayEvery.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numDayStart
            // 
            this.numDayStart.Enabled = false;
            this.numDayStart.Location = new System.Drawing.Point(56, 169);
            this.numDayStart.Margin = new System.Windows.Forms.Padding(4);
            this.numDayStart.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numDayStart.Name = "numDayStart";
            this.numDayStart.Size = new System.Drawing.Size(69, 25);
            this.numDayStart.TabIndex = 57;
            this.numDayStart.Tag = "numDay";
            this.numDayStart.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(307, 174);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 15);
            this.label32.TabIndex = 56;
            this.label32.Text = "天执行一次";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(131, 174);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 15);
            this.label33.TabIndex = 55;
            this.label33.Text = "日开始,每";
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Location = new System.Drawing.Point(12, 171);
            this.rbDay.Margin = new System.Windows.Forms.Padding(4);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(43, 19);
            this.rbDay.TabIndex = 54;
            this.rbDay.Text = "从";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.Click += new System.EventHandler(this.rbClick);
            // 
            // rbDayNoAppoint
            // 
            this.rbDayNoAppoint.AutoSize = true;
            this.rbDayNoAppoint.Location = new System.Drawing.Point(11, 35);
            this.rbDayNoAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayNoAppoint.Name = "rbDayNoAppoint";
            this.rbDayNoAppoint.Size = new System.Drawing.Size(73, 19);
            this.rbDayNoAppoint.TabIndex = 24;
            this.rbDayNoAppoint.TabStop = true;
            this.rbDayNoAppoint.Text = "不指定";
            this.rbDayNoAppoint.UseVisualStyleBackColor = true;
            this.rbDayNoAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // chkDay
            // 
            this.chkDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkDay.CheckOnClick = true;
            this.chkDay.ColumnWidth = 40;
            this.chkDay.Enabled = false;
            this.chkDay.FormattingEnabled = true;
            this.chkDay.Items.AddRange(new object[] {
            "1",
            "17",
            "2",
            "18",
            "3",
            "19",
            "4",
            "20",
            "5",
            "21",
            "6",
            "22",
            "7",
            "23",
            "8",
            "24",
            "9",
            "25",
            "10",
            "26",
            "11",
            "27",
            "12",
            "28",
            "13",
            "29",
            "14",
            "30",
            "15",
            "31",
            "16"});
            this.chkDay.Location = new System.Drawing.Point(35, 90);
            this.chkDay.Margin = new System.Windows.Forms.Padding(4);
            this.chkDay.MultiColumn = true;
            this.chkDay.Name = "chkDay";
            this.chkDay.Size = new System.Drawing.Size(877, 40);
            this.chkDay.TabIndex = 23;
            this.chkDay.TabStop = false;
            this.chkDay.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // rbDayAppoint
            // 
            this.rbDayAppoint.AutoSize = true;
            this.rbDayAppoint.Location = new System.Drawing.Point(11, 62);
            this.rbDayAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayAppoint.Name = "rbDayAppoint";
            this.rbDayAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbDayAppoint.TabIndex = 22;
            this.rbDayAppoint.TabStop = true;
            this.rbDayAppoint.Text = "指定";
            this.rbDayAppoint.UseVisualStyleBackColor = true;
            this.rbDayAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbDayEvery
            // 
            this.rbDayEvery.AutoSize = true;
            this.rbDayEvery.Checked = true;
            this.rbDayEvery.Location = new System.Drawing.Point(11, 8);
            this.rbDayEvery.Margin = new System.Windows.Forms.Padding(4);
            this.rbDayEvery.Name = "rbDayEvery";
            this.rbDayEvery.Size = new System.Drawing.Size(284, 19);
            this.rbDayEvery.TabIndex = 21;
            this.rbDayEvery.TabStop = true;
            this.rbDayEvery.Text = "每日 允许的通配符[ , - * ? / L W]";
            this.rbDayEvery.UseVisualStyleBackColor = true;
            this.rbDayEvery.Click += new System.EventHandler(this.rbClick);
            // 
            // tabMouth
            // 
            this.tabMouth.Controls.Add(this.rbMouthNoAppoint);
            this.tabMouth.Controls.Add(this.rbMouthEvery);
            this.tabMouth.Controls.Add(this.numMouthEvery);
            this.tabMouth.Controls.Add(this.numMouthStart);
            this.tabMouth.Controls.Add(this.label9);
            this.tabMouth.Controls.Add(this.label24);
            this.tabMouth.Controls.Add(this.rbMouthCycle);
            this.tabMouth.Controls.Add(this.numMouthCO);
            this.tabMouth.Controls.Add(this.numMouthCS);
            this.tabMouth.Controls.Add(this.label22);
            this.tabMouth.Controls.Add(this.label23);
            this.tabMouth.Controls.Add(this.chkMouth);
            this.tabMouth.Controls.Add(this.rbMouthAppoint);
            this.tabMouth.Controls.Add(this.rbMouth);
            this.tabMouth.Location = new System.Drawing.Point(4, 25);
            this.tabMouth.Margin = new System.Windows.Forms.Padding(4);
            this.tabMouth.Name = "tabMouth";
            this.tabMouth.Size = new System.Drawing.Size(1077, 297);
            this.tabMouth.TabIndex = 3;
            this.tabMouth.Text = "月";
            this.tabMouth.UseVisualStyleBackColor = true;
            // 
            // rbMouthNoAppoint
            // 
            this.rbMouthNoAppoint.AutoSize = true;
            this.rbMouthNoAppoint.Location = new System.Drawing.Point(11, 39);
            this.rbMouthNoAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbMouthNoAppoint.Name = "rbMouthNoAppoint";
            this.rbMouthNoAppoint.Size = new System.Drawing.Size(73, 19);
            this.rbMouthNoAppoint.TabIndex = 46;
            this.rbMouthNoAppoint.Text = "不指定";
            this.rbMouthNoAppoint.UseVisualStyleBackColor = true;
            this.rbMouthNoAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbMouthEvery
            // 
            this.rbMouthEvery.AutoSize = true;
            this.rbMouthEvery.Checked = true;
            this.rbMouthEvery.Location = new System.Drawing.Point(11, 8);
            this.rbMouthEvery.Margin = new System.Windows.Forms.Padding(4);
            this.rbMouthEvery.Name = "rbMouthEvery";
            this.rbMouthEvery.Size = new System.Drawing.Size(236, 19);
            this.rbMouthEvery.TabIndex = 45;
            this.rbMouthEvery.TabStop = true;
            this.rbMouthEvery.Text = "每月 允许的通配符[ , - * /]";
            this.rbMouthEvery.UseVisualStyleBackColor = true;
            this.rbMouthEvery.Click += new System.EventHandler(this.rbClick);
            // 
            // numMouthEvery
            // 
            this.numMouthEvery.Location = new System.Drawing.Point(211, 68);
            this.numMouthEvery.Margin = new System.Windows.Forms.Padding(4);
            this.numMouthEvery.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMouthEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMouthEvery.Name = "numMouthEvery";
            this.numMouthEvery.Size = new System.Drawing.Size(57, 25);
            this.numMouthEvery.TabIndex = 44;
            this.numMouthEvery.Tag = "numMouth";
            this.numMouthEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMouthEvery.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numMouthStart
            // 
            this.numMouthStart.Location = new System.Drawing.Point(57, 68);
            this.numMouthStart.Margin = new System.Windows.Forms.Padding(4);
            this.numMouthStart.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMouthStart.Name = "numMouthStart";
            this.numMouthStart.Size = new System.Drawing.Size(69, 25);
            this.numMouthStart.TabIndex = 43;
            this.numMouthStart.Tag = "numMouth";
            this.numMouthStart.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 42;
            this.label9.Text = "个月执行一次";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(132, 72);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(75, 15);
            this.label24.TabIndex = 41;
            this.label24.Text = "日开始,每";
            // 
            // rbMouthCycle
            // 
            this.rbMouthCycle.AutoSize = true;
            this.rbMouthCycle.Location = new System.Drawing.Point(11, 132);
            this.rbMouthCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbMouthCycle.Name = "rbMouthCycle";
            this.rbMouthCycle.Size = new System.Drawing.Size(73, 19);
            this.rbMouthCycle.TabIndex = 40;
            this.rbMouthCycle.Text = "周期从";
            this.rbMouthCycle.UseVisualStyleBackColor = true;
            this.rbMouthCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // numMouthCO
            // 
            this.numMouthCO.Enabled = false;
            this.numMouthCO.Location = new System.Drawing.Point(152, 130);
            this.numMouthCO.Margin = new System.Windows.Forms.Padding(4);
            this.numMouthCO.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMouthCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMouthCO.Name = "numMouthCO";
            this.numMouthCO.Size = new System.Drawing.Size(41, 25);
            this.numMouthCO.TabIndex = 39;
            this.numMouthCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMouthCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numMouthCS
            // 
            this.numMouthCS.Enabled = false;
            this.numMouthCS.Location = new System.Drawing.Point(89, 130);
            this.numMouthCS.Margin = new System.Windows.Forms.Padding(4);
            this.numMouthCS.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numMouthCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMouthCS.Name = "numMouthCS";
            this.numMouthCS.Size = new System.Drawing.Size(41, 25);
            this.numMouthCS.TabIndex = 38;
            this.numMouthCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMouthCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(133, 135);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 15);
            this.label22.TabIndex = 37;
            this.label22.Text = "-";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(197, 135);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(22, 15);
            this.label23.TabIndex = 36;
            this.label23.Text = "月";
            // 
            // chkMouth
            // 
            this.chkMouth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkMouth.CheckOnClick = true;
            this.chkMouth.ColumnWidth = 40;
            this.chkMouth.Enabled = false;
            this.chkMouth.FormattingEnabled = true;
            this.chkMouth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.chkMouth.Location = new System.Drawing.Point(81, 101);
            this.chkMouth.Margin = new System.Windows.Forms.Padding(4);
            this.chkMouth.MultiColumn = true;
            this.chkMouth.Name = "chkMouth";
            this.chkMouth.Size = new System.Drawing.Size(683, 20);
            this.chkMouth.TabIndex = 26;
            this.chkMouth.TabStop = false;
            this.chkMouth.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // rbMouthAppoint
            // 
            this.rbMouthAppoint.AutoSize = true;
            this.rbMouthAppoint.Location = new System.Drawing.Point(11, 101);
            this.rbMouthAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbMouthAppoint.Name = "rbMouthAppoint";
            this.rbMouthAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbMouthAppoint.TabIndex = 25;
            this.rbMouthAppoint.Text = "指定";
            this.rbMouthAppoint.UseVisualStyleBackColor = true;
            this.rbMouthAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbMouth
            // 
            this.rbMouth.AutoSize = true;
            this.rbMouth.Location = new System.Drawing.Point(11, 70);
            this.rbMouth.Margin = new System.Windows.Forms.Padding(4);
            this.rbMouth.Name = "rbMouth";
            this.rbMouth.Size = new System.Drawing.Size(43, 19);
            this.rbMouth.TabIndex = 24;
            this.rbMouth.Text = "从";
            this.rbMouth.UseVisualStyleBackColor = true;
            this.rbMouth.Click += new System.EventHandler(this.rbClick);
            // 
            // tabWeek
            // 
            this.tabWeek.Controls.Add(this.rbWeekLast);
            this.tabWeek.Controls.Add(this.rbWeek);
            this.tabWeek.Controls.Add(this.label19);
            this.tabWeek.Controls.Add(this.numWeek);
            this.tabWeek.Controls.Add(this.rbWeekNumIn);
            this.tabWeek.Controls.Add(this.rbWeekNoAppoint);
            this.tabWeek.Controls.Add(this.rbWeekCycle);
            this.tabWeek.Controls.Add(this.numWeekCO);
            this.tabWeek.Controls.Add(this.numWeekCS);
            this.tabWeek.Controls.Add(this.label20);
            this.tabWeek.Controls.Add(this.label21);
            this.tabWeek.Controls.Add(this.chkWeek);
            this.tabWeek.Controls.Add(this.rbWeekAppoint);
            this.tabWeek.Location = new System.Drawing.Point(4, 25);
            this.tabWeek.Margin = new System.Windows.Forms.Padding(4);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Size = new System.Drawing.Size(1077, 297);
            this.tabWeek.TabIndex = 4;
            this.tabWeek.Text = "周";
            this.tabWeek.UseVisualStyleBackColor = true;
            // 
            // rbWeekLast
            // 
            this.rbWeekLast.AutoSize = true;
            this.rbWeekLast.Location = new System.Drawing.Point(231, 69);
            this.rbWeekLast.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekLast.Name = "rbWeekLast";
            this.rbWeekLast.Size = new System.Drawing.Size(163, 19);
            this.rbWeekLast.TabIndex = 41;
            this.rbWeekLast.Text = "本月最后一个星期几";
            this.rbWeekLast.UseVisualStyleBackColor = true;
            this.rbWeekLast.Click += new System.EventHandler(this.rbClick);
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Checked = true;
            this.rbWeek.Location = new System.Drawing.Point(11, 8);
            this.rbWeek.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(284, 19);
            this.rbWeek.TabIndex = 40;
            this.rbWeek.TabStop = true;
            this.rbWeek.Text = "每周 允许的通配符[ , - * ? / L #]";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.Click += new System.EventHandler(this.rbClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(181, 71);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 15);
            this.label19.TabIndex = 39;
            this.label19.Text = "周";
            // 
            // numWeek
            // 
            this.numWeek.Enabled = false;
            this.numWeek.Location = new System.Drawing.Point(136, 66);
            this.numWeek.Margin = new System.Windows.Forms.Padding(4);
            this.numWeek.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeek.Name = "numWeek";
            this.numWeek.Size = new System.Drawing.Size(41, 25);
            this.numWeek.TabIndex = 38;
            this.numWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbWeekNumIn
            // 
            this.rbWeekNumIn.AutoSize = true;
            this.rbWeekNumIn.Location = new System.Drawing.Point(89, 69);
            this.rbWeekNumIn.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekNumIn.Name = "rbWeekNumIn";
            this.rbWeekNumIn.Size = new System.Drawing.Size(43, 19);
            this.rbWeekNumIn.TabIndex = 37;
            this.rbWeekNumIn.Text = "第";
            this.rbWeekNumIn.UseVisualStyleBackColor = true;
            this.rbWeekNumIn.Click += new System.EventHandler(this.rbClick);
            // 
            // rbWeekNoAppoint
            // 
            this.rbWeekNoAppoint.AutoSize = true;
            this.rbWeekNoAppoint.Location = new System.Drawing.Point(11, 39);
            this.rbWeekNoAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekNoAppoint.Name = "rbWeekNoAppoint";
            this.rbWeekNoAppoint.Size = new System.Drawing.Size(73, 19);
            this.rbWeekNoAppoint.TabIndex = 36;
            this.rbWeekNoAppoint.Text = "不指定";
            this.rbWeekNoAppoint.UseVisualStyleBackColor = true;
            this.rbWeekNoAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbWeekCycle
            // 
            this.rbWeekCycle.AutoSize = true;
            this.rbWeekCycle.Location = new System.Drawing.Point(11, 126);
            this.rbWeekCycle.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekCycle.Name = "rbWeekCycle";
            this.rbWeekCycle.Size = new System.Drawing.Size(58, 19);
            this.rbWeekCycle.TabIndex = 35;
            this.rbWeekCycle.Text = "周期";
            this.rbWeekCycle.UseVisualStyleBackColor = true;
            this.rbWeekCycle.Click += new System.EventHandler(this.rbClick);
            // 
            // numWeekCO
            // 
            this.numWeekCO.Enabled = false;
            this.numWeekCO.Location = new System.Drawing.Point(188, 124);
            this.numWeekCO.Margin = new System.Windows.Forms.Padding(4);
            this.numWeekCO.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numWeekCO.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWeekCO.Name = "numWeekCO";
            this.numWeekCO.Size = new System.Drawing.Size(41, 25);
            this.numWeekCO.TabIndex = 34;
            this.numWeekCO.Tag = "numWeekC";
            this.numWeekCO.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWeekCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numWeekCS
            // 
            this.numWeekCS.Enabled = false;
            this.numWeekCS.Location = new System.Drawing.Point(124, 124);
            this.numWeekCS.Margin = new System.Windows.Forms.Padding(4);
            this.numWeekCS.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numWeekCS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekCS.Name = "numWeekCS";
            this.numWeekCS.Size = new System.Drawing.Size(41, 25);
            this.numWeekCS.TabIndex = 33;
            this.numWeekCS.Tag = "numWeekC";
            this.numWeekCS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeekCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(169, 129);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 15);
            this.label20.TabIndex = 31;
            this.label20.Text = "-";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(69, 129);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 15);
            this.label21.TabIndex = 30;
            this.label21.Text = "从星期";
            // 
            // chkWeek
            // 
            this.chkWeek.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkWeek.CheckOnClick = true;
            this.chkWeek.ColumnWidth = 50;
            this.chkWeek.FormattingEnabled = true;
            this.chkWeek.Items.AddRange(new object[] {
            "SUN",
            "MON",
            "TUES",
            "WED",
            "THUR",
            "FRI",
            "SAT"});
            this.chkWeek.Location = new System.Drawing.Point(35, 96);
            this.chkWeek.Margin = new System.Windows.Forms.Padding(4);
            this.chkWeek.MultiColumn = true;
            this.chkWeek.Name = "chkWeek";
            this.chkWeek.Size = new System.Drawing.Size(487, 20);
            this.chkWeek.TabIndex = 29;
            this.chkWeek.TabStop = false;
            this.chkWeek.SelectedValueChanged += new System.EventHandler(this.chk_SelectedValueChanged);
            // 
            // rbWeekAppoint
            // 
            this.rbWeekAppoint.AutoSize = true;
            this.rbWeekAppoint.Location = new System.Drawing.Point(11, 69);
            this.rbWeekAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekAppoint.Name = "rbWeekAppoint";
            this.rbWeekAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbWeekAppoint.TabIndex = 28;
            this.rbWeekAppoint.Text = "指定";
            this.rbWeekAppoint.UseVisualStyleBackColor = true;
            this.rbWeekAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // tabYear
            // 
            this.tabYear.Controls.Add(this.rbYearNoAppoint);
            this.tabYear.Controls.Add(this.rbYearAppoint);
            this.tabYear.Controls.Add(this.numYearCO);
            this.tabYear.Controls.Add(this.numYearCS);
            this.tabYear.Controls.Add(this.label15);
            this.tabYear.Controls.Add(this.label16);
            this.tabYear.Controls.Add(this.label17);
            this.tabYear.Controls.Add(this.rbYear);
            this.tabYear.Location = new System.Drawing.Point(4, 25);
            this.tabYear.Margin = new System.Windows.Forms.Padding(4);
            this.tabYear.Name = "tabYear";
            this.tabYear.Padding = new System.Windows.Forms.Padding(4);
            this.tabYear.Size = new System.Drawing.Size(1077, 297);
            this.tabYear.TabIndex = 5;
            this.tabYear.Text = "年";
            this.tabYear.UseVisualStyleBackColor = true;
            // 
            // rbYearNoAppoint
            // 
            this.rbYearNoAppoint.AutoSize = true;
            this.rbYearNoAppoint.Checked = true;
            this.rbYearNoAppoint.Location = new System.Drawing.Point(11, 8);
            this.rbYearNoAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbYearNoAppoint.Name = "rbYearNoAppoint";
            this.rbYearNoAppoint.Size = new System.Drawing.Size(296, 19);
            this.rbYearNoAppoint.TabIndex = 25;
            this.rbYearNoAppoint.TabStop = true;
            this.rbYearNoAppoint.Text = "未指定 允许的通配符[, - * /] 非必填";
            this.rbYearNoAppoint.UseVisualStyleBackColor = true;
            this.rbYearNoAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // rbYearAppoint
            // 
            this.rbYearAppoint.AutoSize = true;
            this.rbYearAppoint.Location = new System.Drawing.Point(11, 64);
            this.rbYearAppoint.Margin = new System.Windows.Forms.Padding(4);
            this.rbYearAppoint.Name = "rbYearAppoint";
            this.rbYearAppoint.Size = new System.Drawing.Size(58, 19);
            this.rbYearAppoint.TabIndex = 24;
            this.rbYearAppoint.Text = "周期";
            this.rbYearAppoint.UseVisualStyleBackColor = true;
            this.rbYearAppoint.Click += new System.EventHandler(this.rbClick);
            // 
            // numYearCO
            // 
            this.numYearCO.Enabled = false;
            this.numYearCO.Location = new System.Drawing.Point(188, 61);
            this.numYearCO.Margin = new System.Windows.Forms.Padding(4);
            this.numYearCO.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numYearCO.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearCO.Name = "numYearCO";
            this.numYearCO.Size = new System.Drawing.Size(76, 25);
            this.numYearCO.TabIndex = 23;
            this.numYearCO.Tag = "numYearC";
            this.numYearCO.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYearCO.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numYearCS
            // 
            this.numYearCS.Enabled = false;
            this.numYearCS.Location = new System.Drawing.Point(92, 61);
            this.numYearCS.Margin = new System.Windows.Forms.Padding(4);
            this.numYearCS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numYearCS.Name = "numYearCS";
            this.numYearCS.Size = new System.Drawing.Size(69, 25);
            this.numYearCS.TabIndex = 22;
            this.numYearCS.Tag = "numYearC";
            this.numYearCS.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(269, 66);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 15);
            this.label15.TabIndex = 21;
            this.label15.Text = "年";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 66);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(69, 66);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 15);
            this.label17.TabIndex = 19;
            this.label17.Text = "从";
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Location = new System.Drawing.Point(11, 34);
            this.rbYear.Margin = new System.Windows.Forms.Padding(4);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(58, 19);
            this.rbYear.TabIndex = 18;
            this.rbYear.Text = "每年";
            this.rbYear.UseVisualStyleBackColor = true;
            this.rbYear.Click += new System.EventHandler(this.rbClick);
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.textBox1);
            this.tabIntro.Location = new System.Drawing.Point(4, 25);
            this.tabIntro.Margin = new System.Windows.Forms.Padding(4);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Padding = new System.Windows.Forms.Padding(4);
            this.tabIntro.Size = new System.Drawing.Size(1077, 297);
            this.tabIntro.TabIndex = 6;
            this.tabIntro.Text = "cron-expression说明";
            this.tabIntro.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(1069, 289);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label14);
            this.gb1.Controls.Add(this.txtYear);
            this.gb1.Controls.Add(this.btnCopy);
            this.gb1.Controls.Add(this.label8);
            this.gb1.Controls.Add(this.label7);
            this.gb1.Controls.Add(this.label6);
            this.gb1.Controls.Add(this.label5);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.label4);
            this.gb1.Controls.Add(this.txtCron);
            this.gb1.Controls.Add(this.txtWeek);
            this.gb1.Controls.Add(this.txtMonth);
            this.gb1.Controls.Add(this.txtDay);
            this.gb1.Controls.Add(this.txtHour);
            this.gb1.Controls.Add(this.txtMinite);
            this.gb1.Controls.Add(this.txtSecond);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb1.Location = new System.Drawing.Point(0, 326);
            this.gb1.Margin = new System.Windows.Forms.Padding(4);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4);
            this.gb1.Size = new System.Drawing.Size(1085, 145);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            this.gb1.Text = "表达式";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(940, 36);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 15);
            this.label14.TabIndex = 20;
            this.label14.Text = "年";
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(943, 68);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(133, 25);
            this.txtYear.TabIndex = 19;
            this.txtYear.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1004, 100);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(72, 29);
            this.btnCopy.TabIndex = 17;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(253, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "分钟";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(803, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "星期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(665, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "月";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "小时";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "日";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "秒";
            // 
            // txtCron
            // 
            this.txtCron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCron.Location = new System.Drawing.Point(119, 102);
            this.txtCron.Margin = new System.Windows.Forms.Padding(4);
            this.txtCron.Name = "txtCron";
            this.txtCron.Size = new System.Drawing.Size(877, 25);
            this.txtCron.TabIndex = 9;
            // 
            // txtWeek
            // 
            this.txtWeek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeek.Location = new System.Drawing.Point(805, 68);
            this.txtWeek.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.Size = new System.Drawing.Size(133, 25);
            this.txtWeek.TabIndex = 8;
            this.txtWeek.Text = "*";
            this.txtWeek.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtMonth
            // 
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.Location = new System.Drawing.Point(668, 68);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(133, 25);
            this.txtMonth.TabIndex = 7;
            this.txtMonth.Text = "*";
            this.txtMonth.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtDay
            // 
            this.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDay.Location = new System.Drawing.Point(531, 68);
            this.txtDay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(133, 25);
            this.txtDay.TabIndex = 6;
            this.txtDay.Text = "*";
            this.txtDay.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtHour
            // 
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHour.Location = new System.Drawing.Point(393, 68);
            this.txtHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(133, 25);
            this.txtHour.TabIndex = 5;
            this.txtHour.Text = "*";
            this.txtHour.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtMinite
            // 
            this.txtMinite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinite.Location = new System.Drawing.Point(256, 68);
            this.txtMinite.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinite.Name = "txtMinite";
            this.txtMinite.Size = new System.Drawing.Size(133, 25);
            this.txtMinite.TabIndex = 4;
            this.txtMinite.Text = "*";
            this.txtMinite.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtSecond
            // 
            this.txtSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecond.Location = new System.Drawing.Point(119, 68);
            this.txtSecond.Margin = new System.Windows.Forms.Padding(4);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(133, 25);
            this.txtSecond.TabIndex = 3;
            this.txtSecond.Text = "*";
            this.txtSecond.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cron表达式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "表达式字段：";
            // 
            // CronEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 481);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.tabTime);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1101, 526);
            this.Name = "CronEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quartz Cron 生成工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabTime.ResumeLayout(false);
            this.tabSecond.ResumeLayout(false);
            this.tabSecond.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecStart)).EndInit();
            this.tabMinite.ResumeLayout(false);
            this.tabMinite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStart)).EndInit();
            this.tabHour.ResumeLayout(false);
            this.tabHour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHourCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHourStart)).EndInit();
            this.tabDay.ResumeLayout(false);
            this.tabDay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDayW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayStart)).EndInit();
            this.tabMouth.ResumeLayout(false);
            this.tabMouth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMouthCS)).EndInit();
            this.tabWeek.ResumeLayout(false);
            this.tabWeek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeekCS)).EndInit();
            this.tabYear.ResumeLayout(false);
            this.tabYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearCO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearCS)).EndInit();
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.CheckedListBox chkDay;
        private System.Windows.Forms.CheckedListBox chkHour;
        private System.Windows.Forms.CheckedListBox chkMin;
        private System.Windows.Forms.CheckedListBox chkMouth;
        private System.Windows.Forms.CheckedListBox chkSec;
        private System.Windows.Forms.CheckedListBox chkWeek;

        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numDayCO;
        private System.Windows.Forms.NumericUpDown numDayCS;
        private System.Windows.Forms.NumericUpDown numDayEvery;
        private System.Windows.Forms.NumericUpDown numDayStart;
        private System.Windows.Forms.NumericUpDown numDayW;
        private System.Windows.Forms.NumericUpDown numHourCO;
        private System.Windows.Forms.NumericUpDown numHourCS;
        private System.Windows.Forms.NumericUpDown numHourEvery;
        private System.Windows.Forms.NumericUpDown numHourStart;
        private System.Windows.Forms.NumericUpDown numMinCO;
        private System.Windows.Forms.NumericUpDown numMinCS;
        private System.Windows.Forms.NumericUpDown numMinEvery;
        private System.Windows.Forms.NumericUpDown numMinStart;
        private System.Windows.Forms.NumericUpDown numMouthCO;
        private System.Windows.Forms.NumericUpDown numMouthCS;
        private System.Windows.Forms.NumericUpDown numMouthEvery;
        private System.Windows.Forms.NumericUpDown numMouthStart;
        private System.Windows.Forms.NumericUpDown numSecCO;
        private System.Windows.Forms.NumericUpDown numSecCS;
        private System.Windows.Forms.NumericUpDown numSecEvery;
        private System.Windows.Forms.NumericUpDown numSecStart;
        private System.Windows.Forms.NumericUpDown numWeek;
        private System.Windows.Forms.NumericUpDown numWeekCO;
        private System.Windows.Forms.NumericUpDown numWeekCS;
        private System.Windows.Forms.NumericUpDown numYearCO;
        private System.Windows.Forms.NumericUpDown numYearCS;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.RadioButton rbDayAppoint;
        private System.Windows.Forms.RadioButton rbDayCycle;
        private System.Windows.Forms.RadioButton rbDayEvery;
        private System.Windows.Forms.RadioButton rbDayL;
        private System.Windows.Forms.RadioButton rbDayNoAppoint;
        private System.Windows.Forms.RadioButton rbDayW;
        private System.Windows.Forms.RadioButton rbHour;
        private System.Windows.Forms.RadioButton rbHourAppoint;
        private System.Windows.Forms.RadioButton rbHourCycle;
        private System.Windows.Forms.RadioButton rbHourEvery;
        private System.Windows.Forms.RadioButton rbMin;
        private System.Windows.Forms.RadioButton rbMinAppoint;
        private System.Windows.Forms.RadioButton rbMinCycle;
        private System.Windows.Forms.RadioButton rbMinEvery;
        private System.Windows.Forms.RadioButton rbMouth;
        private System.Windows.Forms.RadioButton rbMouthAppoint;
        private System.Windows.Forms.RadioButton rbMouthCycle;
        private System.Windows.Forms.RadioButton rbMouthEvery;
        private System.Windows.Forms.RadioButton rbMouthNoAppoint;
        private System.Windows.Forms.RadioButton rbSec;
        private System.Windows.Forms.RadioButton rbSecAppoint;
        private System.Windows.Forms.RadioButton rbSecCycle;
        private System.Windows.Forms.RadioButton rbSecEvery;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbWeekAppoint;
        private System.Windows.Forms.RadioButton rbWeekCycle;
        private System.Windows.Forms.RadioButton rbWeekLast;
        private System.Windows.Forms.RadioButton rbWeekNoAppoint;
        private System.Windows.Forms.RadioButton rbWeekNumIn;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbYearAppoint;
        private System.Windows.Forms.RadioButton rbYearNoAppoint;
        private System.Windows.Forms.TabPage tabDay;
        private System.Windows.Forms.TabPage tabHour;
        private System.Windows.Forms.TabPage tabIntro;
        private System.Windows.Forms.TabPage tabMinite;
        private System.Windows.Forms.TabPage tabMouth;
        private System.Windows.Forms.TabPage tabSecond;
        private System.Windows.Forms.TabControl tabTime;
        private System.Windows.Forms.TabPage tabWeek;
        private System.Windows.Forms.TabPage tabYear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCron;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.TextBox txtMinite;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.TextBox txtWeek;
        private System.Windows.Forms.TextBox txtYear;
    }
}