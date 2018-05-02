using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using PiPublic.Log;
using PiPublic;
using GLLedPublic;

namespace GlareSysDataCenter.CommRW
{
	class GLLedProtocol
    {
        /// <summary>
        /// CRC交易是否正确
        /// </summary>
        /// <param name="pBuf">数据内容</param>
        /// <param name="iLen">使用多长的字节进行判断对比</param>
        /// <param name="crcRec">比对的CRC</param>
        /// <returns></returns>
        static private bool IsCrcCorrect(byte[] pBuf, int iLen, ushort crcRec)
        {
            ushort wordCrc = CRCUtily.CRC(pBuf, 0, iLen);
            return wordCrc == crcRec;
        }

        /// <summary>
        /// 判断校验和是否对
        /// </summary>
        /// <param name="pBuf"></param>
        /// <param name="iLen"></param>
        /// <param name="bCheckSum"></param>
        /// <returns></returns>
        static public bool IsCheckSumCorrect(byte[] pBuf, byte bChuckSum)
        {
            if (pBuf==null || pBuf.Length<4)
            {
                return false;
            }

            byte bChuckSumTmp = 0;
            int iTmp = 0;
            for (int i = 0; i < pBuf.Length-4; i++)
            {
                iTmp++;
                bChuckSumTmp += (byte)pBuf[i+2];
            }
             
            return bChuckSumTmp == bChuckSum;
        }

        /// <summary>
        ///  构造校验和
        /// </summary>
        /// <param name="pBuf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        static public byte MakeCheckSum(byte[] pBuf, int iOffset, int iLen)
        {
            byte bCheckSum = 0;
            for (int i = iOffset; i < iLen; i++)
            {
                if (i>=pBuf.Length)
                {
                    break;
                }

                bCheckSum += (byte)pBuf[i];
            }
            return bCheckSum;
        }

        /// <summary>
        /// 计算校验和，并替换到相应字段域
        /// </summary>
        /// <param name="lstCmd"></param>
        static void ReplaceByteWithCheckSum(IList<byte> lstCmd)
        {
            byte[] pBuf = lstCmd.ToArray<byte>();
            byte bMakcScheckSum = MakeCheckSum(pBuf, 2, pBuf.Length - 2);
            lstCmd[lstCmd.Count - 2] = bMakcScheckSum;
        }

        /// <summary>
        /// 对存放在LIST的字节数组求长度，同时替换到命令码的长度域
        /// </summary>
        /// <param name="lstCmd"></param>
        static void ReplaceLastByteWithLen(IList<byte> lstCmd)
        {
            lstCmd[GlareLedSysDefPub.GasCardDef.CmdOffsetOfLenSection] = (byte)(lstCmd.Count - GlareLedSysDefPub.GasCardDef.CmdOffsetOfLenSection - 1);
        }

#region 构造命令函数段


