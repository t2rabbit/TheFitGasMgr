using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IOServer.BLL
{
	class DevMgr
	{
		//
		// 单件支持
		//
		#region 单件支持		
		private static DevMgr m_pInst;
		protected DevMgr()
		{
			// 构造函数保护
		}

		static public DevMgr Get()
		{
			if (m_pInst == null)
			{
				m_pInst = new DevMgr();
			}
			return m_pInst;
		}
		#endregion 单件支持

		private IList<IPort> m_lstPorts = new List<IPort>();

		public bool LoadByDB()
		{
			m_lstPorts.Clear();

//             foreach (cnwlcs_PortDdev aDev in DBMgr.Get().ListDevPort)
// 			{
// 				if (aDev.BEnable!=1)
// 				{
// 					continue;
// 				}
// 
// 				IPort aNewPort = null;
// 			}

			return true;
		}

		public bool Start()
		{
			Stop();

			LoadByDB();

			foreach (IPort aPort in m_lstPorts)
			{
				aPort.Start();
			}
			return true;
		}

		public bool Stop()
		{
			foreach (IPort aPort in m_lstPorts)
			{
				aPort.Stop();
			}
			return true;
		}

		public void Release()
		{
			Stop();
		}


	}
}
