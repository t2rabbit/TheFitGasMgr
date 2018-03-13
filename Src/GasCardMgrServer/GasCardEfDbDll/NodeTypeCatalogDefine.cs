///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: NodeTypeCatalogDefine.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-25 0:41:47
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLabelEfDbDll
{
    /// <summary>
    /// 节点类型定义
    /// </summary>
    public class NodeTypeCatalogDefine
    {
        public const int AddrTemperature = 0;       // 温度
        public const int AddrHumidity = 1;          // 湿度
        public const int AddrVoltage= 2;            // 电压
        public const int AddrCurrent= 3;            // 电流
    }
}
