using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using GlareSysEfDbAndModels.Models;
using PiPublic;
using GlareLedSysBll;
using GlareSysEfDbAndModels;

namespace GlareLedSysWs
{
    /// <summary>
    /// 设备管理模块,包括网关，只是对（网关，设备）的增删改查
    /// </summary>
    public partial class GLSysMgr
    {

        [WebMethod]
        public string GetAllCards(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            List<GasCardWithCommInfo> lsts = CardWithCommDevBll.GetAllDevList();
            if (lsts==null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = JsonStrObjConver.Obj2JsonStr(lsts, typeof(List<GasCardWithCommInfo>)),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }


        [WebMethod]
        public string GetCardsListByOrgId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                                                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            int id = 0;
            int.TryParse(reqinfo.Info, out id);
            if (id <= 0)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            List<GasCardWithCommInfo> lstComms = CardWithCommDevBll.GetDevListByOrgId(id);
            if (lstComms == null || lstComms.Count == 0)
            {
                return ServerHlper.MakeInfoByStatus(false, "");
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = JsonStrObjConver.Obj2JsonStr(lstComms, typeof(List<GasCardWithCommInfo>)),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }

        [WebMethod]
        public string GetDevListByProjectId(string strJsonParam)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                        strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }
            int id = 0;
            int.TryParse(reqinfo.Info, out id);
            if (id <= 0)
            {

                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);

            }

            List<GasCardWithCommInfo> lstComms = CardWithCommDevBll.GetDevListByProjectId(id);
            if (lstComms == null || lstComms.Count == 0)
            {
                return ServerHlper.MakeInfoByStatus(false, "");
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = JsonStrObjConver.Obj2JsonStr(lstComms, typeof(List<GasCardWithCommInfo>)),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }

        [WebMethod]
        public string GetDevListByGroupId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            int id = 0;
            int.TryParse(reqinfo.Info, out id);
            if (id <= 0)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            List<GasCardWithCommInfo> lstComms = CardWithCommDevBll.GetDevListByGroupId(id);
            if (lstComms == null || lstComms.Count == 0)
            {
                return ServerHlper.MakeInfoByStatus(false, "");
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = JsonStrObjConver.Obj2JsonStr(lstComms, typeof(List<GasCardWithCommInfo>)),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }

        [WebMethod]
        public string GetCardListByCondAndSetOrder(string strJsonParam)
        {
            // todo
            return "";
        }
        [WebMethod]
        public string AddCard(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strJsonParam, out strError);

            if (reqinfo == null)
            {
                return strError;
            }

            GasCardWithCommInfo mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(GasCardWithCommInfo))
                as GasCardWithCommInfo;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = CardWithCommDevBll.AddDev(ref mod, out strError);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = mod.Id.ToString(),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }


        [WebMethod]
        public string UpdateADev(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            GasCardWithCommInfo mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(GasCardWithCommInfo))
                as GasCardWithCommInfo;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = CardWithCommDevBll.UpdateDev(mod, out strError);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = mod.Id.ToString(),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }

        [WebMethod]
        public string DelADevById(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name, 
                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            int id = 0;
            int.TryParse(reqinfo.Info, out id);

            if (id <= 0)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = CardWithCommDevBll.DelDev(id);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModelString result = new JsonResutlModelString()
            {
                ErrorDesc = "success",
                Info = id.ToString(),
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModelString));
        }

    }
}