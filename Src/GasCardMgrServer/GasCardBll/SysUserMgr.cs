using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using GlareLedSysEfDb;
using PiPublic.Log;


namespace NetLabelBll
{
    public class SysUserMgr
    {
        public static SuperLoginedUserModel SuperLogin(string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                SuperUser userinfo = (from c in ent.SuperUser
                                      where c.Name == userName && c.Password == userPassword
                                    select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }

                int iNextId = LoginUserEnableMgr.Get().InsertANewLogined();
                SuperLoginedUserModel mod = new SuperLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iNextId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        public static OrgLoginedUserModel OrgLogin(string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                OrgUser userinfo = (from c in ent.OrgUser
                                    where c.Name == userName && c.Password == userPassword
                                      select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }

                int iNextId = LoginUserEnableMgr.Get().InsertANewLogined();
                OrgLoginedUserModel mod = new OrgLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iNextId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        public static GroupLoginedUserModel GroupLogin(string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                GroupUser userinfo = (from c in ent.GroupUser
                                      where c.Name == userName && c.Password == userPassword
                                      select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }

                int iNextId = LoginUserEnableMgr.Get().InsertANewLogined();
                GroupLoginedUserModel mod = new GroupLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iNextId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        public static CommDevLoginedUserModel CommDevLogin(string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                CommDevUser userinfo = (from c in ent.CommDevUser
                                        where c.Name == userName && c.Password == userPassword
                                      select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }

                int iNextId = LoginUserEnableMgr.Get().InsertANewLogined();
                CommDevLoginedUserModel mod = new CommDevLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iNextId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        public static bool CheckLoginId




    }
}
