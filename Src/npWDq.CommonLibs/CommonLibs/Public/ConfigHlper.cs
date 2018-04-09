using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Linq;

namespace PiPublic
{
	public class ConfigHlper
	{
		/// <summary>
		/// 根据键值获取配置文件
		/// </summary>
		/// <param name="key">键值</param>
		/// <returns></returns>
		public static string GetConfig(string key)
		{
			string val = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                val = ConfigurationManager.AppSettings[key];
            }
			return val;
		}

		/// <summary>
		/// 获取所有配置文件
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetConfig()
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			foreach (string key in ConfigurationManager.AppSettings.AllKeys)
				dict.Add(key, ConfigurationManager.AppSettings[key]);
			return dict;
		}

        /// <summary>
        /// 根据键值获取配置文件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetConfig(string key, string defaultValue)
        {
            string val = defaultValue;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                val = ConfigurationManager.AppSettings[key];
            if (val == null)
                val = defaultValue;
            return val;
        }

        /// <summary>
        /// 根据键值获取配置文件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetConfig_Int(string key, int iDevVal, out int  iVal)
        {
            iVal = iDevVal;
            string strVal = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                strVal = ConfigurationManager.AppSettings[key];
                if (int.TryParse(strVal, out iVal) )
                {
                    return true;
                }
                {
                    iVal = iDevVal;
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据键值获取配置文件
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetConfig_Int(string key, int iDevVal)
        {
            int iVal = iDevVal;
            string strVal = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                strVal = ConfigurationManager.AppSettings[key];
                if (!int.TryParse(strVal, out iVal))
                {
                    iVal = iDevVal;
                }
            }
            return iVal;
        }

		/// <summary>
		/// 写配置文件,如果节点不存在则自动创建
		/// </summary>
		/// <param name="key">键值</param>
		/// <param name="value">值</param>
		/// <returns></returns>
		public static bool SetConfig(string key, string value)
		{
			try
			{
				Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (!conf.AppSettings.Settings.AllKeys.Contains(key))
                {
                    conf.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    conf.AppSettings.Settings[key].Value = value;
                }
				
                conf.Save();


                //
                // 马上生效
                //
                ConfigurationManager.RefreshSection("appSettings");

				return true;
			}
			catch { return false; }
		}

		/// <summary>
		/// 写配置文件(用键值创建),如果节点不存在则自动创建
		/// </summary>
		/// <param name="dict">键值集合</param>
		/// <returns></returns>
		public static bool SetConfig(Dictionary<string, string> dict)
		{
			try
			{
				if (dict == null || dict.Count == 0)
					return false;
				Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				foreach (string key in dict.Keys)
				{
					if (!conf.AppSettings.Settings.AllKeys.Contains(key))
						conf.AppSettings.Settings.Add(key, dict[key]);
					else
						conf.AppSettings.Settings[key].Value = dict[key];
				}
				conf.Save();
                
                //
                // 马上生效
                //
                ConfigurationManager.RefreshSection("appSettings");

				return true;
			}
			catch
            {
                return false; 
            }
		}

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        static public string GetConnectString(string strName)
        {
            foreach (ConnectionStringSettings aConnSec in ConfigurationManager.ConnectionStrings)
            {
                if (aConnSec.Name == strName)
                {
                    return aConnSec.ConnectionString;
                }
            }
            return "";
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strConn"></param>
        static public void SetConnectString(string strName, string strConn)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.ConnectionStrings.ConnectionStrings[strName] == null)
            {
                ConnectionStringSettings aconn = new ConnectionStringSettings(strName, strConn);
                conf.ConnectionStrings.ConnectionStrings.Add(aconn);
            }
            else
            {
                conf.ConnectionStrings.ConnectionStrings[strName].ConnectionString = strConn;
            }
            conf.Save();

            ConfigurationManager.RefreshSection("connectionStrings");
        }
	}
}
