using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GasCardBll;
using Models;
using PiPublic.Log;
using PiPublic;

namespace NetLabelMgrWs
{
    /// <summary>
    /// NetLabelMgr 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。    
    [System.Web.Script.Services.ScriptService]
    public partial class NetLabelMgr : System.Web.Services.WebService
    {

        /// <summary>
        /// 一个入库的登录，可以判断是那个级别的用户
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        [WebMethod]
        public string LoginOnePoint(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败，参数不对");
            }

            SuperLoginModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SuperLoginModel))
                as SuperLoginModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败,模型参数不对");
            }

            SysUserInfoModel userInfo = SysUserMgr.SuperLogin(mod.Name, mod.Password);
            if (userInfo == null)
            {
                userInfo = SysUserMgr.OrgMgrLogin(mod.Name, mod.Password);
            }
            if (userInfo == null)
            {
                userInfo = SysUserMgr.ProjectGroupMgrLogin(mod.Name, mod.Password);
            }
            if (userInfo == null)
            {
                userInfo = SysUserMgr.ProjectMgrLogin(mod.Name, mod.Password);
            }

            if (userInfo != null)
            {
                SessionInfoMgr.Get().AddSession(userInfo);
                JsonResutlModel<SysUserInfoModel> result = new JsonResutlModel<SysUserInfoModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<SysUserInfoModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, "登录失败，用户名不对或密码不正确");
        }

        [WebMethod]
        public void LoginOnePointHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = LoginOnePoint(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }



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
                return ServerHlper.MakeInfoByStatus(false, "登录失败，参数不对");
            }

            SuperLoginModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SuperLoginModel))
                as SuperLoginModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败,模型参数不对");
            }

            SysUserInfoModel userInfo = SysUserMgr.SuperLogin(mod.Name, mod.Password);
            if (userInfo != null)
            {
                SessionInfoMgr.Get().AddSession(userInfo);
                JsonResutlModel<SysUserInfoModel> result = new JsonResutlModel<SysUserInfoModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<SysUserInfoModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, "登录失败，用户名不对或密码不正确");
        }

        [WebMethod]
        public void SuperLoginHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = SuperLogin(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
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
                return ServerHlper.MakeInfoByStatus(false, "登录失败，参数不对");
            }


            OrgMgrLoginModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgMgrLoginModel))
                as OrgMgrLoginModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败,模型参数不对");
            }

            SysUserInfoModel userInfo = SysUserMgr.OrgMgrLogin(mod.Name, mod.Password);
            if (userInfo != null)
            {
                SessionInfoMgr.Get().AddSession(userInfo);
                JsonResutlModel<SysUserInfoModel> result = new JsonResutlModel<SysUserInfoModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<SysUserInfoModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, "登录失败，用户名不对或密码不正确");
        }

        
        /// <summary>
        /// 组织登录，组织如：七天连锁酒店；标联云；中国石油广州分公司
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public void OrgLoginHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = OrgLogin(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }

        /// <summary>
        /// 工程登录，需要输入组织，和工程名
        /// </summary>
        /// <param name="strOrgName">组织名</param>
        /// <returns></returns>
        [WebMethod]
        public string Projectlogin(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败，参数不对");
            }


            ProjectMgrLoginModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectMgrLoginModel))
                as ProjectMgrLoginModel;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "登录失败,模型参数不对");
            }

            SysUserInfoModel userInfo = SysUserMgr.ProjectMgrLogin(mod.Name, mod.Password);
            if (userInfo != null)
            {
                SessionInfoMgr.Get().AddSession(userInfo);
                JsonResutlModel<SysUserInfoModel> result = new JsonResutlModel<SysUserInfoModel>()
                {
                    ErrorDesc = "success",
                    Info = userInfo,
                    Status = true,
                    StatusInt = 1
                };

                return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<SysUserInfoModel>));
            }
            return ServerHlper.MakeInfoByStatus(false, "登录失败，用户名不对或密码不正确");
        }

        /// <summary>
        /// 工程登录
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public void ProjectloginHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = Projectlogin(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }


        [WebMethod]
        public string Logout(string strJsonParam)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("Logout", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            SessionInfoMgr.Get().DeleteSession(reqinfo.UUID);
            return ServerHlper.MakeInfoByStatus(true, "success");
        }

        [WebMethod]
        public void LogoutHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = Logout(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }



        [WebMethod]
        public string UploadLoginTimeByUuid(string strJsonParam)
        {
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
               as RequestModelString;
            if (reqinfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "刷新登录信息，参数不对");
            }

            bool bRsult = SessionInfoMgr.Get().UpdateSessionLogdt(reqinfo.UUID);
            return ServerHlper.MakeInfoByStatus(bRsult, bRsult.ToString());
        }


        [WebMethod]
        public void UploadLoginTimeByUuidHtml()
        {
            string jsonCallBackFunName;
            string strJsonParam;
            ServerHlper.MakeHead(out jsonCallBackFunName, out strJsonParam);
            string strRet = UploadLoginTimeByUuid(strJsonParam);
            ServerHlper.MakeResponse(jsonCallBackFunName, strRet);
        }
    }
}
