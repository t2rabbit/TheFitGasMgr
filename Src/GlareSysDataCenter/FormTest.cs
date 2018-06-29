using GlareLedSysBll;
using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;
using GLLedPublic;
using PiPublic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();
          
            string strResult = cl.SuperLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // add org user
            string strParmaInfo = "";
            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

            string strResult = cl.OrgLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // add group user
            string strParmaInfo = "";
            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

            string strResult = cl.GroupLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // add group user
            string strParmaInfo = "";
            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

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

            GlareLedServices2.GLSysMgrSoapClient cl = new GlareLedServices2.GLSysMgrSoapClient();

            string strResult = cl.CommDevLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }

        private void buttonMdyCfg_Click(object sender, EventArgs e)
        {

            //1  			//双面显示（单面为0x00）
            //3  			//一面三个牌
            //5  			//每个牌5个8（包含小8）
            //0  			//是否显示9/10
            //8  			//亮度等级

            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "1-3-5-0-8",
                CmdType = GlareLedSysDefPub.CmdDefSetOilCfg,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            PiPublic.Log.LogMgr.WriteDebugDefSys("Insert To db，memdb id is:" + cmd.Id + " result is:" + bSend);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 20; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        bRecived = true;
                        break;
                    }
                }
            }
        }



        private bool InsertCmdToMemcached(int id)
        {
            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                if(PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, id.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            strIds += id.ToString();
            if (strIds.Length > 0)
            {
                strIds += ",";
            }

            return PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strIds);
        }

        private bool RemoveCmdHandledInMemcached(int id)
        {
            bool bFind = false;

            // 从处理结果中找是有该ID，有就把新命令到队列把id删除
            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCmdResult);
            if (strIds.Length == 0)
            {
                return false;
            }


            string[] arrIds = strIds.Split(new char[] { '-', ',' });
            string strNewIds = "";
            foreach (var str in arrIds)
            {
                if (str == id.ToString())
                {
                    bFind = true;
                    continue;
                }

                strNewIds += str;
                if (strNewIds.Length > 0)
                {
                    strNewIds += ",";
                }
            }
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strNewIds);
            return bFind;
        }

        private void button21_Click(object sender, EventArgs e)
        {

            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "11111-22222-33333-44444-55555-66666-77777",
                CmdType = GlareLedSysDefPub.CmdDefSetOilValue,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        bRecived = true;
                        break;
                    }
                }
            }
        }

        // 读取配置
        private void button25_Click(object sender, EventArgs e)
        {
            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "",
                CmdType = GlareLedSysDefPub.CmdDefGetOilCfg,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        MessageBox.Show("处理成功，查询数据库获取结果");
                        bRecived = true;
                        break;
                    }
                }
            }

        }

        private void button26_Click(object sender, EventArgs e)
        {
            // 读取价格
            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "",
                CmdType = GlareLedSysDefPub.CmdDefGetOilValue,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        MessageBox.Show("处理成功，查询数据库获取结果");
                        bRecived = true;
                        break;
                    }
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            // 设置小数点位数
            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "1-1-1-1-1-1-1",
                CmdType = GlareLedSysDefPub.CmdDefSetOilDigiCfg,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        bRecived = true;
                        break;
                    }
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            // 读取小数点位数
            CmdLogs cmd = new CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = "",
                CmdType = GlareLedSysDefPub.CmdDefGetOilDigiCfg,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        MessageBox.Show("处理成功，查询数据库获取结果");
                        bRecived = true;
                        break;
                    }
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //"CardStatus1"
            string strStatus = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCardStatus + "1");
            MessageBox.Show(strStatus);
            strStatus = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCardStatus + "2");
            MessageBox.Show(strStatus);
        }
    }
}
