using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 常量字符串定义
    /// </summary>
    public class ConstStringDefine
    {
        public const string LoginInfoError = "未登录或是登录失败";
        public const string WebMethodParamError = "web接口调用的参数不合法";
        public const string WebMethodModelError = "web接口调用的参数模型数据不合法";
        public const string NameExist = "新加或修改的名字已经存在，操作失败";
    }

    /// <summary>
    /// 设备状态
    /// </summary>
    public enum DevStatusDefine
    {
        EStatusOk = 1,              // 正常
        EStatusLinghtingAlarm = 2,  // 灯具告警（已经有故障）
        EStatusWarning =3,          // 预警（可能会发生故障）
        EStatusConnError = 4,       // 通信异常

    }
}
