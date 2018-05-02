using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlareLedSysBll;
using GlareSysEfDbAndModels.Models;
using PiPublic;

namespace GlareLedSysWs
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
            
            string strTockId;            
            string paramDt;
            string strInfo;
            HttpContext.Current.Response.ContentType = ConstDefineWs.ParamHead;
            callbackparam = HttpContext.Current.Request.Params[ConstDefineWs.JsonCallBakcParam].ToString();
            strInfo = HttpContext.Current.Request.Params[ConstDefineWs.ParamName].ToString();
            strTockId = HttpContext.Current.Request.Params[ConstDefineWs.ParamTockId].ToString();            
            paramDt = HttpContext.Current.Request.Params[ConstDefineWs.ParamDt].ToString();


            DateTime dt;
            DateTime.TryParse(paramDt, out dt);
            RequestModelString reqmod = new RequestModelString()
            {
                Info = strInfo,
                reqDt = dt,
                TockId = strTockId
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

            JsonResutlModelString result = new JsonResutlModelString()
            {
                Info = strError,
                Status = staus,
                ErrorDesc = strError,
                StatusInt = (staus==true?1:0)
            };

            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
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
                    string.Format("{0}_{1}", ConstDefineWs.WebMethodParamError ,strFun));
                return null;
            }

            if (!LoginUserEnableMgr.Get().IsLoginIdEnable(reqinfo.TockId))
            {
                strErrorString = MakeInfoByStatus(false,                    
                    string.Format("{0}_{1}", ConstDefineWs.LoginInfoError, strFun));
            }

            return reqinfo;
        }        
    }
}