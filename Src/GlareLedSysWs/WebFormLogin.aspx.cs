using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GlareLedSysBll;
using GlareSysEfDbAndModels;

namespace GlareLedSysWs
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CommDevLoginedUserModel mod = LoginBll.CommDevLogin(0, TextBox1.Text, TextBox2.Text);
            if(mod!=null)
            {
                
            }
        }

        private void CommDevLogin(string text1, string text2)
        {
            throw new NotImplementedException();
        }
    }
}