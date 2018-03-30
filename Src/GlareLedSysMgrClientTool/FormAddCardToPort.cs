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
using Property.DB;
using DBSqlite;
using YDesmsPublicDefDll;
using YdPublic;

namespace Property
{
    public partial class FormAddCardToPort : Form
    {
        public UIDefine.EUINewOrMdy m_eNewOrMdy{get;set;}
        public GL_LedCard m_OldItem{get;set;}

        public FormAddCardToPort()
        {
            m_eNewOrMdy = UIDefine.EUINewOrMdy.E_NONE;
            InitializeComponent();
            LoadTypeByJson();
        }


        private void InitCardTypeToTree()
        {
            if (m_lstCardType == null)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipTypeNoDef"));
            }
            TreeNode tnOil = treeView1.Nodes.Add(CardTypeDef.strCardOil);
            TreeNode tnDt = treeView1.Nodes.Add(CardTypeDef.strCardDatetime);

            foreach (CardDefine acard in m_lstCardType)
            {
                if (acard.iTypeID != CardTypeDef.iCardOil)
                    continue;

                TreeNode tn = tnOil.Nodes.Add(acard.sTypeDisplay);
                tn.Tag = acard;
            }


            foreach (CardDefine acard in m_lstCardType)
            {
                if (acard.iTypeID != CardTypeDef.iCardDT)
                    continue;

                TreeNode tn = tnDt.Nodes.Add(acard.sTypeDisplay);
                tn.Tag = acard;
            }        
        }

