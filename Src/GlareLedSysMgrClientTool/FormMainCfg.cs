using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SevenSegTest;
using YD_PUBLIC;
using YdPublic;
using YDesmsPublicDefDll;
using DBSqlite;

namespace Property
{
    public partial class FormMainCfg : Form
    {
        public int iMaxHeight = 0;
        public FormMainCfg()
        {
            InitializeComponent();
        }

        private void treeViewCardType_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonReadCfg_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxIsDouble_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetCfg_Click(object sender, EventArgs e)
        {

        }

        private void clickAbleArr1_Click(object sender, EventArgs e)
        {
        }


        private List<Label> m_lstLabels = new List<Label>();
        private List<OilCardScreen> m_lstCard = new List<OilCardScreen>();
        private List<OilCardScreen> m_lstCardCopy = new List<OilCardScreen>();

        private int iCardType; // 控制卡类型,1表示油价,2表示温度,

        // 控制卡型号
        private string m_strCardModule = "";

        private int m_iDigCount = 6;
        private int m_iMainDigCount = 6;
        private int m_iAppendDigCount = 0;
        private bool m_bShowAppend99 = false;
        private bool m_bIsAppend910 = false;
        private int m_iBrighting;

        private int m_iScreenCount = 12;
        private bool m_bIsDouble = false;
        private string m_strDecInfo = "";
        private string m_strValueInfo = "";
        int[] m_iDecInfoArr = new int[12];
        string[] m_strDefVals;

        private void InitCommCombobox()
        {
            string[] arr = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxComm.DataSource = arr;
        }

        private void InitIDCombobox()
        {
            for (int i = 1; i <= 255; i++)
            {
                comboBoxID.Items.Add(i.ToString());
            }
        }

        enum EShowHightLight
        {
            E_TYPE_0,
            E_TYPE_1,
            E_TYPE_2
        };

        EShowHightLight m_eHight;
        private void ShowHight()
        {
            glassButtonOilCard.HightLight = m_eHight == EShowHightLight.E_TYPE_0;
            glassButtonTimeTempCard.HightLight = m_eHight == EShowHightLight.E_TYPE_1;
            glassButton2.HightLight = m_eHight == EShowHightLight.E_TYPE_2;

            tabControl1.SelectedIndex = (int)m_eHight;
        }

