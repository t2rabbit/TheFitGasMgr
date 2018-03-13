using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiPublic.Log;
using PiPublic;
using IOServer.BLL.Protocol.CellsLabel;


namespace IOServer.BLL.Protocol.CellsLabel
{
    /// <summary>
    /// CELL-LABEL_
    /// </summary>
    public class CLN_1601_Protocol
    {

        private static int m_iLastError;

        public static int GetLastError()
        {
            return m_iLastError;
        }
        /// <summary>
        /// WLC1301的数据结构定义，一个结构包含了所有的数据项目
        /// </summary>
        public class DevData
        {
            /// <summary>
            //  温度
            /// </summary>
            public long lTemperature { get; set; }

            /// <summary>
            /// 湿度
            /// </summary>
            public long lHumidity { get; set; }

            /// <summary>
            //  电压
            /// </summary>
            public long lVol { get; set; }

            /// <summary>
            /// 电流
            /// </summary>
            public long lCurrent { get; set; }

            public int CurrentWorkType { get; set; }
        }

        /// <summary>
        /// 构造获取数据，发送控制命令包（同一个包通过控制位是否启用区分命令）
        /// </summary>
        /// <param name="bCtlPWM"></param>
        /// <param name="bCtlRely"></param>
        /// <param name="iAddr"></param>
        /// <param name="iPwm"></param>
        /// <param name="iRely"></param>
        /// <returns></returns>
        public static byte[] MakeWritePWM(ushort devOrBroadOrGroupAddr,
            int iLineAddr,
            int iGroupAddr,
            byte iPwm)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);            
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));
            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeCtlPwm);            
            lstCmd.Add((byte)iLineAddr);
            lstCmd.Add((byte)iGroupAddr);
            lstCmd.Add(iPwm);
            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);
            lstCmd.Add(ProtocolLabelDef.EEnd);
            return lstCmd.ToArray();
        }


        /// <summary>
        /// 设置时间，计划
        /// </summary>
        /// <param name="bReadWriteTime"></param>
        /// <param name="bReadWritePlan"></param>
        /// <param name="iAddr"></param>
        /// <param name="iY"></param>
        /// <param name="iM"></param>
        /// <param name="iD"></param>
        /// <param name="iH"></param>
        /// <param name="iMin"></param>
        /// <param name="iS"></param>
        /// <param name="iWeek"></param>
        /// <param name="bPlanArr"></param>
        /// <returns></returns>
        static public byte[] MakeSendTimePlan(ushort devOrBroadOrGroupAddr,
            int iLineAddr,
            int iGroupAddr,
            int iDefPwm,
            int iDelayTimes,
            int iHStart,int iMinStart,
            int iStartPwm,
            int iHEnd,int iMinEnd,
            int iEndPwm)
        {

            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));

            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeSetPwmByTime);
            lstCmd.Add((byte)iLineAddr);
            lstCmd.Add((byte)iGroupAddr);

            lstCmd.Add((byte)iDefPwm);
            lstCmd.Add((byte)iDelayTimes);
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iHStart));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iMinStart));
            lstCmd.Add((byte)iStartPwm);
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iHEnd));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iMinEnd));
            lstCmd.Add((byte)iEndPwm);

            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);
            lstCmd.Add(ProtocolLabelDef.EEnd);

            return lstCmd.ToArray();
        }



        static public byte[] MakeSendYearPlan(ushort devOrBroadOrGroupAddr,
            int iLineAddr,
            int iGroupAddr,
            int iMonthHig4Bits,
            int iMonthLow8Bits,
            int iHStart, int iMinStart,
            int iHEnd, int iMinEnd,
            int[] arrOf24HourPwm)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));

            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeSetYearPlan);
            lstCmd.Add((byte)iLineAddr);
            lstCmd.Add((byte)iGroupAddr);

            lstCmd.Add((byte)iMonthHig4Bits);
            lstCmd.Add((byte)iMonthLow8Bits);
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iHStart));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iMinStart));            
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iHEnd));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)iMinEnd));
            
            for (int i = 0; i < 24; i++)
            {
                if (arrOf24HourPwm.Length > i)
                {
                    lstCmd.Add((byte)arrOf24HourPwm[i]);
                }
                else
                {
                    lstCmd.Add(0);
                }
            }

            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);
            lstCmd.Add(ProtocolLabelDef.EEnd);

            return lstCmd.ToArray();
        }


        /// <summary>
        /// 构造获取数据，发送控制命令包（同一个包通过控制位是否启用区分命令）
        /// </summary>
        /// <param name="bCtlPWM"></param>
        /// <param name="bCtlRely"></param>
        /// <param name="iAddr"></param>
        /// <param name="iPwm"></param>
        /// <param name="iRely"></param>
        /// <returns></returns>
        public static byte[] MakeCtlGetVal(ushort devOrBroadOrGroupAddr,
            int iLineIndex)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));

            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeRealVal);
            lstCmd.Add((byte)(1<<(iLineIndex-1)));
            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);
            lstCmd.Add(ProtocolLabelDef.EEnd);

            return lstCmd.ToArray();
        }


        public static byte[] MakeSendSetTimeCmd(ushort devOrBroadOrGroupAddr,
            int iLineAddr,
            int iGroupAddr,
            DateTime dtNow)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));

            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeSetTime);

            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.Second));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.Minute));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.Hour));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.DayOfWeek));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.Day));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)dtNow.Month));
            lstCmd.Add((byte)BCDHlper.Val2BCD((byte)(dtNow.Year%100)));

            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);
            lstCmd.Add(ProtocolLabelDef.EEnd);

            return lstCmd.ToArray();
        }


        public static byte[] MakeSetToGroup(ushort devOrBroadOrGroupAddr,
            int iLineIndex,
            int iGroupAddr)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(ProtocolLabelDef.EStart);
            lstCmd.Add(ProtocolLabelDef.EStart2);
            lstCmd.Add((byte)((devOrBroadOrGroupAddr & 0xff00) >> 8));
            lstCmd.Add((byte)(devOrBroadOrGroupAddr & 0x00ff));

            lstCmd.Add(ProtocolLabelDef.ECmdSecStart);
            lstCmd.Add(ProtocolLabelDef.FuncCodeSetGroup);
            lstCmd.Add((byte)(1 << (iLineIndex - 1)));
            lstCmd.Add((byte)iGroupAddr);
            lstCmd.Add(ProtocolLabelDef.ECmdSecEnd);

            lstCmd.Add(ProtocolLabelDef.EEnd);

            return lstCmd.ToArray();
        }

