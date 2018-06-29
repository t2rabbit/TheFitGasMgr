using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.Log
{
    interface ILog
    {
        void Init();
        void WriteLog(string strMod, string strC1, string strC2, string strC3, string strLogDt, string strMsg);
        void WriteLog(
            string strMsg, int iLogType, string strLogMod, int LogLevel, DateTime logDt, 
            int StrLogID, int iGateid, int iDevid, int iModID, int iCommObjID, int iQuatoID, 
            int iExt1, int iExt2, string strExt1, string strExt2,
            int iBuiid, int iDeptid, int iRoomid, string strEmpApp, int iShow);                        
        void WriteLog(string errorMessage);
//         void WriteLog(string errorText,LogGrade grade);
//         void WriteLog(string errorText, LogGrade grade,LogModule module);
        void Release();
    }
}
