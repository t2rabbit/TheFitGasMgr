using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using PiPublic;
using NetLabelEfDbDll;
using NetLabelBll;
using System.Web.Services;

namespace NetLabelMgrWs
{
    public partial class NetLabelMgr
    {

        /// <summary>
        /// 添加工程
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns></returns>
        [WebMethod]
        public string AddNewProjectGroup(string strParams)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddCenterUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            ProjectModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectModel))
                as ProjectModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "工程信息不对");
            }
            return "";
        }


        /// <summary>
        /// 添加工程
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns></returns>
        [WebMethod]
        public string AddNewProject(string strParams)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddCenterUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            ProjectModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectModel))
                as ProjectModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "工程信息不对");
            }
            return "";
        }


        /// <summary>
        /// 添加工程分区
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns></returns>
        [WebMethod]
        public string AddProjectRegion(string strParams)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddCenterUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            ProjectModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectModel))
                as ProjectModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "工程信息不对");
            }
            return "";
        }
    }
}