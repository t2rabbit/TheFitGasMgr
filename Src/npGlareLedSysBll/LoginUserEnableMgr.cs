using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PiPublic.Log;

namespace GlareLedSysBll
{
    public class LoginUserEnableMgr
    {
        Dictionary<string, DateTime> _dicLoginIndexDt = new Dictionary<string, DateTime>();        
        protected LoginUserEnableMgr() { }
        protected static LoginUserEnableMgr _pInst;
        private Thread _thread;
        private bool _bRun;

        public static LoginUserEnableMgr Get()
        {
            if (_pInst == null)
            {
                _pInst = new LoginUserEnableMgr();
                _pInst.StartCheck();
            }

            return _pInst;
        }

        public void Stop()
        {

            _bRun = false;
            if (_thread !=null)
            {
                try
                {
                    if (!_thread.Join(100))
                    {
                        _thread.Abort();
                    }
                    _thread = null;
                }
                catch (Exception)
                {
                    // 不做处理
                }                
            }
        }

        public void StartCheck()
        {
            Stop();
            _thread = new Thread(new ThreadStart(RunCheck));
            _thread.Start();
        }

        private void RunCheck()
        {
            DateTime dtCurTest = DateTime.Now;
            while (_bRun)
            {
                CheckEnable();
                Thread.Sleep(10000);
            }
        }

        private void CheckEnable()
        {
            foreach(var item in _dicLoginIndexDt)
            {
                if (item.Value.AddHours(2) <DateTime.Now)
                {
                    try
                    {
                        _dicLoginIndexDt.Remove(item.Key);     
                    }
                    catch (Exception ex)
                    {
                        //throw;
                    }
                }
            }
        }


        public string InsertANewLogined()
        {
            lock (_pInst)
            {
                string strNewGuid = Guid.NewGuid().ToString();
   

                if (_dicLoginIndexDt.ContainsKey(strNewGuid))
                {
                    LogMgr.WriteErrorDefSys("add new user guid existed...");
                    return strNewGuid;
                }
                else
                {
                    _dicLoginIndexDt.Add(strNewGuid, DateTime.Now);
                }                
                return strNewGuid;
            }
        }

        public bool Logout(string tockId)
        {
            if (_dicLoginIndexDt.ContainsKey(tockId))
            {
                _dicLoginIndexDt.Remove(tockId);
            }

            return true;
        }


        public bool IsLoginIdEnable(string id)
        {
            return _dicLoginIndexDt.ContainsKey(id);
        }

        public void UpdateTockIdTime(string id)
        {
            if (_dicLoginIndexDt.ContainsKey(id))
            {
                _dicLoginIndexDt[id] = DateTime.Now;
            }
        }
    }
}
