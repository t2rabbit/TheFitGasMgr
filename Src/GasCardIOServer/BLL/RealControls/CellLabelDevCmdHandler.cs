///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: CellLabelDevCmdHandler.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-26 22:00:39
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using PiPublic.Log;
using IOServer.BLL.Protocol.CellsLabel;
using NetLabelEfDbDll;
using System.Threading;

namespace IOServer.BLL.RealControls
{
    class CellLabelDevCmdHandler : IModuleCmdHander
    {
        public override bool _HandleCmd(IPort iPort,
            RealControlModel aCmd,
            ref string strCmdHandedMsg)
        {

            LogMgr.WriteDebugDefSys(iPort.GetDevName() + "正常处理命令 cmd :" + aCmd.CmdType + "; " +aCmd.Cmd );
            bool bRet = false;
            int iErrCode = 0;
            
            //
            // 控制模块，如果模块为空表示广播
            //
            DbConstDefine.CmdForTag typeOfDst = (DbConstDefine.CmdForTag)(aCmd.TypeProjGateDevGroup);
            ushort devAddr = 0xffff;
            int groupAddr = 0;
            int lineVal = 0;
            DevInfoModel dev = null;
            switch (typeOfDst)
            {
                case DbConstDefine.CmdForTag.TagLine:
                    dev = (from c in DBMgr.Get().ListDev 
                                        where c.ID == aCmd.DevId 
                                        select c).FirstOrDefault();                    
                    devAddr = (ushort)Convert.ToUInt16(dev.DevAddr, 16);
                    groupAddr = 0;
                    lineVal = (1<<(dev.DevLineIndex-1));
                    lineVal = 0x0f;
                    break;

                case DbConstDefine.CmdForTag.TagDev:
                    dev = (from c in DBMgr.Get().ListDev
                                        where c.ID == aCmd.DevId
                                        select c).FirstOrDefault();
                    devAddr = (ushort)Convert.ToUInt16(dev.DevAddr, 16);
                    groupAddr = aCmd.GroupAddr;
                    lineVal = 0x0f;
                    break;

                case DbConstDefine.CmdForTag.TagGroup:
                    devAddr = 0xffff;
                    groupAddr = aCmd.GroupAddr;
                    lineVal = 0x0f;
                    break;
                case DbConstDefine.CmdForTag.TagGateway:
                    devAddr = 0xffff;
                    groupAddr = 0;
                    break;
                case DbConstDefine.CmdForTag.TagProject:
                    devAddr = 0xffff;
                    groupAddr = 0;
                    break;
                default:
                    break;
            }

            if (aCmd.CmdType == DbConstDefine.CmdTypeGetVal)
            {
                LogMgr.WriteDebugDefSys(iPort.GetDevName() + "正常处理命令 cmd :" +"获取值");
           
                //bRet = iPort._GetAllNodeByModule(iPort) == 1;
            }
            else if (aCmd.CmdType == DbConstDefine.CmdTypeSetGroup)
            {
                LogMgr.WriteDebugDefSys(iPort.GetDevName() + "正常处理命令 cmd :" + "设置组");
                bRet = HlperSetGroup(iPort, devAddr, lineVal, aCmd.GroupAddr, 
                    ref strCmdHandedMsg, ref iErrCode);
            }
            else if (aCmd.CmdType == DbConstDefine.CmdSetPwm)
            {
                LogMgr.WriteDebugDefSys(iPort.GetDevName() + "正常处理命令 cmd :" + "控制PWM");
                int iVal = 0;
                int.TryParse(aCmd.Cmd, out iVal);
                bRet = HlperSetPWM(iPort, devAddr, lineVal, aCmd.GroupAddr, iVal,
                    ref strCmdHandedMsg, ref iErrCode);
            }
            else if (aCmd.CmdType == DbConstDefine.CmdTypeSetPlan)
            {
                LogMgr.WriteDebugDefSys(iPort.GetDevName() + "正常处理命令 cmd :" + "设置计划");
                // 10_50-12:12_100-17:11_0
                string[] strPlanInfos = aCmd.Cmd.Split(new char[] { '_',':','-' });
                if (strPlanInfos.Length < 8)
                {
                    return false;
                }
                int delay, defpwm, hourS, minS, valS, hourE, minE, valE;
                int.TryParse(strPlanInfos[0], out defpwm);
                int.TryParse(strPlanInfos[1], out delay);
                int.TryParse(strPlanInfos[2], out hourS);
                int.TryParse(strPlanInfos[3], out minS);
                int.TryParse(strPlanInfos[4], out valS);
                int.TryParse(strPlanInfos[5], out hourE);
                int.TryParse(strPlanInfos[6], out minE);
                int.TryParse(strPlanInfos[7], out valE);

                bRet = HlperSetPlan(iPort, devAddr, lineVal, aCmd.GroupAddr,
                    defpwm, delay, hourS, minS, valS, hourE, minE, valE,
                    ref strCmdHandedMsg, ref iErrCode);
            }
            else if (aCmd.CmdType == DbConstDefine.CmdTypeSetYearPlan)
            {
                LogMgr.WriteDebugDefSys(iPort.GetDevName() + "； 将要处理的命令是控时计划");                
                string[] strSecs = aCmd.Cmd.Split(new char[]{'-',':', '_'});
                //111111111111_18:00_07:00_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51_51
                if (strSecs.Length != 29)
                {
                    return false;
                }
                if (strSecs[0].Length != 12)
                {
                    return false;
                }
                byte bMonthsH4Bits = HlperGetHight4BitOfString(strSecs[0]);
                byte bMOnthsL8Bits = HpperGetLow8BitsOfString(strSecs[0]);

                int hourS, minS, hourE, minE;
                int.TryParse(strSecs[1], out hourS);
                int.TryParse(strSecs[2], out minS);
                int.TryParse(strSecs[3], out hourE);
                int.TryParse(strSecs[4], out minE);
                int[] iPwmHourArr = new int[24];
                for (int i = 0; i < 24; i++)
                {
                    int.TryParse(strSecs[5+i], out iPwmHourArr[0+i]);
                }

                bRet = HlperSetYearPlan(iPort, devAddr, lineVal, aCmd.GroupAddr,
                    bMonthsH4Bits, bMOnthsL8Bits,
                    hourS, minS, hourE, minE,
                    iPwmHourArr, ref strCmdHandedMsg, ref iErrCode);

            }
            else
            {

            }

            return bRet;
        }


