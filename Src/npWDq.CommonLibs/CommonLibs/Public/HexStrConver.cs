using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiPublic
{
	public class HexStrConver
	{
		public static string Hex2String(byte[] pBuf, int iOffset, int iBufLen)
		{
            StringBuilder strTmp = new StringBuilder();
			foreach (byte b in pBuf)
			{
				strTmp.Append(string.Format("{0,3}", string.Format("{0}{1}", Convert.ToString(b, 16) ," ") ));
			}
			return strTmp.ToString();
		}

		public static byte[] Hex2String(string strInfo)
		{
			string strNewInfo = strInfo.Replace(" ", "");
			byte[] pBuf = new byte[strNewInfo.Length / 2];			
			for (int i = 0; i < strNewInfo.Length; i += 2)
			{
				string strTmp = strNewInfo.Substring(i, 2);
				byte bTmp = Convert.ToByte(strTmp, 16);
				pBuf[i / 2] = bTmp;
			}

			return pBuf;
		}
	}
}
