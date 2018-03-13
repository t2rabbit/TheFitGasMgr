using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using PiPublic;

namespace NetLabelMgrWs
{
    public class ServerHlper
    {
        /// <summary>
        /// 构造请求头，获取请求头的基础数据
        /// </summary>
        /// <param name="callbackparam"></param>
        /// <param name="paramjson"></param>
//         public static void MakeHead(out string callbackparam,
//             out string paramjson,
//             out string paramUUID,
//             out string paramDt)
//         {
//             HttpContext.Current.Response.ContentType = ConstDefine.ParamHead;
//             callbackparam = HttpContext.Current.Request.Params[ConstDefine.JsonCallBakcParam].ToString();
//             paramjson = HttpContext.Current.Request.Params[ConstDefine.ParamName].ToString();
//             paramUUID = HttpContext.Current.Request.Params[ConstDefine.ParamUUID].ToString();
//             paramDt = HttpContext.Current.Request.Params[ConstDefine.ParamDt].ToString();
//         }



        /// <summary>
        /// 构造请求头，获取请求头的基础数据
        /// </summary>
        /// <param name="callbackparam"></param>
        /// <param name="paramjson"></param>
        public static void MakeHead(out string callbackparam,
            out string paramjson)
        {
            
            string paramUUID;
            string paramDt;
            string strInfo;
            HttpContext.Current.Response.ContentType = ConstDefine.ParamHead;
            callbackparam = HttpContext.Current.Request.Params[ConstDefine.JsonCallBakcParam].ToString();
            strInfo = HttpContext.Current.Request.Params[ConstDefine.ParamName].ToString();
            paramUUID = HttpContext.Current.Request.Params[ConstDefine.ParamUUID].ToString();
            paramDt = HttpContext.Current.Request.Params[ConstDefine.ParamDt].ToString();


            DateTime dt;
            DateTime.TryParse(paramDt, out dt);
            RequestModelString reqmod = new RequestModelString()
            {
                Info = strInfo,
                reqDt = dt,
                UUID = paramUUID
            };
            paramjson = JsonStrObjConver.Obj2JsonStr(reqmod, typeof(RequestModelString));
        }
        public static void MakeResponse(string callback, string result)
        {
            HttpContext.Current.Response.Write(string.Format("{0}({1})", callback, result));
            HttpContext.Current.Response.End();
        }




        /// <summary>
        /// 根据参数构造返回的json参数
        /// </summary>
        /// <param name="staus">状态成功与否</param>
        /// <param name="strError">失败的描述,如果成功则为空或是success</param>
        /// <returns></returns>
        public static string MakeInfoByStatus(bool staus, string strError)
        {

            JsonResutlModel<string> result = new JsonResutlModel<string>()
            {
                Info = strError,
                Status = staus,
                ErrorDesc = strError,
                StatusInt = (staus==true?1:0)
            };

            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<string>));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFun">函数名</param>
        /// <param name="strJsonParam"></param>
        /// <param name="strErrorString"></param>
        /// <returns></returns>
        public static RequestModelString GetRequestModelString(string strFun, string strJsonParam,  
            out string strErrorString)
        {
            strErrorString = "";
            RequestModelString reqinfo = JsonStrObjConver.JsonStr2Obj(strJsonParam, typeof(RequestModelString))
                   as RequestModelString;
            if (reqinfo == null)
            {
                strErrorString = MakeInfoByStatus(false,
                    string.Format("{0}_{1}",ConstStringDefine.WebMethodParamError ,strFun));
                return null;
            }

            if (!CheckLoginStatus(reqinfo.UUID))
            {
                strErrorString = MakeInfoByStatus(false,                    
                    string.Format("{0}_{1}",ConstStringDefine.LoginInfoError ,strFun));
            }

            return reqinfo;
        }


        static bool CheckLoginStatus(string strUUID)
        {

            try
            {
#if DEBUG_WEBSERVICES
                return true;
#else
                return SessionInfoMgr.Get().CheckSessionByUuid(strUUID);
#endif
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

    }
}