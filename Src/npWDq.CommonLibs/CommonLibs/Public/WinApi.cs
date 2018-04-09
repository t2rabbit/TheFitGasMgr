using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PiPublic
{
	public class WinApi
	{
		/// <summary>
		/// 检测网络连接状态
		/// </summary>
		/// <param name="dwFlag">参数lpdwFlags返回当前网络状态</param>
		/// <param name="dwReserved">保留参数</param>
		/// <returns></returns>
		[DllImport( "winInet.dll ")]
		public static extern bool InternetGetConnectedState(ref  int dwFlag,int dwReserved);

	}
}
