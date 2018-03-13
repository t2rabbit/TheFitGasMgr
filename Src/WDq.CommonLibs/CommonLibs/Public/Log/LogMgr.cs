///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：LogMgr.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：
///     日志管理模块，日志操作的入口
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015/03/23
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiPublic.Log
{
    /// <summary>
    /// 日志管理模块
    /// 先初始化一次，使用类似观察者模式的实现，如果不知道怎么监听日志，直接用文件和TRACE处理接口
    ///      InitFileTraceLog
    /// 日志会输出到初始化的处理器模块，同时添加到内存队列，这样UI可以通过GetTopLog 获取日志数据
    /// 
    /// 
    /// 
    /// </summary>
    public class LogMgr
    {


        //
        // 日志内存对象，以队列形式存储，定义队列的深度
        //

        private static readonly object lockLstMsg = new object();
        private static List<LogInfo> lstMsg = new List<LogInfo>();
        private static int ST_MAX_COUNT = 1000;

        // 日志处理对象的集合              
        static List<ILog> lstLogHandler = new List<ILog>();

        /// <summary>
        /// 通过外部定义的日志处理类接口挂接到日志处理，比如：
        /// 可以存储到数据库，
        /// 可以发送到串口
        /// 可以发送到TCP端口
        /// 可以显示到LED显示器，只要实现ILOG即可挂接
        /// </summary>
        /// <param name="lstLogs"></param>
        public static void Init(List<ILog> lstLogs)
        {
            lock (lstLogHandler)
            {
                lstLogHandler.Clear();
                lstLogHandler.AddRange(lstLogs);
            }
        }
        
        /// <summary>
        /// 使用默认的文件和TRACE挂接管理日志
        /// </summary>
        public static void InitFileTraceLog()
        {
            lock (lstLogHandler)
            {
                if (lstLogHandler.Count ==0)
                {
                    lstLogHandler.Clear();
                    FileLog fileLog = new FileLog();
                    TraceLog traceLog = new TraceLog();
                    lstLogHandler.Add(fileLog);
                    lstLogHandler.Add(traceLog);
                }
            }
        }

        public static void AppUdpLog(ILog aUdpLogObj)
        {
            lstLogHandler.Add(aUdpLogObj);
        }


        /// <summary>
        /// 日志插入到内存日志队列，所有的日志都先插入到内存中
        /// </summary>
        /// <param name="logInfo"></param>
        private static void InsertLogToMem(LogInfo logInfo)
        {
            lock (lockLstMsg)
            {
                lstMsg.Add(logInfo);
                if (lstMsg.Count > ST_MAX_COUNT)
                {
                    lstMsg.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// 获取日志队列中最新的一条数据，获取马上弹出
        /// </summary>
        /// <param name="logInfo"></param>
        /// <returns></returns>
        public static bool GetTopLog(out LogInfo logInfo)
        {
            logInfo = null;
            lock (lockLstMsg)
            {
                if (lstMsg.Count == 0)
                {
                    return false;
                }

                logInfo  = lstMsg[0];
                lstMsg.RemoveAt(0);
            }
            return true;
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strSubSys">子系统，默认为Sys</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logGrade">警告级别</param>
        /// <param name="errorMessage">日志内容</param>
        public static void WriteLog(string strSubSys, 
                                    LogType logType, 
                                    LogGrade logGrade, 
                                    string errorMessage,
                                    string ext1="",
                                    string ext2="")
        {
            InsertLogToMem(new LogInfo()
                    {
                        LogDt = DateTime.Now,
                        LogGrade = logGrade,
                        LogType = logType,
                        LogMsg = errorMessage,
                        LogSubSys = strSubSys,
                        LogExt1 = ext1,
                        LogExt2 = ext2
                    });

            foreach (ILog logHandler in lstLogHandler)
            {
                logHandler.WriteLog(strSubSys, logType, logGrade, errorMessage, ext1, ext2);
            }
        }

        /// <summary>
        /// 添加信息类的日志，子系统默认为“sys”
        /// </summary>
        /// <param name="errorText">日志内容</param>
        public static void WriteInfoDefSys(string errorText, string ext1="", string ext2="")
        {
            InsertLogToMem(new LogInfo()
            {
                LogDt = DateTime.Now,
                LogGrade = LogGrade.Low,
                LogType = LogType.LogTypeInfo,
                LogMsg = errorText,
                LogSubSys = LogInfo.DEFAULT_SYS,
                LogExt1 = ext1,
                LogExt2 = ext2
            });

            foreach (ILog logHandler in lstLogHandler)
            {
                logHandler.WriteLog(LogInfo.DEFAULT_SYS, LogType.LogTypeInfo, LogGrade.Low, errorText, ext1, ext2);
            }
        }

        /// <summary>
        /// 添加错误类的日志，子系统默认为“sys”
        /// </summary>
        /// <param name="errorText">日志的内容</param>
        public static void WriteErrorDefSys(string errorText, string ext1="", string ext2="")
        {
            InsertLogToMem(new LogInfo()
            {
                LogDt = DateTime.Now,
                LogGrade = LogGrade.High,
                LogType = LogType.LogTypeError,
                LogMsg = errorText,
                LogSubSys = LogInfo.DEFAULT_SYS,
                LogExt1 = ext1,
                LogExt2 = ext2
            });

            foreach (ILog logHandler in lstLogHandler)
            {
                logHandler.WriteLog(LogInfo.DEFAULT_SYS, LogType.LogTypeError, LogGrade.High, errorText, ext1, ext2);
            }
        }

        /// <summary>
        /// 添加调试类型的日志，子系统默认为“sys”
        /// </summary>
        /// <param name="errorText">日志内容</param>
        public static void WriteDebugDefSys(string errorText, string strExt1="", string strExt2="")
        {
            InsertLogToMem(new LogInfo()
            {
                LogDt = DateTime.Now,
                LogGrade = LogGrade.Normal,
                LogType = LogType.LogTypeDebug,
                LogMsg = errorText,
                LogSubSys = LogInfo.DEFAULT_SYS,
                LogExt1 = strExt1,
                LogExt2 = strExt2
            });
            foreach (ILog logHandler in lstLogHandler)
            {
                logHandler.WriteLog("SYS", LogType.LogTypeDebug, LogGrade.Normal, errorText, strExt1, strExt2);
            }
        }

        /// <summary>
        /// 添加警告类型的日志，子系统默认为“sys”
        /// 由于警告的级别需要自定义，因此没有写默认参数需要指定
        /// </summary>                            
        /// <param name="logWarringGrade">警告级别</param>
        /// <param name="errorText">日志内容</param>
        public static void WriteWarringDefSys(LogGrade logWarringGrade, string errorText, string ext1="", string ext2="")
        {
            InsertLogToMem(new LogInfo()
            {
                LogDt = DateTime.Now,
                LogGrade = LogGrade.Low,
                LogType = LogType.LogTypeInfo,
                LogMsg = errorText,
                LogSubSys = LogInfo.DEFAULT_SYS,
                LogExt1 = ext1,
                LogExt2 = ext2
            });

            foreach (ILog logHandler in lstLogHandler)
            {
                logHandler.WriteLog("SYS", LogType.LogTypeWarring, logWarringGrade, errorText, ext1, ext2);
            }
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        public static void  Release()
        {
            lstLogHandler.Clear();
        }

    }
}
