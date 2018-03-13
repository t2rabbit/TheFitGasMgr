///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: GroupMsgBus.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-04-08 4:40:25
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using PiPublic;
using Models;
using Models.UDPMsgBus;

namespace IOServer.BLL
{
    /// <summary>
    /// 使用组播技术的消息总线
    /// </summary>
    public class GroupMsgBus
    {
        private Socket socketGroup;
        private Thread thread;

        public static AutoResetEvent eventReloadDbCmd = new AutoResetEvent(false); 

        public bool Start()
        {

            thread = new Thread(new ThreadStart(Run));
            thread.IsBackground = true;
            thread.Start();
            return true;
        }

        
        /// <summary>
        /// 消息总线启动
        /// </summary>
        /// <returns></returns>
        public void Run()
        {
            try
            {
                socketGroup = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, CfgMgr.GetGroupMsgBusPort());
                EndPoint ep = (EndPoint)iep;
                socketGroup.Bind(iep);
                socketGroup.SetSocketOption(SocketOptionLevel.IP, 
                    SocketOptionName.AddMembership,
                    new MulticastOption(IPAddress.Parse(CfgMgr.GetGroupMsgBusIp())));

                byte[] b = new byte[1024];
                int ilen = socketGroup.ReceiveFrom(b, ref ep);

                string test;
                test = System.Text.Encoding.ASCII.GetString(b, 0, ilen);

                System.Diagnostics.Debug.WriteLine(test);


            }
            catch (System.Exception ex)
            {
            	
            }
        }



        private bool HandleRecMsg(string strMsg)
        {
            UdpMsg msg = JsonStrObjConver.JsonStr2Obj(strMsg, typeof(UdpMsg)) as UdpMsg;
            if (msg == null)
            {
                return false;
            }

            if (msg.StrTo != UdpMsg.ToDefineIoServer)
            {
                return false;
            }

            if (msg.StrMsg == "ReloadDbCmd")
            {
                eventReloadDbCmd.Set();
            }

            return true;
        }
        
    }
        
}
