using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiPublic;
using System.Web.Services;
using GlareSysEfDbAndModels.Models;
using GlareSysEfDbAndModels;
using GlareLedSysBll;

namespace GlareLedSysWs
{
    public partial class GLSysMgr 
    {        
        [WebMethod]
        public string AddNewOrg(string strParams)
        {

            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddNewOrg", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            OrgInfo mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(OrgInfo))
                as OrgInfo;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = OrgBll.AddAOrg(ref mod, out strError);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = "success",
                Info = mod.ID,
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));
        }

        // todo : org select update, del...


        [WebMethod]
        public string AddGroup(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddGroup", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            GroupInfo mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(GroupInfo))
                as GroupInfo;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = GroupBll.AddAGroup(ref mod, out strError);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = "success",
                Info = mod.ID,
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));            
        }
        // todo : group  select update, del...

        [WebMethod]
        public string AddProject(string strParams)
        {
            string strError;
            RequestModelString reqinfo = ServerHlper.GetRequestModelString("AddGroup", strParams, out strError);
            if (reqinfo == null)
            {
                return strError;
            }

            ProjectInfo mod = JsonStrObjConver.JsonStr2Obj(reqinfo.Info, typeof(ProjectInfo))
                as ProjectInfo;

            if (mod == null)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.HttpParamError);
            }

            bool bResult = ProjectBll.AddAProject(ref mod, out strError);
            if (!bResult)
            {
                return ServerHlper.MakeInfoByStatus(false, ConstDefineWs.LoginNameOrPassword);
            }

            // 成功返回成功标志及新增加的ID
            JsonResutlModel<int> result = new JsonResutlModel<int>()
            {
                ErrorDesc = "success",
                Info = mod.Id,
                Status = true,
                StatusInt = 1
            };
            return JsonStrObjConver.Obj2JsonStr(result, typeof(JsonResutlModel<int>));
        }
        // todo : project select update, del...
    }
}