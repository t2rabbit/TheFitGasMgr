using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class ProjectUserBll
    {
        // todo get all 

        public static  bool AddUser(ref ProjectUser model, out string strErrorMsg)
        {
            strErrorMsg = "";
            if (IsUserNameExist(model.Name))
            {
                strErrorMsg = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                ProjectUser newinfo = new ProjectUser()
                {
                    Id = model.Id,
                    MgrProjectId = model.MgrProjectId,
                    Name = model.Name,
                    Password = model.Password,
                    RefOrgId = model.RefOrgId,
                    RefGroupId = model.RefGroupId,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };
                ent.ProjectUser.Add(newinfo);
                ent.SaveChanges();
                model.Id= newinfo.Id;
            }
            return true;
        }

        public static bool UpdateUser(ProjectUser model, out string strErrMsg)
        {
            strErrMsg = "";            
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                ProjectUser oldinfo = (from c in ent.ProjectUser where c.Id == model.Id select c).FirstOrDefault();
                if (oldinfo==null)
                {
                    strErrMsg = ConstDefineBll.InfoCanNotFind;
                    return false;
                }

                oldinfo.Id = model.Id;
                oldinfo.MgrProjectId = model.MgrProjectId;
                oldinfo.Name = model.Name;
                oldinfo.Password = model.Password;
                oldinfo.RefGroupId = model.RefGroupId;
                oldinfo.RefOrgId = model.RefOrgId;
                oldinfo.UpdateDt = DateTime.Now;
                ent.SaveChanges();
            }
            return true;
        }

        public static bool DelUser(int id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.ProjectUser where c.Id == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.ProjectUser.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsUserNameExist(string strName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.ProjectUser where c.Name == strName select c).FirstOrDefault();
                if (delItem != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
        }
    }
}
