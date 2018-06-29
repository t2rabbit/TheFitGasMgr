using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlareSysEfDbAndModels;

namespace GlareSysDataCenter.MemCfgInfo
{
    class MemCfgInfo
    {
        // 只是占位
    }

    class MemCardWithCommDev
    {
        public GasCardWithCommInfo cardInfo;        
        public MemProjectInfo RefProject;
        public int UpdateFlag;
        public int CurStatus;
        public DateTime dtGetted;
        public string strGettedValues;
    }


    class MemProjectInfo
    {
        public ProjectInfo Project;        
        public Dictionary<int, MemCardWithCommDev> DicCardOfProject = new Dictionary<int, MemCardWithCommDev>();
        public MemGroupInfo RefToMemGroup;
        public int UpdateFlag;
    }

    class MemGroupInfo
    {
        public GroupInfo GroupInfo;
        public Dictionary<int, MemCardWithCommDev> DicCardOGoup = new Dictionary<int, MemCardWithCommDev>();
        public Dictionary<int, MemProjectInfo> DicProject = new Dictionary<int, MemProjectInfo>();
        public MemOrgInfo RefOrg;
        public int UpdateFlag;
    }

    class MemOrgInfo
    {
        public OrgInfo Org;
        public Dictionary<int, MemGroupInfo> DicGroupOfOrg = new Dictionary<int, MemGroupInfo>();
        public Dictionary<int, MemProjectInfo> DicProjectOfOrg = new Dictionary<int, MemProjectInfo>();        
        public Dictionary<int, MemCardWithCommDev> DicCardOfOrg = new Dictionary<int, MemCardWithCommDev>();
        public int UpdateFlag;
    }    
}
