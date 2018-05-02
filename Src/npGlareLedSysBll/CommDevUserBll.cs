using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels; 

namespace GlareLedSysBll
{
    public class CommDevUserBll
    {
        // todo get all 

        //public static  bool AddUser(ref CommDevUser model, out string strErrorMsg)
        //{
        //    strErrorMsg = "";
        //    if (IsNameExist(model.Name))
        //    {
        //        strErrorMsg = ConstDefineBll.NameExist;
        //        return false;
        //    }

        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        CommDevUser newinfo = new CommDevUser()
        //        {
        //            Id = model.Id,
        //            MgrCommDevId = model.MgrCommDevId,
        //            Name = model.Name,
        //            Password = model.Password,
        //            RefOrgId = model.RefOrgId,
        //            RefGroupId = model.RefGroupId,
        //            RefProjectId = model.RefProjectId,
        //            CreateDt = DateTime.Now,
        //            UpdateDt = DateTime.Now
        //        };
        //        ent.CommDevUser.Add(newinfo);
        //        ent.SaveChanges();
        //        model.Id= newinfo.Id;
        //    }
        //    return true;
        //}

        //public static bool UpdateUser(CommDevUser model, out string strErrMsg)
        //{
        //    strErrMsg = "";            
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        CommDevUser oldinfo = (from c in ent.CommDevUser where c.Id == model.Id select c).FirstOrDefault();
        //        if (oldinfo==null)
        //        {
        //            strErrMsg = ConstDefineBll.InfoCanNotFind;
        //            return false;
        //        }

        //        oldinfo.Id = model.Id;
        //        oldinfo.MgrCommDevId = model.MgrCommDevId;
        //        oldinfo.Name = model.Name;
        //        oldinfo.Password = model.Password;
        //        oldinfo.RefGroupId = model.RefGroupId;
        //        oldinfo.RefOrgId = model.RefOrgId;
        //        oldinfo.RefProjectId = model.RefProjectId;
        //        oldinfo.UpdateDt = DateTime.Now;
        //        ent.SaveChanges();
        //    }
        //    return true;
        //}

        //public static bool DelUser(int id)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        var delItem = (from c in ent.CommDevUser where c.Id == id select c).FirstOrDefault();
        //        if (delItem == null)
        //        {
        //            return true;
        //        }

        //        ent.CommDevUser.Remove(delItem);
        //        ent.SaveChanges();
        //        return true;
        //    }
        //}

        //public static bool IsNameExist(string strName)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        var delItem = (from c in ent.ProjectUser where c.Name == strName select c).FirstOrDefault();
        //        if (delItem != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }                
        //    }
        //}
    }
}