        private byte HlperGetHight4BitOfString(string strBits)
        {
            byte bVal = 0;
            bVal = (byte)(bVal | (strBits[8] == '1' ? 1 : 0));
            bVal = (byte)(bVal | (strBits[9] == '1' ? (1 << 1) : 0));
            bVal = (byte)(bVal | (strBits[10] == '1' ? (1 << 2) : 0));
            bVal = (byte)(bVal | (strBits[11] == '1' ? (1 << 3) : 0));

            return bVal;
        }

        private byte HpperGetLow8BitsOfString(string strBits)
        {

            byte bVal = 0;
            bVal = (byte)(bVal | (strBits[0] == '1' ? 1 : 0));
            bVal = (byte)(bVal | (strBits[1] == '1' ? (1 << 1) : 0));
            bVal = (byte)(bVal | (strBits[2] == '1' ? (1 << 2) : 0));
            bVal = (byte)(bVal | (strBits[3] == '1' ? (1 << 3) : 0));
            bVal = (byte)(bVal | (strBits[4] == '1' ? (1 << 4) : 0));
            bVal = (byte)(bVal | (strBits[5] == '1' ? (1 << 5) : 0));
            bVal = (byte)(bVal | (strBits[6] == '1' ? (1 << 6) : 0));
            bVal = (byte)(bVal | (strBits[7] == '1' ? (1 << 7) : 0));
            return bVal;
        }

        bool HlperGetModValue()
        {
            return false;
        }

        public override string _GetType()
        {
            return "CellsLabel";
        }

