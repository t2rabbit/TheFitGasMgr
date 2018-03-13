///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: Organization.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-19 7:36:50
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
    public class OrganizationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LevelIndex { get; set; }
        public string Tel { get; set; }
        public string MobileTel { get; set; }
        public string Emaile { get; set; }
        public string Address { get; set; }
        public string Address_Province { get; set; }
        public string Addres_City { get; set; }
        public string Address_Distict { get; set; }
        public string Address_GPS { get; set; }
        public string Manager { get; set; }
        public string SecondManager { get; set; }
    }
}
