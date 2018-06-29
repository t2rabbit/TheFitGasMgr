using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.ChartModel
{
    public class chart
    {
        /// <summary>
        /// 主标题
        /// </summary>
        public string caption { get; set; }
        /// <summary>
        ///  副标题
        /// </summary>
        public string subCaption { get; set; }
        /// <summary>
        /// 横向坐标轴(x轴)名称
        /// </summary>
        public string xAxisname { get; set; }
        /// <summary>
        /// 纵向坐标轴(y轴)名称
        /// </summary>
        public string yAxisName { get; set; }
        /// <summary>
        /// 数字前缀
        /// </summary>
        public string numberPrefix { get; set; }
        /// <summary>
        /// 数字后缀
        /// </summary>
        public string numberSuffix { get; set; }
        /// <summary>
        /// 小数点
        /// </summary>
        public string decimals { get; set; }
        /// <summary>
        /// 每一片的边框填充透明度
        /// </summary>
        public string plotFillAlpha { get; set; }
        /// <summary>
        /// 自定义图表元素颜色(为多个,如过过少会重复),例如："#0075c2,#1aaf5d"
        /// </summary>
        public string paletteColors { get; set; }
        /// <summary>
        /// 基本字颜色
        /// </summary>
        public string baseFontColor { get; set; }
        /// <summary>
        /// 基本字体
        /// </summary>
        public string baseFont { get; set; }
        /// <summary>
        /// 基本字号
        /// </summary>
        public string baseFontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string captionFontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subcaptionFontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subcaptionFontBold { get; set; }
        /// <summary>
        /// 显示边框
        /// </summary>
        public string showBorder { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        public string bgColor { get; set; }
        /// <summary>
        /// 背景透明度
        /// </summary>
        public string bgAlpha { get; set; }
        /// <summary>
        /// 是否显示阴影
        /// </summary>
        public string showShadow { get; set; }
        public string canvasBgColor { get; set; }
        /// <summary>
        ///  画布背景色，6位16进制颜色值
        /// </summary>
        public string canvasBorderAlpha { get; set; }
        /// <summary>
        /// 垂直分区线透明度，[0-100]
        /// </summary>
        public string divlineAlpha { get; set; }
        /// <summary>
        /// 水平分区线颜色，6位16进制颜色值
        /// </summary>
        public string divlineColor { get; set; }
        /// <summary>
        /// 水平分区线厚度，[1-5]
        /// </summary>
        public string divlineThickness { get; set; }
        /// <summary>
        /// 水平分区线是否为虚线
        /// </summary>
        public string divLineIsDashed { get; set; }
        /// <summary>
        /// 水平分区线每个虚线长度
        /// </summary>
        public string divLineDashLen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string divLineGapLen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string usePlotGradientColor { get; set; }
        /// <summary>
        /// 每一片的边框
        /// </summary>
        public string showplotborder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string valueFontColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string placeValuesInside { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showHoverEffect { get; set; }
        /// <summary>
        /// 把值旋转
        /// </summary>
        public string rotateValues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string showXAxisLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xAxisLineThickness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xAxisLineColor { get; set; }
        /// <summary>
        /// 是否在横向网格带交替的颜色，默认为0(False)
        /// </summary>
        public string showAlternateHGridColor { get; set; }
        /// <summary>
        /// 图例透明度
        /// </summary>
        public string legendBgAlpha { get; set; }
        /// <summary>
        /// 图例边框透明度
        /// </summary>
        public string legendBorderAlpha { get; set; }
        /// <summary>
        /// 图例阴影
        /// </summary>
        public string legendShadow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string legendItemFontSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string legendItemFontColor { get; set; }
        /// <summary>
        /// 是否显示Label
        /// </summary>
        public string showLabels { get; set; }
        /// <summary>
        /// Label占图形的占比，一般15就够了。
        /// </summary>
        public string maxLabelWidthPercent { get; set; }
    }
}
