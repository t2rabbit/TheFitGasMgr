using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlareSysEfDbAndModels.Models
{
    /// <summary>
    /// JSON结果对象
    /// </summary>
    public class JsonResutlModelT<T>
    {
        // 成功与否
        public bool Status { get; set; }
        // 成功为1，其他都为错误代码
        public int StatusInt { get; set; }
        // 错误描述，如果成功就写成功
        public string ErrorDesc { get; set; }
        // 返回的扩展信息
        public T Info { get; set; }
    }
}
