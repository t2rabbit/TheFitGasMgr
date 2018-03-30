using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YDesmsPublicDefDll;
using DBSqlite;

namespace Property.Devs
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
		void SetDBDev(GL_Dev aDev);
	}

}
