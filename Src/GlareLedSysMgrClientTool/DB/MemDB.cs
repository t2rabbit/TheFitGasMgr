using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSqlite;

namespace Property.DB
{
    class MemDB
    {
        public IList<GL_Org> lstOrg { get; set; }
        public IList<GL_Dev> lstDev { get; set; }
        public IList<GL_LedCard> lstCard { get; set; }
        public IList<GL_Node> lstNode { get; set; }
        public IList<GL_SystemUser> lstSystemUser {get;set;}

        public IList<GL_Org> lstOrgWithNone
        {
            get
            {
                IList<GL_Org> glOrg = new List<GL_Org>();
                glOrg.Add(new GL_Org() { ID = 0, Name = "--none--" });
                foreach (GL_Org aOrg in DB.MemDB.Get().lstOrg)
                {
                    glOrg.Add(aOrg);
                }
                return glOrg;
            }
        }

        public IList<GL_Org> lstOrgWithAll
        {
            get
            {
                IList<GL_Org> glOrg = new List<GL_Org>();
                glOrg.Add(new GL_Org() { ID = 0, Name = "--all--" });
                foreach (GL_Org aOrg in DB.MemDB.Get().lstOrg)
                {
                    glOrg.Add(aOrg);
                }
                return glOrg;
            }
        }