        private void OnTabButtonClick(object sender, EventArgs e)
        {
            Control ac = (Control)sender;
            int i = 0;
            int.TryParse(ac.Tag.ToString(), out i);
            try
            {
                m_eHight = (EShowHightLight)(i);
                ShowHight();
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void LoadBaseInfoByCfgFile(bool bCom)
        {
            m_strCardModule = ConfigHlper.GetConfig(ConstDef.strKeyDefModule);
            GSTypeHlper.GetTypeInfoByString(m_strCardModule,
                out m_iDigCount,
                out m_iMainDigCount,
                out m_iAppendDigCount,
                out m_bShowAppend99,
                out m_bIsAppend910);
            
            ConfigHlper.GetConfig_Int(ConstDef.strKeyDefScreenCount, 1, out m_iScreenCount);
            ConfigHlper.GetConfig_Int(ConstDef.strKeyDefBrightness, 1, out m_iBrighting);

            ConfigHlper.GetConfig_Int(ConstDef.strKeyDefScreenCount, 1, out m_iScreenCount);
            string strVal = ConfigHlper.GetConfig(ConstDef.strKeyDefIsDouble);
            m_bIsDouble = strVal == "1";
            m_strDecInfo = ConfigHlper.GetConfig(ConstDef.strKeyDefDecInfo);
            GetDecIntByString(m_strDecInfo, m_iDecInfoArr);


            



            //
            // 默认值
            //
            string strDefVals = ConfigHlper.GetConfig(ConstDef.strKeyDefVals, "");
            m_strValueInfo = strDefVals;
            m_strDefVals = strDefVals.Split(new char[] {' ', ',', '-' });


            //
            // 显示到UI
            //
            labelValIsDouble.Text = m_bIsDouble ? "2" : "1";
            labelOilValBriagth.Text = m_iBrighting.ToString();
            labelValOilCount.Text = m_iScreenCount.ToString();
            labelValOilType.Text = m_strCardModule;
            if (bCom)
            {
                radioButtonCom.Checked = ConfigHlper.GetConfig(ConstDef.strKeyCommType, "")=="0";
                radioButtonTCP.Checked = ConfigHlper.GetConfig(ConstDef.strKeyCommType, "")=="1";
                textBoxTcpDevIp.Text = ConfigHlper.GetConfig(ConstDef.strKeyTcpDevIp, "");
                textBoxDevPort.Text = ConfigHlper.GetConfig(ConstDef.strKeyTcpDevPort, "");
                comboBoxComm.Text = ConfigHlper.GetConfig(ConstDef.strKeyCom, "");
                string stridseled = ConfigHlper.GetConfig(ConstDef.strKeyID, "");
                int iSeledIndex = 0;
                int.TryParse(stridseled, out iSeledIndex);
                comboBoxID.SelectedIndex= iSeledIndex-1;
            }

        }

        private void ClearDygnCreateCtonls()
        {
            foreach (Control aItem in m_lstLabels)
            {
                tabPagePanelOilCard.Controls.Remove(aItem);
            }
            foreach (Control aItem in m_lstCard)
            {
                tabPagePanelOilCard.Controls.Remove(aItem);
            }
            foreach (Control aItem in m_lstCardCopy)
            {
                tabPagePanelOilCard.Controls.Remove(aItem);
            }

            m_lstLabels.Clear();
            m_lstCard.Clear();
            m_lstCardCopy.Clear();
        }

        private void CreateControls()
        {
            ClearDygnCreateCtonls();

            int iPoxs = labelPos.Location.X;
            int iPoxy = labelPos.Location.Y;
            bool bWidthWithAppend = (m_bIsAppend910 || m_bShowAppend99);
            int iScreenCount = 32 * m_iMainDigCount + (bWidthWithAppend ? 32 : 0);
            for (int i = 0; i < m_iScreenCount; i++)
            {
                //
                // label
                //
                Label labtmp = new Label();
                labtmp.Location = new Point(iPoxs, iPoxy);
                labtmp.BackColor = Color.Transparent;
                labtmp.Size = new Size(30, 30);
                labtmp.Text = (i + 1).ToString().PadLeft(2, '0') + "#";
                tabPagePanelOilCard.Controls.Add(labtmp);
                m_lstLabels.Add(labtmp);

                OilCardScreen aItem = new OilCardScreen();
                aItem.bEnableMdy = true;
                aItem.iDecmialInMain = m_iDecInfoArr[i];
                aItem.iMainDigHeigh = 64;
                aItem.iMainDigWidth = 32;
                aItem.Location = new Point(iPoxs + 30, iPoxy);
                aItem.iOilCardDigCount = m_iMainDigCount;
                aItem.iShow99 = (m_bShowAppend99 ? m_iAppendDigCount : 0);
                aItem.bShow10_9 = m_bIsAppend910;
                aItem.BackColor = Color.Black;
                aItem.Size = new Size(iScreenCount, 64);
                if (m_strDefVals.Length>i&&m_strDefVals[i].Length > 0)
                {
                    aItem.DigValue = m_strDefVals[i];
                }
                else
                {
                    aItem.DigValue = "8888888888";
                }

                tabPagePanelOilCard.Controls.Add(aItem);
                m_lstCard.Add(aItem);

                if (m_bIsDouble)
                {
                    OilCardScreen aItemCyp = new OilCardScreen();
                    aItemCyp.bEnableMdy = false;
                    aItemCyp.iDecmialInMain = m_iDecInfoArr[i];
                    aItemCyp.iMainDigHeigh = 64;
                    aItemCyp.iMainDigWidth = 32;
                    aItemCyp.Location = new Point(iPoxs + 30 + 4 + iScreenCount, iPoxy);
                    aItemCyp.iOilCardDigCount = m_iMainDigCount;
                    aItemCyp.iShow99 = (m_bShowAppend99 ? m_iAppendDigCount : 0);
                    aItemCyp.bShow10_9 = m_bIsAppend910;
                    aItemCyp.BackColor = Color.Black;
                    aItemCyp.Size = new Size(iScreenCount, 64);

                    tabPagePanelOilCard.Controls.Add(aItemCyp);
                    m_lstCardCopy.Add(aItemCyp);
                }

                iPoxy += 64 + 4;
            }
        }
        string m_strTimeType;
        int m_iYearCount;
        int m_iMonthCount;
        int m_iDayCount;
        int m_iHourCount;
        int m_iMinCount;
        int m_iSecCount;

        int m_iTempCount;
        int m_iTempDigIndex;
        int m_iTempDigUnit;

        int m_iTempShowType; // 1替换,2末尾

        int m_iTimeBrightness;

        private void LoadTimeBaseInfoByCfg()
        {
            m_strTimeType = ConfigHlper.GetConfig(ConstDef.strKeyDefTimeModule);          
            GSTypeHlper.GetTypeInfoByString(m_strTimeType,
                 out m_iYearCount,
                 out m_iMonthCount,
                 out m_iDayCount,
                 out m_iHourCount,
                 out m_iMinCount,
                 out m_iSecCount,
                 out m_iTempCount,
                 out m_iTempDigIndex,
                 out m_iTempDigUnit,
                 out m_iTempShowType);

            timeScreen1.IsShowYear = m_iYearCount > 0;
            timeScreen1.YearCount = m_iYearCount;
            timeScreen1.IsShowMonth = m_iMonthCount > 0;
            timeScreen1.IsShowDay = m_iDayCount > 0;
            timeScreen1.IsShowHour = m_iHourCount> 0;
            timeScreen1.IsShowMinute = m_iMinCount> 0;
            timeScreen1.IsShowSecond= m_iSecCount> 0;

            if (m_iTempShowType == 0)
            {
                tempScreen1.Visible = false;
            }
            else if (m_iTempShowType == 1)
            {
                tempScreen1.Location = new Point(timeScreen1.ReGetWidth() - tempScreen1.ReGetWidth(), timeScreen1.Top);                
            }
            else
            {
                Point pttmp = new Point(timeScreen1.Location.X+timeScreen1.ReGetWidth(), timeScreen1.Location.Y);                 
                tempScreen1.Location = pttmp;
            }

            panelTimeTemp.Width = tempScreen1.Location.X + tempScreen1.Width;            
        }

        private void FormMainCfg_Load(object sender, EventArgs e)
        {
            m_eHight = EShowHightLight.E_TYPE_0;
            ShowHight();
            InitCommCombobox();
            InitIDCombobox();

            LanguageMgr.ReloadLanguage(this.FormMainCfgContextMenuStrip1);
            LanguageMgr.ReloadLanguage(this);
            LoadBaseInfoByCfgFile(true);
            radioButtonCom_CheckedChanged(null, null);

            tabControl1.ItemSize = new Size(10, 1);
            this.tabControl1.Region = new Region(
                new RectangleF(this.tabPagePanelOilCard.Left,
                this.tabPagePanelOilCard.Top, this.tabPagePanelOilCard.Width,
                this.tabPagePanelOilCard.Height));

            CreateControls();

            int i = 0;
            foreach (OilCardScreen aItem in m_lstCard)
            {
                if (m_strDefVals.Length > i && m_strDefVals[i].Length > 0)
                {
                    aItem.DigValue = m_strDefVals[i];
                }
                else
                {
                    aItem.DigValue = "00000000";
                }
                i++;
            }
            i = 0;
            foreach (OilCardScreen aItem in m_lstCardCopy)
            {
                if (m_strDefVals.Length > i && m_strDefVals[i].Length > 0)
                {
                    aItem.DigValue = m_strDefVals[i];
                }
                else
                {
                    aItem.DigValue = "00000000";
                }
                i++;
            }
            LoadTimeBaseInfoByCfg();
        }



        /// <summary>
        /// 根据字符串获取各个屏的小数点
        /// </summary>
        /// <param name="strDecInfo"></param>
        /// <param name="iDecArrInfo"></param>
        private void GetDecIntByString(string strDecInfo, int[] iDecArrInfo)
        {
            string[] strArrDecInfo = strDecInfo.Split(new char[] { '-', ',', '.' });
            int iDec = 0;
            for (int i = 0; i < GLLedDefine.MaxScreen; i++)
            {
                iDec = 1;
                if (strArrDecInfo.Length > i)
                {
                    int.TryParse(strArrDecInfo[i], out iDec);
                }
                iDecArrInfo[i] = iDec;
            }

        }


        private Devs.Rs485Port m_pPort485 = new Devs.Rs485Port();
        private Devs.TCPPort m_pPortTcp = new Devs.TCPPort();

        private void InitPort()
        {
            if (radioButtonCom.Checked)
            {
                m_pPort485.Close();
                m_pPort485.SetDBDev(new GL_Dev()
                {
                    CommType = 1,
                    DevClientName = "",
                    DevServerIP = "",
                    Name = "",
                    DevServerPort = 0,
                    OrgID = 0,
                    Protocol = 0,
                    SerialBaud = 9600,
                    SerialDataBit = 8,
                    SerialParity = 0,
                    SerialPort = comboBoxComm.Text,
                    SerialStopBit = 1,
                    Timeout = 1000
                });
                m_pPort485.Open();
            }
            else
            {
                m_pPortTcp.Close();
                int iPort = 0;
                int.TryParse(textBoxDevPort.Text, out iPort);
                m_pPortTcp.SetDBDev(new GL_Dev()
                {
                    CommType = 0,
                    DevClientName = "",
                    DevServerIP = textBoxTcpDevIp.Text,
                    Name = "",
                    DevServerPort = iPort,
                    OrgID = 0,
                    Protocol = 0,
                    SerialBaud = 9600,
                    SerialDataBit = 8,
                    SerialParity = 0,
                    SerialPort = comboBoxComm.Text,
                    SerialStopBit = 1,
                    Timeout = 1000
                     
                });
                m_pPortTcp.Open();
            }
        }

        private void InitTimePort()
        {
            m_pPort485.Close();
            m_pPort485.SetDBDev(new GL_Dev()
            {
                CommType = 1,
                DevClientName = "",
                DevServerIP = "",
                Name = "",
                DevServerPort = 0,
                OrgID = 0,
                Protocol = 0,
                SerialBaud = 9600,
                SerialDataBit = 8,
                SerialParity = 0,
                SerialPort = comboBoxTimeOpID.Text,
                SerialStopBit = 1,
                Timeout = 1000
            });
            m_pPort485.Open();
        }

        private void buttonExRead_Click(object sender, EventArgs e)
        {
            int iOpID = 0;
            int.TryParse(comboBoxID.Text, out iOpID);

            if (iOpID < 0 && iOpID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }

            InitPort();


            List<GLLedDefine.CardOilValEachNumAByte> lstOilVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            for (int i = 0; i < GLLedDefine.MaxScreen; i++)
            {
                lstOilVal.Add(new GLLedDefine.CardOilValEachNumAByte());
            }

            if (radioButtonCom.Checked)
            {
                if (!m_pPort485.ReadOilVal(iOpID, ref lstOilVal))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                    m_pPort485.Close();
                    return;
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
                }
                m_pPort485.Close();
            }
            else
            {
                if (!m_pPortTcp.ReadOilVal(iOpID, ref lstOilVal))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                    m_pPortTcp.Close();
                    return;
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
                } 
                m_pPortTcp.Close();
            }


            string strVals = MakeValuesByList(lstOilVal);
            m_strValueInfo = strVals;
            SetOilValToView(strVals, m_strDecInfo);

        }


