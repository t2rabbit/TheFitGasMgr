using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;

namespace Property
{
    public partial class ViewOrgRoot : Form
    {
        public ViewOrgRoot()
        {
            InitializeComponent();
        }

        private void ViewOrgRoot_Load(object sender, EventArgs e)
        {
            LoadOrg();
        }

        private void LoadOrg()
        {
            IList<GL_Org> lstOrg = DB.MemDB.Get().lstOrg;
            foreach (GL_Org aOrg in lstOrg)
            {
                dataGridViewOrgs.Rows.Add(new object[] { 
                    aOrg.Name,
                    aOrg.City,
                    aOrg.Manager,
                    aOrg.Tel,
                    DB.MemDB.Get().GetDevCountByOrgID((int)aOrg.ID),
                    DB.MemDB.Get().GetCardCountByOrgID((int)aOrg.ID),                
                });
            }
        }
    }
}
