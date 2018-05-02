using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiPublic.Log;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    public  class OrgBll
    {
        public static bool AddAOrg(ref OrgInfo model, out string strErrInfo)
        {
            strErrInfo = "";
            if (IsNameExist(model.Name))
            {
                strErrInfo = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                OrgInfo newModel = new OrgInfo()
                {
                    Id = 0,
                    Name = model.Name,
                    ManageName = model.ManageName,
                    ManageTel = model.ManageTel,
                    Address = model.Address,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };

                try
                {
                    ent.OrgInfo.Add(newModel);
                    ent.SaveChanges();
                    model.Id = newModel.Id;
                    return true;
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteErrorDefSys("Add Org Ex:" + ex.Message);
                }

                return true;
            }
        }

        public static bool DeleteAOrg(int id, out string strError)
        {
            strError = "";
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.OrgInfo where c.Id == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.OrgInfo.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static  bool UpdateProejct(ref OrgInfo model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    int id = model.Id;
                    OrgInfo mdyMod = (from c in ent.OrgInfo where c.Id == id select c).FirstOrDefault();
                    if (mdyMod == null)
                    {
                        strError = ConstDefineBll.InfoCanNotFind;
                        return false;
                    }
                    
                    mdyMod.Name = model.Name;
                    mdyMod.Address = model.Address;
                    mdyMod.ManageName = model.ManageName;
                    mdyMod.ManageTel = model.ManageTel;
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

        public static List<OrgInfo> GetAllOrgInfo()
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    List<OrgInfo> pros = (from c in ent.OrgInfo
                                              select c).ToList<OrgInfo>();

                    return pros;
                }
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
                throw;
            }
        }

        public static OrgInfo GetAOrgById(int id)
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    OrgInfo pro = (from c in ent.OrgInfo where c.Id == id
                                              select c).FirstOrDefault();

                    return pro;
                }
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
                throw;
            }
        }

        public static List<OrgInfo> GetOrgssBySqlCondtion(string strCond, string strOrderBy, out string strError)
        {
            strError = "";
            // todo
            return null;
        }

        public static bool IsNameExist(string name)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.OrgInfo where c.Name == name select c).FirstOrDefault() != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查是否有存在指定名字工程,除当前的Id外的
        /// </summary>
        /// <param name="iEcxpId">不包括这Id</param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public bool IsNameExist(int iEcxpId, string name)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.OrgInfo
                     where c.Name == name &&c.Id != iEcxpId 
                     select c).FirstOrDefault() == null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
