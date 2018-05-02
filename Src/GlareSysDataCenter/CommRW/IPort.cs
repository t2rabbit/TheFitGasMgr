using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLLedPublic;

namespace GlareSysDataCenter.CommRW
{
	interface IPort
	{
		byte[] Read();
		bool Write(byte[] pMsg, int iOffset, int iLen);
		void OnRead();
		bool Start();
		bool Stop();		
		bool Open();
		bool IsOpen();
		bool Close();
		void SetDBDev(MemCfgInfo.MemCardWithCommDev commInfo);
	}

}
