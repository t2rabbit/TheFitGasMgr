using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class OrgUserBll
    {
        public static  bool AddUser(ref OrgUser model, out string strErrorMsg)
        {
            strErrorMsg = "";
            if (IsUserNameExist(model.Name))
            {
                strErrorMsg = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                OrgUser newinfo = new OrgUser()
                {
                    Id = model.Id,
                    MgrOrgId = model.MgrOrgId,
                    Name = model.Name,
                    Password = model.Password,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };
                ent.OrgUser.Add(newinfo);
                ent.SaveChanges();
                model.Id= newinfo.Id;
            }
            return true;
        }

        public static bool UpdateUser(OrgUser model, out string strErrMsg)
        {
            strErrMsg = "";            
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var oldinfo = (from c in ent.OrgUser where c.Id == model.Id select c).FirstOrDefault();
                if (oldinfo==null)
                {
                    strErrMsg = ConstDefineBll.InfoCanNotFind;
                    return false;
                }

                oldinfo.MgrOrgId = model.MgrOrgId;
                oldinfo.Name = model.Name;
                oldinfo.Password = model.Password;
                oldinfo.UpdateDt = DateTime.Now;
                ent.SaveChanges();
            }
            return true;
        }

        public static bool DelUser(int id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.OrgUser where c.Id == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.OrgUser.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsUserNameExist(string strName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.OrgUser where c.Name == strName select c).FirstOrDefault();
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