        private string MakeValuesByList(List<GLLedDefine.CardOilValEachNumAByte> lstOilVal)
        {
            string strVals = "";
            foreach (GLLedDefine.CardOilValEachNumAByte aVal in lstOilVal)
            {
                if (strVals.Length > 0)
                {
                    strVals += "-";
                }
                foreach (byte aDicVal in aVal.lstArr)
                {
                    strVals += (char)(aDicVal + '0');
                }
            }

            return strVals;
        }

        private void SetOilValToView(string strVals,  string strDecimalInfo)
        {
            string[] strArrDecInfo = strDecimalInfo.Split(new char[] { '-', ',', '.' });
            string[] strArr = strVals.Split(new char[] { '-' });

            for (int iSC = 0; iSC < GLLedDefine.MaxScreen; iSC++)
            {
                string strVal = new string('8', 8);
                if (strArr.Length > iSC)
                {
                    strVal = strArr[iSC];
                }
                strVal = strVal.Replace(".", "");
                strVal = strVal.Replace(",", "");
                //strVal = strVal.Substring(0, CardBaseAPI.GetDigCountByType(strCardMod));
                if (m_lstCard.Count > iSC)
                {
                    m_lstCard[iSC].DigValue = strVal;
                }
                if (m_lstCardCopy.Count > iSC)
                {
                    m_lstCardCopy[iSC].DigValue = strVal;
                }
            }

        }


