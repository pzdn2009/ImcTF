using ImcFramework.WcfInterface;
using ImcFramework.Winform.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public class MyClients
    {
        private static object lockObject = new object();

        /// <summary>
        /// 当前的绑定
        /// </summary>
        private static string m_CurrentBinding = null;

        /// <summary>
        /// 服务字典
        /// </summary>
        private static Dictionary<EServiceType, WsDualClient> dictWcfClients = new Dictionary<EServiceType, WsDualClient>();

        /// <summary>
        /// Tab字典
        /// </summary>
        private static Dictionary<EServiceType, TabPage> dictTabPages = new Dictionary<EServiceType, TabPage>();

        public static TabControl TabControlMain
        {
            get;
            set;
        }

        /// <summary>
        /// 当前主窗体 
        /// </summary>
        public static FrmMain FrmMain
        {
            get;
            set;
        }

        /// <summary>
        /// 当前终结点
        /// </summary>
        public static string CurrentBinding
        {
            get
            {
                lock (lockObject)
                {
                    return m_CurrentBinding;
                }
            }
        }

        public static void SetCurrentBinding(string binding)
        {
            lock (lockObject)
            {
                if (m_CurrentBinding != binding)
                {
                    //更新配置
                    m_CurrentBinding = binding;

                    CloseTabPages(null);

                    FrmMain.GetServiceList();

                    FrmMain.NeedRefresh = true;
                }
            }
        }

        public static string Host { get; set; }

        #region 添加客户端 和 Page

        /// <summary>
        /// 添加Wcf客户端
        /// </summary>
        /// <param name="serviceType">服务</param>
        /// <param name="client">Wcf客户</param>
        public static void Add(EServiceType serviceType, WsDualClient client)
        {
            dictWcfClients[serviceType] = client;
        }

        /// <summary>
        /// 添加TabPage
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="tabPage"></param>
        public static void Add(EServiceType serviceType, TabPage tabPage)
        {
            dictTabPages[serviceType] = tabPage;
        }

        #endregion

        /// <summary>
        /// 是否已经添加了TagPage
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public static bool HasAddTagPage(EServiceType serviceType)
        {
            return dictTabPages.ContainsKey(serviceType);
        }

        /// <summary>
        /// 查找TabPage
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public static TabPage GetTabPage(EServiceType serviceType)
        {
            return dictTabPages[serviceType];
        }

        /// <summary>
        /// 关闭所有TabPage
        /// </summary>
        public static void CloseTabPages(TabPage exceptTabPage)
        {
            var list = TabControlMain.TabPages.OfType<TabPage>().ToList();
            if (exceptTabPage != null)
            {
                list = list.Except(new List<TabPage>() { exceptTabPage }).ToList();
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                CloseTabPage(list[i]);
            }
        }

        /// <summary>
        /// 关闭TabPage
        /// 先关闭连接；然后删除Tab
        /// </summary>
        /// <param name="tabPage"></param>
        public static void CloseTabPage(TabPage tabPage)
        {
            bool exist = dictTabPages.ContainsValue(tabPage);
            if (exist)
            {
                var serviceType = dictTabPages.First(zw => zw.Value == tabPage).Key;

                CloseWcfConnection(serviceType);

                //清楚字典
                dictTabPages.Remove(serviceType);

                //界面删除
                TabControlMain.TabPages.Remove(TabControlMain.SelectedTab);
            }
        }

        #region 关闭Wcf连接

        /// <summary>
        /// 关闭所有的WCF连接
        /// </summary>
        private static void CloseWcfConnections()
        {
            var connections = dictWcfClients.ToList();
            for (int i = connections.Count - 1; i >= 0; i--)
            {
                CloseWcfConnection(connections[i].Key);
            }
        }

        /// <summary>
        /// 关闭指定服务的WCF链接
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        private static bool CloseWcfConnection(EServiceType serviceType)
        {
            try
            {
                if (dictWcfClients.ContainsKey(serviceType))
                {
                    if (dictWcfClients[serviceType].Factory.State != System.ServiceModel.CommunicationState.Faulted)
                        dictWcfClients[serviceType].ClientConnector.UnRegister(serviceType);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dictWcfClients.ContainsKey(serviceType))
                {
                    dictWcfClients[serviceType].Factory.Abort();
                    dictWcfClients.Remove(serviceType);
                }
            }
            return false;
        }

        #endregion
    }
}
