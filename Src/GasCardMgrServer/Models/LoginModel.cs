///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: LoginModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-22 22:13:23
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }


    public class SuperLoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class OrgMgrLoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string OrgName { get; set; }
    }

    public class ProjectMgrLoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string OrgName { get; set; }
        public string ProjectName { get; set; }
    }

}
