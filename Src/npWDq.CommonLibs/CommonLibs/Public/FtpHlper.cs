/*
*
* Filename: FtpHlper
* Description: 
*   FTP 上传下载助手
* Version: 1.0
* Created: 2015/1/12 8:51:20
* Compiler: Visual Studio 2010
*
* Author: Wudanquan
* Company: Pilot
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using PiPublic.Log;
using System.Threading;

namespace PiPublic
{
    /// <summary>
    /// FTP 上传下载助手
    /// </summary>
    public class FtpHlper
    {
        /// <summary>
        /// FTP 文件上传
        /// </summary>
        /// <param name="ftpServerIP">FTP服务器路径(必须如下格式ftp://11.22.11.22 :21)</param>
        /// <param name="ftpUserID">用户名ID</param>
        /// <param name="ftpPassword">用户密码</param>
        /// <param name="filePath">相对路径</param>
        /// <param name="filename">上传保存的文件名</param>
        /// <param name="strUploadLocalFileName">上传文件的全路经</param>
        /// <returns></returns>
        public static bool UploadFtp(string ftpServerIP, 
            string filePath, 
            string ftpUserID, 
            string ftpPassword, 
            string filename,
            string strUploadLocalFileName)
        {
            FileInfo fileInf = new FileInfo(strUploadLocalFileName);
            string uri = ftpServerIP + "/" + filePath+ "/" + filename;
            FtpWebRequest reqFTP;            
            Stream strm = null;
            FileStream fs = null;
            bool bSuccess = false;
            reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(uri)); 
            try
            {               
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                // By default KeepAlive is true, where the control connection is not closed 
                // after a command is executed. 
                reqFTP.KeepAlive = false;
                // Specify the command to be executed. 
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                // Specify the data transfer type. 
                reqFTP.UseBinary = true;
                //reqFTP.UsePassive = false;

                // Notify the server about the size of the uploaded file 
                reqFTP.ContentLength = fileInf.Length;
                reqFTP.ReadWriteTimeout = 1000;
                //reqFTP.Timeout = 1000;
                

                // The buffer size is set to 2kb 
                int buffLength = 4000;
                byte[] buff = new byte[buffLength];
                int contentLen;

                // Opens a file stream (System.IO.FileStream) to read the file to be uploaded 
                fs = fileInf.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                // Stream to which the file to be upload is written 
                strm = reqFTP.GetRequestStream();
                strm.WriteTimeout = 1000;                
                // Read from the file stream 2kb at a time 
                contentLen = fs.Read(buff, 0, buffLength);
                int itotal = contentLen;
                // Till Stream content ends 
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                    if (contentLen >= 0)
                    {
                        itotal += contentLen;
                    }
                    else
                    {
                        LogMgr.WriteDebugDefSys("读取数据小于0。。。。。。");
                        return false;
                    }
                    //strm.Flush();
                }
//                LogMgr.WriteInfoDefSys("strm.Flush()......");
                strm.Flush();

//                 string strMsg = string.Format("第一次读取的长度为：{0}, 累计的文件长度为:{1}",
//                     reqFTP.ContentLength,
//                     itotal);
//                 LogMgr.WriteInfoDefSys(strMsg);
                bSuccess = true;
            }
            catch (Exception ex)
            {
                reqFTP.Abort();
                LogMgr.WriteErrorDefSys("Upload Ftp Ex + " + ex.Message + ex.StackTrace);
                bSuccess = false;
            }
            finally
            {
                if (strm != null)
                {
                    strm.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
            }


            return bSuccess;
        }

        /// <summary>
        /// ftp方式下载 
        /// </summary>
        public static bool DownloadFtp(string ftpServerIP, 
            string ftpUserID, 
            string ftpPassword,
            string filePath,
            string strFileName,
            string strSaveToFile)
        {
            FtpWebResponse response = null;
            Stream ftpStream = null;
            FileStream outputStream = null;
            FtpWebRequest reqFTP=null;
            bool bSuccess = false;

            string uri = ftpServerIP + "/" + filePath +"/"+ strFileName;
            try
            {
                if (Directory.Exists(strSaveToFile))
                {
                    Directory.Delete(strSaveToFile);
                }
                outputStream = new FileStream(strSaveToFile, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.KeepAlive = false; 
                //reqFTP.UsePassive = false;

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                response = (FtpWebResponse)reqFTP.GetResponse();
                ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                bSuccess = true;
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("DownloadFtp Ex:" + ex.Message);
                bSuccess = false;
            }
            finally
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }
                if (outputStream != null)
                {
                    outputStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
            }
            return bSuccess;
        }

        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)
        /// </summary>
        /// <returns></returns>
        public static string[] GetFilesDetailList( string strFtpServer,
            string strPath,
            string strUserName,
            string strPassword)
        {
            string strUri = strFtpServer + "\\" + strPath;
            string[] downloadFiles;
            StringBuilder result = null;
            FtpWebRequest reqFTP = null;
            WebResponse response = null; 
            StreamReader reader = null;
                
            try
            {
                result = new StringBuilder();
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(strUri));
                reqFTP.Credentials = new NetworkCredential(strUserName, strPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                //ftp.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                downloadFiles =  result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("get filelist Ex:" + ex.Message);
                downloadFiles = null;                
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
            }

            return downloadFiles;
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <returns></returns>
        public static string[] GetFileList(
            string strFtpServer,
            string strUserName,
            string strPassword,
            string strPath,           
            string mask)
        {
            string[] downloadFiles = null;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP=null;
            WebResponse response = null;
            StreamReader reader = null;


            string strUri = strFtpServer + "\\" + strPath;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(strUri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(strUserName, strPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                //reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {

                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                downloadFiles = result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                LogMgr.WriteErrorDefSys("GetFileList Ex:" + ex.Message);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
            }

            return downloadFiles;
        }
    
        
        /// <summary>
        /// 测试是否可以连接
        /// </summary>
        /// <param name="strFtpServer"></param>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static bool CheckConnected(string strFtpServer,
            string strUserName,
            string strPassword,
            string strPath)
        {                     
            FtpWebRequest reqFTP = null;
            WebResponse response = null;
            string strUri = strFtpServer;
            bool isError = false;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(strUri));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(strUserName, strPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                response = reqFTP.GetResponse();
                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                LogMgr.WriteErrorDefSys("GetFileList Ex:" + ex.Message);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (reqFTP != null)
                {
                    reqFTP.Abort();
                }
            }

            return (!isError);
        }
       
    
    }
}
