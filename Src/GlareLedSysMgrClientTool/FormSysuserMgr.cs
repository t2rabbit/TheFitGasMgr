using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;
using YdPublic;

namespace Property
{
    public partial class FormSysuserMgr : Form
    {
        public FormSysuserMgr()
        {
            InitializeComponent();
        }

        private void ReloadToGrid()
        {
            dataGridViewSysUser.Rows.Clear();

            using (GLedDBEntities ent = new GLedDBEntities())
            {
                List<GL_Org> lstOrgs = ent.GL_Org.ToList();

                foreach (GL_SystemUser item in ent.GL_SystemUser)
                {
                    GL_Org aOrg = (from c in lstOrgs where c.ID == item.OrgID select c).FirstOrDefault();
                    if (aOrg == null)
                    {
                        continue;
                    }

                    int id = dataGridViewSysUser.Rows.Add(new object[] { 
                        item.Name,
                        aOrg.Name,
                        item.Auth==10?"System User":"Client",
                    });
                    dataGridViewSysUser.Rows[id].Tag = item;
                }
            }
        }
        private void FormSysuserMgr_Load(object sender, EventArgs e)
        {            
            LanguageMgr.ReloadLanguage(this);
            ReloadGridLanguage();
            ReloadToGrid();            
        }

        private void ReloadGridLanguage()
        {
            dataGridViewSysUser.Columns[0].HeaderText = LanguageMgr.GetKey("GridItemUserName");
            dataGridViewSysUser.Columns[1].HeaderText = LanguageMgr.GetKey("GridItemUserAppendOil");
            dataGridViewSysUser.Columns[2].HeaderText = LanguageMgr.GetKey("GridItemUserAuth");        
        }

        private void buttonMdy_Click(object sender, EventArgs e)
        {
            if (dataGridViewSysUser.SelectedRows.Count!=1)
            {
                MessageBox.Show(LanguageMgr.GetKey("PleaseSelOneUser"));
                return;
            }

            GL_SystemUser aOld = dataGridViewSysUser.SelectedRows[0].Tag as GL_SystemUser;

            FormSysUserInfo dlg = new FormSysUserInfo();
            dlg.m_NewOrMdy = YDesmsPublicDefDll.UIDefine.EUINewOrMdy.E_MDY;
            dlg.m_oldItem = aOld;
            dlg.ShowDialog();
            ReloadToGrid();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormSysUserInfo dlg = new FormSysUserInfo();
            dlg.m_NewOrMdy = YDesmsPublicDefDll.UIDefine.EUINewOrMdy.E_NEW;
            dlg.ShowDialog();
            ReloadToGrid();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewSysUser.SelectedRows.Count != 1)
            {
                MessageBox.Show(LanguageMgr.GetKey("PleaseSelOneUser"));
                return;
            }

            if (
                MessageBox.Show(LanguageMgr.GetKey("ConfirmDel"),
                LanguageMgr.GetKey("ConfirmDel"), MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            GL_SystemUser aOld = dataGridViewSysUser.SelectedRows[0].Tag as GL_SystemUser;

            DB.MemDB.Get().DelSysUser((int)aOld.ID);
            ReloadToGrid();
        }
    }
}
