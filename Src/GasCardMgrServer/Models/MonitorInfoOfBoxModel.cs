///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: MonitorInfoOfBoxModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-04-17 11:44:47
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
    /// <summary>
    /// 灯箱控制器的监控信息
    /// </summary>
    public class MonitorInfoOfBoxModel
    {
        public int OrgId { get; set; }
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public int RangeId { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string BoxType { get; set; } // 字符串的，现在没有定义，不知道有什么类型
        public int GatewayId { get; set; }
        public string Adress { get; set; }
        public string Address_GPS { get; set; }
        public string PosInfo { get; set; } // 灯箱的位置信息，png位置
        public int Status { get; set; }       

    }
}
