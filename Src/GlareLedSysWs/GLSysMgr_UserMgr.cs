using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PiPublic;
using GlareSysEfDbAndModels;
using GlareLedSysBll;
using GlareSysEfDbAndModels.Models;

namespace GlareLedSysWs
{
    /// <summary>
    /// 用户管理模块, 完成super， group，project，dev用户的增删改查
    /// </summary>
    public partial class GLSysMgr
    {
        //JsonResutlModel 
        [WebMethod]
        public string AddSuperUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name, 
                strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            SuperUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(SuperUser))
                as SuperUser;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }

            if (SuperUserBll.IsUserNameExist(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户名已经存在");
            }
            bool result = SuperUserBll.AddUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }

        //JsonResutlModel 
        [WebMethod]
        public string AddOrgUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name, 
                strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            if (!LoginBll.CheckLoginId(reqinfo.TockId))
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginInfoError);
            }

            OrgUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgUser)) as OrgUser;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户参数不对");
            }
          
            if (OrgUserBll.IsUserNameExist(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, "需要添加的用户名已经存在");
            }
            bool result = OrgUserBll.AddUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }

        //JsonResutlModel 
        [WebMethod]
        public string AddGroupUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            if (!LoginBll.CheckLoginId(reqinfo.TockId))
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginInfoError);
            }

            GroupUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(GroupUser)) as GroupUser;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            if (GroupUserBll.IsNameExist(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineBll.NameExist);
            }
            bool result = GroupUserBll.AddUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }

        //JsonResutlModel 
        [WebMethod]
        public string AddProjectUser(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString(System.Reflection.MethodBase.GetCurrentMethod().Name,
                strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            if (!LoginBll.CheckLoginId(reqinfo.TockId))
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginInfoError);
            }

            ProjectUser mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectUser)) as ProjectUser;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            if (ProjectUserBll.IsUserNameExist(mod.Name))
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineBll.NameExist);
            }
            bool result = ProjectUserBll.AddUser(ref mod, out strError);
            return ServerHlper.MakeInfoByStatus(result, strError);
        }
        
        // todo 未完成 ;修改，删除未完成
    }


    /// <summary>
    /// 无用的占位符
    /// </summary>
    public class GLSysMgr_UserMgr
    {

    }

    

}