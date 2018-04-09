///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：LogInfo.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：日志类
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015/3/23 16:40:46
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
    /// 定义日志的解构
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// 日志记录时间
        /// </summary>
        public DateTime LogDt {get;set;}  

        /// <summary>
        /// 日志的子系统，默认为"SYS"
        /// </summary>
        public string LogSubSys { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType LogType{ get; set; }

        /// <summary>
        /// 日志的级别
        /// </summary>
        public LogGrade LogGrade { get; set; }

        public string LogExt1 { get; set; }
        public string LogExt2 { get; set; }


        /// <summary>
        /// 日志的内容
        /// </summary>
        public string LogMsg { get; set; }


        public static string DEFAULT_SYS = "sys";

    }
}
