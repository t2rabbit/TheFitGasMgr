///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: NodeInfoModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-24 7:45:07
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
    /// 节点模型
    /// </summary>
    public class NodeInfoModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DevId { get; set; }
        public string strFuncCode { get; set; }
        public string strAddr { get; set; }
        public string strCatalog1 { get; set; }
        public string strCatalog2 { get; set; }
        
    }
}
