using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDesmsPublicDefDll;
using DBSqlite;
using YdPublic;

namespace Property
{
    public partial class FormOrgInfo : Form
    {

        public YDesmsPublicDefDll.UIDefine.EUINewOrMdy m_NewOrMdy {get;set;}
        public GL_Org m_orgOld {get;set;}
        public FormOrgInfo()
        {
            InitializeComponent();
        }

        private void FormOrgInfo_Load(object sender, EventArgs e)
        {
            if (m_NewOrMdy == UIDefine.EUINewOrMdy.E_NONE)
            {
                //null;
            }
            else if (m_NewOrMdy == UIDefine.EUINewOrMdy.E_NEW)
            {
                textBoxSN.Text = Guid.NewGuid().ToString("D");
                textBoxID.Text = "";
            }
            else if (m_NewOrMdy == UIDefine.EUINewOrMdy.E_MDY)
            {
                textBoxOrgName.Text = m_orgOld.Name;
                textBoxOrgTel.Text = m_orgOld.Tel;
                textBoxOrgManager.Text = m_orgOld.Manager;
                textBoxOrgCity.Text = m_orgOld.City;
                textBoxAddr.Text = m_orgOld.Street;
                textBoxID.Text = m_orgOld.ID.ToString();
                textBoxSN.Text = m_orgOld.PCSN;
            }
            else
            {

            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            GL_Org aNewOrg = new GL_Org();
            if (textBoxOrgName.Text == "")
            {
                MessageBox.Show(LanguageMgr.GetKey("InputDataError"));
                return;
            }
            aNewOrg.Name = textBoxOrgName.Text;
            aNewOrg.Tel = textBoxOrgTel.Text;
            aNewOrg.Manager = textBoxOrgManager.Text;            
            aNewOrg.City = textBoxOrgCity.Text;
            aNewOrg.Street = textBoxAddr.Text;
            aNewOrg.PCSN = textBoxSN.Text;
            aNewOrg.Country = "";
            aNewOrg.MPhoneNO  ="";
            aNewOrg.Provice = "";
            aNewOrg.Web = "";
            aNewOrg.MPhoneNO = "";
            aNewOrg.Password = "";


            if (m_NewOrMdy == UIDefine.EUINewOrMdy.E_NEW)
            {
                DB.MemDB.Get().AddOrg(aNewOrg);
            }
            else if (m_NewOrMdy == UIDefine.EUINewOrMdy.E_MDY)
            {
                DB.MemDB.Get().UpdateOrg((int)m_orgOld.ID, aNewOrg);
            }
            else
            {
                System.Diagnostics.Debug.Assert(false);
            }

            DialogResult = DialogResult.OK;
        }


    }
}
