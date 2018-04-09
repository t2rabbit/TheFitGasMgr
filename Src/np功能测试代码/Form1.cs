using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PiPublic;
using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;

namespace 功能测试代码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn登录测试_Click(object sender, EventArgs e)
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
            GlSysMgr.NetLabelMgrSoapClient client = new GlSysMgr.NetLabelMgrSoapClient();
            string strResult = client.SuperLogin(strParmaInfo);
            MessageBox.Show(strResult);
        }
    }
}
