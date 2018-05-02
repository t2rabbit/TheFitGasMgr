using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class GroupUserBll
    {
        public static  bool AddUser(ref GroupUser model, out string strErrorMsg)
        {
            strErrorMsg = "";
            if (IsNameExist(model.Name))
            {
                strErrorMsg = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                GroupUser newinfo = new GroupUser()
                {
                    Id = model.Id,
                    MgrGroupId = model.MgrGroupId,
                    Name = model.Name,
                    Password = model.Password,
                    RefOrgId = model.RefOrgId,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };
                ent.GroupUser.Add(newinfo);
                ent.SaveChanges();
                model.Id= newinfo.Id;
            }
            return true;
        }

        public static bool UpdateUser(GroupUser model, out string strErrMsg)
        {
            strErrMsg = "";            
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                GroupUser oldinfo = (from c in ent.GroupUser where c.Id == model.Id select c).FirstOrDefault();
                if (oldinfo==null)
                {
                    strErrMsg = ConstDefineBll.InfoCanNotFind;
                    return false;
                }

                oldinfo.Id = model.Id;
                oldinfo.MgrGroupId = model.MgrGroupId;
                oldinfo.Name = model.Name;
                oldinfo.Password = model.Password;
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
                var delItem = (from c in ent.GroupUser where c.Id == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.GroupUser.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsNameExist(string strName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.GroupUser where c.Name == strName select c).FirstOrDefault();
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
