using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Xml;
using System.Collections;
using System.IO;
using YD_PUBLIC;
using YDesmsPublicDefDll;
using DBSqlite;
using YdPublic;
using System.Diagnostics;
using YD_PUBLIC.Log;

namespace Property
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
//         private ViewOliCard m_pViewOCard = new ViewOliCard();
//         private ViewTemputer m_pTemp = new ViewTemputer();
//         private ViewSelectedDev m_pSeledDev = new ViewSelectedDev();
//         private ViewSelectAOrg m_pSelOrg = new ViewSelectAOrg();
//         private ViewSelectTCPClientRoot m_pSelTcpRoot = new ViewSelectTCPClientRoot();
//         private ViewSelectPCComDevRoot m_pSelPCCom = new ViewSelectPCComDevRoot();
//         private ViewSelectTCPServerRoot m_pSelTcpServerRoot = new ViewSelectTCPServerRoot();

        private ViewListCards m_pSelListCardsView = new ViewListCards();
        


        /// <summary>
        /// 视图定义，枚举，
        /// </summary>
        private enum EViewDef
        {
//             E_OIL_CARD = 1,
//             E_TEMPUTER_CARD,
//             E_A_DEV,
//             E_A_ORG,
//             E_TCPCLIENT_ROOT,
//             E_PC_COM_ROOT,
//             E_TCP_SERVER_ROOT,         
            E_VIEW_LIST_CARD,
            E_VIEW_A_CARD,
        }


        /// <summary>
        /// 串口根节点
        /// </summary>
        private TreeNode m_tnSerialRoot;
        /// <summary>
        /// TCP服务器设备根节点
        /// </summary>
        private TreeNode m_tnTCPServerRoot;
        /// <summary>
        /// TCP客户端根节点
        /// </summary>
        private TreeNode m_tnTcpClientRoot;

        private TreeNode m_tnOrgRoot;
        
        private void AddPanel(Form pForm)
        {
            pForm.TopLevel = false;
            panelWorkSpace.Controls.Add(pForm);
            pForm.Dock = DockStyle.Fill;
            pForm.Visible = false;
        }

        //TcpServerForGPRSDev m_pTcpServer = new TcpServerForGPRSDev();
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadAllCardToTree();

            treeView1.ExpandAll();
            AddPanel(m_pSelListCardsView);
           // AddPanel(m_pSelAOilCard);

            TcpServerForGPRSDev.Get().Port = 7804;

            SetButtonStat(false);

            treeView1.SelectedNode = treeView1.Nodes[0];

            string strVal = ConfigHlper.GetConfig(ConstDef.strKeyIsRunServer);
            //string strValByCfg = ConfigHlper.GetConfig(ConstDef.strValIsRunServer);
            if (strVal == ConstDef.strValIsRunServer)
            {
                LoadAddDevToMonTreeByOrg();
                buttonStartTCP_Click(null, null);
                DataCenterObject.Get().Init();
                DataCenterObject.Get().Start();
                tabControl1.TabPages.RemoveAt(0);

                timerUpdateOrg.Enabled = true;
                timerUpdateGPRSDev.Enabled = false;
                //mainscript.Visible = false;
                mainscript.Items[1].Visible = false;
                mainscript.Items[2].Visible = false;

                timerSendEMailOrReset.Enabled = true;
            }
            else
            {
                tabControl1.TabPages.RemoveAt(1);
                timerUpdateOrg.Enabled = false;
                timerUpdateGPRSDev.Enabled = true;
            }

            ReLoadLanguage(LanguageMgr.ReadDefaultLanguage());
        }

        private void LoadAllCardToTree()
        {
            if (radioButtonListByItf.Checked)
            {
                LoadAddDevToTreeByDev();
            }
            else 
            {
                LoadAddDevToTreeByOrg();
            }
        }

        private void LoadCardToDev(TreeNode tnDev, GL_Dev aDev)
        {
            IList<GL_LedCard> lstCardOfDev = (from c in DB.MemDB.Get().lstCard where c.DevID == aDev.ID select c).ToList();
            foreach (GL_LedCard aCard in lstCardOfDev)
            {
                TreeNode tnCard = tnDev.Nodes.Add(aCard.Name);
                tnCard.Tag = aCard;
            }
        }


        private void LoadAddDevToTreeByDev()
        {
            treeView1.Nodes.Clear();
            TreeNode tnRoot = treeView1.Nodes.Add("服务器接口列表");
            m_tnSerialRoot = tnRoot.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeySerialPorts));
            int i = 0;
            foreach (GL_Dev aDev in  DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_SERIAL_COM)
                {
                    continue;
                }

                TreeNode tnNode = m_tnSerialRoot.Nodes.Add((i++).ToString(), aDev.Name + "["+aDev.SerialPort +"]",
                    2);
                tnNode.Tag = aDev;

                LoadCardToDev(tnNode, aDev);
            }

            m_tnTCPServerRoot = tnRoot.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyTcpPorts));
            foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_TCP_SERVER)
                {
                    continue;
                }

                TreeNode tnNode = m_tnTCPServerRoot.Nodes.Add((i++).ToString(),
                    aDev.Name + "[" + aDev.DevServerIP +":"+aDev.DevServerPort + "]",
                    2);
                tnNode.Tag = aDev;
                LoadCardToDev(tnNode, aDev);
            }

            m_tnTcpClientRoot = tnRoot.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyGprsPorts));
            foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    continue;
                }

                TreeNode tnNode = m_tnTcpClientRoot.Nodes.Add(aDev.Name + "[" + aDev.DevClientName + "]" + "- 未连接");
                tnNode.Tag = aDev;
                LoadCardToDev(tnNode, aDev);
            }
            
        }


        private void LoadAddDevToMonTreeByOrg()
        {
            int i = 0;
            treeViewOrgMoniter.Nodes.Clear();
            m_tnOrgRoot = treeViewOrgMoniter.Nodes.Add((i++).ToString(),
                LanguageMgr.GetKey(ConstDef.strLanguageKeyoilstation),
                0);

            string strTransferType = "";
            foreach (GL_Org aOrg in DB.MemDB.Get().lstOrg)
            {
                TreeNode tnOrg = m_tnOrgRoot.Nodes.Add((i++).ToString(), aOrg.Name + "-id:" + aOrg.ID+ "-sn:" + aOrg.PCSN +"-not connect",
                    0);
                tnOrg.Tag = aOrg;

                IList<GL_Dev> lstDev = (from c in DB.MemDB.Get().lstDev where c.OrgID == aOrg.ID select c).ToList();
                foreach (GL_Dev aDev in lstDev)
                {
                    TreeNode tnNode = tnOrg.Nodes.Add((i++).ToString(), aDev.Name + "[" + aDev.DevClientName + "]" + "-not connect",
                        2);
                    tnNode.Tag = aDev;
                    LoadCardToDev(tnNode, aDev);
                }

            }

            treeViewOrgMoniter.ExpandAll();
        }


        private void LoadAddDevToTreeByOrg()
        {
            treeView1.Nodes.Clear();
            m_tnOrgRoot = treeView1.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyoilstation));
            
            string strTransferType = "";
            int i = 0;
            foreach (GL_Org aOrg in DB.MemDB.Get().lstOrg)
            {
                TreeNode tnOrg = m_tnOrgRoot.Nodes.Add((i++).ToString(), aOrg.Name, 0);
                tnOrg.Tag = aOrg;

                IList<GL_Dev> lstDev = (from c in DB.MemDB.Get().lstDev where c.OrgID == aOrg.ID select c).ToList();
                foreach (GL_Dev aDev in lstDev)
                {
                    if (aDev.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM)
                    {
                        strTransferType = "Comm";
                    }
                    if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_SERVER)
                    {
                        strTransferType = "TCP-Server";
                    }
                    if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                    {
                        strTransferType = "TCP-Client:7804";
                    }

                    TreeNode tnNode = tnOrg.Nodes.Add((i++).ToString(), strTransferType + ":" + aDev.Name + "[" + aDev.SerialPort + "]",2);
                    tnNode.Tag = aDev;
                    LoadCardToDev(tnNode, aDev);
                }
            }
        }

        private void ShowPanel(EViewDef eType)
        {
            m_pSelListCardsView.Visible = eType == EViewDef.E_VIEW_LIST_CARD;
            if (eType == EViewDef.E_VIEW_LIST_CARD)
            {
                m_pSelListCardsView.SelectFire();
            }
            //m_pSelAOilCard.Visible = eType == EViewDef.E_VIEW_A_CARD;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Tag == null)
            {
                if (m_tnTcpClientRoot == e.Node)
                {
                    m_pSelListCardsView.iSelDevID = 0;
                    m_pSelListCardsView.iSelOrgID = 0;
                    m_pSelListCardsView.eListType = ViewListCards.EListType.E_ALL_ITF_TCPCLIENT_ALL_ORG;
                    m_pSelListCardsView.strTipCurSel = "所有TCP 客户端设备";
                    ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                    return;
                }

                if (m_tnSerialRoot == e.Node)
                {
                    m_pSelListCardsView.iSelDevID = 0;
                    m_pSelListCardsView.iSelOrgID = 0;
                    m_pSelListCardsView.eListType = ViewListCards.EListType.E_ALL_ITF_COMM_ALL_ORG;
                    m_pSelListCardsView.strTipCurSel = "所有串口端设备";
                    ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                    return;
                }

                if (m_tnTCPServerRoot == e.Node)
                {
                    m_pSelListCardsView.iSelDevID = 0;
                    m_pSelListCardsView.iSelOrgID = 0;
                    m_pSelListCardsView.eListType = ViewListCards.EListType.E_ALL_ITF_TCPSERVER_ALL_ORG;
                    m_pSelListCardsView.strTipCurSel = "所有TCP服务器端设备";
                    ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                    return;
                }

                if (m_tnOrgRoot == e.Node)
                {
                    m_pSelListCardsView.iSelDevID = 0;
                    m_pSelListCardsView.iSelOrgID = 0;
                    m_pSelListCardsView.eListType = ViewListCards.EListType.E_ALL_CARDS;
                    m_pSelListCardsView.strTipCurSel = "所有设备";
                    ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                    return;
                }


                m_pSelListCardsView.iSelDevID = 0;
                m_pSelListCardsView.iSelOrgID = 0;
                m_pSelListCardsView.eListType = ViewListCards.EListType.E_ALL_CARDS;
                m_pSelListCardsView.strTipCurSel = "所有设备";
                ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                return;
            }

           
            try
            {
                GL_Org aSelOrg = treeView1.SelectedNode.Tag as GL_Org;
                if (aSelOrg != null)
                {
                    m_pSelListCardsView.iSelDevID = 0;
                    m_pSelListCardsView.iSelOrgID = (int)aSelOrg.ID;
                    m_pSelListCardsView.eListType = ViewListCards.EListType.E_CARD_OF_A_ORG_ALL_ITF;
                    m_pSelListCardsView.strTipCurSel = "加油站：" + aSelOrg.Name;
                    ShowPanel(EViewDef.E_VIEW_LIST_CARD);
                    return;
                }

                GL_Dev aSelDev = treeView1.SelectedNode.Tag as GL_Dev;
                if (aSelDev != null)
                {
                    if (treeView1.SelectedNode.Parent.Parent == m_tnOrgRoot)
                    {
                        m_pSelListCardsView.iSelDevID = (int)aSelDev.ID;
                        m_pSelListCardsView.iSelOrgID = (int)aSelDev.OrgID;
                        m_pSelListCardsView.eListType = ViewListCards.EListType.E_CARD_OF_A_ORG_ALL_ITF;
                        m_pSelListCardsView.strTipCurSel = "加油站：" + aSelOrg.Name;
                        ShowPanel(EViewDef.E_VIEW_LIST_CARD);

                    }
                    else
                    {
                        m_pSelListCardsView.iSelDevID = (int)aSelDev.ID;
                        m_pSelListCardsView.iSelOrgID = 0;
                        m_pSelListCardsView.eListType = ViewListCards.EListType.E_CARD_OF_ADEV;
                        m_pSelListCardsView.strTipCurSel = "端口：" + aSelDev.Name;
                        ShowPanel(EViewDef.E_VIEW_LIST_CARD);

                    }
                    return;
                }

                GL_LedCard aLedCard= treeView1.SelectedNode.Tag as GL_LedCard;
                if (aLedCard!=null)
                {
                    if (aLedCard.CardType == GLLedDefine.LedTypeOil.ToString())
                    {
                        //m_pSelAOilCard.glLedCard = aLedCard;
                        ShowPanel(EViewDef.E_VIEW_A_CARD);
                        //m_pSelAOilCard.SelectedFire();
                    }
                    else if (aLedCard.CardType == GLLedDefine.LedTypeTempDt.ToString())
                    {
                        //m_pSelAOilCard.glLedCard = aLedCard;
                        //m_pSelAOilCard.SelectedFire();
                        ShowPanel(EViewDef.E_VIEW_A_CARD);
                    }
                    else
                    {
                        MessageBox.Show(LanguageMgr.GetKey("TipTypeNoDef"));
                        return;
                    }
                    return;
                }

                MessageBox.Show(LanguageMgr.GetKey("TipConnServerFailed"));
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }


        private void 简体中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageMgr.ReloadLanguage(this);
            LanguageMgr.ReloadLanguage(this.mainscript);
        }

     
        private void DevMgrToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormDevMgr dlg = new FormDevMgr();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                buttonRFresh_Click(null, null);
                buttonRefreshCenOrg_Click(null, null);
            }
        }


        private void buttonRFresh_Click(object sender, EventArgs e)
        {
            LoadAllCardToTree();
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllCardToTree();
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllCardToTree();
            treeView1.SelectedNode = treeView1.Nodes[0];
        }

        private void CfgToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             FormCfgEx dlg = new FormCfgEx();
