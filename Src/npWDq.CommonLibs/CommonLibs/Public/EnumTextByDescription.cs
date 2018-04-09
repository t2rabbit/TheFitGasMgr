using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace PiPublic
{
	public class EnumTextByDescription
	{

        /// <summary>
        /// 获取枚举的文字
        /// </summary>
        /// <param name="e"></param>
        ///   enum TimeOfDay
        /// enum TimeOfDay
        /// {
        ///    [Description("上午")]
        ///    Moning,
        ///    [Description("下午")]
        ///    Afternoon,
        ///    [Description("晚上")]
        ///    Evening,
        /// };
        /// <returns></returns>
		public static string GetEnumDesc(Enum e)
		{
			FieldInfo EnumInfo = e.GetType().GetField(e.ToString());
			DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.
				GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (EnumAttributes.Length > 0)
			{
				return EnumAttributes[0].Description;
			}
			return e.ToString();
		}

	}
}
