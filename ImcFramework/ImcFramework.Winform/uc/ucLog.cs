using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImcFramework.WcfInterface;
using ImcFramework.Infrastructure;
using ImcFramework.WcfInterface.LogInfos;

namespace ImcFramework.Winform
{
    public partial class ucLog : UserControl
    {
        public ucLog()
        {
            InitializeComponent();
        }

        //查询详细事件
        public event EventHandler<RequestLogArgs> GetLogDetailClick;

        //初始化日期
        public void AddLogDateNode(LogInfo[] logInfos)
        {
            foreach (var logInfo in logInfos)
            {
                var rootNode = new TreeNode(logInfo.DateString);
                
                rootNode.ImageIndex = 0;
                rootNode.SelectedImageIndex = 0;

                var groupByList = logInfo.UserLogLevels.GroupBy(zw => zw.User);
                foreach (var sellerAccountItem in groupByList)
                {
                    var secondNode = new TreeNode(sellerAccountItem.Key);
                    secondNode.ImageIndex = 2;
                    secondNode.SelectedImageIndex = 2;

                    foreach (var level in sellerAccountItem.OrderBy(zw => zw.LogLevel))
                    {
                        var thirdNode = new TreeNode(level.LogLevel);
                        thirdNode.ImageIndex = level.LogLevel == "Info" ? 3 : 4;
                        thirdNode.SelectedImageIndex = level.LogLevel == "Info" ? 3 : 4;
                        secondNode.Nodes.Add(thirdNode);
                    }
                    secondNode.ExpandAll();
                    rootNode.Nodes.Add(secondNode);
                }
                trvLogDateAndSellerAccount.Nodes.Add(rootNode);
            }
        }

        //添加日志
        public void AppendRtxLog(string message)
        {
            rtxLogs.AppendText(message);
            rtxLogs.ScrollToCaret();
        }

        #region Events

        //加载
        private void ucLog_Load(object sender, EventArgs e)
        {
            rtxLogs.Clear();
            rtxLogs.ContextMenuStrip = rtxContextMenuStrip;
        }

        //双击节点
        private void trvLogDateAndSellerAccount_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node.Level == 2)
                {
                    if (GetLogDetailClick != null)
                    {
                        var handler = GetLogDetailClick;
                        var levelNode = e.Node;
                        handler(sender, new RequestLogArgs(levelNode.Parent.Parent.Text, levelNode.Parent.Text, levelNode.Text));
                    }
                }
            }
        }

        private CheckLevel checkLevel = CheckLevel.None;
        //过滤
        private void Checks_CheckedChanged(object sender, EventArgs e)
        {
            var level = CheckLevel.None;
            if (chkAll.Checked)
            {
                level = level | CheckLevel.All;
            }
            if (chkInfo.Checked)
            {
                level = level | CheckLevel.Info;
            }
            if (chkWarn.Checked)
            {
                level = level | CheckLevel.Warn;
            }
            if (chkError.Checked)
            {
                level = level | CheckLevel.Error;
            }

            Filter(checkLevel);
        }

        private void Filter(CheckLevel checkLevel)
        {
            foreach (TreeNode dateNode in trvLogDateAndSellerAccount.Nodes)
            {
                foreach (TreeNode subNode in dateNode.Nodes)
                {
                    var level = subNode.Text.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    if (level == "Error")
                    {
                        subNode.TreeView.Visible = true;
                    }
                    else
                    {
                        subNode.TreeView.Visible = false;
                    }
                }
            }
        }

        //右键-->清除
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtxLogs.Text = "";
        }

        #endregion
    }

    [Flags]
    internal enum CheckLevel
    {
        [Description("None")]
        None = 0,
        [Description("Info")]
        Info = 1 << 1,
        [Description("Warn")]
        Warn = 1 << 2,
        [Description("Error")]
        Error = 1 << 3,
        [Description("All")]
        All = 1 << 4
    }
}
