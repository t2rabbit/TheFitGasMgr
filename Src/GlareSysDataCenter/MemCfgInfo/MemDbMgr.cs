using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlareSysEfDbAndModels;
using GlareLedSysBll;
using PiPublic.Log;

namespace GlareSysDataCenter.MemCfgInfo
{
    class MemDbMgr
    {
        static int RunTest = 1000;
        private static MemDbMgr _inst = null;
        protected MemDbMgr() { }
        public static MemDbMgr Get()
        {
            if (_inst == null)
            {
                _inst = new MemDbMgr();
            }
            return _inst;
        }

        public int GetRtuTest()
        {
            return RunTest++;
        }


        //private List<MemOrgInfo> lstMemOrgWithAllInfo = new List<MemOrgInfo>();
        //private List<MemGroupInfo> lstMemGroupWithAllInfo = new List<MemGroupInfo>();
        //private List<MemProjectInfo> lstMemPrjWithAllInfo = new List<MemProjectInfo>();
        //private List<MemCommDev> lstMemCommWithAllInfo = new List<MemCommDev>();
        //private List<MemCardInfo> lstMemCardWithAllInfo = new List<MemCardInfo>();

        public Dictionary<int, MemOrgInfo> dicMemOrgWithAllInfo = new Dictionary<int, MemOrgInfo>();
        public Dictionary<int, MemGroupInfo> dicMemGroupWithAllInfo = new Dictionary<int, MemGroupInfo>();
        public Dictionary<int, MemProjectInfo> dicMemPrjWithAllInfo = new Dictionary<int, MemProjectInfo>();
        public Dictionary<int, MemCardWithCommDev> dicMemCardWithAllInfo = new Dictionary<int, MemCardWithCommDev>();        
        public Dictionary<string, MemCardWithCommDev> dicMemCardWithAllInfoByClientSn = new Dictionary<string, MemCardWithCommDev>();

        // 临时使用的
        private List<OrgInfo> lstOrgsByDb;
        private List<GroupInfo> lstGroupsByDb;
        private List<ProjectInfo> lstProjectsByDb;
        private List<GasCardWithCommInfo> lstCardsByDb;        

        private int _loadFlag = 0;
        public void Load()
        {
            lstOrgsByDb = OrgBll.GetAllOrgInfo();
            lstGroupsByDb = GroupBll.GetAllGroupInfo();
            lstProjectsByDb = ProjectBll.GetAllProject();
            lstCardsByDb = CardWithCommDevBll.GetAllDevList();            

            MakeMemCard(_loadFlag);
            MakeMemProject(_loadFlag);
            MakeMemGroup(_loadFlag);
            MakeMemOrg(_loadFlag);

            MakeMemCommByClientSn(_loadFlag);

            MakeCardRef();
            MakeProjectRef();
            MakeGroupRef();
            MakeOrgRef();

            lstOrgsByDb.Clear();
            lstGroupsByDb.Clear();
            lstProjectsByDb.Clear();            
            lstCardsByDb.Clear();
        }

        public MemProjectInfo GetMemProjectByName(string strName)
        {
            foreach (var item in dicMemPrjWithAllInfo)
            {
                if (item.Value.Project.ProjectName == strName)
                {
                    return item.Value;
                }
            }
            return null;
        }

        private void MakeMemCard(int iUpdateFlag)
        {
            foreach (var item in lstCardsByDb)
            {
                if (dicMemCardWithAllInfo.ContainsKey(item.Id))
                {                    
                    MemCardWithCommDev mem = dicMemCardWithAllInfo[item.Id];
                    mem.UpdateFlag = iUpdateFlag;
                    if (mem.cardInfo.UpdateDt.Value != item.UpdateDt)
                    {
                        mem.cardInfo = item; // 更新
                        // todo 可能会造成内存泄漏，一直有部分list没有删除
                    }
                }
                else
                {
                    MemCardWithCommDev aNewMemCard = new MemCardWithCommDev()
                    {
                        cardInfo = item,
                        RefProject = null,
                        UpdateFlag = iUpdateFlag
                    };
                    dicMemCardWithAllInfo.Add(aNewMemCard.cardInfo.Id, aNewMemCard);
                }
            }
        }        

        private void MakeMemCommByClientSn(int iUpdateFlag)
        {
            foreach (var item in dicMemCardWithAllInfo)
            {
                if (item.Value.UpdateFlag == iUpdateFlag)
                {
                    if (dicMemCardWithAllInfoByClientSn.ContainsKey(item.Value.cardInfo.CommServerSn))
                    {
                        dicMemCardWithAllInfoByClientSn[item.Value.cardInfo.CommServerSn] = item.Value;
                    }
                    else
                    {
                        dicMemCardWithAllInfoByClientSn.Add(item.Value.cardInfo.CommServerSn, item.Value);
                    }
                }
            }
        }

