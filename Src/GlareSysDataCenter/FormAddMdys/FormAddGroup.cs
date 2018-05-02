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
using GlareSysEfDbAndModels;
using GlareLedSysBll;

namespace GlareSysDataCenter.FromAddMdys
{
    public partial class FormAddGroup : Form
    {
        public FormAddGroup()
        {
            InitializeComponent();
        }

        private void FormAddGroup_Load(object sender, EventArgs e)
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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            GroupInfo mod = new GroupInfo()
            {
                CreateDt = DateTime.Now,
                GroupAddress = "",
                GroupName = textBoxName.Text,
                Id = 0,
                IsDel = 0,
                ManageName = textBoxManagerName.Text,
                ManageTel = textBoxTel.Text,
                OrgId = (int)comboBoxOrg.SelectedValue,
                UpdateDt = DateTime.Now
            };

            string strMsg;
            if (!GroupBll.AddAGroup(ref mod, out strMsg))
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(strMsg);
            }
        }        
    }
}
