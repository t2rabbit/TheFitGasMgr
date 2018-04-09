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
