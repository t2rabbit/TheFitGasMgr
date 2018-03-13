///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: MontitorInfoBll.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-23 22:04:15
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using NetLabelEfDbDll.SqlServer;

namespace NetLabelBll
{
    /// <summary>
    /// 监控信息的业务逻辑
    /// </summary>
    public class MontitorInfoBll
    {

        /// <summary>
        /// 获取所有的工程，包括监视信息
        /// </summary>
        /// <returns></returns>
        public static List<MonitorInfoOfAProject> GetAllProjectMonitorInfo()
        {
            // todo 优化

            List<ProjectOrGroupCountModel> lstCounts = GetDevCountByProject();

            List<MonitorInfoOfAProject> lstMons = new List<MonitorInfoOfAProject>();
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    List<Project> lstProjects = ent.Project.ToList();
                    foreach (Project item in lstProjects)
                    {
                        int iDevCount = 0;
                        try
                        {
                            iDevCount = (from c in lstCounts where c.ID == item.ID select c).First().CountValue;
                        }
                        catch (System.Exception ex)
                        {
                        	
                        }
                        

                        MonitorInfoOfAProject aPrj = new MonitorInfoOfAProject()
                        {
                            Address = item.Address,
                            DevCount = iDevCount,
                            GpsInfo = item.Address_GPS,
                            OrgId = (int)item.OrganizationId,
                            OrgName = "",
                            PngPath = item.PngPath,
                            ProjectGroupId = (int)item.ProjectGroupId,
                            ProjectGroupName = "",
                            ProjectId = item.ID,
                            ProjectName = item.Name,
                            ShowStatusInProject = 0,
                        };
                        lstMons.Add(aPrj);
                    }
                    return lstMons;
                }
            }
            catch (System.Exception ex)
            {
                return lstMons;
            }
            
        }

        /// <summary>
        /// 更加ORGid 获取工程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<MonitorInfoOfAProject> GetProjectMonitorInfoByOrgId(int id)
        {
            List<ProjectOrGroupCountModel> lstCounts = GetDevCountByProject();

            List<MonitorInfoOfAProject> lstMons = new List<MonitorInfoOfAProject>();
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    List<Project> lstProjects = (from c in ent.Project where c.OrganizationId == id select c).ToList();
                    foreach (Project item in lstProjects)
                    {
                        int iDevCount = 0;
                        try
                        {
                            iDevCount = (from c in lstCounts where c.ID == item.ID select c).First().CountValue;
                        }
                        catch (System.Exception ex)
                        {

                        }


                        MonitorInfoOfAProject aPrj = new MonitorInfoOfAProject()
                        {
                            Address = item.Address,
                            DevCount = iDevCount,
                            GpsInfo = item.Address_GPS,
                            OrgId = (int)item.OrganizationId,
                            OrgName = "",
                            PngPath = item.PngPath,
                            ProjectGroupId = (int)item.ProjectGroupId,
                            ProjectGroupName = "",
                            ProjectId = item.ID,
                            ProjectName = item.Name,
                            ShowStatusInProject = 0,
                        };
                    }
                    return lstMons;
                }
            }
            catch (System.Exception ex)
            {
                return lstMons;
            }
        }

        /// <summary>
        /// 根据工程组获取工程
        /// </summary>
        /// <param name="iGroupId"></param>
        /// <returns></returns>
        public static List<MonitorInfoOfAProject> GetProjectMonitorInfoByGroup(int iGroupId)
        {
            List<ProjectOrGroupCountModel> lstCounts = GetDevCountByProject();

            List<MonitorInfoOfAProject> lstMons = new List<MonitorInfoOfAProject>();
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    List<Project> lstProjects = (from c in ent.Project 
                                                 where c.ProjectGroupId == iGroupId 
                                                 select c).ToList();
                    foreach (Project item in lstProjects)
                    {
                        int iDevCount = 0;
                        try
                        {
                            iDevCount = (from c in lstCounts where c.ID == item.ID select c).First().CountValue;
                        }
                        catch (System.Exception ex)
                        {

                        }


                        MonitorInfoOfAProject aPrj = new MonitorInfoOfAProject()
                        {
                            Address = item.Address,
                            DevCount = iDevCount,
                            GpsInfo = item.Address_GPS,
                            OrgId = (int)item.OrganizationId,
                            OrgName = "",
                            PngPath = item.PngPath,
                            ProjectGroupId = (int)item.ProjectGroupId,
                            ProjectGroupName = "",
                            ProjectId = item.ID,
                            ProjectName = item.Name,
                            ShowStatusInProject = 0,
                        };
                    }
                    return lstMons;
                }
            }
            catch (System.Exception ex)
            {
                return lstMons;
            }
        }


        /// <summary>
        /// 根据ID获取设备的实时状态，ID使用逗号隔开，如果是sql语句直接使用的字符串
        /// </summary>
        /// <param name="strIds">ID使用逗号隔开，如果是sql语句直接使用的字符串 如："1,2,100,23"</param>
        /// <returns></returns>
        public static List<MonitorInfoOfDevModel> GetDevMonitorInfoByDevIds(string strIds)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from DevInfo");
            if (strIds.Length > 0)
            {
                sb.Append(" where id in(");
                sb.Append(strIds);
                sb.Append(")");
            }
            try
            {

                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    return ent.ExecuteStoreQuery<MonitorInfoOfDevModel>(sb.ToString()).ToList();
                }
            }
            catch (System.Exception ex)
            {
               return new List<MonitorInfoOfDevModel>();
            }
        }

        protected static List<ProjectOrGroupCountModel> GetDevCountByProject()
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                string strSql = "select count(*) as CountValue, projectid  as ID from DevInfo td group by td.ProjectId";
                return ent.ExecuteStoreQuery<ProjectOrGroupCountModel>(strSql).ToList();
            }
        }

    }
}
