using GlareLedSysBll;
using GlareSysDataCenter.FromAddMdys;
using PiEms.PublicV2.CommonLibs.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    public partial class FormInfoMgr : Form
    {
        public FormInfoMgr()
        {
            InitializeComponent();
        }

        private void buttonReloadOrg_Click(object sender, EventArgs e)
        {
            listViewOrg.Items.Clear();
            int i = 1;
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo)
            {
                ListViewItem lvitem = listViewOrg.Items.Add(new ListViewItem(new string[]{item.Value.Org.Id.ToString(),
                    item.Value.Org.Name,
                    item.Value.Org.ManageName,
                    item.Value.Org.ManageTel,
                     item.Value.Org.UpdateDt.ToString() }
                    ));
                lvitem.Tag = item.Value;
            }
        }

        private void buttonAddOrg_Click(object sender, EventArgs e)
        {
            FormAddOrg dlg = new FormAddOrg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MemCfgInfo.MemDbMgr.Get().Load();
            }
        }

        private void buttonReloadGroup_Click(object sender, EventArgs e)
        {
            listViewGroup.Items.Clear();
            int i = 1;
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemGroupWithAllInfo)
            {
                ListViewItem lvitem = listViewGroup.Items.Add(new ListViewItem(
                    new string[]{item.Value.GroupInfo.Id.ToString(),
                    item.Value.GroupInfo.GroupName,
                    item.Value.RefOrg.Org.Name,
                    item.Value.GroupInfo.ManageName,
                    item.Value.GroupInfo.ManageTel }
                    ));
                lvitem.Tag = item.Value;
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            FormAddGroup dlg = new FormAddGroup();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // todo 效率太低
                MemCfgInfo.MemDbMgr.Get().Load();
            }
        }

        private void buttonReloadGasCard_Click(object sender, EventArgs e)
        {
            listViewCard.Items.Clear();
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemCardWithAllInfo)
            {
                ListViewItem lvt = listViewCard.Items.Add(new ListViewItem(new string[] {
                    item.Value.cardInfo.Id.ToString(),
                    item.Value.cardInfo.Name,
                     item.Value.RefProject.RefToMemGroup.RefOrg.Org.Name,
                     item.Value.RefProject.RefToMemGroup.GroupInfo.GroupName,
                     item.Value.RefProject.Project.ProjectName,
                     item.Value.cardInfo.CommServerSn,
                     item.Value.cardInfo.Name,
                     item.Value.cardInfo.CardScreenCount.ToString(),
                     item.Value.cardInfo.ScreenNams
                }));

                lvt.Tag = item.Value;
            }
        }



        private void buttonRoladProject_Click(object sender, EventArgs e)
        {
            listViewProject.Items.Clear();
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemPrjWithAllInfo)
            {
                ListViewItem lvt = listViewProject.Items.Add(new ListViewItem(new string[] {
                    item.Value.Project.Id.ToString(),
                    item.Value.Project.ProjectName,
                     item.Value.RefToMemGroup.RefOrg.Org.Name,
                     item.Value.RefToMemGroup.GroupInfo.GroupName,
                     item.Value.Project.ManagerName,
                     item.Value.Project.ManagerTel
                }));

                lvt.Tag = item.Value;
            }
        }

        private void buttonAddGasCard_Click(object sender, EventArgs e)
        {
            FormAddCard dlg = new FormAddCard();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MemCfgInfo.MemDbMgr.Get().Load();
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            FormAddProject dlg = new FormAddProject();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MemCfgInfo.MemDbMgr.Get().Load();

                buttonRoladProject_Click(null, null);
            }
        }

        private void button设备导入_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.Cancel)
                return;
            //判断文件后缀
            var path = file.FileName;
            string fileSuffix = System.IO.Path.GetExtension(path);
            if (string.IsNullOrEmpty(fileSuffix))
                return;

            using (DataSet dsOrg = new DataSet())
            using (DataSet dsGroup = new DataSet())
            using (DataSet dsProject = new DataSet())
            using (DataSet dsCard = new DataSet())
            {
                //判断Excel文件是2003版本还是2007版本
                string connString = "";
                if (fileSuffix == ".xls")
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                else
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

                //读取文件
                string sql_select1 = " SELECT * FROM [Org$]";
                string sql_select2 = " SELECT * FROM [Group$]";
                string sql_select3 = " SELECT * FROM [Project$]";
                string sql_select4 = " SELECT * FROM [Card$]";
                using (OleDbConnection conn = new OleDbConnection(connString))
                using (OleDbDataAdapter cmdOrg = new OleDbDataAdapter(sql_select1, conn))
                using (OleDbDataAdapter cmdGroup = new OleDbDataAdapter(sql_select2, conn))
                using (OleDbDataAdapter cmdProject = new OleDbDataAdapter(sql_select3, conn))
                using (OleDbDataAdapter cmdCard = new OleDbDataAdapter(sql_select4, conn))
                {
                    conn.Open();
                    cmdOrg.Fill(dsOrg);
                    cmdGroup.Fill(dsGroup);
                    cmdProject.Fill(dsProject);
                    cmdCard.Fill(dsCard);
                }
                if (dsOrg == null || dsOrg.Tables.Count <= 0) return;
                if (dsGroup == null || dsGroup.Tables.Count <= 0) return;
                if (dsProject == null || dsProject.Tables.Count <= 0) return;
                if (dsCard == null || dsCard.Tables.Count <= 0) return;


                InsertNewOrg(dsOrg.Tables[0]);
                InsertGroup(dsGroup.Tables[0]);
                InsertNewCard(dsCard.Tables[0]);

            }
        }

        private void InsertNewOrg(DataTable dtOrg)
        {
            foreach (DataRow row in dtOrg.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["Name"].ToString();
                string strManager = row["ManagerName"].ToString();
                string strManagerTel = row["ManagerTel"].ToString();
                string strAddress = row["Address"].ToString();

                if (OrgBll.IsNameExist(strName))
                    continue;

                GlareSysEfDbAndModels.OrgInfo org = new GlareSysEfDbAndModels.OrgInfo()
                {
                    Address = strAddress,
                    CreateDt = DateTime.Now,
                    Id = 0,
                    IsDel = 0,
                    ManageName = strManager,
                    ManageTel = strManagerTel,
                    Name = strName,
                    UpdateDt = DateTime.Now
                };
                string strError;

                MemCfgInfo.MemDbMgr.Get().Load();               
            }

            MemCfgInfo.MemDbMgr.Get().Load();
        }


        private void InsertGroup(DataTable dtGroup)
        {
            foreach (DataRow row in dtGroup.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["Name"].ToString();
                string strManager = row["ManagerName"].ToString();
                string strManagerTel = row["ManagerTel"].ToString();
                string strAddress = row["Address"].ToString();
                string strRefOrg = row["RefOrgName"].ToString();

                if (GroupBll.IsNameExist(strName))
                    continue;

                GlareSysEfDbAndModels.OrgInfo org = new GlareSysEfDbAndModels.OrgInfo()
                {
                    Address = strAddress,
                    CreateDt = DateTime.Now,
                    Id = 0,
                    IsDel = 0,
                    ManageName = strManager,
                    ManageTel = strManagerTel,
                    Name = strName,
                    UpdateDt = DateTime.Now
                };
                string strError;
                OrgBll.AddAOrg(ref org, out strError);
            }

            MemCfgInfo.MemDbMgr.Get().Load();
        }


        private void InsertProject(DataTable dtProject)
        {
            foreach (DataRow row in dtProject.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["Name"].ToString();
                string strManager = row["ManagerName"].ToString();
                string strManagerTel = row["ManagerTel"].ToString();
                string strAddress = row["Address"].ToString();
                string strRefOrg = row["RefGroupName"].ToString();

                if (GroupBll.IsNameExist(strName))
                    continue;

                GlareSysEfDbAndModels.OrgInfo org = new GlareSysEfDbAndModels.OrgInfo()
                {
                    Address = strAddress,
                    CreateDt = DateTime.Now,
                    Id = 0,
                    IsDel = 0,
                    ManageName = strManager,
                    ManageTel = strManagerTel,
                    Name = strName,
                    UpdateDt = DateTime.Now
                };
                string strError;
                OrgBll.AddAOrg(ref org, out strError);
            }

            MemCfgInfo.MemDbMgr.Get().Load();

        }


        private int GetDigNumByModel(string strMod)
        {
            string[] strArr = strMod.Split(new char[] { '-' });
            if (strArr.Length < 2)
            { return 0; }

            if (strArr[strArr.Length-1]=="910")
            {
                if (strArr.Length!=3)
                {
                    return 0;
                }
                return strArr[1].Length;
            }
            else
            {
                if (strArr.Length==2)
                {
                    return strArr[1].Length;
                }
                else if(strArr.Length == 3)
                {
                    return strArr[1].Length + strArr[2].Length;
                }
                else
                {
                    return 0;
                }
            }

        }

        private void InsertNewCard(DataTable dwCard)
        {
            foreach (DataRow row in dwCard.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["CardName"].ToString();
                string strPass= row["CardPassword"].ToString();
                string strSn= row["CardSn"].ToString();
                string strMod = row["CardModel"].ToString();
                string strIsDoub = row["IsDouble"].ToString();
                string strPointCount = row["PointCount"].ToString();
                string strRefProject = row["RefProject"].ToString();
                string strScreenCount = row["ScreenCount"].ToString();

                if (CardWithCommDevBll.IsNameExist(strName))
                    continue;

                if (CardWithCommDevBll.IsSnExise(strSn))
                    continue;

                int iPointIdx = 0;
                int iScreenCount = 0;
                int.TryParse(strPointCount, out iPointIdx);
                int.TryParse(strScreenCount, out iScreenCount);
                MemCfgInfo.MemProjectInfo prj = MemCfgInfo.MemDbMgr.Get().GetMemProjectByName(strRefProject);
                if (prj == null)
                { continue; }


                GlareSysEfDbAndModels.GasCardWithCommInfo card = new GlareSysEfDbAndModels.GasCardWithCommInfo()
                {
                    Address = "",
                    BEnable = 1,
                    CardBrightness = 9,
                    CardContext = "",
                    CardIsDouble = strIsDoub == "1" ? 1 : 0,
                    CardModel = strMod,
                    CardNumberCount = GetDigNumByModel(strMod),
                    CardPointCount = iPointIdx,
                    CardScreenCount = iScreenCount,
                    CityId = "",
                    Comment = "",
                    CommServerSn = strSn,
                    CommExtConnInfo = "",
                    CommSerialBaud = 0,
                    CommSerialDataBit = 0,
                    CommSerialParity = 0,
                    CommSerialPort = "",
                    CommSerialStopBit = 0,
                    CommServerIp = "",
                    CommServerPort = 0,
                    CommTimeoutMs = 2000,
                    CommType = 0,
                    CreateDt = DateTime.Now,
                    DefName = strName,
                    DefPassword = strPass,
                    GroupId = prj.RefToMemGroup.GroupInfo.Id,
                    Id = 0,
                    IsDel = 0,
                    OrgId = prj.RefToMemGroup.RefOrg.Org.Id,
                    Password = strPass,
                    PosLatitude = "",
                    PosLongitude = "",
                    ProjectId = prj.Project.Id,
                    ProtocolType = 1,
                    ScreenNams = "1#-2#-3#-4#-5#-6#",
                    Name = strName,
                    UpdateDt = DateTime.Now

                };
                string strError;
                CardWithCommDevBll.AddDev(ref card, out strError);             
            }

            MemCfgInfo.MemDbMgr.Get().Load();
        }

        private void buttonMdyOrg_Click(object sender, EventArgs e)
        {

        }

        private void FormInfoMgr_Load(object sender, EventArgs e)
        {
            buttonReloadOrg_Click(null, null);
            buttonReloadGroup_Click(null, null);
            buttonRoladProject_Click(null, null);
            buttonRoladProject_Click(null, null);
            buttonReloadGasCard_Click(null, null);

            SetCombobox(comboBoxOrgInGroupMgr);
            SetCombobox(comboBoxOrgInProjectMgr);
            SetCombobox(comboBoxOrgInCardMgr);            
        }

        private void SetCombobox(ComboBox comboxOrg)
        {
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            lstCommValues.Add(new DisplayStringValueInt()
            {
                DisplayValue = "--All--",
                MemberValue = 0
            });

            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.Org.Id,
                    DisplayValue = item.Value.Org.Name,
                });
            }

            comboxOrg.DisplayMember = "DisplayValue";
            comboxOrg.ValueMember = "MemberValue";
            comboxOrg.DataSource = lstCommValues;
        }

        private void buttonFilterGroup_Click(object sender, EventArgs e)
        {
            int iSelectOrgId = 0;
            
            if (comboBoxOrgInGroupMgr.SelectedIndex > 0)
            {
                iSelectOrgId = (int)comboBoxOrgInGroupMgr.SelectedValue;
            }
            listViewGroup.Items.Clear();
            int i = 1;
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemGroupWithAllInfo)
            {
                if (iSelectOrgId == 0 || item.Value.GroupInfo.OrgId == iSelectOrgId)
                {
                    ListViewItem lvitem = listViewGroup.Items.Add(new ListViewItem(
                      new string[]{item.Value.GroupInfo.Id.ToString(),
                    item.Value.GroupInfo.GroupName,
                    item.Value.RefOrg.Org.Name,
                    item.Value.GroupInfo.ManageName,
                    item.Value.GroupInfo.ManageTel }
                      ));
                    lvitem.Tag = item.Value;
                }                
            }

        }

        private void comboBoxOrgInProjectMgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrgInProjectMgr.SelectedIndex <= 0) return;

            int orgid = (int)comboBoxOrgInProjectMgr.SelectedValue;
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            MemCfgInfo.MemOrgInfo memorg = MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo[orgid];

            lstCommValues.Add(new DisplayStringValueInt()
            {
                MemberValue = 0,
                DisplayValue = "--All--",
            });
            foreach (var item in memorg.DicGroupOfOrg)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.GroupInfo.Id,
                    DisplayValue = item.Value.GroupInfo.GroupName,
                });
            }
            comboBoxGroupInProject.DisplayMember = "DisplayValue";
            comboBoxGroupInProject.ValueMember = "MemberValue";
            comboBoxGroupInProject.DataSource = lstCommValues;
        }

        private void comboBoxOrgInCardMgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrgInCardMgr.SelectedIndex <= 0) return;

            int orgid = (int)comboBoxOrgInCardMgr.SelectedValue;
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            MemCfgInfo.MemOrgInfo memorg = MemCfgInfo.MemDbMgr.Get().dicMemOrgWithAllInfo[orgid];

            lstCommValues.Add(new DisplayStringValueInt()
            {
                MemberValue = 0,
                DisplayValue = "--All--",
            });
            foreach (var item in memorg.DicGroupOfOrg)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.GroupInfo.Id,
                    DisplayValue = item.Value.GroupInfo.GroupName,
                });
            }
            comboBoxGroupInCardMgr.DisplayMember = "DisplayValue";
            comboBoxGroupInCardMgr.ValueMember = "MemberValue";
            comboBoxGroupInCardMgr.DataSource = lstCommValues;

            comboBoxProjectInCardMgr.SelectedIndex = -1;
        }

        private void comboBoxGroupInCardMgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGroupInCardMgr.SelectedIndex <= 0) return;

            int groupId = (int)comboBoxGroupInCardMgr.SelectedValue;
            List<DisplayStringValueInt> lstCommValues = new List<DisplayStringValueInt>();
            MemCfgInfo.MemGroupInfo memGroup = MemCfgInfo.MemDbMgr.Get().dicMemGroupWithAllInfo[groupId];

            lstCommValues.Add(new DisplayStringValueInt()
            {
                MemberValue = 0,
                DisplayValue = "--All--",
            });
            foreach (var item in memGroup.DicProject)
            {
                lstCommValues.Add(new DisplayStringValueInt()
                {
                    MemberValue = item.Value.Project.Id,
                    DisplayValue = item.Value.Project.ProjectName,
                });
            }
            comboBoxProjectInCardMgr.DisplayMember = "DisplayValue";
            comboBoxProjectInCardMgr.ValueMember = "MemberValue";
            comboBoxProjectInCardMgr.DataSource = lstCommValues;
        }

        private void buttonFilterProject_Click(object sender, EventArgs e)
        {
            int iSelectOrgId = 0;
            int iSelGroupId = 0;
            if (comboBoxOrgInProjectMgr.SelectedIndex > 0)
            {
                iSelectOrgId = (int)comboBoxOrgInGroupMgr.SelectedValue;
            }
            if (comboBoxGroupInProject.SelectedIndex>0)
            {
                iSelGroupId = (int)comboBoxGroupInProject.SelectedValue;
            }
            listViewProject.Items.Clear();
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemPrjWithAllInfo)
            {
                bool bInsert = false;
                if (iSelGroupId > 0)
                {
                    bInsert = item.Value.Project.GroupId == iSelGroupId;

                }
                else if (iSelectOrgId > 0)
                {
                    bInsert = item.Value.Project.OrgId == iSelectOrgId;
                }
                else
                {
                    bInsert = true;
                }
                if (bInsert)
                {
                    ListViewItem lvt = listViewProject.Items.Add(new ListViewItem(new string[] {
                    item.Value.Project.Id.ToString(),
                    item.Value.Project.ProjectName,
                     item.Value.RefToMemGroup.RefOrg.Org.Name,
                     item.Value.RefToMemGroup.GroupInfo.GroupName,
                     item.Value.Project.ManagerName,
                     item.Value.Project.ManagerTel
                    }));
                    lvt.Tag = item.Value;
                }                
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            int iSelectOrgId = 0;
            int iSelGroupId = 0;
            int iSelProjectId = 0;
            if (comboBoxOrgInCardMgr.SelectedIndex > 0)
            {
                iSelectOrgId = (int)comboBoxOrgInCardMgr.SelectedValue;
            }
            if (comboBoxGroupInCardMgr.SelectedIndex > 0)
            {
                iSelGroupId = (int)comboBoxGroupInCardMgr.SelectedValue;
            }
            if (comboBoxProjectInCardMgr.SelectedIndex>0)
            {
                iSelProjectId = (int)comboBoxProjectInCardMgr.SelectedValue;
            }

            listViewCard.Items.Clear();
            foreach (var item in MemCfgInfo.MemDbMgr.Get().dicMemCardWithAllInfo)
            {
                bool bInsert = false;
                if (iSelProjectId>0)
                {
                    bInsert = item.Value.cardInfo.ProjectId == iSelProjectId;
                }
                else if (iSelGroupId > 0)
                {
                    bInsert = item.Value.RefProject.Project.GroupId == iSelGroupId;

                }
                else if (iSelectOrgId > 0)
                {
                    bInsert = item.Value.RefProject.Project.OrgId == iSelectOrgId;
                }
                else
                {
                    bInsert = true;
                }
                if (bInsert)
                {
                    ListViewItem lvt = listViewCard.Items.Add(new ListViewItem(new string[] {
                    item.Value.cardInfo.Id.ToString(),
                    item.Value.cardInfo.Name,
                     item.Value.RefProject.RefToMemGroup.RefOrg.Org.Name,
                     item.Value.RefProject.RefToMemGroup.GroupInfo.GroupName,
                     item.Value.RefProject.Project.ProjectName,
                     item.Value.cardInfo.CommServerSn,
                     item.Value.cardInfo.Name,
                     item.Value.cardInfo.CardScreenCount.ToString(),
                     item.Value.cardInfo.ScreenNams
                }));

                    lvt.Tag = item.Value;
                }
            }
        }
    }
}