        //
        // 单件支持
        //
        #region 单件支持
        private static MemDB m_pInst;
        protected MemDB()
        {
        }
        static public MemDB Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new MemDB();
                m_pInst.Init();
               // m_pInst.Start();
            }
            return m_pInst;
        }
        #endregion 单件支持

        private void Init()
        {
            using(GLedDBEntities ent = new GLedDBEntities())
	        {
                lstCard = ent.GL_LedCard.ToList();
                lstDev = ent.GL_Dev.ToList();
                lstOrg = ent.GL_Org.ToList();
                lstNode = ent.GL_Node.ToList();
                lstSystemUser = ent.GL_SystemUser.ToList();
	        }
        }


        public void AddOrg(GL_Org aItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                ent.GL_Org.AddObject(aItem);
                ent.SaveChanges();

                lstOrg = ent.GL_Org.ToList();
            }
        }
        public void UpdateOrg(int aID, GL_Org aNewItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                GL_Org aOldItem = (from c in ent.GL_Org where c.ID == aID select c).SingleOrDefault();
                if (aOldItem == null)
                {
                    return;
                }
                aOldItem = aNewItem;
                aOldItem.ID = aID;
                ent.ApplyCurrentValues<GL_Org>("GL_Org", aNewItem);
                ent.SaveChanges();
                lstOrg = ent.GL_Org.ToList();
            }
        }
        public void DelOrg(int aID)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                ent.GL_Org.DeleteObject((from c in ent.GL_Org where c.ID == aID select c).Single());
                ent.SaveChanges();
                lstOrg = ent.GL_Org.ToList();
            }
        }



        public void AddSysUser(GL_SystemUser aItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                ent.GL_SystemUser.AddObject(aItem);
                ent.SaveChanges();

                lstSystemUser = ent.GL_SystemUser.ToList();
            }
        }
        public void UpdateSysUser(int aID, GL_SystemUser aNewItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                GL_SystemUser aOldItem = (from c in ent.GL_SystemUser where c.ID == aID select c).SingleOrDefault();
                if (aOldItem == null)
                {
                    return;
                }
                aOldItem = aNewItem;
                aOldItem.ID = aID;
                ent.ApplyCurrentValues<GL_SystemUser>("GL_SystemUser", aNewItem);
                ent.SaveChanges();
                lstSystemUser = ent.GL_SystemUser.ToList();
            }
        }
        public void DelSysUser(int aID)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                ent.GL_SystemUser.DeleteObject((from c in ent.GL_SystemUser where c.ID == aID select c).Single());
                ent.SaveChanges();
                lstSystemUser = ent.GL_SystemUser.ToList();
            }
        }

        public void AddDev(GL_Dev aDev)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                ent.GL_Dev.AddObject(aDev);
                ent.SaveChanges();

                lstDev = ent.GL_Dev.ToList();
            }
        }
        public bool UpdateDev(int aID, GL_Dev aNewItem)
        {
            try
            {
                using (GLedDBEntities ent = new GLedDBEntities())
                {

                    GL_Dev aOldItem = (from c in ent.GL_Dev where c.ID == aID select c).SingleOrDefault();
                    if (aOldItem == null)
                    {
                        return false;
                    }
                    aOldItem = aNewItem;
                    aOldItem.ID = aID;
                    ent.ApplyCurrentValues<GL_Dev>("GL_Dev", aNewItem);
                    ent.SaveChanges();
                    lstDev = ent.GL_Dev.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }

        public void DelDev(int aID)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                ent.GL_Dev.DeleteObject((from c in ent.GL_Dev where c.ID == aID select c).Single());
                ent.SaveChanges();
                lstDev = ent.GL_Dev.ToList();
            }
        }

        public void AddCard(GL_LedCard aItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                ent.GL_LedCard.AddObject(aItem);
                ent.SaveChanges();

                lstCard= ent.GL_LedCard.ToList();
            }
        }


 
        public void DelCard(int aID)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                ent.GL_LedCard.DeleteObject((from c in ent.GL_LedCard where c.ID == aID select c).Single());
                ent.SaveChanges();
                lstCard = ent.GL_LedCard.ToList();
            }
        }
                        
        public bool UpdateCard(int aID, GL_LedCard aNewItem)
        {
            try
            {
                using (GLedDBEntities ent = new GLedDBEntities())
                {

                    GL_LedCard aOldItem = (from c in ent.GL_LedCard where c.ID == aID select c).SingleOrDefault();
                    if (aOldItem == null)
                    {
                        return false;
                    }
                    aOldItem = aNewItem;
                    aOldItem.ID = aID;
                    ent.ApplyCurrentValues<GL_LedCard>("GL_LedCard", aNewItem);
                    ent.SaveChanges();
                    lstCard = ent.GL_LedCard.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// 添加一条油价记录
        /// </summary>
        /// <param name="aItem"></param>
        public void AddContext(GL_LedContent aItem)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                ent.GL_LedContent.AddObject(aItem);
                ent.SaveChanges();
                lstCard = ent.GL_LedCard.ToList();
            }
        }



        public void DelAContext(int aID)
        {
            using (GLedDBEntities ent = new GLedDBEntities())
            {

                ent.GL_LedContent.DeleteObject((from c in ent.GL_LedContent where c.ID == aID select c).Single());
                ent.SaveChanges();
                lstCard = ent.GL_LedCard.ToList();
            }
        }

        public bool UpdateCard(int aID, GL_LedContent aNewItem)
        {
            try
            {
                using (GLedDBEntities ent = new GLedDBEntities())
                {

                    GL_LedContent aOldItem = (from c in ent.GL_LedContent where c.ID == aID select c).SingleOrDefault();
                    if (aOldItem == null)
                    {
                        return false;
                    }
                    aOldItem = aNewItem;
                    aOldItem.ID = aID;
                    ent.ApplyCurrentValues<GL_LedContent>("GL_LedContent", aNewItem);
                    ent.SaveChanges();
                    lstCard = ent.GL_LedCard.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return true;
        }   
    

#region    根据ID获取对象或对象的显示内容
        public string GetDevNameByDevID(int iDevID)
        {
            GL_Dev aDev = GetDevByID(iDevID);
            if (aDev == null)
            {
                return "";
            }
            return aDev.Name;
        }

        public GL_Dev GetDevByID(int iDevID)
        {
            GL_Dev aDev= (from c in lstDev where c.ID == iDevID select c).FirstOrDefault();
            return aDev;
        }

        public GL_LedCard GetCardByID(int iCardID)
        {
            GL_LedCard aCard = (from c in lstCard where c.ID == iCardID select c).FirstOrDefault();
            return aCard;
        }

        public string GetCardNameByID(int iCardID)
        {
            GL_LedCard aCard = GetCardByID(iCardID);
            if (aCard == null)
            {
                return "";
            }
            return aCard.Name;
        }

        public string GetDevNameByCardID(int iCardID)
        {
            GL_LedCard aCard = GetCardByID(iCardID);
            if (aCard == null)
            {
                return " ";
            }

            return GetDevNameByDevID((int)aCard.DevID);
        }

        public string GetOrgNameByDevID(int iDevID)
        {
            GL_Dev aDev = GetDevByID(iDevID);
            if (aDev == null)
            {
                return "";
            }
            return GetOrgNameByOrgID((int)aDev.OrgID);
        }

        public string GetOrgNameByCardID(int iCardID)
        {
            GL_LedCard aCard = GetCardByID(iCardID);
            if (aCard == null)
            {
                return " ";
            }
            return GetOrgNameByOrgID((int)aCard.OrgID);
        }

        public string GetOrgNameByOrgID(int iOrgID)
        {
            GL_Org aOrg = GetOrgByOrgID(iOrgID);
            if (aOrg == null )
            {
                return "";
            }
            return aOrg.Name;
        }

        public GL_Org GetOrgByOrgID(int iOrgID)
        {
            GL_Org aOrg = (from c in lstOrg where c.ID == iOrgID select c).FirstOrDefault();
            return aOrg;
        }

        public int GetCardCountByDevID(int iDevID)
        {
            int iCount = (from c in lstCard where c.DevID == iDevID select c).Count();
            return iCount;
        }

        public int GetCardCountByOrgID(int iOrgID)
        {
            int iCount = (from c in lstCard where c.OrgID == iOrgID select c).Count();
            return iCount;
        }
        public int GetDevCountByOrgID(int iOrgID)
        {
            int iCount = (from c in lstDev where c.OrgID == iOrgID select c).Count();
            return iCount;
        }


#endregion
    }
}
