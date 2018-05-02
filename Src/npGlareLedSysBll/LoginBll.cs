using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using GlareSysEfDbAndModels;
using PiPublic.Log;


namespace GlareLedSysBll
{
    public class LoginBll
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

                string iTockId = LoginUserEnableMgr.Get().InsertANewLogined();
                SuperLoginedUserModel mod = new SuperLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iTockId,
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

                string iTockId = LoginUserEnableMgr.Get().InsertANewLogined();
                OrgLoginedUserModel mod = new OrgLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iTockId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        /// <summary>
        /// 查找该分公司下是否有项目组
        /// </summary>
        /// <param name="iOrgId">如果小于等于0，表示全文查找，现在添加也是要求所有企业都唯一</param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static GroupLoginedUserModel GroupLogin(int iOrgId, string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                GroupUser userinfo = null;
                if (iOrgId <=0 )
                {
                    userinfo = (from c in ent.GroupUser
                                          where c.Name == userName && c.Password == userPassword
                                          select c).FirstOrDefault();
                }
                else
                {
                    userinfo = (from c in ent.GroupUser
                                          where c.Name == userName && c.Password == userPassword && c.RefOrgId == iOrgId
                                          select c).FirstOrDefault();
                }

                if (userinfo == null)
                {
                    return null;
                }

                string iTockId = LoginUserEnableMgr.Get().InsertANewLogined();
                GroupLoginedUserModel mod = new GroupLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iTockId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iProjectId">如果项目组小于等于0，那么表示全文查找</param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static ProjectLoginedUserModel ProjectLogin(int iGroupId, string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                ProjectUser userinfo = null;
                if (iGroupId <= 0)
                {
                    userinfo = (from c in ent.ProjectUser
                                            where c.Name == userName && c.Password == userPassword                                            
                                            select c).FirstOrDefault();
                }
                else
                {
                    userinfo = (from c in ent.ProjectUser
                                            where c.Name == userName && c.Password == userPassword
                                            && c.RefGroupId == iGroupId
                                            select c).FirstOrDefault();
                }

                if (userinfo == null)
                {
                    return null;
                }

                string iTockId = LoginUserEnableMgr.Get().InsertANewLogined();
                ProjectLoginedUserModel mod = new ProjectLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iTockId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iProject">如果工程小于等于0，全文查找（插入时已经确保不同工程下名字也不能相同）</param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static CommDevLoginedUserModel CommDevLogin(int iProject, string userName, string userPassword)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                ddCommDevUser userinfo = null;
                if (iProject <= 0)
                {

                        GasCardWithCommInfo dev = (from c in ent.GasCardWithCommInfo
                                                   where c.Name == userName && c.Password == userPassword
                                           select c).FirstOrDefault();
                        if (dev != null)
                        {
                            userinfo = new ddCommDevUser()
                            {
                                CreateDt = DateTime.Now,
                                Id = -1,
                                IsDel = 0,
                                MgrCommDevId = dev.Id,
                                Name = dev.Name,
                                Password = dev.Password,
                                RefGroupId = -1,
                                RefOrgId = -1,
                                RefProjectId = -1,
                                UpdateDt = DateTime.Now
                            };
                        }
                    
                }
                else
                {
                        GasCardWithCommInfo dev = (from c in ent.GasCardWithCommInfo
                                                   where c.Name == userName && c.Password == userPassword
                                           select c).FirstOrDefault();
                        if (dev != null)
                        {
                            userinfo = new ddCommDevUser()
                            {
                                CreateDt = DateTime.Now,
                                Id = -1,
                                IsDel = 0,
                                MgrCommDevId = dev.Id,
                                Name = dev.Name,
                                Password = dev.Password,
                                RefGroupId = -1,
                                RefOrgId = -1,
                                RefProjectId = -1,
                                UpdateDt = DateTime.Now
                            };
                        }
                    
                }

                if (userinfo == null)
                {
                    return null;
                }

                string iTockId = LoginUserEnableMgr.Get().InsertANewLogined();
                CommDevLoginedUserModel mod = new CommDevLoginedUserModel()
                {
                    LoginDt = DateTime.Now,
                    LoginIdByCenter = iTockId,
                    UserInfo = userinfo
                };
                return mod;
            }
        }

        public static bool CheckLoginId(string iTockId)
        {
            if (iTockId==ConstDefineBll.TockIdEnableTest)
            {
                return true;
            }

            return LoginUserEnableMgr.Get().IsLoginIdEnable(iTockId);
        }

        public static bool Logout(string iTockId)
        {
            return LoginUserEnableMgr.Get().Logout(iTockId);
        }

        public static void UpdateLoginStatus(string iTockId)
        {
            LoginUserEnableMgr.Get().UpdateTockIdTime(iTockId);
        }
    }
}