        private void MakeMemProject(int iUpdateFlag)
        {
            foreach (var item in lstProjectsByDb)
            {
                if (dicMemPrjWithAllInfo.ContainsKey(item.Id))
                {
                    MemProjectInfo mem = dicMemPrjWithAllInfo[item.Id];
                    mem.UpdateFlag = iUpdateFlag;
                    if (mem.Project.UpdateDt != item.UpdateDt)
                    {
                        mem.Project = item; // 更新
                        // todo 可能会造成内存泄漏，一直有部分list没有删除
                    }
                }
                else
                {
                    MemProjectInfo aNewMemObj = new MemProjectInfo()
                    {
                         Project = item,
                        //DicCardOfProject = new Dictionary<int, MemCardInfo>(),
                        //DicCommDevOfProject =  new Dictionary<int, MemCommDev>(),
                        UpdateFlag = iUpdateFlag
                    };
                    dicMemPrjWithAllInfo.Add(item.Id, aNewMemObj);
                }
            }
        }

        private void MakeMemGroup(int iUpdateFlag)
        {
            foreach (var item in lstGroupsByDb)
            {
                if (dicMemGroupWithAllInfo.ContainsKey(item.Id))
                {
                    MemGroupInfo mem = dicMemGroupWithAllInfo[item.Id];
                    mem.UpdateFlag = iUpdateFlag;
                    if (mem.GroupInfo.UpdateDt != item.UpdateDt)
                    {
                        mem.GroupInfo = item; // 更新
                        // todo 可能会造成内存泄漏，一直有部分list没有删除
                    }
                }
                else
                {
                    MemGroupInfo aNewMemObj = new MemGroupInfo()
                    {
                        GroupInfo = item,
                        RefOrg = null,
                        //DicCardOfProject = new Dictionary<int, MemCardInfo>(),
                        //DicCommDevOfProject =  new Dictionary<int, MemCommDev>(),
                        UpdateFlag = iUpdateFlag
                    };
                    dicMemGroupWithAllInfo.Add(item.Id, aNewMemObj);
                }
            }

        }
        private void MakeMemOrg(int iUpdateFlag)
        {
            foreach (var item in lstOrgsByDb)
            {
                if (dicMemOrgWithAllInfo.ContainsKey(item.Id))
                {
                    MemOrgInfo mem = dicMemOrgWithAllInfo[item.Id];
                    mem.UpdateFlag = iUpdateFlag;
                    if (mem.Org.UpdateDt != item.UpdateDt)
                    {
                        mem.Org = item; // 更新
                        // todo 可能会造成内存泄漏，一直有部分list没有删除
                    }
                }
                else
                {
                    MemOrgInfo aNewMemObj = new MemOrgInfo()
                    {
                        Org = item,
                        //DicCardOfProject = new Dictionary<int, MemCardInfo>(),
                        //DicCommDevOfProject =  new Dictionary<int, MemCommDev>(),
                        UpdateFlag = iUpdateFlag
                    };
                    dicMemOrgWithAllInfo.Add(item.Id, aNewMemObj);
                }
            }
        }
   

        private void MakeCardRef()
        {
            // 设置自己的直接父亲，也就是工程
            foreach (var item in dicMemCardWithAllInfo)
            {                
                if (dicMemPrjWithAllInfo.ContainsKey(item.Value.cardInfo.ProjectId.Value))
                {
                    item.Value.RefProject = dicMemPrjWithAllInfo[item.Value.cardInfo.ProjectId.Value];
                }
                else
                {
                    LogMgr.WriteErrorDefSys("com has not project Info card id is:" + item.Value.cardInfo.Id
                        + " ,name is:" + item.Value.cardInfo.Name);
                }
            }
        }

