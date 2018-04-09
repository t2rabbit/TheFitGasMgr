///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：ILog.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：日志接口
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015-03-23
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
    /// 日志接口
    /// </summary>
    public interface ILog
    {      
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strSubSys">子系统，默认为Sys</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logGrade">警告级别</param>
        /// <param name="errorMessage">日志内容</param>
        void WriteLog(string strSubSys, LogType logType, LogGrade logGrade, string errorMessage, 
            string ext1, string ext2);


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="objParam">初始化参数</param>
        void Init(object objParam);
    }
}
