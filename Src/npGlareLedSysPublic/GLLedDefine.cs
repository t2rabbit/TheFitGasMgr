



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLLedPublic
{
    public class GlareLedSysDefPub
    {
        // 油价牌的定义信息
        public class GasCardDef
        {
            public const int BT_CmdStart = 0xFE; // 起始字符        
            public const int BT_SendCmdStart = 0xFF; // 发送数据的起始字符
            public const int BT_RecCmdStart = 0xAF; // 发送数据的起始字符
            public const int BT_CmdEnd = 0xEF; // 字符结束

            public const byte BT_CmdSetID = 0x05; // 设置id
            public const byte BT_CmdGetID = 0x06; // 查询id
            public const byte BT_CmdGetCfg = 0x02; // 获取设备信息
            public const byte BT_CmdSetCfg = 0x00; // 设置配置参数
            public const byte BT_CmdSetGasVal = 0x01; // 发送数据内容（价格）
            public const byte BT_CmdGetGasVal = 0x03; // 读取价格
            public const byte BT_CmdSetPoint = 0x04; // 设置小数点
            public const byte BT_CmdGetPoint = 0x07; // 读取小数点

            public const byte BT_CmdGetTime = 0x22;  // 读取时间
            public const byte BT_CmdGetTemp = 0x23;  // 读取温度
            public const byte BT_CmdSetTemp = 0x21;  // 设置时间

            public const byte BT_RecBytesLenSetID = 8;           // 返回的长度-设置id
            public const byte BT_RecBytesLenGetID = 8;           // 返回的长度-查询id
            public const byte BT_RecBytesLenGetCfg = 7 + BT_CfgLen;       // 返回的长度-获取设备信息
            public const byte BT_RecBytesLenSetCfg = 8;      // 返回的长度-设置配置参数
            public const byte BT_RecBytesLenSetGasVal = 8;    // 返回的长度-发送数据内容（价格）
            public const byte BT_RecBytesLenGetGasVal = 7 + GasValMaxLen;    // 返回的长度-读取价格
            public const byte BT_RecBytesLenSetPoint = 8;     // 返回的长度-设置小数点
            public const byte BT_RecBytesLenGetPoint = 7 + MaxScreen;     // 返回的长度-读取小数点


            // 类别
            public const byte LedTypeGas = 1; // 油价牌
            public const byte LedTypeTempDt = 2; // 温度时间
                                                 // 型号为类别下面的型号如GS8888.GS88899等

            /// <summary>
            /// 长度字节域所在的字节下标
            /// </summary>
            public const int CmdOffsetOfLenSection = 2;
            /// <summary>
            /// 命令码所在的字节下标
            /// </summary>
            public const int CmdOffsetOfTypeSection = 3;

            /// <summary>
            /// 一个油价牌的字节数量
            /// </summary>
            public const byte ScreenByteLen = 3;

            /// <summary>
            /// 价格内容最大字节数量
            /// </summary>
            public const byte GasValMaxLen = MaxScreen * ScreenByteLen;

            /// <summary>
            /// 最大屏幕数量
            /// </summary>
            public const byte MaxScreen = 12;
        }


        /// <summary>
        /// 配置参数的字节长度
        /// </summary>
        public const byte BT_CfgLen = 7;
        public class GasCardCfg
        {
            public int iCardType = 0;
            public int iID = 0;

            public int iHardVer = 0;
            public int iFirmVer = 0;
            public bool bDobule = false;
            public int iScreenCount;
            public int iCardDigCount; // 每块牌有几个字
            public int iLight;
            public bool bShowAppend; // 是否显示10/9 或是1/2等
        }


        public const string CmdDefSetOilValue = "SetOilValue";
        public const string CmdDefGetOilValue = "GetOilValue";
        public const string CmdDefSetOilCfg = "SetOilCfg";

        public const string MemcachedKeyNewCmd = "NewCmdIds";
        public const string MemcachedKeyCmdResult = "ResultIds";


        /// <summary>
        /// 油价牌的价格，每个数字一个字节
        /// </summary>
        public class CardGasValEachNumAByte
        {
            public void AddAGasValOfBCDVal(byte[] bVal)
            {
                System.Diagnostics.Debug.Assert(bVal.Count() == 6);
                for (int i=0; i<6; i++)
                {
                    lstArr.Add(bVal[i]);
                }

            }
            public void Clear()
            {
                lstArr.Clear();
            }

            public List<byte> lstArr = new List<byte>();
        }

        /// <summary>
        /// 路牌指示卡的配置信息
        /// </summary>
        public class RoadTipCfg
        {

        }
    }
}
