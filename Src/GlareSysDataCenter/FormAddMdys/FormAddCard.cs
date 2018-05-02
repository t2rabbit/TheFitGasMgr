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
    public partial class FormAddCard : Form
    {
        public FormAddCard()
        {
            InitializeComponent();
        }



        private void FormAddCard_Load(object sender, EventArgs e)
        {
            comboBoxScreenCount.SelectedIndex = 5;
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

            comboBoxGroup.Items.Clear();
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
                

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedIndex < 0) return;

            comboBoxProject.Items.Clear();
            int groupid = (int)comboBoxOrg.SelectedValue;
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            MemCfgInfo.MemGroupInfo memgroup = MemCfgInfo.MemDbMgr.Get().dicMemGroupWithAllInfo[groupid];

            foreach (var item in memgroup.DicProject)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.Project.Id,
                    DisplayValue = item.Value.Project.ProjectName,
                });
            }

            comboBoxProject.DisplayMember = "DisplayValue";
            comboBoxProject.ValueMember = "MemberValue";
            comboBoxProject.DataSource = lstCommValues;
        }


        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string strScrName = textBoxScreenName1.Text + "-"
                + textBoxScreenName2.Text + "-"
                + textBoxScreenName3.Text + "-"
                + textBoxScreenName4.Text + "-"
                + textBoxScreenName5.Text + "-"
                + textBoxScreenName6.Text + "-"
                + textBoxScreenName7.Text + "-"
                + textBoxScreenName8.Text + "-"
                + textBoxScreenName9.Text + "-"
                + textBoxScreenName10.Text + "-"
                + textBoxScreenName11.Text + "-"
                + textBoxScreenName12.Text;

            GasCardWithCommInfo mod = new GasCardWithCommInfo()
            {
                Id = 0,
                Name = textBoxName.Text,
                Address = "1",
                CardModel = comboBoxCardModeType.SelectedText,
                CardIsDouble = 1,
                CardBrightness = 1,
                CardPointCount = comboBoxPointIndex.SelectedIndex,
                CardNumberCount = comboBoxNumCount.SelectedIndex + 1,
                CardScreenCount = comboBoxScreenCount.SelectedIndex + 1,
                ProjectId = (int)comboBoxProject.SelectedValue,
                GroupId = (int)comboBoxGroup.SelectedValue,
                OrgId = (int)comboBoxOrg.SelectedValue,
                CardContext = "888888-888888-888888-888888-888888-888888-888888-888888-888888-888888-888888-888888",
                ScreenNams = strScrName,
                CreateDt = DateTime.Now,
                UpdateDt = DateTime.Now,
                BEnable = 1,
                CityId = "0",
                Comment = "",
                CommExtConnInfo = "",
                CommSerialBaud = 0,
                CommSerialDataBit = 0,
                CommSerialParity = 0,
                CommSerialPort = "0",
                CommSerialStopBit = 0,
                CommServerIp = "",
                CommServerPort = 0,
                CommServerSn = textBoxConnSn.Text,
                CommTimeoutMs = 2000,
                CommType = 1,
                DefName = textBoxName.Text,
                DefPassword = textBoxPassword.Text,
                IsDel = 0,
                Password = textBoxPassword.Text,
                PosLatitude = "0",
                PosLongitude = "0",
                ProtocolType = 0,
            };
            string strMsg;
            if (!CardWithCommDevBll.AddDev(ref mod, out strMsg))
            {
                MessageBox.Show(strMsg);
                DialogResult = DialogResult.None;
            }
        }
    }
}
