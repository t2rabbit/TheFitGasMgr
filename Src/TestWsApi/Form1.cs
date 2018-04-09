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

namespace TestWsApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SuperLoginedUserModel mod = new SuperLoginedUserModel()
            {
                LoginDt = DateTime.Now,
                LoginIdByCenter = 0,
                UserInfo = new SuperUser()
                {
                    Id = 0,
                    EnableTime = DateTime.Now,
                    Name = "xxx",           // 只有这个有意义
                    Password = "xxx",       // 只有这个有意义
                    UserType = 1
                }
            };

            RequestModelObjectT<SuperLoginedUserModel> obj = new RequestModelObjectT<SuperLoginedUserModel>()
            {
                Info = mod,
                reqDt = DateTime.Now,
                TockId = 0
            };

            string strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj, typeof(RequestModelObjectT<SuperLoginedUserModel>));

            ServiceReference1.GLSysMgrSoapClient cl = new ServiceReference1.GLSysMgrSoapClient();



            OrgUser userMod = new OrgUser()
            {
                MgrOrgId = 0,
                Name = "xxx",
                Password = "xxx"
            };
            string strInfo = JsonStrObjConver.Obj2JsonStr(userMod, typeof(OrgUser));
            RequestModelString obj2 = new RequestModelString()
            {
                Info = strInfo,
                reqDt = DateTime.Now,
                TockId = 99663322
            };
            strParmaInfo = JsonStrObjConver.Obj2JsonStr(obj2, typeof(RequestModelString));
            cl.AddOrgUser(strParmaInfo);


            string strResult = cl.SuperLogin(strParmaInfo);
            MessageBox.Show(strResult);

        }
    }
}
