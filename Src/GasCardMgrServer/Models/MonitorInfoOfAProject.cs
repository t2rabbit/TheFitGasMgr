///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: MonitorInfoOfAProject.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-23 21:56:35
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
    /// 一个工程的信息
    /// </summary>
    public class MonitorInfoOfAProject
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int ProjectGroupId { get; set; }
        public string ProjectGroupName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int DevCount { get; set; }
        public int ShowStatusInProject { get; set; }
        public string GpsInfo { get; set; } //  在地图的那个点显示
        public string Address { get; set; } 
        public string PngPath{get;set;}

        public ModelForMapList MapData { get; set; }

    }
}
