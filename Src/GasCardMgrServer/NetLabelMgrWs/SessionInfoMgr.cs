using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace NetLabelMgrWs
{
    public class SessionInfoMgr
    {
        public Dictionary<string, SessionModel> dicSessionByUuid;
        public Dictionary<string, SessionModel> dicSessionByName;

        protected SessionInfoMgr()
        {            
            dicSessionByUuid = new Dictionary<string, SessionModel>();
            dicSessionByName = new Dictionary<string, SessionModel>();
        }
        private static SessionInfoMgr inst;
        public static SessionInfoMgr Get()
        {
            if (inst == null)
            {
                inst = new SessionInfoMgr();
            }
            return inst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strUuid"></param>
        /// <returns></returns>
        public bool CheckSessionByUuid(string strUuid)
        {
            if (!dicSessionByUuid.ContainsKey(strUuid))
            {
                return false;                
            }


            SessionModel sec = dicSessionByUuid[strUuid];
            
            // 现在时间已经超过登录时间N分钟，那么SESSION无效
            // 现在时间比已经登录时间还要小，那么参数出错，SESSION也无效, 为了减少可以利用的时间间隔，间隔定义为10分钟
            if (((DateTime.Now - sec.LoginDt)).TotalMinutes > CfgMgr.Get().SessionUsabelMinutes
                || (DateTime.Now - sec.LoginDt).TotalMinutes < CfgMgr.Get().SessionMissMinuts)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登录成功后，保存最新的登录后的SESSION
        /// </summary>
        /// <param name="userInfo"></param>
        public void AddSession(SysUserInfoModel userInfo)
        {
            // todo 未完成,
            string strFullName = string.Format("{0}_{1}", userInfo.UserType, userInfo.Name);
            if (dicSessionByName.ContainsKey(strFullName))
            {
                SessionModel sess = dicSessionByName[strFullName];
                dicSessionByUuid.Remove(sess.UUID);
                sess.UUID = Guid.NewGuid().ToString("N");
                sess.LoginDt = DateTime.Now;
                dicSessionByUuid.Add(sess.UUID, sess);
            }
            else
            {
                string strUuid = Guid.NewGuid().ToString("N");
                SessionModel sess = new SessionModel()
                {
                    LoginDt = DateTime.Now,
                    UserName = userInfo.Name,
                    UserPassword = userInfo.Password,
                    UUID = strUuid,
                    Version = SessionModel.DefVersion
                };
                dicSessionByUuid.Add(strUuid, sess);
                dicSessionByName.Add(strFullName, sess);
            }            
        }

        /// <summary>
        /// 不删除对象
        /// </summary>
        /// <param name="strUUID"></param>
        public void DeleteSession(string strUUID)
        {
            SessionModel sess = dicSessionByUuid[strUUID];
            if (sess != null)
            {
                dicSessionByUuid.Remove(strUUID);
            }
        }

        /// <summary>
        /// 刷新最后登录时间
        /// </summary>
        /// <param name="strUuid"></param>
        /// <returns></returns>
        public bool UpdateSessionLogdt(string strUuid)
        {
            if (!dicSessionByUuid.ContainsKey(strUuid))
            {
                return false;
            }

            dicSessionByUuid[strUuid].LoginDt = DateTime.Now;
            return true;
        }
    }
}