using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Property
{
    class OrgClientStaticInfo
    {
        public int gateid{get;set;}
        public int curstat{get;set;} // 当前状态,1success,0noconn
        public int commtime{get;set;}
        public int commsuccess{get;set;}
        public DateTime dtLastComm{get;set;}
        public int recontimes{get;set;} // 重新连接次数
        public DateTime dtLastConn{get;set;} // 最后连接上时间        
        public float fCommRate 
        { 
            get
            { 
                if (commtime>0)
                {
                    return (float)commsuccess/(float)commtime;
                }
                return 0;
            } 
        }
    }
}

