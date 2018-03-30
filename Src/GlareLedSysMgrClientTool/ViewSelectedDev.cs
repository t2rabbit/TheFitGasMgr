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
using Property.DB;
using YDesmsPublicDefDll.Public;

namespace Property
{
    public partial class ViewSelectedDev : Form
    {
        public int DevIDSeled { get;set; }
        //public bool loadedDB{get;set;}
        public ViewSelectedDev()
        {
            InitializeComponent();
        }

        public GL_Org m_org {get;set;}

        private void LoadCards()
        {
            dataGridViewCards.Rows.Clear();

            if (DevIDSeled == 0)
            {
                return;
            }

            using (DBSqlite.GLedDBEntities ent = new DBSqlite.GLedDBEntities())
            {
                GL_Dev aDev = (from c in ent.GL_Dev where c.ID == DevIDSeled select c).FirstOrDefault();
                //IList<GL_Dev> lstDev = (from c in ent.GL_Dev where c.OrgID == OrgIDSeled select c).ToList();
                //foreach (GL_Dev aDev in lstDev)
                //{
                    IList<GL_LedCard> lstCard = (from c in ent.GL_LedCard where c.DevID == DevIDSeled select c).ToList();
                    foreach (GL_LedCard aCard in lstCard)
                    {
                        int iID = dataGridViewCards.Rows.Add(new object[]{  
                            false,                           
                            aCard.Name + ":"  + aCard.Addr,
                            aDev.Name,
                            DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                            aCard.ScreenCount, 
                            aCard.ScreentContext, 
                        });
                        dataGridViewCards.Rows[iID].Tag = aCard;
                    }
                //}
            }
        }


        private void ViewSelectedDev_Load(object sender, EventArgs e)
        {
            datagridviewCheckboxHeaderCell chCard = new datagridviewCheckboxHeaderCell();
            chCard.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(chDev_OnCheckBoxClicked);//关联单击事件
            DataGridViewCheckBoxColumn checkboxColCard = this.dataGridViewCards.Columns[0] as DataGridViewCheckBoxColumn;
            checkboxColCard.HeaderCell = chCard;
            checkboxColCard.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字
        }

        private void chDev_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.dataGridViewCards.Rows)
            {
                if (e.CheckedState)
                {
                    dgvRow.Cells[0].Value = true;
                }
                else
                {
                    dgvRow.Cells[0].Value = false;
                }
            }
        }



        private void buttonSend_Click(object sender, EventArgs e)
        {
            IList<GL_LedCard> lstCard = new List<GL_LedCard>();
            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
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

        private void buttonRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请到相应的页面，单个读取");
            return;
        }

        private void buttonSetContext_Click(object sender, EventArgs e)
        {
            int iSeled = 0;
            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    iSeled++;
                }
            }

            if (iSeled <=0)
            {
                return;
            }

            FormSetContextVal dlg = new FormSetContextVal();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    GL_LedCard aCard = aRow.Tag as GL_LedCard;
                    aCard.ScreentContext = dlg.strContext;
                    MemDB.Get().UpdateCard((int)aCard.ID, aCard);
                }
            }
            
        }

        private void ViewSelectedDev_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadCards();
                GL_Dev aDev = (from c in MemDB.Get().lstDev where c.ID == DevIDSeled select c).FirstOrDefault();
                textBox1.Text = aDev.Name;
            }
        }


        public void SelectedFire()
        {
            ViewSelectedDev_VisibleChanged(null, null);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
