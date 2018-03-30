using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;
using YDesmsPublicDefDll;
using YdPublic;

namespace Property
{
    public partial class FormDevMgr : Form
    {
        public FormDevMgr()
        {
            InitializeComponent();
        }

        private void FormSysMgr_Load(object sender, EventArgs e)
        {
            LoadAllCardToTree();
            LanguageMgr.ReloadLanguage(this);
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

        private void LoadAllCardToTree()
        {
            if (radioButtonByDev.Checked)
            {
                LoadAddDevToTreeByDev();
            }
            else
            {
                LoadAddDevToTreeByOrg();
            }

            treeView1.ExpandAll();
        }


        private void radioButtonByDev_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllCardToTree();
        }

        private void radioButtonByOrg_CheckedChanged(object sender, EventArgs e)
        {
            LoadAllCardToTree();
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
            m_tnSerialRoot = treeView1.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeySerialPorts));
            foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_SERIAL_COM)
                {
                    continue;
                }

                TreeNode tnNode = m_tnSerialRoot.Nodes.Add(aDev.Name + "[" + aDev.SerialPort + "]");
                tnNode.Tag = aDev;

                LoadCardToDev(tnNode, aDev);
            }

            m_tnTCPServerRoot = treeView1.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyTcpPorts));
            foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_TCP_SERVER)
                {
                    continue;
                }

                TreeNode tnNode = m_tnTCPServerRoot.Nodes.Add(aDev.Name + "[" + aDev.DevServerIP + ":" + aDev.DevServerPort + "]");
                tnNode.Tag = aDev;
                LoadCardToDev(tnNode, aDev);
            }


            m_tnTcpClientRoot = treeView1.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyGprsPorts));
            foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
            {
                if (aDev.CommType != (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    continue;
                }

                TreeNode tnNode = m_tnTcpClientRoot.Nodes.Add(aDev.Name + "[" + aDev.DevClientName + "]");
                tnNode.Tag = aDev;
                LoadCardToDev(tnNode, aDev);
            }
// 
//             m_tnSerialRoot.Expand();
//             m_tnTcpClientRoot.Expand();
//             m_tnTCPServerRoot.Expand();
        }


        private void LoadAddDevToTreeByOrg()
        {
            treeView1.Nodes.Clear();
            TreeNode tnOrgRoot = treeView1.Nodes.Add(LanguageMgr.GetKey(ConstDef.strLanguageKeyoilstation));

            string strTransferType = "";
            foreach (GL_Org aOrg in DB.MemDB.Get().lstOrg)
            {
                TreeNode tnOrg = tnOrgRoot.Nodes.Add(aOrg.Name);
                tnOrg.Tag = aOrg;

                foreach (GL_Dev aDev in DB.MemDB.Get().lstDev)
                {
                    if (aDev.OrgID != aOrg.ID)
                    {
                        continue;
                    }
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

                    TreeNode tnNode = tnOrg.Nodes.Add(strTransferType + ":" + aDev.Name + "[" + aDev.SerialPort + "]");
                    tnNode.Tag = aDev;
                    LoadCardToDev(tnNode, aDev);
                }
            }
        }


        private void buttonAddPort_Click(object sender, EventArgs e)
        {
            FormAddDev dlg = new FormAddDev();
            dlg.m_NewMdy = UIDefine.EUINewOrMdy.E_NEW;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadAllCardToTree();
            }
        }

        private void buttonAddCard_Click(object sender, EventArgs e)
        {
            FormAddCardToPort dlg = new FormAddCardToPort();
            dlg.m_eNewOrMdy = UIDefine.EUINewOrMdy.E_NEW;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadAllCardToTree();
            }
        }

        private void buttonAddOrg_Click(object sender, EventArgs e)
        {
            FormOrgInfo dlg = new FormOrgInfo();
            dlg.m_NewOrMdy = YDesmsPublicDefDll.UIDefine.EUINewOrMdy.E_NEW;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadAllCardToTree();
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonRFresh_Click(object sender, EventArgs e)
        {
            LoadAllCardToTree();
        }


        private bool GetTreeSelected()
        {
            return true;
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            GL_Org aOrg = null;
            GL_Dev aDev = null;
            GL_LedCard aCard = null;
            object aTag = (treeView1.SelectedNode.Tag);

            if (treeView1.SelectedNode == null || aTag == null)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipPleaseSelectItem"));
                return;
            }
            if ( (aOrg=aTag as GL_Org) != null )
            {
                FormOrgInfo dlg = new FormOrgInfo();
                dlg.m_NewOrMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_orgOld = aOrg;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }
            if ((aDev = aTag as GL_Dev) != null)
            {
                FormAddDev dlg = new FormAddDev();
                dlg.m_NewMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_oldItem = aDev;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }

            if ((aCard = aTag as GL_LedCard) != null)
            {
                FormAddCardToPort dlg = new FormAddCardToPort();
                dlg.m_eNewOrMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_OldItem = aCard;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            GL_Org aOrg = null;
            GL_Dev aDev = null;
            GL_LedCard aCard = null;
            object aTag = (treeView1.SelectedNode.Tag);

            try
            {
                if (treeView1.SelectedNode == null || aTag == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipPleaseSelectItem"));
                    return;
                }
                if ((aOrg = aTag as GL_Org) != null)
                {
                    DB.MemDB.Get().DelOrg((int)aOrg.ID);
                }
                if ((aDev = aTag as GL_Dev) != null)
                {
                    DB.MemDB.Get().DelDev((int)aDev.ID);

                }

                if ((aCard = aTag as GL_LedCard) != null)
                {
                    DB.MemDB.Get().DelCard((int)aCard.ID);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(LanguageMgr.GetKey("OpFailed"));
            }
            
        }

        private void buttonMdy_Click(object sender, EventArgs e)
        {
            
            GL_Org aOrg = null;
            GL_Dev aDev = null;
            GL_LedCard aCard = null;
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipPleaseSelectItem"));
                return;
            }

            object aTag = (treeView1.SelectedNode.Tag);

            if (treeView1.SelectedNode == null || aTag == null)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipPleaseSelectItem"));
                return;
            }
            if ((aOrg = aTag as GL_Org) != null)
            {
                FormOrgInfo dlg = new FormOrgInfo();
                dlg.m_NewOrMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_orgOld = aOrg;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }
            if ((aDev = aTag as GL_Dev) != null)
            {
                FormAddDev dlg = new FormAddDev();
                dlg.m_NewMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_oldItem = aDev;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }

            if ((aCard = aTag as GL_LedCard) != null)
            {
                FormAddCardToPort dlg = new FormAddCardToPort();
                dlg.m_eNewOrMdy = UIDefine.EUINewOrMdy.E_MDY;
                dlg.m_OldItem = aCard;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCardToTree();
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

    }
}
