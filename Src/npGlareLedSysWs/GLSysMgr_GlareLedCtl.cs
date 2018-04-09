using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PiPublic;
using GlareLedSysEfDb;

namespace GlSysMgrWs
{
    /// <summary>
    /// 设备控制
    /// </summary>
    public partial class GLSysMgr : System.Web.Services.WebService
    {
        /// <summary>
        /// 发送命令到单个设备
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string SetCmdToDb(string strParams)
        {
            return "";
        }
    }
}