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

namespace Property
{
    public partial class ViewSelectAOrg : Form
    {
        private int m_iOrgIdSeled;

        public int OrgIDSeled {
            get
            {
                return m_iOrgIdSeled;
            }
            set
            {
                m_iOrgIdSeled = value;
                loadedDB = false;
            }
        }
        public bool loadedDB{get;set;}


        public ViewSelectAOrg()
        {
            InitializeComponent();
        }

        private void buttonSetContext_Click(object sender, EventArgs e)
        {

        }

        private void LoadCards()
        {
            if (!loadedDB)
            {
                loadedDB = true;
            }
            else
            {
                return;
            }

            dataGridViewCards.Rows.Clear();

            if (OrgIDSeled == 0 )
            {
                return;
            }

            using (DBSqlite.GLedDBEntities ent = new DBSqlite.GLedDBEntities())
            {
                IList<GL_Dev> lstDev = (from c in ent.GL_Dev where c.OrgID == OrgIDSeled select c).ToList();
                foreach (GL_Dev aDev in lstDev)
                {
                    IList<GL_LedCard> lstCard = (from c in ent.GL_LedCard where c.DevID == aDev.ID select c).ToList();
                    foreach (GL_LedCard aCard in lstCard)
                    {
                        int iID = dataGridViewCards.Rows.Add(new object[]{
                            aDev.Name,
                            DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                             aCard.Name + ":"  + aCard.Addr,
                              aCard.ScreenCount,                              
                        } );
                        dataGridViewCards.Rows[iID].Tag = aCard;
                    }
                }
            }
        }


        private void ViewSelectOrg_Load(object sender, EventArgs e)
        {
            
        }

        private void ViewSelectOrg_VisibleChanged(object sender, EventArgs e)
        {            
            if (Visible)
            {
                LoadCards();
            }
        }

        public void SelectedFire()
        {
            ViewSelectOrg_VisibleChanged(null, null);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

        }
    }
}
