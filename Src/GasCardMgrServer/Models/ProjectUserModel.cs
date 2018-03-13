///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ProjectUserModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-21 21:50:33
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
    public class ProjectUserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Auth { get; set; }
        public int OrgId { get; set; }
        public int OrgInLevelIndex { get; set; }
        public int PorjectId { get; set; }
    }
}
