using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiPublic;

namespace NetLabelMgrWs
{
    /// <summary>
    /// 配置文件读取器，使用单件，那么只需要创建一次对象完成所有的读取
    /// </summary>
    public class CfgMgr
    {
        //
        // 单件类的实现段
        //
        private static object lockObj = new object();
        protected static CfgMgr inst = null;
        protected CfgMgr()
        {

        }

        public static CfgMgr Get()
        {
            lock (lockObj)
            {
                if (inst == null)
                {
                    inst = new CfgMgr();
                    inst.LoadCfg();
                }
                return inst;
            }
        }




        public void LoadCfg()
        {
            sessionUsabelMinutes = ConfigHlper.GetConfig_Int(KeySessionUsableMinus, 60);
            sessionMissMinuts = ConfigHlper.GetConfig_Int(KeySessionMissMinuts, 10);
        }

        //
        // 外部参数接口
        //
        
        /// <summary>
        /// Session有效时间
        /// </summary>
        public int SessionUsabelMinutes
        {
            get
            {
                return sessionUsabelMinutes;
            }
        }

        /// <summary>
        /// session允许的时间误差
        /// </summary>
        public int SessionMissMinuts
        {
            get
            {
                return sessionMissMinuts;
            }
        }








        //
        // 配置参数
        //

        private int sessionUsabelMinutes = 60; 
        private int sessionMissMinuts = 10;

        // 
        // 配置文件的常量定义
        //
        private readonly string KeySessionUsableMinus = "SessionUsableMinus";
        private readonly string KeySessionMissMinuts = "SessionMissMinuts";
        
    }
}