using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlareSysEfDbAndModels.Models
{
    /// <summary>
    /// 请求的数据包，数据内容使用字符串描述
    /// </summary>
    public class RequestModelString
    {
        public string TockId { get; set; }
        public DateTime reqDt { get; set; }
        public string Info { get; set; }
    }
}
