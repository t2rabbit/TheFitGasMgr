///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ProjectBll.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-19 7:48:13
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using PiPublic.Log;


#if SQL_SERVER
using NetLabelEfDbDll.SqlServer;
#else
// mysql
// sqlite
#endif


namespace NetLabelBll
{
    /// <summary>
    /// 工程管理的业务逻辑类，增删改查
    /// </summary>
    public  class ProjectBll
    {
        /// <summary>
        /// 添加工程，成功返回true，ID会被修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddAProject(ref ProjectModel model, out string strErrInfo)
        {
            strErrInfo = "";
            if (IsProjectNameExist(model.Name))
            {
                strErrInfo = "名字已经存在";
                return false;
            }

            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                Project aNewProject = new Project()
                {
                    Address = model.Address,
                    Address_City = model.Addres_City,
                    Address_Distict = model.Address_Distict,
                    Address_GPS = model.Address_GPS,
                    Address_Province = model.Address_Province,
                    Email = model.Emaile,                    
                    LevelIndex = model.LevelIndex,
                    Manager = model.Manager,
                    MobileTel = model.MobileTel,
                    Name = model.Name,
                    OrganizationId = model.OrganizationId,
                    SecondManager = model.SecondManager,
                    Tel = model.Tel,
                };
                
                try
                {

                    ent.Project.AddObject(aNewProject);
                    ent.SaveChanges();
                    model.ID = aNewProject.ID;
                    return true;
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteErrorDefSys("Add Project Ex:" + ex.Message);
                }

                return false;
            }
        }

        /// <summary>
        /// 删除一个工程
        /// </summary>
        /// <param name="iProjectID"></param>
        /// <returns></returns>
        public static bool DeleteAProject(int iProjectID, out string strError)
        {
            strError = "";
            // todo 
            return true;
        }

        /// <summary>
        /// 更新一个工程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static  bool UpdateAProejct(ref ProjectModel model, out string strError)
        {
            strError = "";
            // todo 
            return true;
        }

        public static ProjectModel GetAProjectById(int iId)
        {
            // todo
            return null;
        }

        /// <summary>
        /// 返回工程，没有做分页
        /// </summary>
        /// <param name="strCond"></param>
        /// <param name="strOrderBy"></param>
        /// <returns></returns>
        public static List<ProjectModel> GetProjectsBySqlCondtion(string strCond, string strOrderBy, out string strError)
        {
            strError = "";
            // todo
            return null;
        }


        /// <summary>
        /// 检查是否有存在指定名字工程
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        private static bool IsProjectNameExist(string projectName)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                if ((from c in ent.Project where c.Name == projectName select c).FirstOrDefault() == null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查是否有存在指定名字工程,除当前的ID外的
        /// </summary>
        /// <param name="iEcxpId">不包括这ID</param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        private bool IsProjectNameExist(int iEcxpId, string projectName)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                if ((from c in ent.Project 
                     where c.Name == projectName &&c.ID != iEcxpId 
                     select c).FirstOrDefault() == null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
