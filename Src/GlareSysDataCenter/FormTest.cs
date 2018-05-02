using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;
using PiPublic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strParmaInfo = "";
            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            SuperUser userMod = new SuperUser()
            {
                Id = 0,
                EnableTime = DateTime.Now,
                UserType = 0,
                Name = "bbb",
                Password = "bbb"
            };
            string strInfo = JsonStrObjConver.Obj2JsonStr(userMod, typeof(SuperUser));

            RequestModelString obj2 = new RequestModelString()
            {
                Info = strInfo,
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };
            strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj2, typeof(RequestModelString));
            string strResult = cl.AddSuperUser(strParmaInfo);                      
            MessageBox.Show(strResult);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginNamePassModel mod = new LoginNamePassModel()
            {
                UserName = "bbb",           // 只有这个有意义
                Password = "bbb",       // 只有这个有意义            
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(LoginNamePassModel)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();
          
            string strResult = cl.SuperLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add org user
            string strParmaInfo = "";
            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            OrgUser userMod = new OrgUser()
            {
                Id = 0,
                MgrOrgId = 1,
                Name = "orgname",
                Password = "orgpassword"
            };
            string strInfo = JsonStrObjConver.Obj2JsonStr(userMod, typeof(OrgUser));

            RequestModelString obj2 = new RequestModelString()
            {
                Info = strInfo,
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };
            strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj2, typeof(RequestModelString));
            string strResult = cl.AddOrgUser(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // org user login 
            LoginNamePassModel mod = new LoginNamePassModel()
            {
                UserName = "orgname",    
                Password = "orgpassword",
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(LoginNamePassModel)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.OrgLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add group user
            string strParmaInfo = "";
            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            GroupUser userMod = new GroupUser()
            {
                Id = 0,
                MgrGroupId = 1,
                RefOrgId = 1,
                Name = "groupname",
                Password = "grouppassword"
            };
            string strInfo = JsonStrObjConver.Obj2JsonStr(userMod, typeof(GroupUser));

            RequestModelString obj2 = new RequestModelString()
            {
                Info = strInfo,
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };
            strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj2, typeof(RequestModelString));
            string strResult = cl.AddGroupUser(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            // group user login 
            LoginNamePassModel mod = new LoginNamePassModel()
            {
                UserName = "groupname",
                Password = "grouppassword",
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(LoginNamePassModel)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.GroupLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // add group user
            string strParmaInfo = "";
            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            ProjectUser userMod = new ProjectUser()
            {
                Id = 0,
                MgrProjectId = 1,
                RefGroupId = 1,
                RefOrgId = 1,
                Name = "projectname",
                Password = "projectpassword"
            };
            string strInfo = JsonStrObjConver.Obj2JsonStr(userMod, typeof(ProjectUser));

            RequestModelString obj2 = new RequestModelString()
            {
                Info = strInfo,
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };
            strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj2, typeof(RequestModelString));
            string strResult = cl.AddProjectUser(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // project user login 
            LoginNamePassModel mod = new LoginNamePassModel()
            {
                UserName = "projectname",
                Password = "projectpassword",
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(LoginNamePassModel)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.Projectlogin(strParmaInfo);
            MessageBox.Show(strResult);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // add org
            OrgInfo mod = new OrgInfo()
            {
                Address = "添加测试地址",
                ManageName = "manager name",
                Id = 0,
                ManageTel = "telnon...123456",
                Name = "neworgname"
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(OrgInfo)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.AddNewOrg(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // add group
            GroupInfo mod = new GroupInfo()
            {
                GroupAddress = "添加测试地址",
                ManageName = "manager name",
                Id = 0,
                ManageTel = "telnon...123456",
                GroupName = "newgroupname",
                OrgId = 1
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(GroupInfo)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.AddGroup(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // add project
            ProjectInfo mod = new ProjectInfo()
            {
                Id = 0,
                Address = "address",
                GroupId = 1,
                ManagerName = "manager",
                ManagerTel = "tel 000111",
                OrgId = 1,
                ProjectName = "project name"
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(ProjectInfo)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.AddProject(strParmaInfo);
            MessageBox.Show(strResult);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // add commdev
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            GasCardWithCommInfo mod = new GasCardWithCommInfo()
            {
                Id = 0,
                Name = "CardName",
                Address = "",
                BEnable = 1,
                CardBrightness = 1,
                CardIsDouble = 1,
                CardNumberCount = 1,
                CardPointCount = 1,
                CardScreenCount = 6,
                CityId = "",
                Comment = "",
                CommExtConnInfo = "",
                CommSerialBaud = 0,
                CommSerialDataBit = 0,
                CommSerialParity = 0,
                CommSerialPort = "",
                CommSerialStopBit = 0,
                CommServerIp = "",
                CommServerPort = 0,
                CommServerSn = "sn00006",
                CommTimeoutMs = 2000,
                CommType = 1,
                DefName = "defname003",
                DefPassword = "password",
                IsDel = 0,
                Password = "password",
                PosLatitude = "",
                PosLongitude = "",
                ProtocolType = 0,

                CardModel = "GL-88888-910",

                ProjectId = 1,
                GroupId = 1,
                OrgId = 1,
                CardContext = "1111-1111-111-111-11-11-11-11-11-11-11-11-11",
                ScreenNams = "94#-dic95-00-00-00-00-00-00-00-00-00",
                CreateDt = DateTime.Now,
                UpdateDt = DateTime.Now,

            };


            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(GasCardWithCommInfo)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.AddCard(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // dev user login 
            LoginNamePassModel mod = new LoginNamePassModel()
            {
                UserName = "NewCard",
                Password = "123456",
            };

            RequestModelString obj = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(mod, typeof(LoginNamePassModel)),
                reqDt = DateTime.Now,
                TockId = ConstDefineTestWebapi.TockIdEnableTest
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelString));

            GlareLedServices.GLSysMgrSoapClient cl = new GlareLedServices.GLSysMgrSoapClient();

            string strResult = cl.CommDevLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }
    }
}