        /// <summary>
        /// 控制灯亮度
        /// </summary>
        /// <param name="iPort"></param>
        /// <param name="aMod"></param>
        /// <param name="aCmd"></param>
        /// <param name="strCmdHandedMsg"></param>
        /// <returns></returns>
        private bool HlperSetPWM(IPort iPort,
            ushort devaddr, int lineVal, int groupaddr, int pwm,
            ref string strCmdHandedMsg, ref int iErrCode)
        {
            strCmdHandedMsg = "控制失败";
            byte[] bCmd = CLN_1601_Protocol.MakeWritePWM(devaddr, lineVal, groupaddr, (byte)pwm);
            iPort._Write(bCmd, 0, bCmd.Length);
            Thread.Sleep(100);
            byte[] pRecBuf = iPort._Read(0);
            if (pRecBuf == null)
            {
                strCmdHandedMsg += "没有接受到数据";
                if (devaddr == 0xffff)
                {
                    strCmdHandedMsg += "广播或是组播地址，无返回，命令发送成功";
                    return true;
                }
                else
                {
                    return false;
                }                
            }
                        
            // todo 分析
            strCmdHandedMsg = "控制成功";
            return true;
        }

        /// <summary>
        /// 发送计划
        /// </summary>
        /// <returns></returns>
        private bool HlperSetGroup(IPort iPort,
            ushort devaddr, int lineVal, int groupaddr,
            ref string strCmdHandedMsg, ref int iErrCode)
        {

            byte[] bCmd = CLN_1601_Protocol.MakeSetToGroup(devaddr, lineVal, groupaddr);
            iPort._Write(bCmd, 0, bCmd.Length);
            Thread.Sleep(100);
            byte[] pRecBuf = iPort._Read(0);
            if (pRecBuf == null)
            {
                if (devaddr == 0xffff)
                {
                    strCmdHandedMsg += "广播或是组播地址，无返回，命令发送成功";
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // todo 分析
            strCmdHandedMsg = "发送计划成功";
            return true;
        }


        /// <summary>
        /// 发送计划
        /// </summary>
        /// <returns></returns>
        private bool HlperSetPlan(IPort iPort,
            ushort devaddr, int lineVal, int groupaddr, int defPwm, int delayTime,
            int iHourS, int iMinS, int pwmStart, int iHourE, int iMinE, int pwmEnd,
            ref string strCmdHandedMsg, ref int iErrCode)
        {

            byte[] bCmd = CLN_1601_Protocol.MakeSendTimePlan(devaddr, lineVal, groupaddr, defPwm,
                delayTime,
                iHourS, iMinS, pwmStart, iHourE, iMinE, pwmEnd);
            iPort._Write(bCmd, 0, bCmd.Length);
            Thread.Sleep(100);
            byte[] pRecBuf = iPort._Read(0);
            if (pRecBuf == null)
            {
                strCmdHandedMsg += "没有接受到数据";
                return false;
            }

            // todo 分析
            strCmdHandedMsg = "发送计划成功";
            return true;
        }



        /// <summary>
        /// 发送年度计划
        /// </summary>
        /// <returns></returns>
        private bool HlperSetYearPlan(IPort iPort,
            ushort devaddr, int lineVal, int groupaddr, int monthH4Bits, int monthL8Bits,
            int iHourS, int iMinS, int iHourE, int iMinE,
            int[] iArr24HourPwm,
            ref string strCmdHandedMsg, ref int iErrCode)
        {

            byte[] bCmd = CLN_1601_Protocol.MakeSendYearPlan(devaddr, lineVal, groupaddr, 
               monthH4Bits, monthL8Bits, 
               iHourS, iMinS, iHourE, iMinE,
               iArr24HourPwm);
            iPort._Write(bCmd, 0, bCmd.Length);
            Thread.Sleep(100);
            byte[] pRecBuf = iPort._Read(0);
            if (pRecBuf == null)
            {
                strCmdHandedMsg += "没有接受到数据";
                return false;
            }

            // todo 分析
            strCmdHandedMsg = "发送计划成功";
            return true;
        }
    }

    
}
