using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PiPublic;

namespace GlareLedSysWs
{
    /// <summary>
    /// 设备控制
    /// </summary>
    public partial class GLSysMgr
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