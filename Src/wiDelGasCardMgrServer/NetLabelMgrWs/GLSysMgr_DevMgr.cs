using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PiPublic;

namespace NetLabelMgrWs
{
    /// <summary>
    /// 设备管理模块,包括网关，只是对（网关，设备）的增删改查
    /// </summary>
    public partial class GlareDevMgr: System.Web.Services.WebService
    {
        /// <summary>
        /// 获取网关列表，参数具体内容为空
        /// </summary>
        /// <param name="strJsonParam"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetGatewayList(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string GetGatewayInfoByCondAndSetOrder(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string AddGateway(string strJsonParam)
        {
            return "";
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
            return "";
        }

        [WebMethod]
        public string GetDevListByProjectGroupId(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string GetDevListByProjectId(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string GetDevListByRangeId(string strJsonParam)
        {
            return "";
        }

        [WebMethod]
        public string AddDev(string strJsonParam)
        {
            return "";
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
            return "";
        }


        [WebMethod]
        public string DelANodeById(string strJsonParam)
        {
            return "";
        }


    }
}