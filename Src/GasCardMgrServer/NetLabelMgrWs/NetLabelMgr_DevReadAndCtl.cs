using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using PiPublic;
using NetLabelBll;

namespace NetLabelMgrWs
{
    /// <summary>
    /// 设备控制
    /// </summary>
    public partial class NetLabelMgr : System.Web.Services.WebService
    {
        /// <summary>
        /// 发送命令到单个设备
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string SetCmdToDb(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("SetCmdToDev", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            RealControlModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(RealControlModel))
                as RealControlModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }


            bool result = ControlBll.AddANewCtrlCmd(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }

        [WebMethod]
        public void SetCmdToDbHTML()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = SetCmdToDb(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }

        /// <summary>
        /// 获取命令处理的结果
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetCmdHandledResult(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("SetCmdToDev", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            RealControlModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(RealControlModel))
                as RealControlModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }


            bool result = ControlBll.AddANewCtrlCmd(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }
    }

    /// <summary>
    /// 仅仅是占位符
    /// </summary>
    class NetLabelMGr_DevReadAndCtl
    {

    }
}