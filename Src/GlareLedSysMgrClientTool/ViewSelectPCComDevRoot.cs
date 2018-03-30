using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;
using Property.DB;
using YDesmsPublicDefDll.Public;
using YDesmsPublicDefDll;

namespace Property
{
    public partial class ViewSelectPCComDevRoot : Form
    {
        public ViewSelectPCComDevRoot()
        {
            InitializeComponent();
        }

        public GL_Org m_org {get;set;}



        private void ViewSelectPCComDevRoot_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (m_org == null)
                {
                    comboBoxSelOrg.Visible = true;
                }
                else 
                {
                    comboBoxSelOrg.Visible = false;
                }



                dataGridViewDevList.Visible = radioButtonShowDev.Checked;
                dataGridViewCardList.Visible = radioButtonShowCard.Checked;
                panelOPPanel.Enabled = radioButtonShowCard.Checked;

                checkBoxAllCard.Enabled = radioButtonShowCard.Checked;
                checkBoxSellAllDev.Enabled = radioButtonShowDev.Checked;

                if (radioButtonShowDev.Checked)
                {
                    LoadDevToGrid();
                }
                else
                {
                    LoadCardToGrid();
                }
            }
        }



        private void ViewSelectPCComDevRoot_Load(object sender, EventArgs e)
        {
            InitOrgToSelect();

            dataGridViewCardList.Dock = DockStyle.Fill;
            dataGridViewDevList.Dock = DockStyle.Fill;
        }
// 
//             datagridviewCheckboxHeaderCell chDev = new datagridviewCheckboxHeaderCell();
//             chDev.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(chDev_OnCheckBoxClicked);//关联单击事件
//             DataGridViewCheckBoxColumn checkboxCol = this.dataGridViewDevList.Columns[0] as DataGridViewCheckBoxColumn;
//             checkboxCol.HeaderCell = chDev;
//             checkboxCol.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字
// 
// 
//             datagridviewCheckboxHeaderCell chCard = new datagridviewCheckboxHeaderCell();
//             chCard.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(chCard_OnCheckBoxClicked);//关联单击事件
//             DataGridViewCheckBoxColumn checkboxColCard = this.dataGridViewCardList.Columns[0] as DataGridViewCheckBoxColumn;
//             checkboxColCard.HeaderCell = chCard;
//             checkboxColCard.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字
//         }
// 
//         private void chDev_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
//         {
//             foreach (DataGridViewRow dgvRow in this.dataGridViewDevList.Rows)
//             {
//                 if (e.CheckedState)
//                 {
//                     dgvRow.Cells[0].Value = true;
//                 }
//                 else
//                 {
//                     dgvRow.Cells[0].Value = false;
//                 }
//             }
//         }
// 
//         private void chCard_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
//         {
//             foreach (DataGridViewRow dgvRow in this.dataGridViewCardList.Rows)
//             {
//                 if (e.CheckedState)
//                 {
//                     dgvRow.Cells[0].Value = true;
//                 }
//                 else
//                 {
//                     dgvRow.Cells[0].Value = false;
//                 }
//             }
//         }

        private void InitOrgToSelect()
        {
            comboBoxSelOrg.DisplayMember = "Name";
            comboBoxSelOrg.ValueMember = "ID";
            comboBoxSelOrg.DataSource = MemDB.Get().lstOrgWithAll;
        }

        private void LoadDevToGrid()
        {
            dataGridViewDevList.Rows.Clear();
            IList<GL_Dev> lstDev = (from c in DB.MemDB.Get().lstDev where c.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM select c).ToList();
            if (m_org != null)
            {
                lstDev = (from c in DB.MemDB.Get().lstDev where c.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM && c.OrgID == m_org.ID select c).ToList();
            }
            
            foreach (GL_Dev aDev in lstDev)
            {
                dataGridViewDevList.Rows.Add(new object[]{
                    false,
                    aDev.Name,
                    DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                    MemDB.Get().GetOrgNameByDevID((int)aDev.ID),
                    MemDB.Get().GetCardCountByDevID((int)aDev.ID),
                });
            }
        }

        private void LoadCardToGrid()
        {
            dataGridViewCardList.Rows.Clear();
            IList<GL_LedCard> lstCardWithoutDevType = null;
            IList<GL_LedCard> lstCardWithDevType = null;
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                List<GL_Dev> lstDev = (from c in ent.GL_Dev select c).ToList();
                if (m_org != null)
                {
                    lstCardWithoutDevType = (from c in ent.GL_LedCard where c.OrgID == m_org.ID select c).ToList();

                    //lstCard = (from c in ent.GL_LedCard where c.GL_Dev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT && c.OrgID == m_org.ID select c).ToList();
                }
                else
                {
                    lstCardWithoutDevType = (from c in ent.GL_LedCard select c).ToList();
                }

                foreach (GL_LedCard aCard in lstCardWithoutDevType)
                {
                    GL_Dev aDev = (from c in lstDev where c.ID == aCard.DevID select c).FirstOrDefault();
                    if (aDev != null && aDev.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM)
                    {
                        lstCardWithDevType.Add(aCard);
                    }
                }
                
            }

            foreach (GL_LedCard aCard in lstCardWithDevType)
            {
                GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == aCard.DevID select c).FirstOrDefault();
                int iIndex = dataGridViewCardList.Rows.Add(new object[]{
                    false,
                    aCard.Name,
                    MemDB.Get().GetOrgNameByCardID((int)aCard.ID),
                    MemDB.Get().GetDevNameByCardID((int)aCard.ID),
                    DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                    
                });

                dataGridViewCardList.Rows[iIndex].Tag = aCard;
            }
        }

        private void radioButtonShowCard_CheckedChanged(object sender, EventArgs e)
        {
            ViewSelectPCComDevRoot_VisibleChanged(null, null);
        }

        private void radioButtonShowDev_CheckedChanged(object sender, EventArgs e)
        {
            ViewSelectPCComDevRoot_VisibleChanged(null, null);
        }


        private void buttonViewCardVal_Click(object sender, EventArgs e)
        {

        }

        private void buttonSendCardContext_Click(object sender, EventArgs e)
        {
            IList<GL_LedCard> lstCard = new List<GL_LedCard>();
            foreach (DataGridViewRow aRow in dataGridViewCardList.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    lstCard.Add((GL_LedCard)aRow.Tag);
                }
            }


            FormSendToCardTip dlg = new FormSendToCardTip();
            dlg.lstCardToSend = lstCard;
            dlg.ShowDialog();
        }

        private void buttonMdyCardVal_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSelOrg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAllCard_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow aRow in dataGridViewCardList.Rows)
            {
                aRow.Cells[0].Value = checkBoxAllCard.Checked;
            }
        }

        private void checkBoxSellAllDev_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow aRow in dataGridViewDevList.Rows)
            {
                aRow.Cells[0].Value = checkBoxSellAllDev.Checked;
            }
        }
    }
}
