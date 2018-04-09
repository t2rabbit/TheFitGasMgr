using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GlareLedSysBll;
using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;
using PiPublic;

namespace GlSysMgrWs
{
    /// <summary>
    /// NetLabelMgr 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
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

            SuperLoginedUserModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SuperLoginedUserModel))
                as SuperLoginedUserModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            SuperLoginedUserModel userInfo = LoginBll.SuperLogin(mod.UserInfo.Name, mod.UserInfo.Password);
            if (userInfo != null)
            {                
                JsonResutlModel<SuperLoginedUserModel> result = new JsonResutlModel<SuperLoginedUserModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<SuperLoginedUserModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }

        [WebMethod]
        public void SuperLoginHtml()
        {
            //string jsonCallBackFunName;
            //string strJsonParam;
            //ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            //string strRet = SuperLogin(strJsonParam);
            //ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }

        /// <summary>
        /// 组织登录，组织如：七天连锁酒店；标联云；中国石油广州分公司
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string OrgLogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            OrgLoginedUserModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgLoginedUserModel))
                as OrgLoginedUserModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            OrgLoginedUserModel userInfo = LoginBll.OrgLogin(mod.UserInfo.Name, mod.UserInfo.Password);
            if (userInfo != null)
            {
                JsonResutlModel<OrgLoginedUserModel> result = new JsonResutlModel<OrgLoginedUserModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<OrgLoginedUserModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }
        
        [WebMethod]
        public void OrgLoginHtml()
        {
            //string jsonCallBackFunName;
            //string strJsonParam;
            //ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            //string strRet = OrgLogin(strJsonParam);
            //ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
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

            ProjectLoginedUserModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectLoginedUserModel))
                as ProjectLoginedUserModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            ProjectLoginedUserModel userInfo = LoginBll.ProjectLogin(mod.UserInfo.Name, mod.UserInfo.Password);
            if (userInfo != null)
            {                
                JsonResutlModel<ProjectLoginedUserModel> result = new JsonResutlModel<ProjectLoginedUserModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<ProjectLoginedUserModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
        }

        /// <summary>
        /// 工程登录
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public void ProjectloginHtml()
        {
            //ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
            //string jsonCallBackFunName;
            //string strJsonParam;
            //ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            //string strRet = Projectlogin(strJsonParam);
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
        public void LogoutHtml()
        {
            //string jsonCallBackFunName;
            //string strJsonParam;
            //ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            //string strRet = Logout(strJsonParam);
            //ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
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


        [WebMethod]
        public void UpdateLoginTimeByUuidHtml()
        {
            return;
            //string jsonCallBackFunName;
            //string strJsonParam;
            //ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            //string strRet = UploadLoginTimeByUuid(strJsonParam);
            //ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }
    }
}
