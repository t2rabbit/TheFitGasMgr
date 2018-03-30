using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YD_PUBLIC.Log;
using YDesmsPublicDefDll;

namespace Property
{
    class TimeTempProtocol
    {
        /// <summary>
        /// 构造同步时间的命令
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public byte[] MakeSyncTime(int id, DateTime dtSet)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(0xfe);
            lstCmd.Add(0xff);
            lstCmd.Add(0); // 命令长度
            lstCmd.Add(0x21); // 
            lstCmd.Add((byte)id);
            lstCmd.Add((byte)(dtSet.Year % 100));
            lstCmd.Add((byte)(dtSet.Month));
            lstCmd.Add((byte)(dtSet.Day));
            lstCmd.Add((byte)(dtSet.Hour));
            lstCmd.Add((byte)(dtSet.Minute));
            lstCmd.Add((byte)(dtSet.Second));
            lstCmd[2] = (byte)(lstCmd.Count - 3 + 2);
            byte bMakcScheckSum = GLLedProtocol.MakeCheckSum(lstCmd.ToArray(), 2, lstCmd.Count);
            lstCmd.Add(bMakcScheckSum);
            lstCmd.Add(0xfe);
            return lstCmd.ToArray();
        }

        static public byte[] MakeGetTime(int iID)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(0xfe);
            lstCmd.Add(0xff);
            lstCmd.Add(0); // 命令长度
            lstCmd.Add(0x22); // 
            lstCmd.Add((byte)iID);
            lstCmd[2] = (byte)(lstCmd.Count - 3 + 2);
            byte bMakcScheckSum = GLLedProtocol.MakeCheckSum(lstCmd.ToArray(), 2, lstCmd.Count);
            lstCmd.Add(bMakcScheckSum);
            lstCmd.Add(0xfe);
            return lstCmd.ToArray();
        }

        static public bool AnalyseGetTime(byte[] pBufRec, int iBufLen, ref DateTime dt)
        {
            byte bCmdType = GLLedDefine.btCmdGetTime;

            if (pBufRec[0] != GLLedDefine.btCmdStart
                && pBufRec[1] != GLLedDefine.btRecCmdStart
                && pBufRec[GLLedDefine.iCmdOffsetOfTypeSection] != bCmdType
                && pBufRec[pBufRec.Length - 1] != GLLedDefine.btCmdEnd)
            {
                FileLog.WriteLog("命令码不对");
                return false;
            }

            if (!GLLedProtocol.IsCheckSumCorrect(pBufRec, pBufRec[pBufRec.Length - 2]))
            {
                FileLog.WriteLog("校验错了");
                return false;
            }

            return true;
        }


        static public byte[] MakeGetTempture(int iID)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(0xfe);
            lstCmd.Add(0xff);
            lstCmd.Add(0); // 命令长度
            lstCmd.Add(0x23); // 
            lstCmd.Add((byte)iID);
            lstCmd[2] = (byte)(lstCmd.Count - 3 + 2);
            byte bMakcScheckSum = GLLedProtocol.MakeCheckSum(lstCmd.ToArray(), 2, lstCmd.Count);
            lstCmd.Add(bMakcScheckSum);
            lstCmd.Add(0xfe);
            return lstCmd.ToArray();

        }

        public static byte[] MakeSetTemp(int iID, int iVal)
        {
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(0xfe);
            lstCmd.Add(0xff);
            lstCmd.Add(0); // 命令长度
            lstCmd.Add(0x25); // 
            lstCmd.Add((byte)iID);
            lstCmd.Add((byte)iVal); // 
            lstCmd[2] = (byte)(lstCmd.Count - 3 + 2);
            byte bMakcScheckSum = GLLedProtocol.MakeCheckSum(lstCmd.ToArray(), 2, lstCmd.Count);
            lstCmd.Add(bMakcScheckSum);
            lstCmd.Add(0xfe);
            return lstCmd.ToArray();
        }

        public static byte[] MakeSetCfg(int iID, int iTmp, int iDigCount, int iBrightness)
        {
            
            List<byte> lstCmd = new List<byte>();
            lstCmd.Add(0xfe);
            lstCmd.Add(0xff);
            lstCmd.Add(0); // 命令长度
            lstCmd.Add(0x20); // 
            lstCmd.Add((byte)iID);
            lstCmd.Add((byte)iTmp); // 
            lstCmd.Add((byte)iDigCount); // 
            lstCmd.Add((byte)iBrightness); // 
            lstCmd[2] = (byte)(lstCmd.Count - 3 + 2);
            byte bMakcScheckSum = GLLedProtocol.MakeCheckSum(lstCmd.ToArray(), 2, lstCmd.Count);
            lstCmd.Add(bMakcScheckSum);
            lstCmd.Add(0xfe);
            return lstCmd.ToArray();
        }
    }
}
