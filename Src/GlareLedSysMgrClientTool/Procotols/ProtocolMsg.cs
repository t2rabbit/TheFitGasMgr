using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using PiPublic.Log;


namespace Property.Procotols
{
	class ProtocolMsg
	{
		const int MODBUS_READ_REG_MSG_LEN = 8;
		const int MODBUS_READ_REG_REC_MSG_LEN = 7;
		static public byte[] MakeModbusReadHoldRegMsgRtu(int iSerID, int iFun, int iResAddr, int iCount)
		{
			// 
			byte[] bArr = new byte[MODBUS_READ_REG_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)iSerID;
			bArr[iOffset++] = (byte)iFun;
			bArr[iOffset++] = (byte)( (iResAddr&0xff00)>>8 );
			bArr[iOffset++] = (byte)( iResAddr&0x00ff );
			bArr[iOffset++] = (byte)((iCount & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iCount & 0x00ff);
			ushort wordCrc =  PiPublic.CRCUtily.CRC(bArr, 0, iOffset);
			bArr[iOffset++] = (byte)((wordCrc & 0x00ff));
			bArr[iOffset++] = (byte)( (wordCrc & 0xff00)>>8 );

			System.Diagnostics.Debug.Assert(iOffset == MODBUS_READ_REG_MSG_LEN);
			return bArr;
		}

		static public bool AnalyseRecReadHoldRegRtu(int iSerID, int iFun, int iResAddr, int iCount, byte[] bRec, int[] iArr, int iArrCount)
		{
			if (bRec.Length < MODBUS_READ_REG_REC_MSG_LEN && bRec.Length > MODBUS_READ_REG_MSG_LEN + 5)
            {
//                 Program.AddDevMsg("devmsg", "modbus crc", "iSerID:" + iSerID, "", "", "crc error");
//                 LogMgr.WriteLog("gw", 0, 0, "接收到数据长度不对" + 
//                     bRec.Length);
				return false;
			}

			// check crc
			if (!IsCrcCorrect(bRec, 
                bRec.Length-2,
				(ushort) (bRec[bRec.Length - 2] + (bRec[bRec.Length - 1] << 8)) ) )
			{
				//LogMgr.WriteLog("接收到MODBUS数据校验出错");
//                 Program.AddDevMsg("devmsg", "modbus crc", "iSerID:" + iSerID, "", "", "crc error");
//                 LogMgr.WriteLog("gw", 0, 0, "modbus crc" +
//                     bRec.Length);
				return false;
			}

			// 
			if (iSerID != bRec[0] 
				|| iFun != bRec[1] 
				|| iCount != (bRec[2]/2) )
			{
				return false;
			}


			int iValTmp = 0;
            for (int i = 0; i < iCount * 2; i += 2)
            {
                iValTmp = 0;
                iValTmp = bRec[3 + i] << 8;
                iValTmp += bRec[3 + 1 + i];
                iArr[i / 2] = iValTmp;
            }

			return true;
		}


		static private bool IsCrcCorrect(byte[] pBuf, int iLen, ushort crcRec)
		{
			ushort wordCrc = PiPublic.CRCUtily.CRC(pBuf, 0, iLen);
			return wordCrc == crcRec;
		}

		void MakeModbusReadHoldRegMsgASCII(int iSerID, int iFun, int iResAddr, int iCount)
		{
		}


		const int WLT_CTL_IO_MSG_LEN = 7;
		static public byte[] MakeWltIO(int iAddr, int iCmd)
		{
			byte[] bArr = new byte[WLT_CTL_IO_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)WLT_CTL_IO_MSG_LEN-3;
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdIO;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			bArr[iOffset++] = (byte)(iCmd);
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_CTL_IO_MSG_LEN);
			return bArr;
		}

		const int WLT_CTL_PWN_MSG_LEN = 7;
		static public byte[] MakeWltPWM(int iAddr, int iCmd)
		{
			byte[] bArr = new byte[WLT_CTL_PWN_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)WLT_CTL_PWN_MSG_LEN-3;
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdPWM;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			bArr[iOffset++] = (byte)(iCmd);
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_CTL_PWN_MSG_LEN);
			return bArr;
		}


