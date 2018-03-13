///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: GatewayModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-21 22:31:30
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
    public class GatewayModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CommType { get; set; }
        public string ProtocolType { get; set; }
        public string ProtocolSN { get; set; }
        public string ProtocolSIM { get; set; }
        public int ProjectId { get; set; }
        public int Status { get; set; }
    }
}
