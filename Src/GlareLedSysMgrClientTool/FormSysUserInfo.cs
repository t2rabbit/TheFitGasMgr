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
    public partial class FormSysUserInfo : Form
    {
        public FormSysUserInfo()
        {
            InitializeComponent();
        }

        public YDesmsPublicDefDll.UIDefine.EUINewOrMdy m_NewOrMdy { get; set; }
        public GL_SystemUser m_oldItem{ get; set; }
        

        private void FormSysUserInfo_Load(object sender, EventArgs e)
        {
            LanguageMgr.ReloadLanguage(this);
            LoadOrgCombobox();
        }

        private void LoadOrgCombobox()
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                List<GL_Org> lstOrg = ent.GL_Org.ToList();
                comboBoxOilStation.ValueMember = "ID";
                comboBoxOilStation.DisplayMember = "Name";
                comboBoxOilStation.DataSource = lstOrg;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxUserName.Text.Length ==0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputUserName"));
                return;
            }

            if (textBoxPassword.Text.Length < 1)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputPasswordError"));
                return;
            }

            if (comboBoxOilStation.SelectedIndex <0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputSelectOilStation"));
                return;
            }

            if (comboBoxAuth.SelectedIndex <0)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }




            if(m_NewOrMdy== YDesmsPublicDefDll.UIDefine.EUINewOrMdy.E_NEW)
            {
                using (GLedDBEntities ent = new GLedDBEntities())
                {
                    GL_SystemUser aolduser = (from c in ent.GL_SystemUser where c.Name == textBoxUserName.Text select c).FirstOrDefault();
                    if (aolduser != null)
                    {
                        MessageBox.Show(LanguageMgr.GetKey("UserNameExisted"));
                        return;
                    }

                    GL_SystemUser anew = new GL_SystemUser()
                    {
                        Auth = comboBoxAuth.SelectedIndex == 1 ? 10 : 100,
                        ID = 0,
                        Name = textBoxUserName.Text,
                        OrgID = (int)(long)comboBoxOilStation.SelectedValue,
                        Password = textBoxPassword.Text
                    };
                    DB.MemDB.Get().AddSysUser(anew);
                }
            }
            else if(m_NewOrMdy == YDesmsPublicDefDll.UIDefine.EUINewOrMdy.E_MDY)
            {
                using (GLedDBEntities ent = new GLedDBEntities())
                {
                    GL_SystemUser aolduser = (from c in ent.GL_SystemUser where c.Name == textBoxUserName.Text select c).FirstOrDefault();
                    if (aolduser != null && aolduser.ID != m_oldItem.ID)
                    {
                        MessageBox.Show(LanguageMgr.GetKey("UserNameExisted"));
                        return;
                    }

                    GL_SystemUser anew = new GL_SystemUser()
                    {
                        Auth = comboBoxAuth.SelectedIndex == 1 ? 10 : 100,
                        ID = m_oldItem.ID,
                        Name = textBoxUserName.Text,
                        OrgID = (int)comboBoxOilStation.SelectedValue,
                        Password = textBoxPassword.Text
                    };
                    DB.MemDB.Get().UpdateSysUser((int)m_oldItem.ID, anew);
                }
            }
            else
            {
                System.Diagnostics.Debug.Assert(false);
            }
            MessageBox.Show(LanguageMgr.GetKey("OpSuccess"));
            DialogResult = DialogResult.OK;
        }
    }
}
