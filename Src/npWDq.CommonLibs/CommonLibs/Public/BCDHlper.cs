using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiPublic
{
    public  class BCDHlper
    {

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
        /// 把十六进制数据转换成BCD 如：11->0x11
        /// </summary>
        /// <param name="bVal"></param>
        /// <returns></returns>
        static public byte Val2BCD(byte bVal)
        {
            byte bTmp = 0;
            byte iTenB = (byte)((bVal/10)<<4);
            byte iFirstB = (byte)(bVal%10);
            bTmp = (byte)(iTenB + iFirstB);
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
            byte iTenB = (byte)((bVal & 0xf0) >> 4);
            byte iFirstB = (byte)(bVal & 0x0f);
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
            byte bTmp = 0;
            int iTenB = bVal / 10;
            int iFirstB = bVal % 10;
            bTmp = (byte)(iTenB << 4 | iFirstB);
            return bTmp;
        }

        static public byte MakeCheckSum(byte[] pBuf, int iOffset, int iLen)
        {
            byte bCheckSum = 0;
            for (int i = iOffset; i < iLen; i++)
            {
                if (i >= pBuf.Length)
                {
                    break;
                }

                bCheckSum += (byte)pBuf[i];
            }
            return bCheckSum;
        }
    }
}
