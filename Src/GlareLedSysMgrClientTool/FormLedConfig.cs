using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDesmsPublicDefDll;
using System.IO;
using YD_PUBLIC;
using DBSqlite;
using Property.Devs;
using YdPublic;

namespace Property
{
    public partial class FormLedConfig : Form
    {

        public GL_LedCard m_ledCard;
        public FormLedConfig()
        {
            InitializeComponent();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            bool bSendResult = false;
            GLLedDefine.CardCfg cfgObj = new GLLedDefine.CardCfg();
            //JsonDev aDev = (from c in OrgClient.Get().m_lstDevs where c.ID == m_ledCard.DevID select c).FirstOrDefault();
           
            List<GLLedDefine.CardOilValEachNumAByte> lstCardVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)m_ledCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }
                bSendResult = aPort.GetCfg((int)m_ledCard.Addr, ref cfgObj);

            }
            else if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT)
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }
                JsonCardCfg jsoncfgobj = new JsonCardCfg();
                bSendResult = pTcp.GetLedCfg((int)m_ledCard.Addr, ref jsoncfgobj);

                cfgObj.bDobule = jsoncfgobj.bDobule;
                cfgObj.bShowAppend = jsoncfgobj.bShowAppend;
                cfgObj.iCardDigCount = jsoncfgobj.iCardDigCount;
                cfgObj.iCardType = jsoncfgobj.iCardType;
                cfgObj.iFirmVer = jsoncfgobj.iFirmVer;
                cfgObj.iHardVer = jsoncfgobj.iHardVer;
                cfgObj.iID = jsoncfgobj.iID;
                cfgObj.iLight = jsoncfgobj.iLight;
                cfgObj.iScreenCount = jsoncfgobj.iScreenCount;

            }
            else
            {

            }

            if (bSendResult)
            {
                Mem2View(cfgObj);                                
                MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
            }
        }


        /// <summary>
        /// 把存储成BCD码的数字转换成普通数据 如：0x11-->11
        /// </summary>
        /// <param name="bVal"></param>
        /// <returns></returns>
        static public byte BCD2Val(byte bVal)
        {
            byte bTmp = 0;
            byte iTenB = (byte)(bVal >> 4);
            byte iFirstB = (byte)(bVal & 0x0f);
            bTmp = (byte)(iTenB * 10 + iFirstB);
            return bTmp;
        }

        /// <summary>
        /// 获取BCD码的数字，分别获取高低部分，如0X23,分别获取2，3
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte GetHeightLowByteByBCDVal(byte bVal, bool bHight)
        {
            byte iTenB = (byte)((bVal & 0xf0) >> 4);
            byte iFirstB = (byte)(bVal & 0x0f);
            return bHight ? iTenB : iFirstB;
        }


        /// <summary>
        /// 2普通数字,高低位转换成BCD码， 0x1,0x5-->0x15
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte MakeVal2BCD_ByTowVal(byte bHight, byte bLow)
        {
            byte bTmp = 0;
            bTmp = (byte)(bHight << 4 | bLow);
            return bTmp;
        }

        /// <summary>
        /// 普通数字转换成BCD码， int  a=11--->0X11;
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte GetValOfBCD_HightOrLow(byte bVal, bool bHight)
        {
            byte bTmp = 0;
            int iTenB = bVal / 10;
            int iFirstB = bVal % 10;
            if (bHight)
                return (byte)iTenB;
            else
                return (byte)iFirstB;
        }
        
        private void Mem2View(GLLedDefine.CardCfg cfg)
        {

            //textBoxFVer.Text = "未获取";
            int iH = GetValOfBCD_HightOrLow((byte)cfg.iHardVer, true);
            int il = GetValOfBCD_HightOrLow((byte)cfg.iHardVer, false);
            textBoxHardVer.Text = iH + "." + il;
            iH = GetValOfBCD_HightOrLow((byte)cfg.iFirmVer, true);
            il = GetValOfBCD_HightOrLow((byte)cfg.iFirmVer, false);
            textBoxFVer.Text = iH + "." + il;

            textBoxReadID.Text = cfg.iID.ToString();
            comboBoxIsDouble.SelectedIndex = cfg.bDobule ? 1 : 0;
            comboBoxDigNumCount.SelectedIndex = cfg.iCardDigCount - 1;
            comboBoxScreenCount.SelectedIndex = cfg.iScreenCount - 1;
            comboBoxLights.SelectedIndex = cfg.iLight;
            comboBoxShowAppend.SelectedIndex = cfg.bShowAppend ? 1 : 0;

        }


        private void buttonSetCfg_Click(object sender, EventArgs e)
        {

            GLLedDefine.CardCfg cfgObj = new GLLedDefine.CardCfg();
            cfgObj.bDobule = comboBoxIsDouble.SelectedIndex == 1;
            cfgObj.bShowAppend = comboBoxShowAppend.SelectedIndex == 1;
            cfgObj.iScreenCount = comboBoxScreenCount.SelectedIndex + 1;
            cfgObj.iCardDigCount = comboBoxDigNumCount.SelectedIndex + 1;
            cfgObj.iCardType = 0;
            cfgObj.iLight = comboBoxLights.SelectedIndex;
            
            bool bSendResult = false;
            //JsonDev aDev = (from c in OrgClient.Get().m_lstDevs where c.ID == m_ledCard.DevID select c).FirstOrDefault();

            List<GLLedDefine.CardOilValEachNumAByte> lstCardVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)m_ledCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }
                bSendResult = aPort.SetCfg((int)m_ledCard.Addr, cfgObj);

            }
            else if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT)
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }


                JsonCardCfg jsoncfgobj = new JsonCardCfg();
                jsoncfgobj.bDobule = cfgObj.bDobule;
                jsoncfgobj.bShowAppend = cfgObj.bShowAppend;
                jsoncfgobj.iCardDigCount = cfgObj.iCardDigCount;
                jsoncfgobj.iCardType = cfgObj.iCardType;
                jsoncfgobj.iFirmVer = cfgObj.iFirmVer;
                jsoncfgobj.iHardVer = cfgObj.iHardVer;
                jsoncfgobj.iID = cfgObj.iID;
                jsoncfgobj.iLight = cfgObj.iLight;
                jsoncfgobj.iScreenCount = cfgObj.iScreenCount;

                bSendResult = pTcp.SetLedCfg((int)m_ledCard.Addr, jsoncfgobj);
            }
            else
            {

            }

            if (bSendResult)
            {
                MessageBox.Show(LanguageMgr.GetKey("OpSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("OpFailed"));
            }
        }

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

                TreeNode tn = treeViewOilType.Nodes.Add(acard.sTypeDisplay);
                tn.Tag = acard;
            }

        }


        private List<CardDefine> m_lstCardType;
        private void FormLedConfig_Load(object sender, EventArgs e)
        {
            textBoxCurOilCard.Text = m_ledCard.Name;
            LoadTypeByJson();
            InitCardTypeToTree();

            //
            // load info by db
            //
            SetSelectTreeNode(m_ledCard.CardModule);
        }


        private void SetSelectTreeNode(string strType)
        {
            foreach (TreeNode tnNode in treeViewOilType.Nodes)
            {
                if (tnNode.Text == strType)
                {
                    treeViewOilType.SelectedNode = tnNode;
                    return;
                }
            }
        }

        private void buttonSaveToDB_Click(object sender, EventArgs e)
        {
            m_ledCard.IsDouble = comboBoxIsDouble.SelectedIndex;
            m_ledCard.ScreenCount = comboBoxScreenCount.SelectedIndex + 1;
            m_ledCard.NumberCount = comboBoxDigNumCount.SelectedIndex + 1;
            m_ledCard.Brightness = comboBoxLights.SelectedIndex;
            m_ledCard.CardModule = treeViewOilType.SelectedNode.Text;

            DB.MemDB.Get().UpdateCard((int)m_ledCard.ID, m_ledCard);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CardDefine aCard = treeViewOilType.SelectedNode.Tag as CardDefine;
            SetDisPlayByType(aCard.sTypeDisplay);
        }

        //
        // 设置显示
        //
        private int iMainWidth = 30;
        private int iMainPadd = 4;
        private void SetDisPlayByType(string strType)
        {
            //"GS-8888-99"
            string[] strInfo = strType.Split(new char[] { '-', ',' });
            if (strInfo.Count() < 1)
            {
                return;
            }

            int iCountMain = strInfo[1].Length;
            oilScreen1.iMainCount = iCountMain;
            bool bAppend = false;

            if (strInfo.Length < 3)
            {
                oilScreen1.BAppend10_9 = false;
                oilScreen1.BAppend99 = false;                
            }
            else
            {
                if (strInfo[2] == "910")
                {
                    oilScreen1.BAppend10_9 = true;
                    oilScreen1.BAppend99 = false;
                    bAppend = true;
                }
                else if (strInfo[2]=="99")
                {

                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = true;
                    oilScreen1.iAppendCount = 2;
                }
                else if (strInfo[2] == "9")
                {
                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = true;
                    oilScreen1.iAppendCount = 1;
                }
                else
                {
                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = false;
                }
            }

            comboBoxDigNumCount.SelectedIndex = iCountMain - 1;
            comboBoxShowAppend.SelectedIndex = bAppend ? 1 : 0;
        }

        private void buttonLoadByDB_Click(object sender, EventArgs e)
        {
            SetSelectTreeNode(m_ledCard.CardModule);

            string[] strInfo = m_ledCard.CardModule.Split(new char[] { '-', ',' });          
            int iCountMain = strInfo.Length>1?strInfo[1].Length:0;
            oilScreen1.iMainCount = iCountMain;
            bool bAppend = false;

            if (strInfo.Length < 3)
            {
                oilScreen1.BAppend10_9 = false;
                oilScreen1.BAppend99 = false;
            }
            else
            {
                if (strInfo[2] == "910")
                {
                    oilScreen1.BAppend10_9 = true;
                    oilScreen1.BAppend99 = false;
                    bAppend = true;
                }
                else if (strInfo[2] == "99")
                {

                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = true;
                    oilScreen1.iAppendCount = 2;
                }
                else if (strInfo[2] == "9")
                {
                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = true;
                    oilScreen1.iAppendCount = 1;
                }
                else
                {
                    oilScreen1.BAppend10_9 = false;
                    oilScreen1.BAppend99 = false;
                }
            }
            textBoxReadID.Text = m_ledCard.Addr.ToString();
            comboBoxIsDouble.SelectedIndex = (int)m_ledCard.IsDouble;
            comboBoxShowAppend.SelectedIndex = bAppend ? 1 : 0;
            comboBoxScreenCount.SelectedIndex = (int)m_ledCard.ScreenCount - 1;
            comboBoxDigNumCount.SelectedIndex = iCountMain-1;
            comboBoxLights.SelectedIndex = (int)m_ledCard.Brightness;
        }
    }
}
