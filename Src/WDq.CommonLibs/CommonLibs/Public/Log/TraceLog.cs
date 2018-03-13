///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：TraceLog.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：
///     TRACE日志操作类，实现日志接口
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
using System.Diagnostics;

namespace PiPublic.Log
{
    class TraceLog :ILog
    {

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strSubSys">子系统，默认为Sys</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logGrade">警告级别</param>
        /// <param name="errorMessage">日志内容</param>
        public void WriteLog(string strSubSys, LogType logType, LogGrade logGrade, 
            string errorMessage, string strExt1, string strExt2)
        {
            string strLog = string.Format("{0,-20};{1,-10};{2,-10};{3,-10};ex{4:-10};ex{5:-10};{6,-10}",
                            DateTime.Now,
                            strSubSys,
                            EnumTextByDescription.GetEnumDesc(logType),
                            EnumTextByDescription.GetEnumDesc(logGrade),
                            errorMessage,
                            strExt1,strExt2);
            System.Diagnostics.Trace.WriteLine(strLog);
            
        }

        /// <summary>
        /// 初始化，不需要执行任何动作
        /// </summary>
        /// <param name="obj"></param>
        public void Init(object obj)
        {
            return;
        }

    }
}
