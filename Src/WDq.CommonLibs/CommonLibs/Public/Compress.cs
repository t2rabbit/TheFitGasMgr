//======================================================================
//
//        Copyright (C) 2007-2008 三月软件工作室    
//        All rights reserved
//
//        filename :Class
//        description :
//
//        created by任天胜 at  06/07/2011 18:41:28
//        qq:625246906
//        url:http://www.marchsoft.cn/ 
//        
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.IO;
using PiPublic.Log;

namespace PiPublic
{
    public class Compress
    {
        #region winrar压缩
        #endregion


        #region 7z压缩
        /// 压缩文件
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileName">被压缩文件的文件名</param>
        /// <param name="zipFileName">压缩文件名</param>
        /// <returns>返回值为true:成功  false:失败</returns>
        public static bool WinrarZipFile(ArrayList fileName, string zipFileName)
        {
            try
            {
                string zipPara;  //压缩文件的命令行参数
                for (int i = 0; i < fileName.Count; i++)    //获取压缩文件并将其添加到命令行参数中
                {
                    zipPara =  " a -r \"" + zipFileName + "\" \"" + fileName[i].ToString().Trim() + "\"";
                    if (!SeventZPrcess(zipPara))
                        return false;
                }
                //启动进程并调用Winrar

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// 压缩文件
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="fileName">被压缩文件的文件名</param>
        /// <param name="zipFileName">压缩文件名</param>
        /// <returns>返回值为true:成功  false:失败</returns>
        public static bool WinrarZipFileMore(ArrayList fileName, string zipFileName)
        {
            try
            {                
                for (int i = 0; i <= (fileName.Count - 1) / 10; i++)    //获取压缩文件并将其添加到命令行参数中
                {
                    string zipPara ;  //压缩文件的命令行参数
                    for (int j = i * 10; j < i * 10 + 10; j++)
                    {
                        if (j < fileName.Count)
                        {
                            
                            zipPara =" a \"" + zipFileName + "\"    "+ " \"" + fileName[j].ToString().Trim() + "\"";
                            if (!SeventZPrcess(zipPara))
                                return false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return true; ;
            }
            catch
            {
                return false;
            }
        }

        /// 解压缩文件(解压后不带目录)
        /// <summary>
        /// 解压缩文件（解压后不带目录）
        /// </summary>
        /// <param name="zipFileName">压缩文件名</param>
        /// <param name="unzipPath">解压缩后文件的路径</param>
        /// <returns>返回值true:成功  false:失败</returns>
        public static bool WinrarUnZipFile(string zipFileName, string unZipPath)
        {
            try
            {

                string arguments = " e -y \"" + zipFileName + "\" -o\"" + unZipPath + "\"";

                return SeventZPrcess(arguments);
            }
            catch
            {
                return false;
            }
        }

        /// 解压缩文件(解压后带目录)
        /// <summary>
        /// 解压缩文件（解压后带目录）
        /// </summary>
        /// <param name="zipFileName">压缩文件名</param>
        /// <param name="unzipPath">解压缩后文件的路径</param>
        /// <returns>返回值true:成功  false:失败</returns>
        public static bool WinrarUnZipPath(string zipFileName, string unZipPath)
        {
            try
            {
                string arguments = " x -y \"" + zipFileName + "\" -o\"" + unZipPath + "\"";
                return  SeventZPrcess(arguments);                
            }
            catch(Exception ex)
            {
                LogMgr.WriteErrorDefSys("unzip path ex:" + ex.Message);
                return false;
            }
        }
      
        public static bool SeventZPrcess(string arguments)
        {
            Process winrarPro = new System.Diagnostics.Process();
            winrarPro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏压缩窗口
            winrarPro.StartInfo.FileName =System.Windows.Forms. Application.StartupPath + "\\7z.exe";
            winrarPro.StartInfo.CreateNoWindow = false;
            winrarPro.StartInfo.Arguments = arguments;
            winrarPro.Start();
            winrarPro.WaitForExit();
            int iExitCode = 0;
            if (winrarPro.HasExited)
            {
                iExitCode = winrarPro.ExitCode;
                winrarPro.Close();
                if (iExitCode != 0 && iExitCode != 1)
                {
                    return false;
                }
            }
            return true;

        }
        #endregion
    }
}