        private void MakeProjectRef()
        {
            // 设置自己的父亲，也就是项目组（区域）
            foreach (var item in dicMemPrjWithAllInfo)
            {
                if (dicMemGroupWithAllInfo.ContainsKey(item.Value.Project.GroupId.Value))
                {
                    item.Value.RefToMemGroup = dicMemGroupWithAllInfo[item.Value.Project.GroupId.Value];
                }
                else
                {
                    LogMgr.WriteErrorDefSys("project has not group Info project id is:" + item.Value.Project.Id
                        + " ,name is:" + item.Value.Project.ProjectName);
                }
            }
            
            
            // 该工程下所有的卡
            foreach (var item in dicMemCardWithAllInfo)
            {
                if (!dicMemPrjWithAllInfo.ContainsKey(item.Value.cardInfo.ProjectId.Value))
                    continue;

                if (dicMemPrjWithAllInfo[item.Value.cardInfo.ProjectId.Value].DicCardOfProject.ContainsKey(item.Value.cardInfo.Id))
                {
                    dicMemPrjWithAllInfo[item.Value.cardInfo.ProjectId.Value].DicCardOfProject[item.Value.cardInfo.Id] = item.Value;
                }
                else
                {
                    dicMemPrjWithAllInfo[item.Value.cardInfo.ProjectId.Value].DicCardOfProject.Add(item.Value.cardInfo.Id, item.Value);
                }
            }

        }
        private void MakeGroupRef()
        {
            // 设置自己的父亲，也就是集团
            foreach (var item in dicMemGroupWithAllInfo)
            {
                if (dicMemOrgWithAllInfo.ContainsKey(item.Value.GroupInfo.OrgId.Value))
                {
                    item.Value.RefOrg = dicMemOrgWithAllInfo[item.Value.GroupInfo.OrgId.Value];
                }
                else
                {
                    LogMgr.WriteErrorDefSys("group has not org Info group id is:" + item.Value.GroupInfo.Id
                        + " ,name is:" + item.Value.GroupInfo.GroupName);
                }
            }

            // 该区域下所有的工程
            foreach (var item in dicMemPrjWithAllInfo)
            {
                if (!dicMemGroupWithAllInfo.ContainsKey(item.Value.Project.GroupId.Value))
                    continue;

                if (dicMemGroupWithAllInfo[item.Value.Project.GroupId.Value].DicProject.ContainsKey(item.Value.Project.Id))
                {
                    dicMemGroupWithAllInfo[item.Value.Project.GroupId.Value].DicProject[item.Value.Project.Id] = item.Value;
                }
                else
                {
                    dicMemGroupWithAllInfo[item.Value.Project.GroupId.Value].DicProject.Add(item.Value.Project.Id, item.Value);
                }
            }
            // 该区域下所有的卡
            foreach (var item in dicMemCardWithAllInfo)
            {
                if (!dicMemGroupWithAllInfo.ContainsKey(item.Value.cardInfo.GroupId.Value))
                    continue;

                if (dicMemGroupWithAllInfo[item.Value.cardInfo.GroupId.Value].DicCardOGoup.ContainsKey(item.Value.cardInfo.Id))
                {
                    dicMemGroupWithAllInfo[item.Value.cardInfo.GroupId.Value].DicCardOGoup[item.Value.cardInfo.Id] = item.Value;
                }
                else
                {
                    dicMemGroupWithAllInfo[item.Value.cardInfo.GroupId.Value].DicCardOGoup.Add(item.Value.cardInfo.Id, item.Value);
                }
            }
        }
        private void MakeOrgRef()
        {
            // 该集团下所有的区域
            foreach (var item in dicMemGroupWithAllInfo)
            {
                if (!dicMemOrgWithAllInfo.ContainsKey(item.Value.GroupInfo.OrgId.Value))
                    continue;

                if (dicMemOrgWithAllInfo[item.Value.GroupInfo.OrgId.Value].DicGroupOfOrg.ContainsKey(item.Value.GroupInfo.Id))
                {
                    dicMemOrgWithAllInfo[item.Value.GroupInfo.OrgId.Value].DicGroupOfOrg[item.Value.GroupInfo.Id] = item.Value;
                }
                else
                {
                    dicMemOrgWithAllInfo[item.Value.GroupInfo.OrgId.Value].DicGroupOfOrg.Add(item.Value.GroupInfo.Id, item.Value);
                }
            }

            // 该集团下所有的工程
            foreach (var item in dicMemPrjWithAllInfo)
            {
                if (!dicMemOrgWithAllInfo.ContainsKey(item.Value.Project.OrgId.Value))
                    continue;

                if (dicMemOrgWithAllInfo[item.Value.Project.OrgId.Value].DicProjectOfOrg.ContainsKey(item.Value.Project.Id))
                {
                    dicMemOrgWithAllInfo[item.Value.Project.OrgId.Value].DicProjectOfOrg[item.Value.Project.Id] = item.Value;
                }
                else
                {
                    dicMemOrgWithAllInfo[item.Value.Project.OrgId.Value].DicProjectOfOrg.Add(item.Value.Project.Id, item.Value);
                }
            }
            // 该区域下所有的卡
            foreach (var item in dicMemCardWithAllInfo)
            {
                if (!dicMemOrgWithAllInfo.ContainsKey(item.Value.cardInfo.OrgId.Value))
                    continue;

                if (dicMemOrgWithAllInfo[item.Value.cardInfo.OrgId.Value].DicCardOfOrg.ContainsKey(item.Value.cardInfo.Id))
                {
                    dicMemOrgWithAllInfo[item.Value.cardInfo.OrgId.Value].DicCardOfOrg[item.Value.cardInfo.Id] = item.Value;
                }
                else
                {
                    dicMemOrgWithAllInfo[item.Value.cardInfo.OrgId.Value].DicCardOfOrg.Add(item.Value.cardInfo.Id, item.Value);
                }
            }
        }
    }
}
