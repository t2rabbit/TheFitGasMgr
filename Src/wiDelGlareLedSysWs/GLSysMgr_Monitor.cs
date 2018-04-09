using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GlareSysEfDbAndModels.Models;
using PiPublic;

namespace GlSysMgrWs
{
    /// <summary>
    /// 界面数据查询，实时监视的数据
    /// </summary>
    public partial class GLSysMgr 
    {
        /// <summary>
        /// 超超级管理员进入后，看到所有的工程
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetAllProject(string strJsonParam)
        {
            return "";

            //string strError;
            //RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetAllProject", strJsonParam, out strError);
            //if (reqinfo == null)
            //{
            //    return strError;
            //}

            //List<MonitorInfoOfAProject> lsts = MontitorInfoBll.GetAllProjectMonitorInfo();
            //JsonResutlModel<List<MonitorInfoOfAProject>> result = new JsonResutlModel<List<MonitorInfoOfAProject>>()
            //{
            //    ErrorDesc = "",
            //    Info = lsts,
            //    Status = true,
            //    StatusInt = 1,
            //};
            //return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<MonitorInfoOfAProject>>));
        }

        /// <summary>
        /// 超超级管理员进入后，看到所有的工程
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public void GetAllProjectHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = GetAllProject(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }



        ///// <summary>
        ///// 获取单个分公司的所有的工程
        ///// </summary>
        ///// <param name="strJsonParam"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetProjectByOrgId(string strJsonParam)
        //{
        //    string strError;
        //    RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
        //    if (reqinfo == null)
        //    {
        //        return strError;
        //    }

        //    List<GatewayModel> lsts = GatewayBll.GetAllGatewayList();
        //    JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
        //    {
        //        ErrorDesc = "",
        //        Info = lsts,
        //        Status = true,
        //        StatusInt = 1,
        //    };
        //    return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        //}

        ///// <summary>
        ///// 获取某个工程组下所有的工程
        ///// </summary>
        ///// <param name="strJsonParam"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetProjectByGroupId(string strJsonParam)
        //{
        //    string strError;
        //    RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
        //    if (reqinfo == null)
        //    {
        //        return strError;
        //    }

        //    List<GatewayModel> lsts = GatewayBll.GetAllGatewayList();
        //    JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
        //    {
        //        ErrorDesc = "",
        //        Info = lsts,
        //        Status = true,
        //        StatusInt = 1,
        //    };
        //    return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        //}


        ///// <summary>
        ///// 获取工程下所有的设备
        ///// </summary>
        ///// <param name="strJsonParam"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetDevStatusByProject(string strJsonParam)
        //{
        //    string strError;
        //    RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
        //    if (reqinfo == null)
        //    {
        //        return strError;
        //    }

        //    List<GatewayModel> lsts = GatewayBll.GetAllGatewayList();
        //    JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
        //    {
        //        ErrorDesc = "",
        //        Info = lsts,
        //        Status = true,
        //        StatusInt = 1,
        //    };
        //    return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        //}


        ///// <summary>
        ///// 获取工程下所有的区域
        ///// </summary>
        ///// <param name="strJsonParam"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetRegionByProject(string strJsonParam)
        //{
        //    string strError;
        //    RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
        //    if (reqinfo == null)
        //    {
        //        return strError;
        //    }

        //    List<GatewayModel> lsts = GatewayBll.GetAllGatewayList();
        //    JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
        //    {
        //        ErrorDesc = "",
        //        Info = lsts,
        //        Status = true,
        //        StatusInt = 1,
        //    };
        //    return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        //}
    }
}