using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic
{
    public class ResultHelper
    {        
        /// <summary>
        /// 结果Bool
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 结果Int
        /// </summary>
        public int Ret { get; set; }
        /// <summary>
        /// 结果详情
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 结果提示
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 结果数据
        /// </summary>
        public object Obj { get; set; }
    }
}
