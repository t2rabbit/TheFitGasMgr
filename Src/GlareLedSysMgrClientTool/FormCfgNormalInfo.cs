using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YD_PUBLIC;
using YDesmsPublicDefDll;
using DBSqlite;
using YdPublic;

namespace Property
{
    public partial class FormCfgNormalInfo : Form
    {
        public FormCfgNormalInfo()
        {
            InitializeComponent();
        }

        public string StrComm { get; set; }
        public int IDefID { get; set; }
        public int IComType { get; set; }
        public string StrTcpDevIp { get; set; }
        public string StrTcpDevPort { get; set; }

        private Devs.Rs485Port m_pPort485 = new Devs.Rs485Port();
        private Devs.TCPPort m_pPortTcp= new Devs.TCPPort();

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
                    SerialPort = comboBoxCom.Text,
                    SerialStopBit = 1,
                    Timeout = 300
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
                    SerialPort = comboBoxCom.Text,
                    SerialStopBit = 1,
                    Timeout = 1000
                });
                m_pPortTcp.Open();
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            int iOpID = 0;
            int.TryParse(comboBoxID.Text, out iOpID);
            if (iOpID < 0 && iOpID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }
            InitPort();
            GLLedDefine.CardCfg cfg = new GLLedDefine.CardCfg();
            if (radioButtonCom.Checked)
            {
                if (!m_pPort485.GetCfg(iOpID, ref cfg))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                    m_pPort485.Close();
                    return;
                }
                m_pPort485.Close();
            }
            else
            {
                if (!m_pPortTcp.GetCfg(iOpID, ref cfg))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                    m_pPort485.Close();
                    return;
                }
                m_pPortTcp.Close();
            }

            //textBoxFVer.Text = "未获取";
            int iH = GLLedProtocol.GetValOfBCD_HightOrLow((byte)cfg.iHardVer, true);
            int il = GLLedProtocol.GetValOfBCD_HightOrLow((byte)cfg.iHardVer, false);
            textBoxHardVer.Text = "V" + iH + "." + il;
            iH = GLLedProtocol.GetValOfBCD_HightOrLow((byte)cfg.iFirmVer, true);
            il = GLLedProtocol.GetValOfBCD_HightOrLow((byte)cfg.iFirmVer, false);
            textBoxFVer.Text = "V" + iH + "." + il;

            textBoxReadID.Text = cfg.iID.ToString();
            comboBoxIsDouble.SelectedIndex = cfg.bDobule ? 1 : 0;
            comboBoxDigNumCount.SelectedIndex = cfg.iCardDigCount - 1;
            comboBoxScreenCount.SelectedIndex = cfg.iScreenCount - 1;
            if (cfg.iLight<0 || cfg.iLight>10)
            {
                comboBoxLights.SelectedIndex = 0;
            }
            else
            {
                comboBoxLights.SelectedIndex = cfg.iLight;
            }
            comboBoxShowAppend.SelectedIndex = cfg.bShowAppend ? 1 : 0;
            SaveCfgToCfgFile();
        }

        private void InitCommCombobox()
        {
            string[] arr = System.IO.Ports.SerialPort.GetPortNames();
            this.comboBoxCom.DataSource = arr;
        }

        private void InitIDCombobox()
        {
            for (int i = 1; i <= 255; i++)
            {
                comboBoxID.Items.Add(i.ToString());
            }
        }
         
        private void FormCfgNormalInfo_Load(object sender, EventArgs e)
        {
            InitCommCombobox();
            InitIDCombobox();

            LoadTypeByJson();
            InitCardTypeToTree();

            comboBoxCom.Text = StrComm;
            comboBoxID.Text = IDefID.ToString();
            radioButtonCom.Checked = IComType == 0;
            radioButtonTCP.Checked = IComType == 1;
            textBoxTcpDevIp.Text = StrTcpDevIp;
            textBoxDevPort.Text = StrTcpDevPort;
            radioButtonCom_CheckedChanged(null, null);            
            SelectedCardItem(ConfigHlper.GetConfig(ConstDef.strKeyDefModule, "GS-888888"));
            LanguageMgr.ReloadLanguage(this);
        }

        private void SelectedCardItem(string strType)
        {
            foreach (TreeNode tn in treeViewCardType.Nodes)
            {
                if (tn.Text == strType)
                {
                    treeViewCardType.SelectedNode = tn;
                    break;
                }
            } 
            
            SetDisplayByType(strType);
        }
        

        private void InitCardTypeToTree()
        {
            if (m_lstCardType == null)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipTypeNoDef"));
                return;
            }
            foreach (CardDefine acard in m_lstCardType)
            {
                if (acard.iTypeID != CardTypeDef.iCardOil)
                    continue;

                TreeNode tn = treeViewCardType.Nodes.Add(acard.sTypeDisplay);
                tn.Tag = acard;
            }

        }


        private List<CardDefine> m_lstCardType;

        private void LoadTypeByJson()
        {
            try
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory;
                string strFile = strPath + ConstDef.strJsonTypeFile;
                FileStream fs = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                StreamReader m_streamReader = new StreamReader(fs, Encoding.UTF8);
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                string strAllInfo = m_streamReader.ReadToEnd();
                m_lstCardType = JsonStrObjConver.JsonStr2Obj(strAllInfo, typeof(List<CardDefine>)) as List<CardDefine>;

                m_streamReader.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void SetDisplayByType(string strType)
        {
            int iDigCount;
            int iMainDigCount;
            int iAppDigCount;
            bool bShow99;
            bool bShow109;

            GSTypeHlper.GetTypeInfoByString(strType,
            out iDigCount,
            out iMainDigCount,
            out iAppDigCount,
            out bShow99,
            out bShow109);

            comboBoxDigNumCount.SelectedIndex = (iMainDigCount + iAppDigCount-1);
            oilCardScreen1.iOilCardDigCount = iMainDigCount;
            oilCardScreen1.bEnableMdy = false;
            oilCardScreen1.bShow10_9 = bShow109;
            oilCardScreen1.iShow99 = iAppDigCount;
            oilCardScreen1.DigValue = "8888888888";

        }

        private void treeViewCardType_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                
                CardDefine aCard =  treeViewCardType.GetNodeAt(e.X, e.Y).Tag as CardDefine;
                if (aCard == null)
                {
                    return;
                }
                SetDisplayByType(aCard.sTypeDisplay);
            }
        }

        private void treeViewCardType_MouseUp(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                CardDefine aCard = treeViewCardType.GetNodeAt(e.X, e.Y).Tag as CardDefine;
                if (aCard == null)
                {
                    return;
                }
                SetDisplayByType(aCard.sTypeDisplay);
            }
        }


        private void SaveCfgToCfgFile()
        {
            ConfigHlper.SetConfig(ConstDef.strKeyDefScreenCount, comboBoxScreenCount.Text);
            ConfigHlper.SetConfig(ConstDef.strKeyDefModule, treeViewCardType.SelectedNode.Text);
            ConfigHlper.SetConfig(ConstDef.strKeyDefIsDouble, comboBoxIsDouble.SelectedIndex==1 ? "1" : "0");
        }

        private void buttonSetCfg_Click(object sender, EventArgs e)
        {
            SaveCfgToCfgFile();

            int iOpID = 0;
            int.TryParse(comboBoxID.Text, out iOpID);
            if (iOpID < 0 && iOpID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }

            if (comboBoxScreenCount.SelectedIndex < 0
                || comboBoxLights.SelectedIndex<0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }



            InitPort();

            GLLedDefine.CardCfg cfg = new GLLedDefine.CardCfg();
            cfg.bDobule = comboBoxIsDouble.SelectedIndex == 1;
            cfg.bShowAppend = comboBoxShowAppend.SelectedIndex == 1;
            cfg.iScreenCount = comboBoxScreenCount.SelectedIndex + 1;
            cfg.iCardDigCount = comboBoxDigNumCount.SelectedIndex + 1;
            if (cfg.iCardDigCount==0)
            {
                cfg.iCardDigCount = 6;
            }
            cfg.iCardType = 0;
            cfg.iLight = comboBoxLights.SelectedIndex;

            if (radioButtonCom.Checked)
            {
                if (!m_pPort485.SetCfg(iOpID, cfg))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                    m_pPort485.Close();
                    return;
                }
                m_pPort485.Close();
            }
            else
            {
                if (!m_pPortTcp.SetCfg(iOpID, cfg))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                    m_pPortTcp.Close();
                    return;
                }
                m_pPortTcp.Close();

            }
            MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void treeViewCardType_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void radioButtonTCP_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDevPort.ReadOnly = radioButtonCom.Checked;
            textBoxTcpDevIp.ReadOnly = radioButtonCom.Checked;
            comboBoxCom.Enabled = radioButtonCom.Checked;            
        }

        private void radioButtonCom_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDevPort.ReadOnly = radioButtonCom.Checked;
            textBoxTcpDevIp.ReadOnly = radioButtonCom.Checked;
            comboBoxCom.Enabled = radioButtonCom.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetDisplayByType(ConfigHlper.GetConfig(ConstDef.strKeyDefModule, "GS-888888"));
            timer1.Enabled = false;
        }
    }
}
