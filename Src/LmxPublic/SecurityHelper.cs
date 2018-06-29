using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LmxPublic
{
    /// <summary>
    /// 安全帮助类
    /// </summary>
    public class SecurityHelper
    {
        /// <summary>
        /// MD5加密(Encoding.UTF8)
        /// </summary>
        /// <param name="text">原文.</param>
        /// <returns>返回加密结果的小写形式(Encoding.UTF8)</returns>
        /// <remarks></remarks>
        public static string MD5(string text)
        {
            return MD5(text, Encoding.UTF8);//Encoding.Default
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="text">原文.</param>
        /// <param name="encode">字符编码格式.</param>
        /// <returns>返回加密结果的小写形式</returns>
        /// <remarks></remarks>
        public static string MD5(string text, Encoding encode)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(encode.GetBytes(text))).Replace("-", "").ToLower();
        }

       

    }
}
