using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace LmxPublic.Log
{
    class TraceLog
    {
        public static void WriteLog(string errorMesssage)
        {
            Trace.WriteLine(string.Format("{0}-->{1}", DateTime.Now, errorMesssage));
        }

//         public static void WriteLog(string errorMesssage, LogGrade grade)
//         {
//             Trace.WriteLine(string.Format("{0} {1}-->{2}", DateTime.Now, grade, errorMesssage));
//         }
// 
//         public static void WriteLog(string errorMesssage, LogGrade grade, LogModule module)
//         {
//             Trace.WriteLine(string.Format("{0} {1}({2})-->{3}", DateTime.Now, module, grade, errorMesssage));
//         }

        void WriteLog(string strMod, string strC1, string strC2, string strC3, string strLogDt, string strMsg)
        {
            Trace.WriteLine(string.Format("{0}-->{1}->{2}->{3}-{4}->{5}->{6}", DateTime.Now, strMod, strC1, strC2, strC3, strLogDt, strMod));
                
        }
        void WriteLog(
            string strMsg, int iLogType, string strLogMod, int LogLevel, DateTime logDt,
            int StrLogID, int iGateid, int iDevid, int iModID, int iCommObjID, int iQuatoID,
            int iExt1, int iExt2, string strExt1, string strExt2,
            int iBuiid, int iDeptid, int iRoomid, string strEmpApp, int iShow)
        {
            WriteLog(strLogMod, iLogType.ToString(), LogLevel.ToString(), "", logDt.ToString(), strMsg);
        }
    }
}
