using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LmxPublic.Log
{
    public class FileLog
    {
        private static readonly object lockObj = new object();

        public static void WriteLog(string errorText)
        {
            try
            {
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + LogMgr.strFileName;
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\"))
                {
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\");
                }
                lock (lockObj)
                {
                    FileInfo fi = new FileInfo(logPath);
                    if (fi.Exists && fi.Length > LogMgr.iFileLen)
                    {
                        FileCopy(logPath);
                        fi.Delete();
                    }

                    using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Unicode))
                    {
                        sw.WriteLine(string.Format("{0}-->{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), errorText));
                    }
                }

            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);

            }
        }


        public static void WriteLog(string strMod, int iLogType, int iLogLevel, string strMsg)
        {
            try
            {
                string logPath = AppDomain.CurrentDomain.BaseDirectory + LogMgr.strFileName;

                lock (lockObj)
                {
                    FileInfo fi = new FileInfo(logPath);
                    if (fi.Exists && fi.Length > LogMgr.iFileLen)
                    {
                        FileCopy(logPath);
                        fi.Delete();
                    }

                    using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Unicode))
                    {
                        sw.WriteLine(string.Format("{0}-->{1}->{2}->{3}-{4}", DateTime.Now, strMod, iLogType, iLogLevel, strMsg));
                    }
                }

            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);

            }
        }

        static private void FileCopy(string strSrcPath)
        {
            string strPathBase = Path.GetDirectoryName(strSrcPath);
            string strFile = Path.GetFileNameWithoutExtension(strSrcPath);
            int i = 1;
            //strFile += i.ToString();
            string strNew = strPathBase + "\\" + strFile + ".log";
            while (File.Exists(strNew))
            {
                strFile = "_" + i;
                strNew = strPathBase + "\\" + strFile + ".log";
                i++;
            }

            File.Copy(strSrcPath, strNew);
        }

        public void WriteLog(
            string strMsg, int iLogType, string strLogMod, int LogLevel, DateTime logDt,
            int StrLogID, int iGateid, int iDevid, int iModID, int iCommObjID, int iQuatoID,
            int iExt1, int iExt2, string strExt1, string strExt2,
            int iBuiid, int iDeptid, int iRoomid, string strEmpApp, int iShow)
        {
            WriteLog(strLogMod, iLogType, LogLevel, strMsg);
        }
    }
}
