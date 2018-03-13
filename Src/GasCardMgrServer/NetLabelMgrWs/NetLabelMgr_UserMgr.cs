using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Web.Services;
using PiPublic;
using NetLabelBll;
using NetLabelEfDbDll;

namespace NetLabelMgrWs
{
    /// <summary>
    /// 用户管理模块
    /// </summary>
    public partial class NetLabelMgr
    {
        //JsonResutlModel 
        [WebMethod]
        public string AddCenterSysUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddCenterUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            SysUserInfoModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SysUserInfoModel))
                as SysUserInfoModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }

            if (SysUserMgr.CheckAnyUserNameInDb(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户名已经存在");
            }
            mod.OrgInLevelIndex = (int)DbConstDefine.OrgLevelDefine.CentralOrgLevelIndex;
            bool result = SysUserMgr.AddCentralOrgNewUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }


        //JsonResutlModel 
        [WebMethod]
        public string AddOrgUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddOrgUser", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }
            SysUserInfoModel mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SysUserInfoModel))
                as SysUserInfoModel;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstStringDefine.WebMethodModelError + ";(AddOrgUser)");
            }

            bool bRet = SysUserMgr.AddOrgNewUser(ref mod, out strError);           
            return ServerHlper.MakeInfoByStatus(bRet, strError);
        }

    }


    /// <summary>
    /// 无用的占位符
    /// </summary>
    public class NetLabelMgr_UserMgr
    {

    }

    

}