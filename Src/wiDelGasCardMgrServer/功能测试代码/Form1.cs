using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PiPublic;

namespace 功能测试代码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonJsonTest_Click(object sender, EventArgs e)
        {
            Models.RequestModes.QueryDevByIdModel mos = new Models.RequestModes.QueryDevByIdModel()
            {
                GroupId = 0,
                GatewayId = 1,
                OrgId = 1,
                ProjectId = 1,
                RangeId = 1,
            };
            string strInfo2 = JsonStrObjConver.Obj2JsonStr(mos, typeof(Models.RequestModes.QueryDevByIdModel));
            string strjsonMod = @"{""GatewayId"":1,""GroupId"":0,""OrgId"":1,""ProjectId"":1,""RangeId"":1}";
            mos = JsonStrObjConver.JsonStr2Obj(strjsonMod, typeof(Models.RequestModes.QueryDevByIdModel))
                as Models.RequestModes.QueryDevByIdModel;

            string strjsonMod2 = @"{""GroupId"":0,""OrgId"":1,""ProjectId"":1,""RangeId"":1}";
            mos = JsonStrObjConver.JsonStr2Obj(strjsonMod2, typeof(Models.RequestModes.QueryDevByIdModel))
                as Models.RequestModes.QueryDevByIdModel;

            JsonResutlModel<DevInfoModel> mod = new JsonResutlModel<DevInfoModel>()
            {
                Info = new DevInfoModel()
                {
                    Address_GPS = "",
                    Adress = "",
                    DevAddr = "",
                    DevType = "",
                    GatewayId = 0,
                    ID = 0,
                    Name = "dsfdsf",
                    GroupId = 1,
                    OrgId = 1,
                    PosInfo = "",
                    ProjectId = 1,
                    RangeId = 1,
                },
                Status = false,
            };

            string strInfo = JsonStrObjConver.Obj2JsonStr(mod, typeof(JsonResutlModel<DevInfoModel>));
            MessageBox.Show(strInfo);
        }

        private void buttonLoginWs_Click(object sender, EventArgs e)
        {
            LoginModel obj = new LoginModel()
                {
                    Name = "sdfsfs",
                    Password = "7788"
                };
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(obj, typeof(LoginModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };

            string strInfo = JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString));
            strInfo = "{\"UUID\":\"\", \"reqDt\":\"2015-01-01 11:11:11\"}";
            RequestModelString mod = JsonStrObjConver.JsonStr2Obj(strInfo, typeof(RequestModelString)) as RequestModelString;
            MessageBox.Show(strInfo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SysUserInfoModel obj = new SysUserInfoModel()
             {
                 ID = 0,
                 Auth = 1,
                 Name = "wudq",
                 OrgId = 0,
                 OrgInLevelIndex = 0,
                 Password = "sdfdsf",
                 ProjectId = 0,
                 SuperOrgId = 0,
                 UserType = (int)DbConstDefine.SysUserType.CenterUser
             };

            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(obj, typeof(SysUserInfoModel)),
                  reqDt = DateTime.Now,
                   UUID = ""
            };
            string strInfo = ifs.AddCenterSysUser(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show(strInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GatewayModel obj = new GatewayModel()
            {
                CommType = "GPRS",
                Name = "广州高铁-广州站-1号",
                ProjectId = 1,
                ProtocolSIM = "13322221111",
                ProtocolSN = "GRRS_SN",
                ProtocolType = "CELL_01",// 不参与                
            };
            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(obj, typeof(GatewayModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.AddGateway(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show("JSON 状态表示成功与否，信息是最新的ID"+strInfo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DevInfoModel obj = new DevInfoModel()
            {
                Address_GPS = "22.22,33.1",
                Adress = "广州XXX地址",
                DevAddr = "341f",
                ProjectId = 1,
                PosInfo = "位置信息描述使用",
                OrgId = 1,
                Name = "KFC-店面",
                ID = 0,
                GroupId = 1,
                RangeId = 1,
                DevType = DbConstDefine.DevTypeCellsLed2804,
                GatewayId = 1,
                DevLineIndex = 0
            };
            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(obj, typeof(DevInfoModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.AddDev(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show("JSON 状态表示成功与否，信息是最新的ID"+strInfo);            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NodeInfoModel obj = new NodeInfoModel()
            {
                DevId = 1,
                Name = "电压",
                strAddr = NodeTypeCatalogDefine.AddrVoltage.ToString(),
                strCatalog1 = NodeTypeCatalogDefine.AddrVoltage.ToString(),
                strCatalog2 = "",
                strFuncCode = "",                                
            };
            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(obj, typeof(NodeInfoModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.AddNode(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show("JSON 状态表示成功与否，信息是最新的ID" + strInfo);            


        }

        private void buttonDel_Click(object sender, EventArgs e)
        {            
            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = textBox1.Text,
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.DelANodeById(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show(strInfo); 
        }
     

        private void button5_Click(object sender, EventArgs e)
        {

            RealControlModel ctlMod = new RealControlModel()
            {
                AddByUserId = 0, // 用户ID
                ID = 0,
                Cmd = "10_50-9:9_100-23:59_0",
                CmdFlag = (int)DbConstDefine.CmdFlag.NewCmd,
                CmdType = DbConstDefine.CmdTypeSetPlan,
                ControlUserId = 0,
                DevAddr = 0x8001,// 可以不填
                DevId = 1,
                DevLineIndex = 1,
                GatewayId = 1,
                GroupAddr = 0,
                //LogDt = DateTime.Now,
                ProjectId = 0,
                TypeProjGateDevGroup = (int)DbConstDefine.CmdForTag.TagLine
            };


            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(ctlMod, typeof(RealControlModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.SetCmdToDb(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show(strInfo); 
        }

        private void buttonAddRelCtl_Click(object sender, EventArgs e)
        {
            RealControlModel ctlMod = new RealControlModel()
            {
                AddByUserId = 0, // 用户ID
                ID = 0,
                Cmd = "100",// 全开
                CmdFlag = (int)DbConstDefine.CmdFlag.NewCmd,
                CmdType = DbConstDefine.CmdTypeSetPlan,
                ControlUserId = 0,
                DevAddr = 0x8001,// 可以不填
                DevId = 1,
                DevLineIndex = 1,
                GatewayId = 1,
                GroupAddr = 0,
                //LogDt = DateTime.Now, 
                ProjectId = 0,
                TypeProjGateDevGroup = (int)DbConstDefine.CmdForTag.TagLine
            };


            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = JsonStrObjConver.Obj2JsonStr(ctlMod, typeof(RealControlModel)),
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.SetCmdToDb(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show(strInfo); 
        }

        private void buttonGetAllProject_Click(object sender, EventArgs e)
        {
           

            NetLabelMgrWS.NetLabelMgrSoapClient ifs = new NetLabelMgrWS.NetLabelMgrSoapClient();
            RequestModelString req = new RequestModelString()
            {
                Info = "",
                reqDt = DateTime.Now,
                UUID = ""
            };
            string strInfo = ifs.GetAllProject(JsonStrObjConver.Obj2JsonStr(req, typeof(RequestModelString)));
            MessageBox.Show(strInfo); 
        }
    }
}