        /// <summary>
        /// 构造设置ID，强制设置
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedSetID(int iAddr)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0); // 字节长度
            lstCmd.Add(0); // 源ID，强制为0
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdSetID); 
            lstCmd.Add((byte)iAddr); // 目标ID
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }

        /// <summary>
        /// 构造获取基本信息
        /// </summary>
        /// <param name="iAddr">卡的ID可以为0</param>
        /// <returns></returns>
        static public byte[] MakeCmdLedGetBaseInfo(int iAddr)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdGetID);
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }

      
        /// <summary>
        /// 设置设备参数
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedSetCfg(int iAddr, GlareLedSysDefPub.GasCardCfg cardCfg)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdSetCfg);
            // 内容
            lstCmd.Add((byte)(cardCfg.bDobule ? 1 : 0));
            lstCmd.Add((byte)cardCfg.iScreenCount);
            lstCmd.Add((byte)cardCfg.iCardDigCount);
            lstCmd.Add((byte)(cardCfg.bShowAppend ? 1 : 0));
            lstCmd.Add((byte)cardCfg.iLight);
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }

        /// <summary>
        /// 获取设备参数
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedGetCfg(int iAddr)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdGetCfg);            
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);     
            ReplaceByteWithCheckSum(lstCmd);      
            return lstCmd.ToArray<byte>();
        }


        /// <summary>
        /// 查询油价价格
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedGetOilVal(int iAddr)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdGetGasVal);
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }

        /// <summary>
        /// 设置油价价格
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedSetOilVal(int iAddr, IList<GlareLedSysDefPub.CardGasValEachNumAByte> lstValOfEachScreen)
        {
            try
            {
                IList<byte> lstCmd = new List<byte>();
                lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
                lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
                lstCmd.Add(0);
                lstCmd.Add((byte)iAddr);
                lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdSetGasVal);
                for (int i = 0; i < 12; i++)
                {
                    if (i < lstValOfEachScreen.Count)
                    {
                        if (lstValOfEachScreen[i].lstArr.Count != 6)
                        {
                            System.Diagnostics.Debug.Assert(false);
                            return null;
                        }
                        byte b1 = MakeVal2BCD_ByTowVal(lstValOfEachScreen[i].lstArr[0], lstValOfEachScreen[i].lstArr[1]);
                        byte b2 = MakeVal2BCD_ByTowVal(lstValOfEachScreen[i].lstArr[2], lstValOfEachScreen[i].lstArr[3]);
                        byte b3 = MakeVal2BCD_ByTowVal(lstValOfEachScreen[i].lstArr[4], lstValOfEachScreen[i].lstArr[5]);
                        lstCmd.Add(b1);
                        lstCmd.Add(b2);
                        lstCmd.Add(b3);

                    }
                    else
                    {
                        for (int iSDig = 0; iSDig < 3; iSDig++)
                            lstCmd.Add(0);
                    }
                }
                lstCmd.Add(0);
                lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
                ReplaceLastByteWithLen(lstCmd);
                ReplaceByteWithCheckSum(lstCmd);
                return lstCmd.ToArray<byte>();
            }
            catch (System.Exception ex)
            {
                return new byte[1];
            }
            
        }
     

        /// <summary>
        /// 设置小数点
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public byte[] MakeCmdLedSetDecimal(int iAddr, int[] lstEachScreen)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdSetPoint);
            for (int i = 0; i < GlareLedSysDefPub.GasCardDef.MaxScreen; i++ )
            {
                if (i<lstEachScreen.Count())
                {
                    lstCmd.Add((byte)lstEachScreen[i]);
                }
                else
                {
                    lstCmd.Add(0);
                }
            }
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }


        /// <summary>
        /// 获取小数点
        /// </summary>
        /// <param name="iAddr">卡ID</param>
        /// <returns></returns>
        static public byte[] MakeCmdLedGetDecimal(int iAddr)
        {
            IList<byte> lstCmd = new List<byte>();
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdStart);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_SendCmdStart);
            lstCmd.Add(0);
            lstCmd.Add((byte)iAddr);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdGetPoint);
            lstCmd.Add(0);
            lstCmd.Add(GlareLedSysDefPub.GasCardDef.BT_CmdEnd);
            ReplaceLastByteWithLen(lstCmd);
            ReplaceByteWithCheckSum(lstCmd);
            return lstCmd.ToArray<byte>();
        }
#endregion

