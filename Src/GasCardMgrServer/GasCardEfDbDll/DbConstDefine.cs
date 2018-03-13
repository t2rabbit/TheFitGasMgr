///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: DbConstDefine.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-20 11:49:10
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLabelEfDbDll
{
    /// <summary>
    /// DB常量的定义
    /// </summary>
    public class DbConstDefine
    {
        /// <summary>
        /// 公司级别，总公司为0，第一级分公司为1，其他分公司下面的则直接在分公司或子公司加1
        /// </summary>
        public enum OrgLevelDefine
        {
            CentralOrgLevelIndex = 0,
            FirstBranchOrgLeveIndex = 1,
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        public enum SysUserType
        {
            CenterUser = 0,
            OrgUser = 1,
            GroupUser = 2,
            ProjectUser = 3
        }

        /// <summary>
        /// 命令标志
        /// </summary>
        public enum CmdFlag
        {
            NewCmd = 1,
            CmdHandedSuccess = 2,
            CmdHandedFailed = 3,
            CmdTimeout = 4,
            CmdHandling = 5
        }

        //
        // cmd type
        //
        public const string CmdTypeGetVal = "GetValue";
        public const string CmdTypeSetGroup = "SetGroup";
        public const string CmdTypeSetPlan = "SetPlan";
        public const string CmdSetTime = "SetTime";
        public const string CmdTypeSetYearPlan = "SetYearPlan";
        public const string CmdSetPwm = "SetPwm";

        public enum CmdForTag
        {
            //1表示单个回路，2表示单个设备，3表示灯箱，4表示一组，5表示网关，6表示工程
            TagLine = 1,
            TagDev = 2,
            TagBox = 3,
            TagGroup = 4,
            TagGateway = 5,
            TagProject = 6,
        }


        /// <summary>
        /// 最后一次值
        /// </summary>
        public enum ValueFlag
        {
            ValueNotInit = 0,
            ValueOk = 1,
            ValueOld = 2
        }

        // GPRS== GPRSTCPCLIENT == TCPCLIENT 三个完全相等的
        public const string GateInfo_CommType_GPRS_TCPCLIENT = "GRPS_TCPCLIENT";
        public const string GateInfo_CommType_GPRS = "GPRS";
        public const string GateInfo_CommType_TCPCLIENT = "TCPCLIENT";
        public const string GateInfo_CommType_TCPSERVER = "TCPSERVER";
        public const string GateInfo_CommType_UDP = "UDP";
        public const string GateInfo_CommType_COM = "COM";


        //
        // 设备类型
        //
        public const string DevTypeCellsLed2804 = "C2804";

        /// <summary>
        /// 网关或设置状态
        /// </summary>
        public enum DevGatewayStatus
        {
            StatusAddNew = 0,
            StatusConfirmed = 1,
            StatusDenial = 2,
            StatusDelete = 99
        }

    }
}
