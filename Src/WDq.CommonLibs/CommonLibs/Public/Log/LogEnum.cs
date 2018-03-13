

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace PiPublic.Log
{
    /// <summary>
    /// 警告级别有很多是默认对应的
    /// 比如：
    /// 错误默认对应：高级别
    /// 调试默认对应：正常级别
    /// 信息默认对应：低级别
    /// 
    /// 警告的级别需要自己指定
    /// </summary>
    public enum LogGrade
    {
        [Description("低级别")]
        Low,
        [Description("正常级别")]
        Normal,                              
        [Description("高级别")]
        High,
    };


    /// <summary>
    /// 日志类型，初步定义为错误，警告，调试和信息
    /// </summary>
    public enum LogType
    {
        [Description("错误")]
        LogTypeError,
        [Description("警告")]
        LogTypeWarring,
        [Description("调试")]
        LogTypeDebug,
        [Description("信息")]
        LogTypeInfo,
    };
}
