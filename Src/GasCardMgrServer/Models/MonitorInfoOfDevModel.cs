///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ReadedDevSensorModel.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-22 7:18:52
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
    /// 一个设备传感器的值,一个设备会有4路开关,这里的设备直接是控制器，如果有4路，那么就有4个设备
    /// </summary>
    public class MonitorInfoOfDevModel
    {
        public string Name { get; set; }
        public string AddressGps { get; set; }
        public string strAddres { get; set; }
        public string PosInfo { get; set; }
        public string PngPath { get; set; }

        public int GatewayId { get; set; }
        public int DevId { get; set; }
        public int DevLineIndex { get; set; }
        public int DevAddr { get; set; }    // 设备地址

        public int DevStatus { get; set; }  // 控制器状态


        public int Status { get; set; }         // 状态，告警可以存放在这个字段
        public int Temperature { get; set; }    // 温度
        public int Humidity { get; set; }       // 湿度
        public int Voltage { get; set; }        // 电压
        public int Current { get; set; }        // 电流
    }

}
