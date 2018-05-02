using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiPublic.Log;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    public  class ProjectBll
    {
        public static bool AddAProject(ref ProjectInfo model, out string strErrInfo)
        {
            strErrInfo = "";
            if (IsNameExist(model.ProjectName))
            {
                strErrInfo = "名字已经存在";
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                ProjectInfo newModel = new ProjectInfo()
                {
                    Id = 0,
                    ProjectName = model.ProjectName,
                    Address = model.Address,
                    ManagerName = model.ManagerName,
                    ManagerTel = model.ManagerTel,
                    GroupId = model.GroupId,
                    OrgId = model.OrgId,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };

                try
                {
                    ent.ProjectInfo.Add(newModel);
                    ent.SaveChanges();
                    model.Id = newModel.Id;
                    return true;
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteErrorDefSys("Add Project Ex:" + ex.Message);
                }

                return true;
            }
        }

        public static bool DeleteAProject(int iProjectID, out string strError)
        {
            strError = "";
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.ProjectInfo where c.Id == iProjectID select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.ProjectInfo.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static  bool UpdateProejct(ref ProjectInfo model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    int id = model.Id;
                    ProjectInfo mdyMod = (from c in ent.ProjectInfo where c.Id == id select c).FirstOrDefault();
                    if (mdyMod == null)
                    {
                        strError = ConstDefineBll.InfoCanNotFind;
                        return false;
                    }
                    
                    mdyMod.ProjectName = model.ProjectName;
                    mdyMod.Address = model.Address;
                    mdyMod.ManagerName = model.ManagerName;
                    mdyMod.ManagerTel = model.ManagerTel;
                    mdyMod.GroupId = model.GroupId;
                    mdyMod.OrgId = model.OrgId;
                    mdyMod.UpdateDt = DateTime.Now;
                    ent.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }

        }

        public static List<ProjectInfo> GetAllProject()
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    List<ProjectInfo> pros = (from c in ent.ProjectInfo
                                              select c).ToList<ProjectInfo>();

                    return pros;
                }
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
                //throw;
            }
            return null;
        }

        public static ProjectInfo GetAProjectById(int id)
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    ProjectInfo pro = (from c in ent.ProjectInfo where c.Id == id
                                              select c).FirstOrDefault();

                    return pro;
                }
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
                //throw;
            }
            return null;
        }

        public static List<ProjectInfo> GetProjectsByOrgId(int iOrgId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<ProjectInfo> pros = (from c in ent.ProjectInfo
                                          where c.OrgId == iOrgId
                                          select c).ToList<ProjectInfo>();
                return pros;
            }
        }

        public static List<ProjectInfo> GetProjectsByGroupId(int iGroupId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<ProjectInfo> pros = (from c in ent.ProjectInfo
                                          where c.GroupId == iGroupId
                                          select c).ToList<ProjectInfo>();
                return pros;
            }
        }

        public static List<ProjectInfo> GetProjectsBySqlCondtion(string strCond, string strOrderBy, out string strError)
        {
            strError = "";
            // todo
            return null;
        }

        public static bool IsNameExist(string projectName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.ProjectInfo where c.ProjectName == projectName select c).FirstOrDefault() != null)
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
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.ProjectInfo
                     where c.ProjectName == projectName &&c.Id != iEcxpId 
                     select c).FirstOrDefault() == null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
