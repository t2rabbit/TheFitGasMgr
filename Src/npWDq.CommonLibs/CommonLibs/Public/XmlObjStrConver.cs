///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：XmlObjStrConver.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：
///     XML序列化反序列化辅助类
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015/5/7 9:30:46
///
///修改记录 
/// 作者   时间    					版本      	修改描述
/// Wudq   2015/5/7 9:30:46		v1.00		创建
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PiPublic
{
    public class XmlObjStrConver
    {
        /// <summary>  
        /// 反序列化XML字符串为指定类型  
        /// </summary>  
        public static object Deserialize(string Xml, Type ThisType)
        {            
            try
            {

                XmlSerializer mySerializer = new XmlSerializer(ThisType);
                StreamReader mem2 = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(Xml)),
                    System.Text.Encoding.UTF8);
                return mySerializer.Deserialize(mem2);
            }
            catch (Exception innerException)
            {
                System.Diagnostics.Trace.WriteLine(innerException.Message);
                return null;
            }
        }

        public static object DeserializeByFile(string fileName, Type t)
        {   
            try
            {
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader m_streamReader = new StreamReader(fs);

                //
                // StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
                //   
                //使用StreamReader类来读取文件
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容

                string strLine = m_streamReader.ReadLine();
                while (strLine != null)
                {
                    sb.Append(strLine);
                    strLine = m_streamReader.ReadLine();
                }
                m_streamReader.Close();


                return Deserialize(sb.ToString(), t);
            }
            catch (System.Exception ex)
            {
                return null;
            }
            
        }



        /// <summary>  
        /// 序列化object对象为XML字符串  
        /// </summary>  
        public static string Serialize(object ObjectToSerialize)
        {
            string result = null;
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new UTF8Encoding(false));
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xmlTextWriter, ObjectToSerialize, ns);
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                    UTF8Encoding uTF8Encoding = new UTF8Encoding(false, true);
                    result = uTF8Encoding.GetString(memoryStream.ToArray());
                }
            }
            catch (Exception innerException)
            {
                System.Diagnostics.Trace.WriteLine(innerException.Message);
                return "";
            }
            return result;
        }  
    }
}
