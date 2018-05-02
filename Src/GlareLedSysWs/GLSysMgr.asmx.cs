using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GlareLedSysBll;
using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;
using PiPublic;

namespace GlareLedSysWs
{
    /// <summary>
    /// NetLabelMgr 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://webapi.glareled.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。    
    [System.Web.Script.Services.ScriptService]
    public partial class GLSysMgr : System.Web.Services.WebService
    {
        /// <summary>
        /// 超级管理员登录
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        [WebMethod]
        public string SuperLogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            LoginNamePassModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(LoginNamePassModel))
                as LoginNamePassModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            SuperLoginedUserModel userInfo = LoginBll.SuperLogin(mod.UserName, mod.Password);
            if (userInfo != null)
            {                
                JsonResutlModelString result = new JsonResutlModelString()
                {
                    ErrorDesc = "success",
                    Info = JsonStrObjConver.Obj2JsonStr(userInfo, typeof(SuperLoginedUserModel)),
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }
        
        [WebMethod]
        public string OrgLogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            LoginNamePassModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(LoginNamePassModel))
                as LoginNamePassModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            OrgLoginedUserModel userInfo = LoginBll.OrgLogin(mod.UserName, mod.Password);
            if (userInfo != null)
            {
                JsonResutlModelString result = new JsonResutlModelString()
                {
                    ErrorDesc = "success",
                    Info = JsonStrObjConver.Obj2JsonStr(userInfo, typeof(OrgLoginedUserModel)),
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }

        [WebMethod]
        public string GroupLogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            LoginNamePassModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(LoginNamePassModel))
                as LoginNamePassModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            GroupLoginedUserModel userInfo = LoginBll.GroupLogin(-1, mod.UserName, mod.Password);
            if (userInfo != null)
            {
                JsonResutlModelString result = new JsonResutlModelString()
                {
                    ErrorDesc = "success",
                    Info = JsonStrObjConver.Obj2JsonStr(userInfo, typeof(GroupLoginedUserModel)),
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }

        [WebMethod]
        public string Projectlogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            LoginNamePassModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(LoginNamePassModel))
                as LoginNamePassModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            ProjectLoginedUserModel userInfo = LoginBll.ProjectLogin(0, mod.UserName, mod.Password);
            if (userInfo != null)
            {                
                JsonResutlModelString result = new JsonResutlModelString()
                {
                    ErrorDesc = "success",
                    Info = JsonStrObjConver.Obj2JsonStr(userInfo, typeof(ProjectLoginedUserModel)),
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }

        
        [WebMethod]
        public string CommDevLogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            LoginNamePassModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(LoginNamePassModel))
                as LoginNamePassModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            CommDevLoginedUserModel userInfo = LoginBll.CommDevLogin(0, mod.UserName, mod.Password);
            if (userInfo != null)
            {
                JsonResutlModelString result = new JsonResutlModelString()
                {
                    ErrorDesc = "success",
                    Info = JsonStrObjConver.Obj2JsonStr(userInfo,typeof(CommDevLoginedUserModel)),
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }              

        [WebMethod]
        public string Logout(string strJsonParam)
        {

            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
                as RequestModelString;

            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }
            
            LoginBll.Logout(reqinfo.TockId);
            return ServerHlper.MakeInfoByStatus(true, "success");
        }
        

        [WebMethod]
        public string UpdateLoginTimeByUuid(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "刷新登录信息，参数不对");
            }

            bool bRsult = true;
            LoginBll.UpdateLoginStatus(reqinfo.TockId);
            return ServerHlper.MakeInfoByStatus(bRsult, bRsult.ToString());
        }        
    }
}
