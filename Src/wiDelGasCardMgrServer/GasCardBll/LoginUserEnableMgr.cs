using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GlareLedSysBll
{
    class LoginUserEnableMgr
    {
        Dictionary<int, DateTime> _dicLoginIndexDt = new Dictionary<int, DateTime>();
        private int _baseLoginIndex = 600000;
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


        public int InsertANewLogined()
        {
            lock (_pInst)
            {
                Random rd = new Random();
                _baseLoginIndex += rd.Next(1, 10);
                while (true)
                {
                    if(!_dicLoginIndexDt.ContainsKey(_baseLoginIndex))
                    {
                        break;
                    }
                    else
                    {
                        _baseLoginIndex += 1;
                    }
                }

                if (_dicLoginIndexDt.ContainsKey(_baseLoginIndex))
                {
                    _dicLoginIndexDt[_baseLoginIndex] = DateTime.Now;
                }
                else
                {
                    _dicLoginIndexDt.Add(_baseLoginIndex, DateTime.Now);
                }                
                return _baseLoginIndex;
            }
        }

        public bool Logout(int tockId)
        {
            if (_dicLoginIndexDt.ContainsKey(tockId))
            {
                _dicLoginIndexDt.Remove(tockId);
            }

            return true;
        }


        public bool IsLoginIdEnable(int id)
        {
            return _dicLoginIndexDt.ContainsKey(id);
        }

        public void UpdateTockIdTime(int id)
        {
            if (_dicLoginIndexDt.ContainsKey(id))
            {
                _dicLoginIndexDt[id] = DateTime.Now;
            }
        }
    }
}
