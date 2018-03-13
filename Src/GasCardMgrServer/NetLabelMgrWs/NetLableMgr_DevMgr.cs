using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Models.RequestModes;
using System.Web.Services;
using PiPublic;
using NetLabelBll;

namespace NetLabelMgrWs
{
    /// <summary>
    /// 设备管理模块,包括网关，只是对（网关，设备）的增删改查
    /// </summary>
    public partial class NetLabelMgr
    {
        /// <summary>
        /// 获取网关列表，参数具体内容为空
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetGatewayList(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            List<GatewayModel> lsts = GatewayBll.GetAllGatewayList();
            JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        }

        [WebMethod]
        public string GetGatewayInfoByCondAndSetOrder(string strJsonParam)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayInfoByCondAndSetOrder",
                strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            SqlQueryExtinoModel extInfo = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SqlQueryExtinoModel))
                        as SqlQueryExtinoModel;
            if (extInfo== null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (GetGatewayList)");
            }

            List<GatewayModel> lsts = GatewayBll.GetGatewayByCondtion(extInfo.ConditionInfo, extInfo.OrderInfo);
            JsonResutlModel<List<GatewayModel>> result = new JsonResutlModel<List<GatewayModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
        }

        [WebMethod]
        public string AddGateway(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddGateway", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            GatewayModel obj = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(GatewayModel))
                        as GatewayModel;
            if (obj == null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (AddGateway)");
            }

            bool bRet = GatewayBll.AddGatewayInfo(ref obj, out strError);
            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = strError,
                Info = obj.ID,
                Status = bRet,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));
        }

        [WebMethod]
        public string UpdateGateway(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string DeleteGatewayById(string strJsonParam)
        {
            // todo
            return "";
        }

        [WebMethod]
        public string GetDevListByGwId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetGatewayList", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }
            
            QueryDevByIdModel extInfo = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(QueryDevByIdModel))
                        as QueryDevByIdModel;
            if (extInfo== null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (GetDevListByGwId)");
            }

            List<DevInfoModel> lsts = DevBll.GetDevByGroupId(extInfo.GatewayId);
            JsonResutlModel<List<DevInfoModel>> result = new JsonResutlModel<List<DevInfoModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));
       
        }

        [WebMethod]
        public string GetDevListByProjectGroupId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetDevListByProjectGroupId", 
            strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }
            
            QueryDevByIdModel extInfo = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(QueryDevByIdModel))
                        as QueryDevByIdModel;
            if (extInfo== null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (GetDevListByProjectGroupId)");
            }

            List<DevInfoModel> lsts = DevBll.GetDevByGroupId(extInfo.GroupId);
            JsonResutlModel<List<DevInfoModel>> result = new JsonResutlModel<List<DevInfoModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));       
        }

        [WebMethod]
        public string GetDevListByProjectId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetDevListByProjectId",
            strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            QueryDevByIdModel extInfo = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(QueryDevByIdModel))
                        as QueryDevByIdModel;
            if (extInfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (GetDevListByProjectId)");
            }

            List<DevInfoModel> lsts = DevBll.GetDevByProjectId(extInfo.ProjectId);
            JsonResutlModel<List<DevInfoModel>> result = new JsonResutlModel<List<DevInfoModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));       
        
        }

        [WebMethod]
        public string GetDevListByRangeId(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("GetDevListByProjectId",
            strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            QueryDevByIdModel extInfo = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(QueryDevByIdModel))
                        as QueryDevByIdModel;
            if (extInfo == null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (GetDevListByProjectId)");
            }

            List<DevInfoModel> lsts = DevBll.GetDevByRangeId(extInfo.RangeId);
            JsonResutlModel<List<DevInfoModel>> result = new JsonResutlModel<List<DevInfoModel>>()
            {
                ErrorDesc = "",
                Info = lsts,
                Status = true,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<List<GatewayModel>>));       
        
        }

        [WebMethod]
        public string AddDev(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddDev", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            DevInfoModel obj = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(DevInfoModel))
                        as DevInfoModel;
            if (obj == null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (AddDev)");
            }

            bool bRet = DevBll.AddDev(ref obj, out strError);

            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = strError,
                Info = obj.ID,
                Status = bRet,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));      
        }

        [WebMethod]
        public string DelADevById(string strJsonParam)
        {
            // todo
            return "";
        }

        [WebMethod]
        public string UpdateADev(string strJsonParam)
        {
            // todo
            return "";
        }

        [WebMethod]
        public string AddNode(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddNode", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            NodeInfoModel obj = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(NodeInfoModel))
                        as NodeInfoModel;
            if (obj == null)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (AddNode)");
            }

            bool bRet = NodeBll.AddNode(ref obj, out strError);

            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = strError,
                Info = obj.ID,
                Status = bRet,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));             
        }


        [WebMethod]
        public string DelANodeById(string strJsonParam)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddNode", strJsonParam, out strError);
            if (reqinfo == null)
            {
                return strError;
            }


            int iId = 0;
            int.TryParse(reqinfo.Info, out iId);
            if (iId == 0)
            {
                return ServerHlper.MakeInfoByStatus(false,
                    ConstStringDefine.WebMethodModelError + "; (DelANodeById)");
            }

            bool bRet = NodeBll.DelNodeById(iId);

            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = strError,
                Info = 0,
                Status = bRet,
                StatusInt = 1,
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));   
        }


    }
}