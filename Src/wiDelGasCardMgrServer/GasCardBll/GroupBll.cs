using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiPublic.Log;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    public  class GroupBll
    {
        public static bool AddAGroup(ref GroupInfo model, out string strErrInfo)
        {
            strErrInfo = "";
            if (IsGroupNameExist(model.GroupName))
            {
                strErrInfo = ConstDef.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                GroupInfo newModel = new GroupInfo()
                {
                    ID = 0,
                    GroupName = model.GroupName,
                    ManageName = model.ManageName,
                    ManageTel = model.ManageTel,
                    GroupAddress = model.GroupAddress,
                    OrgId = model.OrgId
                };

                try
                {
                    ent.GroupInfo.Add(newModel);
                    ent.SaveChanges();
                    model.ID = newModel.ID;
                    return true;
                }
                catch (System.Exception ex)
                {
                    LogMgr.WriteErrorDefSys("Add Org Ex:" + ex.Message);
                }

                return true;
            }
        }

        public static bool DeleteAGroup(int id, out string strError)
        {
            strError = "";
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.GroupInfo where c.ID == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.GroupInfo.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static  bool UpdateProejct(ref GroupInfo model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    int id = model.ID;
                    GroupInfo mdyMod = (from c in ent.GroupInfo where c.ID == id select c).FirstOrDefault();
                    if (mdyMod == null)
                    {
                        strError = ConstDef.InfoCanNotFind;
                        return false;
                    }
                    
                    mdyMod.GroupName = model.GroupName;
                    mdyMod.GroupAddress = model.GroupAddress;
                    mdyMod.ManageName = model.ManageName;
                    mdyMod.ManageTel = model.ManageTel;
                    mdyMod.OrgId = model.OrgId;
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

        public static List<GroupInfo> GetAllGroupInfo()
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    List<GroupInfo> pros = (from c in ent.GroupInfo
                                              select c).ToList<GroupInfo>();

                    return pros;
                }
            }
            catch (Exception ex)
            {
                LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
                throw;
            }
        }

        public static GroupInfo GetAGroupById(int id)
        {
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    GroupInfo pro = (from c in ent.GroupInfo where c.ID == id
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

        public static List<GroupInfo> GetGroupssBySqlCondtion(string strCond, string strOrderBy, out string strError)
        {
            strError = "";
            // todo
            return null;
        }

        private static bool IsGroupNameExist(string name)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.GroupInfo where c.GroupName == name select c).FirstOrDefault() == null)
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
        private bool IsGroupNameExist(int iEcxpId, string name)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.GroupInfo
                     where c.GroupName == name &&c.ID != iEcxpId 
                     select c).FirstOrDefault() == null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
