///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: DBWriteTimerMgr.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///     数据库写的对象
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-04-10 19:55:31
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IOServer.BLL
{
    class DBWriteTimerMgr
    {
        private Thread thread;
        private bool isRun;

        public DBWriteTimerMgr()
        {

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }


        private void ThreadSleep(int iMinSec)
        {
            while (iMinSec > 0)
            {
                Thread.Sleep(100);
                iMinSec -= 100;

                if (!isRun)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 数据库插入线程
        /// </summary>
        public void Run()
        {
            while (isRun)
            {
                

                ThreadSleep(CfgMgr.GetInsertDbMinute());
            }
        }
    }
}
