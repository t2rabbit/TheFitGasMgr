///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：FileLog.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：
///     
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015/03/24
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PiPublic.Log
{
    public class FileLog: ILog
    {
		private static readonly object lockObj = new object();


        /// <summary>
        /// 初始化，不需要执行任何动作
        /// </summary>
        /// <param name="obj"></param>
        public void Init(object obj)
        {
            return;
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strSubSys">子系统，默认为Sys</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logGrade">警告级别</param>
        /// <param name="errorMessage">日志内容</param>
        public void WriteLog(string strSubSys, LogType logType, LogGrade logGrade, string errorMessage,
            string strExt1, string strExt2)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "FileLogs");
                string logPath = string.Format("{0}filelogs\\{1}", AppDomain.CurrentDomain.BaseDirectory, strFileName);

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "FileLogs"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "FileLogs");
                }

                lock (lockObj)
                {
                    FileInfo fi = new FileInfo(logPath);
                    if (fi.Exists && fi.Length > iFileLen)
                    {
                        FileCopy(logPath);
                        fi.Delete();
                    }

                    using (StreamWriter sw = new StreamWriter(logPath, true, Encoding.Unicode))
                    {
                        sw.WriteLine(string.Format("{0,-20};{1,-10};{2,-10};{3,-10};{4,-10};{5,-10};{6,-10}",
                            DateTime.Now,
                            strSubSys,
                            EnumTextByDescription.GetEnumDesc(logType),
                            EnumTextByDescription.GetEnumDesc(logGrade),
                            strExt1,strExt2,
                            errorMessage));
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex.Message);
            }
        }


        /// <summary>
        /// 备份文件，在原有文件基础后面添加数字后缀
        /// </summary>
        /// <param name="strSrcPath">文件的全路经</param>
        private void FileCopy(string strSrcPath)
        {
            string strPathBase = Path.GetDirectoryName(strSrcPath);
            string strFile = Path.GetFileNameWithoutExtension(strSrcPath);
            string strNew = string.Format("{0}\\{1}.log", strPathBase, fileIndex);
            System.Diagnostics.Trace.WriteLine("new File is:" + strNew);
            string strFileDel = string.Format("{0}\\{1}.log", strPathBase, (fileIndex - 10));
            fileIndex++;
            System.Diagnostics.Trace.WriteLine("will del file is:" + strFileDel);


            if (File.Exists(strFileDel))
            {
                File.Delete(strFileDel);
            }

            File.Copy(strSrcPath, strNew);
        }


        static public string strFileName = "FileLog.log";
        static public int iFileLen = 1000 * 1024; // K    
        private int fileIndex = 0;
    }
}
