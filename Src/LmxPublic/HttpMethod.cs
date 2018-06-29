using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LmxPublic
{
    public class HttpMethod
    {
        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string postDataStr)
        {
            #region  第一版
            byte[] postData = Encoding.UTF8.GetBytes(postDataStr);//编码，尤其是汉字，事先要看下抓取网页的编码方式   
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET
            byte[] responseData = webClient.UploadData(Url, "POST", postData);//得到返回字符流             
            string srcString = Encoding.UTF8.GetString(responseData);//解码 
            return srcString;
            #endregion
            #region 第二版
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //byte[] data = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(postDataStr);
            ////request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //Stream myRequestStream = request.GetRequestStream();
            ////StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            //myRequestStream.Write(data, 0, data.Length);
            //myRequestStream.Close();
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("gb2312"));
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();
            //return retString;
            #endregion
        }

        public static string HttpPostJson(string Url, string postDataStr)
        {
            byte[] postData = Encoding.UTF8.GetBytes(postDataStr);//编码，尤其是汉字，事先要看下抓取网页的编码方式   
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");//采取POST方式必须加的header，如果改为GET
            byte[] responseData = webClient.UploadData(Url, "POST", postData);//得到返回字符流             
            string srcString = Encoding.UTF8.GetString(responseData);//解码 
            return srcString;
        }


        /// <summary>
        /// HttpPostList
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpPostList(string Url, NameValueCollection list)
        {
            WebClient client = new WebClient();
            byte[] bResult = client.UploadValues(Url, list);
            string strResult = System.Text.Encoding.Default.GetString(bResult);
            return strResult;
        }

        /// <summary>
        /// WebGet
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// WebGet
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static string HttpGetJson(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        /// <summary>
        /// 专用微信红包
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string HttpPostWxRedPack(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...  
            try
            {
                //CerPath证书路径
                //@"F:\Jeffrey9061\SVN\Project\CompanyProject\西安培华微信用户实时更新客户端\西安培华微信用户实时更新客户端\" + WxPayConfig.SSLCERT_PATH;
                string certPath = ConfigurationManager.AppSettings["password"].ToString();//要绝对路径，另外，我已经导入电脑

                //证书密码
                string password = ConfigurationManager.AppSettings["certPath"].ToString(); ;
                X509Certificate2 cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(certPath, password, X509KeyStorageFlags.MachineKeySet);

                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.ContentLength = data.Length;
                request.ClientCertificates.Add(cert);
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }
    }
}
