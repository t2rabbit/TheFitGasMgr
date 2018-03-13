///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: SessionConstDefine.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-20 7:43:23
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// Session常量的定义
    /// </summary>
    public class SessionConstDefine
    {
        public const string LOGIN_USER_NAME = "LoginName";
        public const string LOGIN_STATUS = "LoginStatus";

        /// <summary>
        /// 登录号，分配一个UUID，UUID保存时间为1小时，格式是：一个合理算法的值-时间-校验码
        /// </summary>
        public const string LOGIN_UUID = "LoginUuid";
    }
}