        private void timerUpdateDouble_Tick(object sender, EventArgs e)
        {
            if (!m_bIsDouble)
            {
                return;
            }

            for (int i = 0; i < m_lstCard.Count(); i++)
            {
                m_lstCardCopy[i].DigValue = m_lstCard[i].DigValue;
            }
        }

        private void FormMainCfg_VisibleChanged(object sender, EventArgs e)
        {                       
            timerUpdateDouble.Enabled = Visible;            
        }



        private string GetContextByView(bool bIsDouble)
        {
            List<string> lstContextOfView = new List<string>();
            lstContextOfView.Clear();
            for (int i = 0; i <m_lstCard.Count(); i++)
            {                 
                lstContextOfView.Add(m_lstCard[i].DigValue);                 
            }


            string strContext = "";
            int iIndex = 0;
            foreach (string astr in lstContextOfView)
            {
                if (strContext.Length > 0)
                {
                    strContext += "-";
                }

                astr.PadLeft(m_iDigCount, '0');
                iIndex++;
                strContext += astr;
            }
            return strContext;
        }

        private void buttonExWrite_Click(object sender, EventArgs e)
        {
            string strVals = GetContextByView(false);
            int iOpID = 0;
            int.TryParse(comboBoxID.Text, out iOpID);

            if (iOpID < 0 && iOpID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }
            InitPort();

            string strTmp = strVals;
            strTmp.Replace(" ", "");
            strTmp.Replace(".", "");
            string[] strArrTmp = strTmp.Split(new char[] { ',', '-' });
            List<string> lstOilVals = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                if (strArrTmp.Length > i)
                {
                    lstOilVals.Add(strArrTmp[i]);
                }
                else
                {
                    lstOilVals.Add("000000");
                }
            }
            if (radioButtonCom.Checked)
            {
                if (m_pPort485.SendOilContext(iOpID, lstOilVals))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                }
                m_pPort485.Close();
            }
            else
            {
                if (m_pPortTcp.SendOilContext(iOpID, lstOilVals))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                }
                m_pPortTcp.Close();
            }

            
        }

        private void FormMainCfg_SizeChanged(object sender, EventArgs e)
        {

            this.tabControl1.Region = new Region(
                new RectangleF(this.tabPagePanelOilCard.Left,
                this.tabPagePanelOilCard.Top, this.tabPagePanelOilCard.Width,
                this.tabPagePanelOilCard.Height));
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {

        }

        private void buttonEx1_Click_1(object sender, EventArgs e)
        {
            this.FormMainCfgContextMenuStrip1.Show(tabPagePanelOilCard.PointToScreen(new Point(buttonExAdvFun.Right,
                buttonExAdvFun.Bottom)));
        }

        private void 修改IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword dlgpassward = new FormInputPassword();
            dlgpassward.StrPassword = "263";
            if (dlgpassward.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FormMdyID dlg = new FormMdyID();
            dlg.StrComm = comboBoxComm.Text;
            dlg.strDefID = comboBoxID.Text;
            dlg.StrTcpDevPort = textBoxDevPort.Text;
            dlg.StrTcpDevIp = textBoxTcpDevIp.Text;
            dlg.IComType = radioButtonCom.Checked ? 0 : 1;

            dlg.ShowDialog();
            SetOilValToView(m_strValueInfo, m_strDecInfo);
        }

        private void 修改配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword dlgpassward = new FormInputPassword();
            dlgpassward.StrPassword = "163";
            if (dlgpassward.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FormCfgNormalInfo dlg = new FormCfgNormalInfo();
            dlg.StrComm = comboBoxComm.Text;
            int i;
            int.TryParse(comboBoxID.Text, out i);
            dlg.IDefID = i;
            dlg.StrTcpDevPort = textBoxDevPort.Text;
            dlg.StrTcpDevIp = textBoxTcpDevIp.Text;
            dlg.IComType = radioButtonCom.Checked ? 0 : 1;


            dlg.ShowDialog();
            LoadBaseInfoByCfgFile(false);
            CreateControls();
            SetOilValToView(m_strValueInfo, m_strDecInfo);
        }

        private void 修改小数点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInputPassword dlgpassward = new FormInputPassword();
            dlgpassward.StrPassword = "263";
            if (dlgpassward.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            FormCfgAdv dlg = new FormCfgAdv();
            dlg.IScreenCount = m_iScreenCount;
            dlg.StrModeType = m_strCardModule;
            dlg.StrComm = comboBoxComm.Text;
            dlg.StrTcpDevPort = textBoxDevPort.Text;
            dlg.StrTcpDevIp = textBoxTcpDevIp.Text;
            dlg.IComType = radioButtonCom.Checked ? 0 : 1;

            int i;            
            int.TryParse(comboBoxID.Text, out i);
            dlg.IDefID = i;
            dlg.ShowDialog();
            LoadBaseInfoByCfgFile(false);
            CreateControls();
            SetOilValToView(m_strValueInfo, m_strDecInfo);
        }

        private void FormMainCfg_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToCfg();
        }

        private void SaveToCfg()
        {

            ConfigHlper.SetConfig(ConstDef.strKeyTcpDevIp, textBoxTcpDevIp.Text);
            ConfigHlper.SetConfig(ConstDef.strKeyTcpDevPort, textBoxDevPort.Text);

            ConfigHlper.SetConfig(ConstDef.strKeyCommType, radioButtonCom.Checked?"0":"1");

            ConfigHlper.SetConfig(ConstDef.strKeyCom, comboBoxComm.Text);
            ConfigHlper.SetConfig(ConstDef.strKeyID, comboBoxID.Text);

            string strVals = GetContextByView(false);
            ConfigHlper.SetConfig(ConstDef.strKeyDefVals, strVals);
        }

        private void buttonEx2_Click(object sender, EventArgs e)
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

        private void ChangeLanguage(object sender, EventArgs e)
        {
            ToolStripMenuItem aitem = (ToolStripMenuItem)sender;

            LanguageMgr.WriteDefaultLanguage(aitem.Tag.ToString());
            ReLoadLanguage(aitem.Tag.ToString());
        }

        private void ReLoadLanguage(string lang)
        {
            LanguageMgr.ReloadLanguage(this);
            LanguageMgr.ReloadLanguage(this.FormMainCfgContextMenuStrip1);
            LoadBaseInfoByCfgFile(true);
            panel4.Invalidate();
        }

        private void buttonExReadTimeTemp_Click(object sender, EventArgs e)
        {
            timeScreen1.SetVal(DateTime.Now);
            tempScreen1.SetVal("23.1");

            return;
            int iOpID = comboBoxTimeOpID.SelectedIndex + 1;

            if (iOpID < 0 && iOpID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }



            InitTimePort();


            List<GLLedDefine.CardOilValEachNumAByte> lstOilVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            for (int i = 0; i < GLLedDefine.MaxScreen; i++)
            {
                lstOilVal.Add(new GLLedDefine.CardOilValEachNumAByte());
            }

            if (!m_pPort485.ReadOilVal(iOpID, ref lstOilVal))
            {
                MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                m_pPort485.Close();
                return;
            }

            m_pPort485.Close();

        }

        bool m_iTimeTempSp = false;
        private void timerTimeTempSplick_Tick(object sender, EventArgs e)
        {
            if (m_iTempShowType == 1)
            {
                timeScreen1.Visible = m_iTimeTempSp;
                tempScreen1.Visible = !m_iTimeTempSp;
                m_iTimeTempSp = !m_iTimeTempSp;
            }
        }

        private void radioButtonCom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCom.Checked)
            {
                textBoxDevPort.ReadOnly = true;
                textBoxTcpDevIp.ReadOnly = true;
                comboBoxComm.Enabled = true;
            }
        }

        private void radioButtonTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTCP.Checked)
            {
                textBoxDevPort.ReadOnly = false;
                textBoxTcpDevIp.ReadOnly = false;
                comboBoxComm.Enabled = false;
            }
        }

        private void contextMenuStripLanguage_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
