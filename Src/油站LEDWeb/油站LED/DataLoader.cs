using OilStationLED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OilStationLED
{
    public class DataLoader
    {
        /// <summary>
        /// 加载Org
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadOrg()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 
                            'org_'+cast(o.ID as varchar) as [id],
                            o.Name as [text],
                            CAST((select COUNT(*) from GroupInfo b where b.OrgID=o.ID and b.IsDel!=1)+(select COUNT(*) from ProjectInfo bg where bg.OrgID=o.ID and bg.IsDel!=1) as varchar) as [state],
                            iconCls='icon-org'
                            from OrgInfo o
                            where o.IsDel!=1");
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }
        /// <summary>
        /// 加载Group
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadGroup(string strOrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
                                'group_'+cast(o.ID as varchar) as [id],
                                o.GroupName as [text],
                                CAST((select COUNT(*) from ProjectInfo b where b.GroupId=o.ID and b.IsDel!=1)+(select COUNT(*) from GasCardWithCommInfo bg where bg.GroupId=o.ID and bg.IsDel!=1) as varchar) as [state],
                                iconCls='icon-group'
                                from GroupInfo o
                                where o.OrgId='{0}'
                                and o.IsDel!=1", strOrgID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 加载Project
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadProject(string strGroupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
                                'project_'+cast(o.ID as varchar) as [id],
                                o.ProjectName as [text],
                                CAST((select COUNT(*) from GasCardWithCommInfo b where b.IsDel!=1) as varchar) as [state],
                                iconCls='icon-project'
                                from ProjectInfo o
                                where o.GroupId='{0}'
                                and o.IsDel!=1", strGroupID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 加载GasCardWithCommInfo
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadGasCardWithCommInfo(string strProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
                                'gas_'+cast(o.ID as varchar) as [id],
                                o.Name as [text],
                                '0' as [state],
                                iconCls='icon-gas'
                                from GasCardWithCommInfo o
                                where o.ProjectId='{0}'
                                and o.IsDel!=1", strProjectID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 获取所有GasCardWithCommInfo列表
        /// </summary>
        /// <param name="strOrgID"></param>
        /// <returns></returns>
        public static List<ModelForGasCardWithCommInfo> GetAllGasCardWithCommInfoList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select
                                gm.*,
                                o.Id OrgId,
                                o.Name OrgName,
                                g.Id GroupId,
                                g.GroupName,
                                p.Id ProjectId,
                                p.ProjectName
                                from GasCardWithCommInfo gm
                                left join OrgInfo o on gm.OrgId=o.Id
                                left join GroupInfo g on g.Id=gm.GroupId
                                left join ProjectInfo p on p.Id=gm.ProjectId
                                where gm.IsDel!=1");
            using (LedDbEntities db = new LedDbEntities())
            {
                List<ModelForGasCardWithCommInfo> list = db.Database.SqlQuery<ModelForGasCardWithCommInfo>(strSql.ToString()).ToList();
                return list;
            }
        }
        /// <summary>
        /// 通过OrgID获取GasCardWithCommInfo列表
        /// </summary>
        /// <param name="strOrgID"></param>
        /// <returns></returns>
        public static List<ModelForGasCardWithCommInfo> GetGasCardWithCommInfoByOrgId(string strOrgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select
                                gm.*,
                                o.Id OrgId,
                                o.Name OrgName,
                                g.Id GroupId,
                                g.GroupName,
                                p.Id ProjectId,
                                p.ProjectName
                                from GasCardWithCommInfo gm
                                left join OrgInfo o on gm.OrgId=o.Id
                                left join GroupInfo g on g.Id=gm.GroupId
                                left join ProjectInfo p on p.Id=gm.ProjectId
                                where o.Id='{0}'
                                and gm.IsDel!=1", strOrgID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<ModelForGasCardWithCommInfo> list = db.Database.SqlQuery<ModelForGasCardWithCommInfo>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 通过GorupID获取GasCardWithCommInfo列表
        /// </summary>
        /// <param name="strOrgID"></param>
        /// <returns></returns>
        public static List<ModelForGasCardWithCommInfo> GetGasCardWithCommInfoByGorupID(string strGorupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select
                                gm.*,
                                o.Id OrgId,
                                o.Name OrgName,
                                g.Id GroupId,
                                g.GroupName,
                                p.Id ProjectId,
                                p.ProjectName
                                from GasCardWithCommInfo gm
                                left join OrgInfo o on gm.OrgId=o.Id
                                left join GroupInfo g on g.Id=gm.GroupId
                                left join ProjectInfo p on p.Id=gm.ProjectId
                                where g.Id='{0}'
                                and gm.IsDel!=1", strGorupID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<ModelForGasCardWithCommInfo> list = db.Database.SqlQuery<ModelForGasCardWithCommInfo>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 通过ProjectID获取GasCardWithCommInfo列表
        /// </summary>
        /// <param name="strOrgID"></param>
        /// <returns></returns>
        public static List<ModelForGasCardWithCommInfo> GetGasCardWithCommInfoByProjectID(string strProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select
                                gm.*,
                                o.Id OrgId,
                                o.Name OrgName,
                                g.Id GroupId,
                                g.GroupName,
                                p.Id ProjectId,
                                p.ProjectName
                                from GasCardWithCommInfo gm
                                left join OrgInfo o on gm.OrgId=o.Id
                                left join GroupInfo g on g.Id=gm.GroupId
                                left join ProjectInfo p on p.Id=gm.ProjectId
                                where p.Id='{0}'
                                and gm.IsDel!=1", strProjectID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<ModelForGasCardWithCommInfo> list = db.Database.SqlQuery<ModelForGasCardWithCommInfo>(strSql.ToString()).ToList();
                return list;
            }
        }



        /*   此处两个方法屏蔽
        /// <summary>
        /// 加载Commdev
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadCommdev(string strProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
                                'comdev_'+cast(o.ID as varchar) as [id],
                                o.Name as [text],
                                CAST((select COUNT(*) from GasCardInfo b where b.CommDevId=o.ID) as varchar) as [state],
                                iconCls='icon-commdev'
                                from CommDevInfo o
                                where o.ProjectId='{0}'", strProjectID);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 加载GasCard
        /// </summary>
        /// <returns></returns>
        public static List<TreeSelectorEntity> LoadGasCard(string strCommDevD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select 
                                'gas_'+cast(o.ID as varchar) as [id],
                                o.CardName as [text],
                                '0' as [state],
                                iconCls='icon-gas'
                                from GasCardInfo o
                                where o.CommDevId='{0}'", strCommDevD);
            using (LedDbEntities db = new LedDbEntities())
            {
                List<TreeSelectorEntity> list = db.Database.SqlQuery<TreeSelectorEntity>(strSql.ToString()).ToList();
                return list;
            }
        }
        */
    }
}