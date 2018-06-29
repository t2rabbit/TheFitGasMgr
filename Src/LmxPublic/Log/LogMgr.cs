using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.Log
{
    public class LogMgr
    {
        public static void WriteLog(string strMod, int iLogTpe, int iLogLevel, string strMsg)
        {

            FileLog.WriteLog(strMod, iLogTpe, iLogLevel, strMsg);
            //TraceLog.WriteLog(strMod, strC1, strC2, strC3, strLogDt, strMsg);
            DBLog.WriteLog(strMod, iLogTpe, iLogLevel, strMsg);
        }

        public static void WriteLog(string errorMesssage)
        {
            FileLog.WriteLog(errorMesssage);
            DBLog.WriteLog(errorMesssage);
        }

        public static void WriteLog(
            string strMsg, int iLogType, string strLogMod, int LogLevel, DateTime logDt,
            int StrLogID, int iGateid, int iDevid, int iModID, int iCommObjID, int iQuatoID,
            int iExt1, int iExt2, string strExt1, string strExt2,
            int iBuiid, int iDeptid, int iRoomid, string strEmpApp, int iShow)
        {
            FileLog.WriteLog(strLogMod, iLogType,  LogLevel, strMsg);
            DBLog.WriteLog(strMsg, iLogType, strLogMod, LogLevel, logDt,
                StrLogID, iGateid, iDevid, iModID, iCommObjID, iQuatoID, iExt1, iExt2, strExt1, strExt2,
                iBuiid, iDeptid, iRoomid, strEmpApp, iShow);
        }

//         public static void WriteLog(string errorMesssage, LogGrade grade)
//         {
//             FileLog.WriteLog(errorMesssage, grade);
//             //TraceLog.WriteLog(errorMesssage, grade);
//             DBLog.WriteLog(errorMesssage, grade);
// 
//         }
// 
// 		public static void WriteLog(string errorMesssage, LogGrade grade, LogModule module)
// 		{
// 			FileLog.WriteLog(errorMesssage, grade, module);
// 			//TraceLog.WriteLog(errorMesssage, grade, module);
// 			DBLog.WriteLog(errorMesssage, grade, module);
// 		}

		static public string strFileName = "FileLog.log";
		static public int iFileLen = 1000 * 1024; // K
    }
}