        private bool SetSelected(TreeNode tn, string strType)
        {
            if (tn.Tag != null)
            {
                CardDefine aTyp = tn.Tag as CardDefine;
                if (aTyp.sTypeDisplay == strType)
                {
                    treeView1.SelectedNode = tn;
                    return true;
                }                
            }
            else
            {
                foreach (TreeNode tnSub in tn.Nodes)
                {
                    if (SetSelected(tnSub, strType))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private List<CardDefine> m_lstCardType;
        private void FormAddCardToPort_Load(object sender, EventArgs e)
        {
            LanguageMgr.ReloadLanguage(this);

            panelcardoil.Dock = DockStyle.Left;
            panelCardDt.Dock = DockStyle.Left;
            panelCardNotSel.Dock = DockStyle.Left;

            comboBoxScreenCount.SelectedIndex = 1;

            InitDevCombobox();
            InitCardTypeToTree();

            for(int i=0; i<10; i++)
            {
                comboBoxBrightness.Items.Add(i.ToString());
            }

            if (m_eNewOrMdy == UIDefine.EUINewOrMdy.E_MDY)
            {
                textBoxCardName.Text = m_OldItem.Name;
                textBoxAddr.Text = m_OldItem.Addr.ToString();
                comboBoxBrightness.SelectedIndex = (int)m_OldItem.Brightness;
                comboBoxScreenCount.SelectedIndex = (int)m_OldItem.ScreenCount-1;
                comboBoxDev.SelectedValue = m_OldItem.DevID;
                comboBoxNumCount.SelectedIndex = m_OldItem.NumberCount - 1;
                foreach (TreeNode tn in treeView1.Nodes)
                {
                    if (SetSelected(tn, m_OldItem.CardModule))
                    {
                        return;
                    }
                }
            }
            else if (m_eNewOrMdy == UIDefine.EUINewOrMdy.E_NEW)
            {

            }
            else if (m_eNewOrMdy == UIDefine.EUINewOrMdy.E_NONE)
            {
                System.Diagnostics.Debug.Assert(false);
            }

            treeView1.SelectedNode = treeView1.Nodes[0];
            comboBoxBrightness.SelectedIndex = 0;

        }

        private void InitDevCombobox()
        {
            IList<GL_Dev> lstDev = MemDB.Get().lstDev;
            comboBoxDev.DisplayMember = "Name";
            comboBoxDev.ValueMember = "ID";
            comboBoxDev.DataSource = lstDev;
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
            catch  (Exception ex)
            {

            }
        }

        private void ShowSelectedCardPreview(int iType)
        {
            panelCardDt.Visible = iType == CardTypeDef.iCardDT;
            panelcardoil.Visible = iType == CardTypeDef.iCardOil;
            panelCardNotSel.Visible = iType == 0;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                ShowSelectedCardPreview(0);
                return;
            }

            CardDefine aCard = treeView1.SelectedNode.Tag as CardDefine;
            if (aCard == null)
            {
                ShowSelectedCardPreview(0);
                return;
            }       
     
            SetDisPlayByType(aCard.sTypeDisplay);
            ShowSelectedCardPreview(aCard.iTypeID);
        }

        //
        // 设置显示
        //
        private int iMainWidth = 30;
        private int iMainPadd = 4;
        private void SetDisPlayByType(string strType)
        {
            //"GS-8888-99"
            string[] strInfo = strType.Split(new char[] {'-',',' });
            if (strInfo.Count() <1 )
            {
                return;
            }

            int iCountMain = strInfo[1].Length;
            int iWidht = iCountMain * 30 + (iCountMain+1) * iMainPadd;
            sevenSegmentArrayMain.Width = iWidht;
            int iStartY_1 = sevenSegmentArrayMain.Left + iWidht;
            panelAppend99.Left = iStartY_1;
            panelAppend910.Left = iStartY_1;
            bool bAppend9_10 = false;

            int iPointIndex = 1;
//             int.TryParse(strInfo[1], out iPointIndex);
//             if (iPointIndex <0)
//             {
//                 iPointIndex = 0;
//             }
            sevenSegmentArrayMain.IndexOfPoint = (iCountMain - iPointIndex);

            bAppend9_10 = false;
            if (strInfo.Length > 2 && strInfo[2] == "9")
            {
                panelAppend910.Visible = false;
                panelAppend99.Visible = true;
                sevenSegmentT1.Visible = true;
                sevenSegmentT2.Visible = false;
            }
            else if (strInfo.Length > 2 && strInfo[2] == "99")
            {
                panelAppend910.Visible = false;
                panelAppend99.Visible = true;
                sevenSegmentT1.Visible = true;
                sevenSegmentT2.Visible = true;
            }
            else if (strInfo.Length > 2 && strInfo[2] == "910")
            {
                panelAppend910.Visible = true;
                panelAppend99.Visible = false;
                sevenSegmentT1.Visible = false;
                sevenSegmentT2.Visible = false;
                bAppend9_10 = true;
            }
            else
            {
                panelAppend99.Visible = false;
                panelAppend910.Visible = false;
                bAppend9_10 = false;
            }


            //
            //  显示9/10
            //
            sevenSegment10_9_0.Value = "0";
            sevenSegment10_9_1.Value = "1";
            sevenSegment_10_9_9.Value = "9";

            comboBoxNumCount.SelectedIndex = iCountMain - 1;
            comboBoxIsShow910.SelectedIndex = bAppend9_10 ? 1 : 0;
            sevenSegmentArrayMain.ArrayCount = iCountMain;
            sevenSegmentArrayMain.IndexOfPoint = iCountMain-1;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int iAddr = 0;
            int iDevID = 0;
            int iNumCount = 0;
            

            if (comboBoxNumCount.SelectedIndex <0)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipSetDec"));
                iNumCount = comboBoxNumCount.SelectedIndex + 1;
                return;
            }

            iNumCount = comboBoxNumCount.SelectedIndex + 1;
            if (comboBoxScreenCount.SelectedIndex <0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }

            if (comboBoxBrightness.SelectedIndex <0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }

            int.TryParse(textBoxAddr.Text, out iAddr); 
            if (iAddr <= 0 && iAddr>=255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }

            try
            {
                iDevID = (int)(long)comboBoxDev.SelectedValue;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipSelPort"));
                return;
            }

            CardDefine aCardType = null;
            try
            {
                aCardType = treeView1.SelectedNode.Tag as CardDefine;
                if(aCardType == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                    return;
                }                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }

            GL_Dev aDev = DB.MemDB.Get().GetDevByID(iDevID);

            GL_LedCard aCard = new GL_LedCard()
            {
                Addr = iAddr,
                Brightness = comboBoxBrightness.SelectedIndex,
                CardModule = aCardType.sTypeDisplay,
                CardType = aCardType.iTypeID.ToString(),
                DevID = iDevID,                
                IsDouble = checkBoxIsDouble.Checked ? 1 : 0,
                Name = textBoxCardName.Text,
                OrgID = aDev.OrgID,
                ScreentContext ="000000",    
                ScreenCount = comboBoxScreenCount.SelectedIndex + 1,
                NumberCount = iNumCount,
                DecimalInfo = textBoxDecInfo.Text,                      
            };

            if (m_eNewOrMdy == UIDefine.EUINewOrMdy.E_MDY)
            {
                DB.MemDB.Get().UpdateCard((int)m_OldItem.ID, aCard);
            }
            else if (m_eNewOrMdy == UIDefine.EUINewOrMdy.E_NEW)
            {
                DB.MemDB.Get().AddCard(aCard);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false);
            }

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
