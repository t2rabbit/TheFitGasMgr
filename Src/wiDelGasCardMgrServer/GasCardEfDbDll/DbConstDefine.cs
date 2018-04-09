using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlareSysEfDbAndModels
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
            ProjectUser = 3,
            CommDevUser = 4,
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
        // 协议类型
        //
        public const string ProtocolGasCard001 = "GasCard2018";

        /// <summary>
        /// 网关或设置状态
        /// </summary>
        public enum DevGatewayStatus
        {
            StatusAddNew = 0,
            StatusOnLine = 1,
            StatusOffLine = 2,
            StatusDelete = 99
        }
    }
}
