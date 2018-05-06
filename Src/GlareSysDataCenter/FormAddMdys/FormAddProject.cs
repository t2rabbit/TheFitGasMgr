using GlareLedSysBll;
using GlareSysEfDbAndModels;
using PiEms.PublicV2.CommonLibs.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter.FromAddMdys
{
    public partial class FormAddProject : Form
    {
        public FormAddProject()
        {
            InitializeComponent();
        }

        private void FormAddProject_Load(object sender, EventArgs e)
        {
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.Org.Id,
                    DisplayValue = item.Value.Org.Name,
                });
            }

            comboBoxOrg.DisplayMember = "DisplayValue";
            comboBoxOrg.ValueMember = "MemberValue";
            comboBoxOrg.DataSource = lstCommValues;
        }

        private void comboBoxOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrg.SelectedIndex < 0) return;
            
            int orgid = (int)comboBoxOrg.SelectedValue;
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            MemCfgInfo.MemOrgInfo memorg = MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo[orgid];

            foreach (var item in memorg.DicGroupOfOrg)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.GroupInfo.Id,
                    DisplayValue = item.Value.GroupInfo.GroupName,
                });
            }

            comboBoxGroup.DisplayMember = "DisplayValue";
            comboBoxGroup.ValueMember = "MemberValue";
            comboBoxGroup.DataSource = lstCommValues;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ProjectInfo mod = new ProjectInfo()
            {
                CreateDt = DateTime.Now,
                Address = "",
                GroupId = (int)comboBoxGroup.SelectedValue,
                ManagerName = textBoxManagerName.Text,
                ManagerTel = textBoxTel.Text,
                Id = 0,
                IsDel = 0,
                OrgId = (int)comboBoxOrg.SelectedValue,
                UpdateDt = DateTime.Now,
                ProjectName = textBoxName.Text
            };
            string strMsg;
            if (!ProjectBll.AddAProject(ref mod, out strMsg))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(strMsg);
            }
        }
    }
}