		const int WLT_GET_AD_MSG_LEN = 6;
		static public byte[] MakeGetAD(int iAddr)
		{
			byte[] bArr = new byte[WLT_GET_AD_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)WLT_GET_AD_MSG_LEN-3;
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdGetAD;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_GET_AD_MSG_LEN);
			return bArr;
		}
		const int WLT_GET_AD_RET_MSG_LEN = 5;
		static public bool AnalyseGetAD(byte[] bRec, out int iVal)
		{
			iVal = 0;
			if ( bRec.Length == WLT_GET_AD_RET_MSG_LEN
				|| bRec[2] == (int)EDefine.EWlt.E_ERR_OK)
			{
				iVal = bRec[3];
				return true;
			}
			return false;
		}


        static public byte GetByteBCD(byte bVal)
        {
            byte bTmp = 0;
            int iTenB = bVal / 10;
            int iFirstB = bVal % 10;
            bTmp = (byte)(iTenB << 4 | iFirstB);
            return bTmp;
        }
		public const int WLT_SYNC_TIME_MSG_LEN = 13;
		public const int WLT_SYNC_TIME_RET_MSG_LEN = 4;
		static public byte[] MakeSetTime(int iAddr, int iY, int iM, int iD, int iH, int iMin, int iS, int iWeek)
		{
			byte[] bArr = new byte[WLT_SYNC_TIME_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)WLT_SYNC_TIME_MSG_LEN - 3;
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdSetTime;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			bArr[iOffset++] = (byte)GetByteBCD((byte)iS);
			bArr[iOffset++] = (byte)GetByteBCD((byte)iMin); 
			bArr[iOffset++] = (byte)GetByteBCD((byte)iH); 
			bArr[iOffset++] = (byte)GetByteBCD((byte)iWeek);
			bArr[iOffset++] = (byte)GetByteBCD((byte)iD);
			bArr[iOffset++] = (byte)GetByteBCD((byte)iM);
			bArr[iOffset++] = (byte)GetByteBCD((byte)(iY%100));			
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_SYNC_TIME_MSG_LEN);
			return bArr;
		}
		public static bool AnalyseSetTime(byte[] bRec)
		{
			if (bRec==null 
				//|| bRec.Length != WLT_SYNC_TIME_RET_MSG_LEN
				|| bRec[2] != EDefine.EWlt.E_ERR_OK				)
			{
				LogMgr.WriteErrorDefSys("同步时间失败");
				return false;
			}
			return true;
		}

		public static int SetRouteMsgLen = 6;
		public static int SetRouteRetMsgLen = 10;
		public static byte[] MakeSetRoute(int iAddr)
		{
			byte[] bArr = new byte[WLT_GET_AD_MSG_LEN];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)(SetRouteMsgLen - 3);
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdGetRemoteRouteTab;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_GET_AD_MSG_LEN);
			return bArr;
		}
		public static bool AnalyseSetRoute(int iAddr, byte[] bRec)
		{
			if (bRec.Length < SetRouteRetMsgLen
				|| bRec[2] != EDefine.EWlt.ECmdGetRemoteRouteTab
				|| bRec[3] != (byte)((iAddr & 0xff00) >> 8)
				|| bRec[4] != (byte)((iAddr & 0xff)))
			{
				LogMgr.WriteErrorDefSys("查找路由失败");
				return false;
			}

			return true;
		}

		public static int SetPlanMsgLen = 15;
		public static int PlanBytes = 9;
		static public byte[] MakeSetPlan(int iAddr, int[] iSecArr)
		{
			byte[] bArr = new byte[SetPlanMsgLen];
			int iOffset = 0;
			bArr[iOffset++] = (byte)EDefine.EWlt.EStart;
			bArr[iOffset++] = (byte)(SetPlanMsgLen-3);
			bArr[iOffset++] = (byte)EDefine.EWlt.ECmdSedPlan;
			bArr[iOffset++] = (byte)((iAddr & 0xff00) >> 8);
			bArr[iOffset++] = (byte)(iAddr & 0x00ff);
			for (int i = 0; i < PlanBytes; i++)
			{
				bArr[iOffset++] = (byte)iSecArr[i];
			}
			bArr[iOffset++] = (byte)EDefine.EWlt.EEnd;

			System.Diagnostics.Debug.Assert(iOffset == WLT_GET_AD_MSG_LEN);
			return bArr;
		}

		static public bool AnalyseSendPlan(int iAddr, byte[] pBuf)
		{
			if (pBuf[0] != EDefine.EWlt.EStart
				|| pBuf[pBuf.Length - 1] != EDefine.EWlt.EEnd)
			{
				return false;
			}
			if (pBuf[2] == EDefine.EWlt.E_ERR_CMD_LEN_FAUSE)
			{
				System.Diagnostics.Debug.Assert(false);
				LogMgr.WriteErrorDefSys("pBuf[2] == EDefine.EWlt.E_ERR_CMD_LEN_FAUSE");
				return false;
			}

			return pBuf[2] == EDefine.EWlt.E_ERR_OK;
		}

	}

	public class EDefine
	{
		public class EWlt
		{
			public const int EStart = 0xAA;
			public const int EEnd = 0x55;

			public const int ECmdTxData = 0xd1; // 传输数据	0xD1
			public const int ECmdGetLocalRouteTab = 0xd2; // 查找本地路由表	0xD2
			public const int ECmdGetRemoteRouteTab = 0xd3; // 查找远程路由表	0xD3
			public const int ECmdSetLocalRoutTab = 0xd4; // 设置本地路由表	0xD4
			public const int ECmdIO = 0xd5; // 控制IO命令	0xD5
			public const int ECmdPWM = 0xd6; // 控制PWM命令	0xD6
			public const int ECmdGetAD = 0xd7; // 读取AD命令	0xD7
			public const int ECmdSetTime = 0xd8; // 设置时间命令	0xD8
			public const int ECmdSedPlan = 0xd9; // 发送计划 0xD9

			//
			// 错误代码
			//
			public const int E_ERR_OK = 0;//SEND_OK	0x00	发送成功
			public const int E_ERR_FIND_LOCAL_ROUTE = 0xA1;//	查找本地路由表失败
			public const int E_ERR_SEND_DATA_TIMEOUT = 0xA4;//	发送数据超时
			public const int E_ERR_DEVICE_BUSY = 0xA5; //设备忙
			public const int E_ERR_CMD_LEN_FAUSE = 0xA6; // 协议错，应该被发现 

		}
	}
}
