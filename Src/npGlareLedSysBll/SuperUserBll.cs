using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class SuperUserBll
    {
        public static List<SuperUser> GetAllUser()
        {
            // todo 
            return null;
        }

        public static  bool AddUser(ref SuperUser model, out string strErrorMsg)
        {
            strErrorMsg = "";
            if (IsUserNameExist(model.Name))
            {
                strErrorMsg = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                SuperUser newinfo = new SuperUser()
                {
                    Id = model.Id,
                    EnableTime = model.EnableTime,
                    UserType = model.UserType,
                    Name = model.Name,
                    Password = model.Password,
                    CreateDt = DateTime.Now,
                    UpdateDt = DateTime.Now
                };
                ent.SuperUser.Add(newinfo);
                ent.SaveChanges();
                model.Id= newinfo.Id;
            }
            return true;
        }

        public static bool UpdateUser(SuperUser model, out string strErrMsg)
        {
            strErrMsg = "";            
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var oldinfo = (from c in ent.SuperUser where c.Id == model.Id select c).FirstOrDefault();
                if (oldinfo==null)
                {
                    strErrMsg = ConstDefineBll.InfoCanNotFind;
                    return false;
                }

                oldinfo.EnableTime = model.EnableTime;
                oldinfo.UserType = model.UserType;
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
                var delItem = (from c in ent.SuperUser where c.Id == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return false;
                }

                ent.SuperUser.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsUserNameExist(string strName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.SuperUser where c.Name == strName select c).FirstOrDefault();
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
