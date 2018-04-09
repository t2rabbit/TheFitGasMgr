using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PiPublic;
using GlareSysEfDbAndModels;
using GlareLedSysBll;
using GlareSysEfDbAndModels.Models;

namespace GlSysMgrWs
{
    /// <summary>
    /// 用户管理模块, 完成super， group，project，dev用户的增删改查
    /// </summary>
    public partial class GLSysMgr: System.Web.Services.WebService
    {
        //JsonResutlModel 
        [WebMethod]
        public string AddSuperUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddCenterUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            OrgUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgUser))
                as OrgUser;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }

            if (OrgUserMgr.IsProjectUserNameExist(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户名已经存在");
            }
            bool result = OrgUserMgr.AddUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }

        //JsonResutlModel 
        [WebMethod]
        public string AddOrgUser(string strParams)
        {
            // todo 未完成 
            return "";

            //string strError;
            //RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddSuper", strParams, out strError);
            //if (reqinfo == null)
            //{
            //    return strError;
            //}

            //OrgUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgUser))
            //    as OrgUser;

            //if (mod == null)
            //{
            //    return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            //}

            //if (OrgUserMgr.IsProjectUserNameExist(mod.Name))
            //{
            //    return ServerHlper.MakeInfoByStatus(false, "需要添加的用户名已经存在");
            //}
            //bool result = OrgUserMgr.AddUser(ref mod, out strError);
            //return ServerHlper.MakeInfoByStatus(result, strError);
        }      

        // todo 未完成
    }


    /// <summary>
    /// 无用的占位符
    /// </summary>
    public class GLSysMgr_UserMgr
    {

    }

    

}