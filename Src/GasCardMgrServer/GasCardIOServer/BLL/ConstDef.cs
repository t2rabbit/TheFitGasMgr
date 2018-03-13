using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOServer.BLL
{
	class ConstDef
	{
		public const string strCommServerIP = "192.168.0.111";
		public const int iCommServerPort = 7004;

		public const int iSectionsNodeValInvaild = 100; // 100 秒后认为数据不正确

		public const int iSyncTimeNextSecs = 60*70;// 70分钟同步一次时间

        //
        // 配置节点定义
        //
        public const string KEY_CFG_GW_GETDEVDATETIME = "GW_GetDevDataTime";
        public const string KEY_CFG_GW_SENDDATATIME = "GW_SendDataTime";
        public const string KEY_CFG_AUTOSTART = "autostart";
        public const string KEY_CFG_INTERNAL_NEXT_NODE = "node_next_internal";
        public const string KEY_CFG_PICKUPRATE = "PickupRate";
        

        public static readonly string STR_KEY_SHOW_CFG = "showConfig";
	}
}