#region 分析函数段


        /// <summary>
        /// 分析设置ID命令是否成功
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public bool AnalyeseRecSetID(byte []pBufRec, int iAddr)
        {
            if (pBufRec != null)
            {
                String strRec = BitConverter.ToString(pBufRec);
                //string strInfo = "gprs info " + strGprsInfo;
                LogMgr.WriteInfoDefSys(strRec);
            }
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetID;
            if (pBufRec == null || pBufRec.Length != GlareLedSysDefPub.GasCardDef.BT_RecBytesLenSetID)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对");
                return false;
            }

            if (pBufRec[0]!= GlareLedSysDefPub.GasCardDef.BT_CmdStart 
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart 
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length-1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 分析查询ID命令是否成功
        /// </summary>
        /// <param name="pBufRec">接收到的字节数组</param>
        /// <param name="iAddrsrc">源地址, 可以为0</param>
        /// <param name="iAddrReaded">获取到的地址</param>
        /// <returns></returns>
        static public bool AnalyeseRecGetID(byte[] pBufRec, int iAddrsrc, out int iAddrReaded)
        {
            if (pBufRec != null)
            {
                String strRec = BitConverter.ToString(pBufRec);
                //string strInfo = "gprs info " + strGprsInfo;
                LogMgr.WriteInfoDefSys(strRec);
            }
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdSetID;
            iAddrReaded = 0;

            if (pBufRec == null || pBufRec.Length != GlareLedSysDefPub.GasCardDef.BT_RecBytesLenSetID)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对");
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec, pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            iAddrReaded = pBufRec[5];
            return true;
        }


        /// <summary>
        /// 分析查询设备参数
        /// </summary>
        /// <param name="pBufRec">接收到的字节数组</param>
        /// <param name="iAddrsrc">源地址, 可以为0</param>
        /// <param name="objCfgReaded">设备参数</param>
        /// <returns></returns>
        static public bool AnalyeseRecGetCfg(byte[] pBufRec, int iAddrsrc, ref GlareLedSysDefPub.GasCardCfg objCfgReaded)
        {
            if (pBufRec != null)
            {
                String strRec = BitConverter.ToString(pBufRec);
                //string strInfo = "gprs info " + strGprsInfo;
                LogMgr.WriteInfoDefSys(strRec);
            }
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetCfg;
            int iWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenGetCfg;
            
            if (pBufRec == null || pBufRec.Length != iWantLen)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对");
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            int iTmp = 5;
            objCfgReaded.iID = pBufRec[3];
            objCfgReaded.iHardVer = pBufRec[iTmp++];
            objCfgReaded.iFirmVer = pBufRec[iTmp++];
            objCfgReaded.bDobule = pBufRec[iTmp++] == 1;
            objCfgReaded.iScreenCount = pBufRec[iTmp++];
            objCfgReaded.iCardDigCount = pBufRec[iTmp++];
            objCfgReaded.bShowAppend = pBufRec[iTmp++] == 1;
            objCfgReaded.iLight = pBufRec[iTmp++];


            return true;
        }

        /// <summary>
        /// 分析设置设备配置命令是否成功
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public bool AnalyeseRecSetCardCfg(byte[] pBufRec, int iAddr)
        {
            if (pBufRec != null)
            {
                String strRec = BitConverter.ToString(pBufRec);
                //string strInfo = "gprs info " + strGprsInfo;
                LogMgr.WriteInfoDefSys(strRec);
            }
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdSetCfg;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenSetCfg;
            if (pBufRec == null || pBufRec.Length != iRecWantLen)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对");
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            return true;
        }


        /// <summary>
        /// 分析设置发送价格内容是否成功
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public bool AnalyeseRecSetOilVal(byte[] pBufRec, int iAddr)
        {
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdSetGasVal;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenSetGasVal;
            if (pBufRec == null)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对");
                return false;
            } 
            if (pBufRec.Length != iRecWantLen)
            {
                String strRec = BitConverter.ToString(pBufRec);
                LogMgr.WriteInfoDefSys(strRec);
            }
            
            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 分析读取的价格内容是否成功
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <param name="lstOilVals"></param>
        /// <returns></returns>
        static public bool AnalyeseRecGetOilVal(byte[] pBufRec, int iAddr, ref List<GlareLedSysDefPub.CardGasValEachNumAByte> lstOilVals)
        {
            try
            {
                byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetGasVal;
                int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenGetGasVal;
                if (pBufRec == null)
                {
                    LogMgr.WriteInfoDefSys("想要的长度不对get oil val:");
                    return false;
                }

                if (pBufRec.Length != iRecWantLen)
                {
                    string str = BitConverter.ToString(pBufRec);
                    LogMgr.WriteInfoDefSys("想要的长度不对get oil val:" + str);
                    return false;
                }

                if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
                && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
                && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
                && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
                {
                    LogMgr.WriteInfoDefSys("命令码不对");
                    return false;
                }

                if (!IsCheckSumCorrect(pBufRec, pBufRec[pBufRec.Length - 2]))
                {
                    LogMgr.WriteInfoDefSys("校验错了");
                    return false;
                }



                while (lstOilVals.Count < GlareLedSysDefPub.GasCardDef.MaxScreen)
                {
                    GlareLedSysDefPub.CardGasValEachNumAByte aItem = new GlareLedSysDefPub.CardGasValEachNumAByte();
                    //                 aItem.lstArr.Add(0);
                    //                 aItem.lstArr.Add(0);
                    //                 aItem.lstArr.Add(0);
                    //                 aItem.lstArr.Add(0);
                    //                 aItem.lstArr.Add(0);
                    //                 aItem.lstArr.Add(0);
                    lstOilVals.Add(aItem);
                }

                int iTmp = 5;
                byte[] bArrScreenVal = new byte[6];
                for (int i = 0; i < GlareLedSysDefPub.GasCardDef.MaxScreen; i++)
                {
                    byte bValBcd1 = pBufRec[iTmp++];
                    byte bValBcd2 = pBufRec[iTmp++];
                    byte bValBcd3 = pBufRec[iTmp++];
                    bArrScreenVal[0] = GetHeightLowByteByBCDVal(bValBcd1, true);
                    bArrScreenVal[0 + 1] = GetHeightLowByteByBCDVal(bValBcd1, false);
                    bArrScreenVal[0 + 2] = GetHeightLowByteByBCDVal(bValBcd2, true);
                    bArrScreenVal[0 + 3] = GetHeightLowByteByBCDVal(bValBcd2, false);
                    bArrScreenVal[0 + 4] = GetHeightLowByteByBCDVal(bValBcd3, true);
                    bArrScreenVal[0 + 5] = GetHeightLowByteByBCDVal(bValBcd3, false);

                    lstOilVals[i].lstArr.Add(bArrScreenVal[0]);
                    lstOilVals[i].lstArr.Add(bArrScreenVal[1]);
                    lstOilVals[i].lstArr.Add(bArrScreenVal[2]);
                    lstOilVals[i].lstArr.Add(bArrScreenVal[3]);
                    lstOilVals[i].lstArr.Add(bArrScreenVal[4]);
                    lstOilVals[i].lstArr.Add(bArrScreenVal[5]);

                }

                return true;
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteInfoDefSys(ex.Message);
                return false;
            }
            
        }




        /// <summary>
        /// 分析读取的价格内容是否成功
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <param name="lstOilVals"></param>
        /// <returns></returns>
        static public bool AnalyeseRecGetOilValString(byte[] pBufRec, int iAddr, ref string strVals)
        {
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetGasVal;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenGetGasVal;
            if (pBufRec == null)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:");
                return false;
            }

            if (pBufRec.Length != iRecWantLen)
            {
                string str = BitConverter.ToString(pBufRec);
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:" + str);
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec, pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            int iTmp = 5;
            byte[] bArrScreenVal = new byte[6];
            try
            {
                for (int i = 0; i < GlareLedSysDefPub.GasCardDef.MaxScreen; i++)
                {
                    byte bValBcd1 = pBufRec[iTmp++];
                    byte bValBcd2 = pBufRec[iTmp++];
                    byte bValBcd3 = pBufRec[iTmp++];
                    string strAScreen = GetHeightLowByteByBCDVal(bValBcd1, true).ToString() +
                        GetHeightLowByteByBCDVal(bValBcd1, false).ToString() +
                        GetHeightLowByteByBCDVal(bValBcd2, true).ToString() +
                        GetHeightLowByteByBCDVal(bValBcd2, false).ToString() +
                        GetHeightLowByteByBCDVal(bValBcd3, true).ToString() +
                        GetHeightLowByteByBCDVal(bValBcd3, false).ToString();
                    if (i > 0)
                    {
                        strVals += "-";
                    }
                    strVals += strAScreen;
                }
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteInfoDefSys(ex.Message);
            }
            

            return true;
        }


        /// <summary>
        /// 分析设置发送设置小数点位置
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        static public bool AnalyeseRecSetDecemil(byte[] pBufRec, int iAddr)
        {
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdSetPoint;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenSetPoint;
            if (pBufRec == null)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:");
                return false;
            }

            if (pBufRec.Length != iRecWantLen)
            {
                string str = BitConverter.ToString(pBufRec);
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:" + str);
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 分析读取的小数点位数
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <param name="lstOilVals"></param>
        /// <returns></returns>
        static public bool AnalyeseRecGetDecmail(byte[] pBufRec, int iAddr, ref int[] arrPoint)
        {
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetPoint;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenGetPoint;
            if (pBufRec == null)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:");
                return false;
            }

            if (pBufRec.Length != iRecWantLen)
            {
                string str = BitConverter.ToString(pBufRec);
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:" + str);
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec,  pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }


            if (arrPoint.Length!= GlareLedSysDefPub.GasCardDef.MaxScreen)
            {
                return false;
            }

            int iOffset = 5;
            for (int i = 0; i < GlareLedSysDefPub.GasCardDef.MaxScreen; i++)
            {
                arrPoint[i] = pBufRec[iOffset++];
            }
            return true;
        }



        /// <summary>
        /// 分析读取的小数点位数
        /// </summary>
        /// <param name="pBufRec"></param>
        /// <param name="iAddr"></param>
        /// <param name="lstOilVals"></param>
        /// <returns></returns>
        static public bool AnalyeseRecGetDecmailString(byte[] pBufRec, ref string strDots)
        {
            byte bCmdType = GlareLedSysDefPub.GasCardDef.BT_CmdGetPoint;
            int iRecWantLen = GlareLedSysDefPub.GasCardDef.BT_RecBytesLenGetPoint;
            if (pBufRec == null)
            {
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:");
                return false;
            }

            if (pBufRec.Length != iRecWantLen)
            {
                string str = BitConverter.ToString(pBufRec);
                LogMgr.WriteInfoDefSys("想要的长度不对get oil val:" + str);
                return false;
            }

            if (pBufRec[0] != GlareLedSysDefPub.GasCardDef.BT_CmdStart
            && pBufRec[1] != GlareLedSysDefPub.GasCardDef.BT_RecCmdStart
            && pBufRec[GlareLedSysDefPub.GasCardDef.CmdOffsetOfTypeSection] != bCmdType
            && pBufRec[pBufRec.Length - 1] != GlareLedSysDefPub.GasCardDef.BT_CmdEnd)
            {
                LogMgr.WriteInfoDefSys("命令码不对");
                return false;
            }

            if (!IsCheckSumCorrect(pBufRec, pBufRec[pBufRec.Length - 2]))
            {
                LogMgr.WriteInfoDefSys("校验错了");
                return false;
            }


            
            int iOffset = 5;
            for (int i = 0; i < GlareLedSysDefPub.GasCardDef.MaxScreen; i++)
            {
                if (strDots.Length != 0)
                {
                    strDots += "-";
                }
                strDots += (pBufRec[iOffset++]).ToString();
                
            }
            return true;
        }
#endregion








#region 其他辅助函数段

        /// <summary>
        /// 通过字符串构造发送价格内容
        /// </summary>
        /// <param name="lstVals"></param>
        /// <returns></returns>
        static public IList<GlareLedSysDefPub.CardGasValEachNumAByte> MakeOilValBytesByString(IList<string> lstVals)
        {
            IList<GlareLedSysDefPub.CardGasValEachNumAByte> lstOil = new List<GlareLedSysDefPub.CardGasValEachNumAByte>();
            foreach (string aStr in lstVals)
            {
                string strTmp = aStr;
                strTmp.Replace(".", "");

                while (strTmp.Length < 6)
                {
                    strTmp += "0";
                }

                GlareLedSysDefPub.CardGasValEachNumAByte aNewOilVal = new GlareLedSysDefPub.CardGasValEachNumAByte();
                byte[] bArr = new byte[6];
                for (int i = 0; i < 6; i++)
                {
                    byte bTmp = 0;
                    string strABit = strTmp.Substring(i, 1);
                    byte.TryParse(strABit, out bTmp);
                    bArr[i] = bTmp;
                }
                aNewOilVal.AddAGasValOfBCDVal(bArr);

                lstOil.Add(aNewOilVal);
            }

            return lstOil;
        }

        /// <summary>
        /// 通过内容构造字符串
        /// </summary>
        /// <param name="strContext"></param>
        /// <returns></returns>
        static public IList<string> MakeStringListByContext(string strContext)
        {
            strContext = strContext.Replace(" ", "");
            strContext = strContext.Replace(".", "");
            string[] strArrScreen = strContext.Split(new char[] { '-', ',' });
            IList<string> lst = new List<string>();
            foreach (string strAstr in strArrScreen)
            {
                lst.Add(strAstr);
            }

            return lst;
        }

        /// <summary>
        /// 把存储成BCD码的数字转换成普通数据 如：0x11-->11
        /// </summary>
        /// <param name="bVal"></param>
        /// <returns></returns>
        static public byte BCD2Val(byte bVal)
        {
            byte bTmp = 0;
            byte iTenB = (byte)(bVal >> 4);
            byte iFirstB = (byte)(bVal & 0x0f);
            bTmp = (byte)(iTenB * 10 + iFirstB);
            return bTmp;
        }

        /// <summary>
        /// 获取BCD码的数字，分别获取高低部分，如0X23,分别获取2，3
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte GetHeightLowByteByBCDVal(byte bVal, bool bHight)
        {
            byte iTenB = (byte)((bVal &0xf0) >> 4);
            byte iFirstB = (byte)(bVal &0x0f);
            return bHight ? iTenB : iFirstB;
        }


        /// <summary>
        /// 2普通数字,高低位转换成BCD码， 0x1,0x5-->0x15
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte MakeVal2BCD_ByTowVal(byte bHight, byte bLow)
        {
            byte bTmp = 0;
            bTmp = (byte)(bHight << 4 | bLow);
            return bTmp;
        }

        /// <summary>
        /// 普通数字转换成BCD码， int  a=11--->0X11;
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="bHight">获取的是搞4字节还是低四字节</param>
        /// <returns></returns>
        static public byte GetValOfBCD_HightOrLow(byte bVal, bool bHight)
        {
            //byte bTmp = 0;
            int iTenB = bVal / 10;
            int iFirstB = bVal % 10;
            //bTmp = (byte)(iTenB << 4 | iFirstB);
            if (bHight)
            {
                return (byte)iTenB;
            }
            return (byte)iFirstB;
            
        }

#endregion

	}
}
