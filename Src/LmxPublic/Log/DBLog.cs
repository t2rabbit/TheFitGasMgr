using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LmxPublic;

namespace LmxPublic.Log
{
    class DBLog
    {
        public static void WriteLog(string errorMesssage)
        {
// 			if (errorMesssage.Length > 450)
// 			{
// 				errorMesssage = errorMesssage.Substring(0, 450);
// 			}
// 			WriteLog("sys", DBDefines.CLogTypeDefine.TYPE_INFO, DBDefines.CLogLevelDefine.LEVEL_INFO, errorMesssage);
		}

        public static void WriteLog(string strMod, int iLogType, int iLogLevel, string strMsg)
        {
//             if (strMsg.Length > 450)
//             {
//                 strMsg = strMsg.Substring(0, 450);
//             }
//             WriteLog(strMsg, iLogType, strMod, iLogLevel, DateTime.Now, 
//                 0, 0, 0, 0, 0, 0,
//                 0, 0, "", "", 
//                 0, 0, 0, "", 0);
        }

       public static  void WriteLog(
            string strMsg, int iLogType, string strLogMod, int LogLevel, DateTime logDt,
            int StrLogID, int iGateid, int iDevid, int iModID, int iCommObjID, int iQuatoID,
            int iExt1, int iExt2, string strExt1, string strExt2,
            int iBuiid, int iDeptid, int iRoomid, string strEmpApp, int iShow)
        {
//             if (strMsg.Length > 450)
//             {
//                 strMsg = strMsg.Substring(0, 450);
//             }
//             StringBuilder sb = new StringBuilder();
//             sb.Append("insert into [log](msg, logtype, logmodule, loglevel, logdt, srclogid, gateid, devid, moduleid, commobjid, quatoid, extint1, extint2, extstr1, extstr2, buildingid, departmentid, roomid, empappoint, isshow) values(");
//             sb.Append(string.Format("\'{0}\', ", strMsg)); // msg
//             sb.Append(string.Format("{0},", iLogType) ); // logtype
//             sb.Append(string.Format("\'{0}\',", strLogMod) ); // logmodule
//             sb.Append(string.Format("{0},", LogLevel) ); // loglevel
//             sb.Append(string.Format("\'{0}\',", logDt.ToString()) ); // logdt
//             sb.Append(string.Format("{0},", StrLogID) ); // srclogid
//             sb.Append(string.Format("{0},", iGateid) ); // gateid
//             sb.Append(string.Format("{0},", iDevid) ); // devid
//             sb.Append(string.Format("{0},", iModID) ); // moduleid
//             sb.Append(string.Format("{0},", iCommObjID) ); // commobjid
//             sb.Append(string.Format("{0},", iQuatoID) ); // quatoid
//             sb.Append(string.Format("{0},", iExt1) ); // extint1
//             sb.Append(string.Format("{0},", iExt2) ); // extint2
//             sb.Append(string.Format("\'{0}\',", strExt1) ); // extstr1
//             sb.Append(string.Format("\'{0}\',", strExt2) ); // extstr2
//             sb.Append(string.Format("{0},", iBuiid) ); // buildingid
//             sb.Append(string.Format("{0},", iDeptid) ); // departmentid
//             sb.Append(string.Format("{0},", iRoomid) ); // roomid
//             sb.Append(string.Format("\'{0}\',", strEmpApp) ); // empappoint
//             sb.Append(string.Format("{0}", iShow) ); // isshow
//             sb.Append(")");
// 
//             DBHlper.ExecSqlCmd(sb.ToString(), ConnStrApp);
        }

       // public static string ConnStrApp = "yd_esms_insert_log";
    }
}