// 
//         static int GetVal(int b1, int b2, int b3, int b4)
//         {
//             b1 <<= 24;
//             b2 <<= 16;
//             b3 <<= 8;
//             b4 <<= 0;
//             int iVal = b1 + b2 + b3 + b4;
//             return iVal;
//         }
//         
        


        /// <summary>
        /// 是否为合法的WLT命令，头，尾，长度
        /// </summary>
        /// <param name="pBuf"></param>
        /// <returns></returns>
        public static bool IsWltCmd(byte[] pBuf, int iCldLen) 
        {

            return (pBuf.Length >= 3 &&
                pBuf[0] == ProtocolLabelDef.EStart &&
                pBuf[iCldLen - 1] == ProtocolLabelDef.EEnd );
        }


        public static bool AnalyseReadValRet(byte[] bCmds, int iCmdLen, 
            ushort reqDevAddr, int reqDevLineIdx,
            ref int[] Vals)
        {
            try
            {
                if (!IsWltCmd(bCmds, iCmdLen))
                {
                    LogMgr.WriteInfoDefSys(BitConverter.ToString(bCmds), "数据包头异常");
                    return false;
                }
                if (bCmds[1]!= ProtocolLabelDef.FuncCodeRealVal)
                {
                    LogMgr.WriteInfoDefSys(BitConverter.ToString(bCmds), "非获取数据的功能码");
                    return false;
                }
                ushort readed = (ushort)(bCmds[2]<<8);
                readed += bCmds[3];
                if (readed != reqDevAddr)
                {
                    string strLogTmp = string.Format("{0}_{1}", readed, reqDevAddr);
                    //Program.AddDevMsg(MsgDirect.E_READ, BitConverter.ToString(bCmds), strLogTmp);
                    LogMgr.WriteInfoDefSys(BitConverter.ToString(bCmds), strLogTmp);
                    return false;
                }
                if(bCmds[6] != reqDevLineIdx)
                {
                    LogMgr.WriteInfoDefSys(BitConverter.ToString(bCmds), "子地址不匹配");
                    //Program.AddDevMsg(MsgDirect.E_READ, BitConverter.ToString(bCmds), "子地址不匹配");
                    return false;
                }
                Vals[0] = (bCmds[7] <<8 + bCmds[8]);
                Vals[1] = (bCmds[9] <<8 + bCmds[10]);
                Vals[2] = (bCmds[11] <<8 + bCmds[12]);
                Vals[3] = (bCmds[13] <<8 + bCmds[14]);
                return true;
                
            }
            catch (System.Exception ex)
            {
            	
            }

            return false;
        }

    }
}
