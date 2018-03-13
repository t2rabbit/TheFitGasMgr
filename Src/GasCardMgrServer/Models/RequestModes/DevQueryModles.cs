///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: DevQueryModles.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-24 20:43:25
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.RequestModes
{
    /// <summary>
    /// 占位符
    /// </summary>
    public class DevQueryModles
    {
    }

    /// <summary>
    /// 根据某个ID查询数据
    /// </summary>
    public class QueryDevByIdModel
    {
        public int GatewayId { get; set; }
        public int OrgId { get; set; }
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public int RangeId { get; set; }
    }
}
