///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: DevCtlModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-22 7:20:09
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
    /// 设备控制数据模型，控制分多种，因此这个类为占位而已
    /// </summary>
    public class RealControlModel
    {
        public int ID { get; set; }             // 填写0
        public string CmdType { get; set; }     // SetPwm,SetPlan 参考DbConstDefine.CmdTypeGetVal，等等
        
        // CmdForTag 1表示单个回路，2表示单个设备，3表示一组，4表示网关，5表示工程
        public int TypeProjGateDevGroup { get; set; }   
        public int ProjectId { get; set; }  // 项目ID，可以没有，但是tag是工程一定要有
        public int GatewayId { get; set; }  // 网关ID，一定要有，否则不知道给那个网关
        public int DevId { get; set; }      // 设备ID，一定要有，
        public int DevAddr { get; set; }    // 设备地址，可以不填
        public int DevLineIndex { get; set; }   //第几回路，从0开始，0-3
        public int GroupAddr { get; set; }      // 组播地址

        // 命令具体内容，调光直接一个数字：1；
        // 如果是计划，使用"-:—_”三个字符隔开的字符串（本来想用对象，但是担心前台传输麻烦），如：
        // 10_50-12:12_100-17:11_0 表示延时10秒，默认50，12点12分开100，17点15分开0也就是关
        public string Cmd { get; set; }         

        public DateTime LogDt { get; set; }
        public int ControlUserId { get; set; }
        public int AddByUserId { get; set; }
        public int CmdFlag { get; set; }            //1新添加，2处理完成，5正在处理
    }

    
    /// <summary>
    /// 实时控制PWM
    /// </summary>
    class DevCtlModel_PWM
    {
        byte groupAddr { get; set; }    // 0 标识设备地址，FF广播，其他为组播
        byte devAddr { get; set; }      // 设备地址
        byte pwmValue { get; set; }
    }

    /// <summary>
    /// 定时指令控制，17点开，23点关，假如现在时间是晚上18点下发，设备是关灯的，那么默认工作状态会触发开？
    /// </summary>
    class DevCtlModel_OnTimePWM
    {
        byte groupAddr { get; set; }    // 0 标识设备地址，FF广播，其他为组播
        byte devAddr { get; set; }      // 设备地址
        byte initPwmValue { get; set; }
        
        int hourOne { get; set; }
        int minuteOne { get; set; }
        byte pwmValOne { get; set; }
        
        int hourTwo { get; set; }
        int minuteTwo { get; set; }
        byte pwmValTwo { get; set; }
        
        
    }
}
