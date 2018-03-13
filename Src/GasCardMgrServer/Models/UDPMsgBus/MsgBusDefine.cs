///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: MsgBusDefine.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-04-08 7:10:02
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.UDPMsgBus
{
    public class UdpMsg
    {
        public const string ToDefineIoServer = "IOServer";

        public string StrFrom { get; set; }
        public string StrTo { get; set; }
        public DateTime MsgDt { get; set; }
        public string StrMsg { get; set; }
    }
}
