using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class OrgUserMgr
    {
        public static  bool AddUser(ref OrgUser model, out string strErrorMsg)
        {
            strErrorMsg = "";
            if (IsProjectUserNameExist(model.Name))
            {
                strErrorMsg = ConstDefineBll.NameExist;
                return false;
            }

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                OrgUser newinfo = new OrgUser()
                {
                    ID = model.ID,
                    MgrOrgId = model.MgrOrgId,
                    Name = model.Name,
                    Password = model.Password
                };
                ent.OrgUser.Add(newinfo);
                ent.SaveChanges();
                model.ID = newinfo.ID;
            }
            return true;
        }

        public static bool UpdateUser(OrgUser model, out string strErrMsg)
        {
            strErrMsg = "";            
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                OrgUser oldinfo = (from c in ent.OrgUser where c.ID == model.ID select c).FirstOrDefault();
                if (oldinfo==null)
                {
                    strErrMsg = ConstDefineBll.InfoCanNotFind;
                    return false;
                }

                oldinfo.ID = model.ID;
                oldinfo.MgrOrgId = model.MgrOrgId;
                oldinfo.Name = model.Name;
                oldinfo.Password = model.Password;                              
                ent.SaveChanges();
            }
            return true;
        }

        public static bool DelUser(int id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.OrgUser where c.ID == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.OrgUser.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsProjectUserNameExist(string strName)
        {
            // todo
            return false;
        }
    }
}