//             dlg.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void buttonStartTCP_Click(object sender, EventArgs e)
        {
            if (TcpServerForGPRSDev.Get().Start())
            {
                labelGPRSServerStat.Text = "started";
                SetButtonStat(true);
            }
            else
            {
                labelGPRSServerStat.Text = "not start";
                SetButtonStat(false);
            }
        }

        private void buttonTCPServerStop_Click(object sender, EventArgs e)
        {
            TcpServerForGPRSDev.Get().Stop();
            labelGPRSServerStat.Text = "not start";
            SetButtonStat(false);
        }

        private void SetButtonStat(bool bCurStat)
        {
            buttonTCPServerStop.Enabled = bCurStat;
            buttonStartTCP.Enabled = !bCurStat;

        }

        private void timerUpdateGPRSDev_Tick(object sender, EventArgs e)
        {
            UpdateGprsDevStatus();
        }

        private void UpdateGprsDevStatus()
        {
            foreach (TreeNode tnGprsDev in m_tnTcpClientRoot.Nodes)
            {
                GL_Dev aDev = tnGprsDev.Tag as GL_Dev;
                if (aDev == null)
                {
                    continue;
                }

                bool bConned = TcpServerForGPRSDev.Get().GetDevIsConnected((int)aDev.ID);
                
                UpdateString(tnGprsDev, bConned, 2);
                

            }
        }

        private void UpdateString(TreeNode tn, bool bStat, int iIndexOfImg)
        {
            string strTmp = tn.Text;
            int i = strTmp.LastIndexOf("-");
            strTmp = strTmp.Substring(0, i+1);
            strTmp =string.Format("{0}{1}",strTmp, bStat ? "connected" : "not connect");
            if (strTmp == tn.Text)
            {
                return;
            }
            tn.Text = strTmp;

            if (bStat)
            {
                tn.ImageIndex = iIndexOfImg + 1;
            }
            else
            {
                tn.ImageIndex = iIndexOfImg;
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            listViewLogForDC.Items.Clear();
        }

        public void InsertIntoLogList(string strMod, string strC1, string strC2, string strC3, string strLogDt, string strMsg)
        {
            if (checkBoxShowLog.Checked)
                return;
            //
            // 判断是否需要显示
            //
            bool bShow = true;

            if (textBoxFiltLogM.Text.Length == 0
                && textBoxFiltC1.Text.Length == 0
                && textBoxFiltc2.Text.Length == 0
                && textBoxFiltc3.Text.Length == 0
                )
            {
                bShow = true;
            }
            else
            {
                bShow = false;
            }

            if (textBoxFiltLogM.Text.Length > 0)
            {
                int iCmp = string.Compare(strMod, textBoxFiltLogM.Text, true);

                if (iCmp == 0)
                {
                    bShow = true;
                }
            }


            if (!bShow && textBoxFiltC1.Text.Length > 0)
            {
                int iCmp = string.Compare(strC1, textBoxFiltC1.Text, true);

                if (iCmp == 0)
                {
                    bShow = true;
                }
            }
            if (!bShow && textBoxFiltc2.Text.Length > 0)
            {
                int iCmp = string.Compare(strC2, textBoxFiltc2.Text, true);

                if (iCmp == 0)
                {
                    bShow = true;
                }
            }
            if (!bShow && textBoxFiltc3.Text.Length > 0)
            {
                int iCmp = string.Compare(strC3, textBoxFiltc3.Text, true);

                if (iCmp == 0)
                {
                    bShow = true;
                }
            }

            if (!bShow)
            {
                return;
            }

            listViewLogForDC.Items.Add(new ListViewItem(new string[]{
                "0",strMod, strC1, strC2, strC3, strLogDt, strMsg
            }));

            if (!listViewLogForDC.Focused)
            {
                listViewLogForDC.Items[listViewLogForDC.Items.Count - 1].EnsureVisible();
            }

            if (listViewLogForDC.Items.Count > 10000 )
            {
                listViewLogForDC.Items.RemoveAt(0);
            }
        }

        private void timerUpdateOrg_Tick(object sender, EventArgs e)
        {
            if (m_tnOrgRoot == null)
            {
                return;
            }

            foreach (TreeNode tnOrg in m_tnOrgRoot.Nodes)
            {
                foreach (TreeNode tnGprsDev in tnOrg.Nodes)
                {
                    GL_Dev aDev = tnGprsDev.Tag as GL_Dev;
                    if (aDev == null)
                    {
                        continue;
                    }

                    bool bConned = TcpServerForGPRSDev.Get().GetDevIsConnected((int)aDev.ID);

                    UpdateString(tnGprsDev, bConned, 2);
                }
            }

            foreach (TreeNode tnOrg in m_tnOrgRoot.Nodes)
            {
                GL_Org aOrg = tnOrg.Tag as GL_Org;
                if (aOrg == null)
                {
                    continue;
                }

                bool bConnected = DataCenterObject.Get().m_pGwServerPort.IsGWConnected((int)aOrg.ID);
                UpdateString(tnOrg, bConnected, 0);
            }

        }

        private void buttonStartDC_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefreshCenOrg_Click(object sender, EventArgs e)
        {
            LoadAddDevToMonTreeByOrg();
        }

  

        private void buttonShowHideLog_Click(object sender, EventArgs e)
        {
            panelLog.Visible = !panelLog.Visible;
        }

        private void buttonDevMgr_Click(object sender, EventArgs e)
        {
            FormDevMgr dlg = new FormDevMgr();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                buttonRFresh_Click(null, null);
                buttonRefreshCenOrg_Click(null, null);
            }
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            ToolStripMenuItem aitem = (ToolStripMenuItem)sender;

            LanguageMgr.WriteDefaultLanguage(aitem.Tag.ToString());
            ReLoadLanguage(aitem.Tag.ToString());
        }

        private void ReLoadLanguage(string lang)
        {
            LanguageMgr.ReloadLanguage(this);            
        }
        private void buttonExSelLanguage_Click(object sender, EventArgs e)
        {
            contextMenuStripLanguage.Items.Clear();
            List<LangItem> lstItem = LanguageMgr.ReadLangageItems();
            string strDef = LanguageMgr.ReadDefaultLanguage();

            foreach (LangItem aLangItem in lstItem)
            {
                ToolStripMenuItem aItem = new ToolStripMenuItem();
                aItem.Name = "ToolStripMenuItem_" + aLangItem.strTxt;
                aItem.Size = new System.Drawing.Size(130, 22);
                aItem.Text = aLangItem.strTxt;
                aItem.Tag = aLangItem.strVal;
                aItem.Click += new System.EventHandler(this.ChangeLanguage);
                if (strDef == aLangItem.strVal)
                {
                    aItem.Checked = true;
                }
                contextMenuStripLanguage.Items.Add(aItem);
            }

            this.contextMenuStripLanguage.Show(PointToScreen(new Point(buttonExSelLanguage.Right,
                buttonExSelLanguage.Bottom)));
        }

        private void buttonSysUserMgr_Click(object sender, EventArgs e)
        {
            FormSysuserMgr dlg = new FormSysuserMgr();
            dlg.ShowDialog();
        }

        DateTime dtSendEMail = DateTime.Now;
        private void timerSendEMailOrReset_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour !=12 )
            {
                return;
            }

            if (dtSendEMail.AddDays(1)<DateTime.Now)
            {
                SendMail aSend = new SendMail();
                aSend.SetSendMailInfo("85885357@qq.com", "bb140501@163.com", "aaasdfds", "sfsdfdsfds", "t22014");
                bool bSended = aSend.Send();
                FileLog.WriteLog("send email result is:" + bSended.ToString());
                dtSendEMail = DateTime.Now;


                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void contextMenuStripLanguage_Opening(object sender, CancelEventArgs e)
        {

        }
    }


}
