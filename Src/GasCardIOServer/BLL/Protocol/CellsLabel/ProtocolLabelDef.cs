///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ProtocolLabelDef.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-26 14:32:52
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOServer.BLL.Protocol.CellsLabel
{
    public class ProtocolLabelDef
    {

        public const int EStart = 0xAA;
        public const int EStart2 = 0xD1;
        public const int EEnd = 0x55;
        public const byte ECmdSecStart = 0xAC;
        public const byte ECmdSecEnd = 0xCA;

        public const int FuncCodeCtlPwm = 1;
        public const int FuncCodeSetPwmByTime = 2;
        public const int FuncCodeRealVal = 3;
        public const int FuncCodeSetGroup = 4;
        public const int FuncCodeSetTime = 5;
        public const int FuncCodeSetYearPlan = 7;


        public const ushort BroadAddress = 0xffff;        

        //
        // 错误代码
        //
        public const int E_ERR_OK = 0;//SEND_OK	0x00	发送成功
        public const int E_ERR_NODEFINE = 0xB0;//错误不理会，反正就是失败了
        public const int E_ERR_FIND_LOCAL_ROUTE = 0xA1;//	查找本地路由表失败
        public const int E_ERR_SEND_DATA_TIMEOUT = 0xA4;//	发送数据超时
        public const int E_ERR_DEVICE_BUSY = 0xA5; //设备忙
        public const int E_ERR_CMD_LEN_FAUSE = 0xA6; // 协议错，应该被发现 

        public const int E_PLAN_LEN = 66;
    }

    /// <summary>
    /// 控制码定义
    /// </summary>
    public enum ECtlModSelCode
    {
        E_NONE = 0,
        E_READ = 1,
        E_WRITE = 2,
    }
    
}
