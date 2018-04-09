///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: LastStatusInfo.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-04-13 21:06:48
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace IOServer.BLL
{
    public class LastStatusInfo
    {
        public ETypeInfo TypeInfo { get; set; }
        public int GatewayId { get; set; }
        public int DevId { get; set; }
        public EStatus Status { get; set; }
        public string ThreadName { get; set; }
        public DateTime UpdateDt { get; set; }



        public enum ETypeInfo
        {
            ETGateway = 1,
            ETDev = 2,
            ETThread = 3,
        }

        public enum EStatus
        {
            [Description("掉线")]
            ESOffLine = 0,
            [Description("在线")]
            ESOnLine = 1,
            [Description("未知或异常")]
            ESExcpetion = 2
        }
    }
}
