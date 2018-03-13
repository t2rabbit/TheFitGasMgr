///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: SqlQueryExtinoModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-23 6:17:40
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
    /// select * from aaa where name ='sdfdf' and id >100 order by name desc
    /// ConditionInfo="name ='sdfdf' and id >100 "
    /// OrderInfo= "name desc"
    /// 
    /// 其他会自动拼接字符串
    /// </summary>
    public class SqlQueryExtinoModel
    {
        public string ConditionInfo { get; set; }
        public string OrderInfo { get; set; }
    }
}
