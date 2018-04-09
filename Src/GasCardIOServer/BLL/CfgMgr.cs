using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;
using PiPublic;

namespace IOServer.BLL
{
    /// <summary>
    /// 配置文件类,读写配置文件
    /// </summary>
	public class CfgMgr
	{

        public const string KEY_GW_GetDevDataRate = "GW_GetDevDataRate";
        public const string KEY_GATEWAY_TIMEUT = "TCPTimeout";
        public const string KEY_GATEWAY_READSN = "ConnSNReadTimeout";
        public const string KEY_GROUPMSGBUSPORT = "GroupMsgBusPort";
        public const string KEY_GROUPMSGBUSIP = "GroupMsgBusIp";
        public const string KEY_ADDTODBMINUTE = "AddToDbMinute";
        

        public static int GetGPRSTimeout()
        {
            return ConfigHlper.GetConfig_Int(KEY_GATEWAY_TIMEUT, 2000);
        }

        public static int GetGPRSSNTimeout()
        {
            return ConfigHlper.GetConfig_Int(KEY_GATEWAY_READSN, 50000);
        }


		public static int GetGetDevDataRate()
		{
            return ConfigHlper.GetConfig_Int(KEY_GW_GetDevDataRate, 5000);
		}

        public static int GetGroupMsgBusPort()
        {
            return ConfigHlper.GetConfig_Int(KEY_GROUPMSGBUSPORT, 7202);
        }

        public static string GetGroupMsgBusIp()
        {
            return ConfigHlper.GetConfig(KEY_GROUPMSGBUSIP);
        }

        public static int GetInsertDbMinute()
        {
            return ConfigHlper.GetConfig_Int(KEY_ADDTODBMINUTE, 60000);
        }
	}

}
