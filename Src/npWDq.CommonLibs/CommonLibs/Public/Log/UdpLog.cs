///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product：PiEMS
///
///文件名称：UdpLog.cs
///开发环境：Microsoft Visual Studio 2010
///描    述：
///     通过UDP发送数据
///
///当前版本：V1.0
///作    者：Wudq
///完成日期：2015/5/13 18:58:35
///
///修改记录 
/// 作者   时间    					版本      	修改描述
/// Wudq   2015/5/13 18:58:35		v1.00		创建
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace PiPublic.Log
{
    /// <summary>
    /// UDP日志类
    /// </summary>
    public class UdpLog : ILog
    {
        private List<SocketServerInfo> lstServerInfo;
        private UdpClient udp;
        
        public void Init(object objParam)
        {
            List<SocketServerInfo> lstServerInfoTmp = objParam as List<SocketServerInfo>;
            if (lstServerInfoTmp != null)
            {
                this.lstServerInfo = lstServerInfoTmp;
            }

            udp = new UdpClient();
        }


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strSubSys">子系统，默认为Sys</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logGrade">警告级别</param>
        /// <param name="errorMessage">日志内容</param>
        public void WriteLog(string strSubSys, LogType logType, LogGrade logGrade, string errorMessage,
            string ext1, string ext2)
        {
            try
            {
                LogInfo log = new LogInfo()
                    {
                        LogDt = DateTime.Now,
                        LogGrade = logGrade,
                        LogType = logType,
                        LogMsg = errorMessage,
                        LogSubSys = strSubSys,
                        LogExt1 = ext1,
                        LogExt2 = ext2
                    };
                string strLog = JsonStrObjConver.Obj2JsonStr(log, typeof(LogInfo));

                byte[] bufLog = System.Text.Encoding.UTF8.GetBytes(strLog);
                foreach (SocketServerInfo aServer in lstServerInfo)
                {
                    udp.Send(bufLog, bufLog.Count(), aServer.Ip, aServer.Port);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return;
            }

        }



        
        
    }

    /// <summary>
    /// UDP接收数据的端口号
    /// </summary>
    public class SocketServerInfo
    {
        public string Ip { get; set; }
        public int Port { get; set; }
    }


}
