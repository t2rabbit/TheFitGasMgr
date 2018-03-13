///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: SysUserMgr.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-18 0:47:57
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLabelEfDbDll;
using Models;
#if SQL_SERVER
using NetLabelEfDbDll.SqlServer;
#else
//USING MYSQL
#endif
using System.Diagnostics;
using PiPublic.Log;


namespace NetLabelBll
{
    public class SysUserMgr
    {
        /// <summary>
        /// 超级管理员登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static SysUserInfoModel SuperLogin(string userName, string userPassword)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                CentralOrganizationUser userinfo = (from c in ent.CentralOrganizationUser
                                                    where c.Name == userName && c.Password == userPassword 
                                                    select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }


                SysUserInfoModel sysUserInfo = new SysUserInfoModel()
                {
                    Auth = (int)userinfo.Athority,
                    ID = userinfo.ID,
                    Name = userName,
                    OrgId = 0,
                    OrgInLevelIndex = (int)userinfo.LevelIndex,
                    Password = userPassword,
                    ProjectId = 0,
                    SuperOrgId = (int)userinfo.OrganizationID,
                    UserType = (int)DbConstDefine.SysUserType.CenterUser,
                };

                return sysUserInfo;
            }
        }




        /// <summary>
        /// 超级管理员登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static SysUserInfoModel OrgMgrLogin(string userName, string userPassword)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                OrganizationUser userinfo = (from c in ent.OrganizationUser
                                                    where c.Name == userName && c.Password == userPassword                                                     
                                                    select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }


                SysUserInfoModel sysUserInfo = new SysUserInfoModel()
                {
                    Auth = (int)userinfo.Athority,
                    ID = userinfo.ID,
                    Name = userName,
                    OrgId = (int)userinfo.OrganizationID,
                    OrgInLevelIndex = (int)userinfo.LevelIndex,
                    Password = userPassword,
                    ProjectId = 0,
                    SuperOrgId = (int)userinfo.OrganizationID,
                    UserType = (int)DbConstDefine.SysUserType.OrgUser,
                };

                return sysUserInfo;
            }

        }


        /// <summary>
        /// 项目登录-工程组（管理登录）
        /// </summary>
        /// <param name="strOrgName"></param>
        /// <param name="strProjectName"></param>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static SysUserInfoModel ProjectGroupMgrLogin(string strUserName, string strPassword)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                ProjectGroupUser userinfo = (from c in ent.ProjectGroupUser
                                        where c.Name == strUserName && c.Password == strPassword
                                        select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }


                SysUserInfoModel sysUserInfo = new SysUserInfoModel()
                {
                    Auth = (int)userinfo.Athority,
                    ID = userinfo.ID,
                    Name = strPassword,
                    OrgId = 0,
                    OrgInLevelIndex = 0,
                    Password = strPassword,
                    ProjectId = (int)userinfo.ProjectGroupID,
                    SuperOrgId = 0,
                    UserType = (int)DbConstDefine.SysUserType.GroupUser,
                };

                return sysUserInfo;
            }

        }

        /// <summary>
        /// 工程管理登录
        /// </summary>
        /// <param name="strOrgName"></param>
        /// <param name="strProjectName"></param>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static SysUserInfoModel ProjectMgrLogin(string strUserName, string strPassword)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                ProjectUser userinfo = (from c in ent.ProjectUser
                                             where c.Name == strUserName && c.Password == strPassword
                                             select c).FirstOrDefault();

                if (userinfo == null)
                {
                    return null;
                }

                SysUserInfoModel sysUserInfo = new SysUserInfoModel()
                {
                    Auth = (int)userinfo.Athority,
                    ID = userinfo.ID,
                    Name = strPassword,
                    OrgId = 0,
                    OrgInLevelIndex = 0,
                    Password = strPassword,
                    ProjectId = (int)userinfo.ProjectID,
                    ProjectGroupId = (int)userinfo.ProjectGroupId,
                    SuperOrgId = 0,
                    UserType = (int)DbConstDefine.SysUserType.ProjectUser,
                };

                return sysUserInfo;
            }
        }

        /// <summary>
        /// 添加总公司用户,添加后ID会修改
        /// </summary>
        /// <returns></returns>
        public static bool AddCentralOrgNewUser(ref SysUserInfoModel sysUser, out string strError)
        {
            strError = "";

            string strName = sysUser.Name;
            if (sysUser.OrgInLevelIndex != (int)DbConstDefine.OrgLevelDefine.CentralOrgLevelIndex)
            {
                LogMgr.WriteErrorDefSys("Add SysUser error orgidex is not central");
                return false;
            }
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    CentralOrganizationUser user = new CentralOrganizationUser()
                    {
                        Athority = sysUser.Auth,
                        LevelIndex = (int)DbConstDefine.OrgLevelDefine.CentralOrgLevelIndex,
                        Name = sysUser.Name,
                        OrganizationID = sysUser.OrgId,
                        Password = sysUser.Password,
                        ID = 0,
                    };

                    ent.CentralOrganizationUser.AddObject(user);
                    ent.SaveChanges();
                    sysUser.ID = user.ID;
                    return true;
                }
           
            }
            catch (System.Exception ex)
            {
                LogMgr.WriteErrorDefSys("Add SysUser ex:" + ex.Message);
                return false;
            }        
        }



        /// <summary>
        /// 添加分公司用户,添加后ID会修改
        /// </summary>
        /// <returns></returns>
        public static bool AddOrgNewUser(ref SysUserInfoModel sysUser, out string strError)
        {
            strError = null;
            string strName = sysUser.Name;
            if (sysUser.OrgInLevelIndex == (int)DbConstDefine.OrgLevelDefine.CentralOrgLevelIndex)
            {
                LogMgr.WriteErrorDefSys("Add AddOrgNewUser error orgidex is central, need branch index");
                return false;
            }
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    OrganizationUser user = new OrganizationUser()
                    {
                        Athority = sysUser.Auth,
                        LevelIndex = sysUser.OrgInLevelIndex,
                        Name = sysUser.Name,
                        OrganizationID = sysUser.OrgId,
                        Password = sysUser.Password,
                        ID = 0,
                    };

                    ent.OrganizationUser.AddObject(user);
                    ent.SaveChanges();
                    sysUser.ID = user.ID;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                LogMgr.WriteErrorDefSys("Add SysUser ex:" + ex.Message);
                return false;
            }
        }


        public static bool AddProjectGroupNewUser(ref SysUserInfoModel sysUser, out string strError)
        {

            strError = null;
            string strName = sysUser.Name;
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    ProjectGroupUser user = new ProjectGroupUser()
                    {
                        Name = sysUser.Name,
                        ProjectGroupID = sysUser.ProjectGroupId,
                        Password = sysUser.Password,
                        ID = 0,
                        Athority = sysUser.Auth,
                        LevelIndex = sysUser.OrgInLevelIndex,
                    };

                    ent.ProjectGroupUser.AddObject(user);
                    ent.SaveChanges();
                    sysUser.ID = user.ID;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                LogMgr.WriteErrorDefSys("Add SysUser ex:" + ex.Message);
                return false;
            }
        }


        public static bool AddProjectNewUser(ref SysUserInfoModel projUser, out string strError)
        {

            strError = null;
            string strName = projUser.Name;
           
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    ProjectUser user = new ProjectUser()
                    {
                        Name = projUser.Name,
                        ProjectID = projUser.ProjectId,
                        ProjectGroupId = projUser.ProjectGroupId,
                        Password = projUser.Password,
                        ID = 0,
                        Athority = projUser.Auth,
                        OrganizationId = projUser.OrgId,
                        LevelIndex = projUser.OrgInLevelIndex,
                    };

                    ent.ProjectUser.AddObject(user);
                    ent.SaveChanges();
                    projUser.ID = user.ID;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                LogMgr.WriteErrorDefSys("Add SysUser ex:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 检查任何一个表是否有用户
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static bool CheckAnyUserNameInDb(string strName)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                if((from c in ent.CentralOrganizationUser
                    where c.Name == strName
                    select c).FirstOrDefault() != null)
                {
                    return true;
                }

                if ((from c in ent.OrganizationUser
                     where c.Name == strName
                     select c).FirstOrDefault() != null)
                {
                    return true;
                }

                if ((from c in ent.ProjectGroupUser
                     where c.Name == strName
                     select c).FirstOrDefault() != null)
                {
                    return true;
                }

                if ((from c in ent.ProjectUser
                     where c.Name == strName
                     select c).FirstOrDefault() != null)
                {
                    return true;
                }

                return false;
            }
        }

    }
}
