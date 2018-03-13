///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: DevInfoModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-19 7:26:50
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
    public class DevInfoModel
    {               
        public int GroupId {get;set;}
        public int ProjectId {get;set;}
        public int RangeId{get;set;}
        public int OrgId{get;set;}
        public int ID { get; set; }
        public string Name { get; set; }
        public string DevType { get; set; }
        public string DevAddr { get; set; }
        public int DevLineIndex { get; set; }
        public int GatewayId { get; set; }
        public string Adress { get; set; }
        public string Address_GPS { get; set; }
        public string PosInfo { get; set; }
        public int Status { get; set; }
    }
}