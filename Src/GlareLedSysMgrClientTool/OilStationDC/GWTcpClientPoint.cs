//
// File
//  GWTcpClientPoint.cs
//  TCP客户端对象，当服务器接收到远程数据网关的连接后，会创建此对象
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using YD_PUBLIC.Log;
using YD_PUBLIC;
using YDesmsPublicDefDll;
using System.IO;
using DBSqlite;
using Property.DB;

namespace Property
{
    //
    // TCP客户端对象，当服务器接收到远程数据网关的连接后，会创建此对象
    // 对象创建后定时读取数据，分析命令 
    //
    //
	class GWTcpClientPoint
	{
        bool m_bGprs = false;
		int iClientID = 0;
		static public int curID_Test = 0;
        TcpClient m_tcpClient;
        public GL_Org m_org;

		public GWTcpClientPoint()
		{
			iClientID = curID_Test ++;
		}

        public bool Open()
        {
            return (m_tcpClient != null && m_tcpClient.Connected);
        }

        public bool IsOpen()
        {
            return (m_tcpClient != null && m_tcpClient.Connected);
        }
        public bool Close()
        {
            if (m_org!=null)
            {
                //DataCenterObject.Get().SetConnStatus(m_GatewayInfo.ID, 0);
            }
            m_tcpClient.Close();
            return true;
        }


        byte[] m_bRecBuf = new Byte[10240];
		public string Read(int iTimeout = 50)
		{
            if (m_org != null)
            {
                DataCenterObject.Get().AddCommTimeNoCheck(m_org.ID);
            }

			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
				return null;
			}
			NetworkStream stream = m_tcpClient.GetStream();
			
			String responseData = String.Empty;
			DateTime dtNow = DateTime.Now;
			bool bReadAble = false;
			try
			{
				while (iTimeout > 0)
				{
					if (stream.DataAvailable)
					{
						bReadAble = true;
						break;
					}

                    iTimeout -= 10;
					Thread.Sleep(10);
				}

				if (!bReadAble)
				{
					return null;
				}

				Int32 iReadedLen = stream.Read(m_bRecBuf, 0, m_bRecBuf.Length);
				if (iReadedLen <= 0)
				{
					return "";
				}

		
                if (m_org != null)
                {
                    DataCenterObject.Get().AddCommSuccessTime(m_org.ID);
                }

                if (iReadedLen>10 * 1024)
                {
                    FileLog.WriteLog("read error.... len:" + iReadedLen);
                    return "";
                }

                string recData = Encoding.UTF8.GetString(m_bRecBuf, 0, iReadedLen);

                Program.AddDevMsg(ConstDef.strLogDCClient, "read", "", "", DateTime.Now.ToString(), recData);
                return recData;

			}
			catch (System.Exception ex)
			{
                FileLog.WriteLog("tcpclient Read ex:" + ex.Message);
				return null;
			}
			finally
			{
			}
		}

#region 处理命令函数段
        /// <summary>
        /// 获取认证原始码，第一次认证需要用户的PC码
        /// </summary>
        /// <param name="strRec"></param>
        /// <returns></returns>
        bool Hlp_getauthsn(string strRec)
        {
            object cmdobj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendGetAuthSN));
            CmdSendGetAuthSN getsn = cmdobj as CmdSendGetAuthSN;
            if (getsn == null)
            {
                return false;
            }

            GL_Org dw = (from c in DB.MemDB.Get().lstOrg where c.ID == getsn.gateid select c).FirstOrDefault();
            if (dw == null)
            {
                return false;
            }

            if (dw.PCSN != getsn.pcsn)
            {
                return false;
            }

            m_org = dw;
            RepRecGetAuthSN rep = new RepRecGetAuthSN()
            {
                gateid = (int)dw.ID,
                rep = "ok",
                sn = DCGWCommStructs.MakeSnByGateid(getsn.gateid),
                tranid = getsn.tranid,
            };

            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecGetAuthSN));
            Write(strRep);
            return true;
        }

        /// <summary>
        /// 第二次合法性认证，算法加密匹配程序合法性
        /// </summary>
        /// <param name="strRec"></param>
        /// <returns></returns>
        bool Hlp_checkauthsn(string strRec)
        {
            object cmdobj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendCheckAuthSN));
            CmdSendCheckAuthSN getsn = cmdobj as CmdSendCheckAuthSN;
            if (getsn == null)
            {
                return false;
            }

            RepRecDef rep = new RepRecDef()
            {
                tranid = getsn.tranid,
                rep = "ok",
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            m_org = (from c in DB.MemDB.Get().lstOrg where c.ID == getsn.gateid select c).SingleOrDefault();
            return true;
        }

        /// <summary>
        /// 心跳检测处理函数
        /// </summary>
        /// <param name="strRec"></param>
        /// <returns></returns>
        bool Hlp_keepal(string strRec)
        {
            object cmdobj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendKeepAL));
            CmdSendKeepAL getsn = cmdobj as CmdSendKeepAL;
            if (getsn == null)
            {
                return false;
            }

            RepRecDef rep = new RepRecDef()
            {

                tranid = getsn.tranid,
                rep = "ok",
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            return true;
        }


        bool Hlp_getdevs(string strRec)
        {            
            CmdGetDevs cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetDevs)) as CmdGetDevs;
            if (cmdObj == null)
            {
                return false;
            }

            bool bAllDev = false;
            GL_Org aOrg = (from c in DB.MemDB.Get().lstOrg where c.ID == cmdObj.gateid select c).First();
            if (aOrg.OrgLevel > 0)
            {
                bAllDev = true;
            }
            //
            // 获取devs
            //            
            IList<GL_Dev> lstDev = null;
            if (bAllDev)
                lstDev = (from c in DB.MemDB.Get().lstDev select c).ToList();
            else
                lstDev = (from c in DB.MemDB.Get().lstDev where c.OrgID == cmdObj.gateid select c).ToList();

            List<JsonDev> lstJsonDev = new List<JsonDev>();
            foreach (GL_Dev aDev in lstDev )
            {
                JsonDev aJsonDev = new JsonDev()
                {
                    Baud = (aDev.SerialBaud==null?0:(int)aDev.SerialBaud),
                    BEnable = (aDev.BEnable==null?0:(int)aDev.BEnable),
                    Comment = aDev.Comment,
                    CommPort = aDev.SerialPort,
                    DevServerPort = (aDev.DevServerPort==null?0:(int)aDev.DevServerPort),
                    CommType = (aDev.CommType==null?0:(int)aDev.CommType),
                    DataBit = (aDev.SerialDataBit==null?0:(int)aDev.SerialDataBit),
                    DevClientName = aDev.DevClientName,
                    DevServerIP = aDev.DevServerIP,
                    ID = (int)aDev.ID,
                    lstModel = null,
                    Name = aDev.Name,
                    OrgID = (aDev.OrgID==null?0:(int)aDev.OrgID ),
                    Parity = (aDev.SerialParity==null?0:(int)aDev.SerialParity),
                    Protocol = (aDev.Protocol==null?0:(int)aDev.Protocol),
                    StopBit = (aDev.SerialStopBit==null?0:(int)aDev.SerialStopBit),
                    TimeOut = (aDev.Timeout==null?100:(int)aDev.Timeout),
                };
                lstJsonDev.Add(aJsonDev);
            }


            RepGetDevs rep = new RepGetDevs()
            {
                tranid = cmdObj.tranid,
                rep = "ok",
                data = lstJsonDev,
                gateid = cmdObj.gateid,
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDevs));
            Write(strRep);
            return true;
        }



        bool Hlp_getorgs(string strRec)
        {
            CmdGetOrgs cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetOrgs)) as CmdGetOrgs;
            if (cmdObj == null)
            {
                return false;
            }

            bool bAllDev = false;
            
            //
            // 获取devs
            //            
            IList<GL_Org> lstDev = null;                       
            lstDev = (from c in DB.MemDB.Get().lstOrg select c).ToList();

            List<JsonOrgInfo> lstJsonDev = new List<JsonOrgInfo>();
            foreach (GL_Org aDev in lstDev)
            {
                JsonOrgInfo aJsonDev = new JsonOrgInfo()
                {
                    City = aDev.City,
                    Country = aDev.Country,
                    ID = (int)aDev.ID,
                    Manager = aDev.Manager,
                    MPhoneNo = aDev.MPhoneNO,
                    Name = aDev.Name,
                    NoOfStreet = aDev.NoOfStreet,
                    Password = aDev.Password,
                    PcSN = aDev.PCSN,
                    PhoneNo = aDev.PhoneNo,
                    Provice = aDev.Provice,
                    Stree = aDev.Street,
                    Tel = aDev.Tel,
                    Web = aDev.Web
                };
                lstJsonDev.Add(aJsonDev);
            }


            RepGetOrgs rep = new RepGetOrgs()
            {
                tranid = cmdObj.tranid,
                rep = "ok",
                data = lstJsonDev,
                gateid = cmdObj.gateid,
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetOrgs));
            Write(strRep);
            return true;
        }

        bool Hlp_getdevbyid(string strRec)
        {
            CmdGetDevByID cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetDevByID)) as CmdGetDevByID;
            if (cmdObj == null)
            {
                return false;
            }

            //
            // 获取devs
            //            
            IList<GL_Dev> lstDev = (from c in DB.MemDB.Get().lstDev where c.OrgID == cmdObj.gateid && c.ID == cmdObj.devid select c).ToList();
            JsonDev aJsonDev = null;
            if (lstDev.Count == 1 )
            {
                aJsonDev = new JsonDev()
                {
                    Baud = (int)lstDev[0].SerialBaud,
                    BEnable = (int)lstDev[0].BEnable,
                    Comment = lstDev[0].Comment,
                    CommPort = lstDev[0].SerialPort,
                    DevServerPort = (int)lstDev[0].DevServerPort,
                    CommType = (int)lstDev[0].CommType,
                    DataBit = (int)lstDev[0].SerialDataBit,
                    DevClientName = lstDev[0].DevClientName,
                    DevServerIP = lstDev[0].DevServerIP,
                    ID = (int)lstDev[0].ID,
                    lstModel = null,
                    Name = lstDev[0].Name,
                    OrgID = (int)lstDev[0].OrgID,
                    Parity = (int)lstDev[0].SerialParity,
                    Protocol = (int)lstDev[0].Protocol,
                    StopBit = (int)lstDev[0].SerialStopBit,
                    TimeOut = (int)lstDev[0].Timeout,
                };
            }
            

            RepGetDevByID rep = new RepGetDevByID()
            {
                tranid = cmdObj.tranid,
                rep = aJsonDev==null?"error-no-or-more":"ok",
                data = aJsonDev,
                gateid = cmdObj.gateid,
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDevs));
            Write(strRep);
            return true;
        }

        bool Hlp_getledcards(string strRec)
        {
            CmdGetLedCards cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetLedCards)) as CmdGetLedCards;
            if (cmdObj == null)
            {
                return false;
            }

            //
            // 获取devs
            // 
            bool bAllDev = false;
            GL_Org aOrg = (from c in DB.MemDB.Get().lstOrg where c.ID == cmdObj.gateid select c).First();
            if (aOrg.OrgLevel > 0)
            {
                bAllDev = true;
            }
            IList<GL_LedCard> lstDev = null;
            if (bAllDev)
                lstDev = (from c in DB.MemDB.Get().lstCard select c).ToList();
            else
                lstDev = (from c in DB.MemDB.Get().lstCard where c.OrgID == cmdObj.gateid select c).ToList();
            List<JsonLEDCard> lstJsonDev = new List<JsonLEDCard>();
            foreach (GL_LedCard aDev in lstDev)
            {
                JsonLEDCard aJsonDev = new JsonLEDCard()
                {
                    Addr = (int)aDev.Addr,
                    Brightness = (int)aDev.Brightness,
                    CardModule = aDev.CardModule,
                    CardType = aDev.CardType,
                    DevID = (int)aDev.DevID,
                    ID = (int)aDev.ID,
                    IsDouble = (int)aDev.IsDouble,
                    Name = aDev.Name,
                    OrgID = (int)aDev.OrgID,
                    ScreenCount = (int)aDev.ScreenCount,
                    ScreentContext = aDev.ScreentContext,
                    DecimalInfo = aDev.DecimalInfo,
                    NumberCount = (int)aDev.NumberCount,

                };
                lstJsonDev.Add(aJsonDev);
            }


            RepGetLedCards rep = new RepGetLedCards()
            {
                tranid = cmdObj.tranid,
                rep = "ok",
                data = lstJsonDev,
                gateid = cmdObj.gateid,
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetLedCards));
            Write(strRep);
            return true;
        }
        
        bool Hlp_getledcardbyid(string strRec)
        {
            CmdGetLedCardByID cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetLedCardByID)) as CmdGetLedCardByID;
            if (cmdObj == null)
            {
                return false;
            }

            //
            // 获取devs
            //            
            IList<GL_LedCard> lstDev = (from c in DB.MemDB.Get().lstCard where c.OrgID == cmdObj.gateid && c.ID == cmdObj.ledcardid select c).ToList();
            JsonLEDCard aJsonDev = null;
            if (lstDev.Count == 1)
            {
                aJsonDev = new JsonLEDCard()
                {
                    Addr = (int)lstDev[0].Addr,
                    Brightness = (int)lstDev[0].Brightness,
                    CardModule = lstDev[0].CardModule,
                    CardType = lstDev[0].CardType,
                    DevID = (int)lstDev[0].DevID,
                    ID = (int)lstDev[0].ID,
                    IsDouble = (int)lstDev[0].IsDouble,
                    Name = lstDev[0].Name,
                    OrgID = (int)lstDev[0].OrgID,
                    ScreenCount = (int)lstDev[0].ScreenCount,
                    ScreentContext = lstDev[0].ScreentContext,
                    DecimalInfo = lstDev[0].DecimalInfo,
                    NumberCount = (int)lstDev[0].NumberCount,
                };
            }

            RepGetLedCardByID rep = new RepGetLedCardByID()
            {
                tranid = cmdObj.tranid,
                rep = aJsonDev == null ? "error-no-or-more" : "ok",
                data = aJsonDev,
                gateid = cmdObj.gateid,
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDevs));
            Write(strRep);
            return true;
        }

        bool Hlp_updatedev(string strRec)
        {
            CmdUpdateDevInfo cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdUpdateDevInfo)) as CmdUpdateDevInfo;
            if (cmdObj == null)
            {
                return false;
            }

            //
            // 获取devs
            //            
            GL_Dev aDev = new GL_Dev()
            {
                SerialBaud = (int)cmdObj.info.Baud,
                BEnable = (int)cmdObj.info.BEnable,
                Comment = cmdObj.info.Comment,
                SerialPort= cmdObj.info.CommPort,
                DevServerPort = (int)cmdObj.info.DevServerPort,
                CommType = (int)cmdObj.info.CommType,
                SerialDataBit = (int)cmdObj.info.DataBit,
                DevClientName = cmdObj.info.DevClientName,
                DevServerIP = cmdObj.info.DevServerIP,
                ID = (int)cmdObj.info.ID,                
                Name = cmdObj.info.Name,
                OrgID = (int)cmdObj.info.OrgID,
                SerialParity = (int)cmdObj.info.Parity,
                Protocol = (int)cmdObj.info.Protocol,
                SerialStopBit = (int)cmdObj.info.StopBit,
                Timeout = (int)cmdObj.info.TimeOut,
            };

            bool bUpdate = DB.MemDB.Get().UpdateDev(cmdObj.devid, aDev);

            RepRecDef rep = new RepRecDef()
            {
                tranid = cmdObj.tranid,
                rep = bUpdate?"ok":"error",
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDevs));
            Write(strRep);
            return true;
        }

        bool Hlp_updateledcard(string strRec)
        {
            CmdUpdateLedCard cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdUpdateLedCard)) as CmdUpdateLedCard;
            if (cmdObj == null)
            {
                return false;
            }

            //
            // 获取devs
            //            
            GL_LedCard aDev = new GL_LedCard()
            {
                Addr = cmdObj.info.Addr,
                Brightness = cmdObj.info.Brightness,
                CardModule = cmdObj.info.CardModule,
                CardType = cmdObj.info.CardType,
                DevID = cmdObj.info.DevID,
                IsDouble= cmdObj.info.IsDouble,
                Name = cmdObj.info.Name,
                OrgID = cmdObj.info.OrgID,
                ScreenCount = cmdObj.info.ScreenCount,
                ScreentContext = cmdObj.info.ScreentContext,
                DecimalInfo = cmdObj.info.DecimalInfo,
                NumberCount = cmdObj.info.NumberCount,
            };

            bool bUpdate = DB.MemDB.Get().UpdateCard(cmdObj.ledcardid, aDev);

            RepRecDef rep = new RepRecDef()
            {
                tranid = cmdObj.tranid,
                rep = bUpdate ? "ok" : "error",
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            return true;
        }


        bool Hlp_Login(string strRec)
        {
//             CmdSendLogin cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendLogin)) as CmdSendLogin;
//             if (cmdObj == null)
//             {
//                 return false;
//             }
//             GL_SystemUser aUser = (from c in MemDB.Get().lstSystemUser where cmdObj.username == c.Name && cmdObj.password == c.Password && cmdObj.gateid == c.OrgID select c).FirstOrDefault();
//             bool bLogin = false;
//             if (aUser == null)
//             {
// 
//             }
//             else
//             {
// 
//             }
            return true;
        }

        bool Hlp_getdevstatus(string strRec)
        {
            LogMgr.WriteLog(strRec);
            CmdGetDevStatus cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetDevStatus)) as CmdGetDevStatus;
            if (cmdObj == null)
            {
                LogMgr.WriteLog("Hlp_getdevstatus param error....");
                return false;
            }

            //
            // 获取dev status
            // 
            string strInfo = "";
            try
            {

                foreach (GL_Dev aDev in MemDB.Get().lstDev)
                {
                    bool bConned = TcpServerForGPRSDev.Get().GetDevIsConnected((int)aDev.ID);
                    if (strInfo.Length > 0)
                    {
                        strInfo += ",";
                    }
                    strInfo += aDev.ID.ToString() + ":" + (bConned ? "1" : "0");

                    //LogMgr.WriteLog(strInfo);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
           
            RepGetDevStatus rep = new RepGetDevStatus()
            {
                tranid = cmdObj.tranid,
                gateid = cmdObj.gateid,
                info = strInfo,
                rep = "ok"               
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDevStatus));
            Write(strRep);

            LogMgr.WriteLog(strRep);
            return true;
        }

        // 发送卡neritic
        bool Hlp_sendcardoilval(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            CmdSendOilVal cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendOilVal)) as CmdSendOilVal;
            if (cmdObj == null)
            {
                return false;
            }
            
            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null )
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {               
                IList<string> lstStrConext = GLLedProtocol.MakeStringListByContext(cmdObj.data);
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT) 
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {                        
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.SendOilContext((int)cmdObj.cardaddr, lstStrConext))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }

            }
            


            RepRecDef rep = new RepRecDef()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg ),
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            return true;
        }


        // 发送卡neritic
        bool Hlp_getcardoilval(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            string strVals = "";
            CmdGetOilVal cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetOilVal)) as CmdGetOilVal;
            if (cmdObj == null)
            {
                return false;
            }

            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null)
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {
                //IList<string> lstStrConext = GLLedProtocol.MakeStringListByContext(cmdObj.data);
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.ReadOilValString((int)cmdObj.cardaddr, ref strVals))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }
            }



            RepGetOilVal rep = new RepGetOilVal()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg),
                data = strVals,
                gateid = cmdObj.gateid
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetOilVal));
            Write(strRep);
            return true;
        }



        // 发送卡小数点
        bool Hlp_sendcarddot(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            CmdSendCardDot cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSendCardDot)) as CmdSendCardDot;
            if (cmdObj == null)
            {
                return false;
            }

            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null)
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {
                //IList<string> lstStrConext = GLLedProtocol.MakeStringListByContext(cmdObj.data);
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.SendOilDot((int)cmdObj.cardaddr, cmdObj.data))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }

            }



            RepRecDef rep = new RepRecDef()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg),
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            return true;
        }


        // 获取卡的小数点
        bool Hlp_getcardDot(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            string strVals = "";
            CmdGetCardDot cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetCardDot)) as CmdGetCardDot;
            if (cmdObj == null)
            {
                return false;
            }

            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null)
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.ReadLedDotValString((int)cmdObj.cardaddr, ref strVals))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }
            }



            RepGetDotInfo rep = new RepGetDotInfo()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg),
                data = strVals,
                gateid = cmdObj.gateid
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetDotInfo));
            Write(strRep);
            return true;
        }


        // 获取卡的配置信息
        bool Hlp_getcardcfg(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            string strVals = "";
            CmdGetLedCardCfg cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdGetLedCardCfg)) as CmdGetLedCardCfg;
            if (cmdObj == null)
            {
                return false;
            }

            JsonCardCfg cfg = new JsonCardCfg();

            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null)
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.GetLedCfg((int)cmdObj.cardaddr, ref cfg))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }
            }



            RepGetLedCardCfg rep = new RepGetLedCardCfg()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg),
                data = cfg,
                gateid = cmdObj.gateid
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepGetLedCardCfg));
            Write(strRep);
            return true;
        }


        // 发送卡配置
        bool Hlp_sendcardcfg(string strRec)
        {
            bool bSendSuccess = false;
            string strMsg = "";
            CmdSetLedCardCfg cmdObj = JsonStrObjConver.JsonStr2Obj(strRec, typeof(CmdSetLedCardCfg)) as CmdSetLedCardCfg;
            if (cmdObj == null)
            {
                return false;
            }

            GL_Dev aDev = (from c in DB.MemDB.Get().lstDev where c.ID == cmdObj.devid select c).FirstOrDefault();
            if (aDev == null)
            {
                strMsg = "not def dev...";
                bSendSuccess = false;
            }
            else
            {
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        strMsg = "TCP/GPRS not connected...";
                        bSendSuccess = false;
                    }
                    else
                    {
                        if (aTcpClient.SetLedCfg((int)cmdObj.cardaddr, cmdObj.cfg))
                        {
                            bSendSuccess = true;
                        }
                        else
                        {
                            strMsg = "not define...";
                            bSendSuccess = false;
                        }
                    }
                }

            }



            RepRecDef rep = new RepRecDef()
            {
                tranid = cmdObj.tranid,
                rep = (bSendSuccess ? "ok" : "error" + strMsg),
            };
            string strRep = JsonStrObjConver.Obj2JsonStr(rep, typeof(RepRecDef));
            Write(strRep);
            return true;
        }

#endregion

        //被动客户端响应接受到的特定命令
        void AnalyseRec(string strRec)
        {
            // 获取端口的状态
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getdevstatus) >0)
            {
                if (Hlp_getdevstatus(strRec))
                {
                    return;
                }
            }

            // 第一次握手
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getauth) > 0)
            {
                if (Hlp_getauthsn(strRec))
                {
                    return;
                }
            }

            // 算法认证，合法性认证
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_checkauthsn) > 0)
            {
                if (Hlp_checkauthsn(strRec))
                {
                    return;
                }
            }
          
            // 心跳
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_keelal) > 0)
            {
                if (Hlp_keepal(strRec))
                {
                    return;
                }
            } // end get history data

            // 获取所有的组织
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getorgs) > 0)
            {
                if (Hlp_getorgs(strRec))
                {
                    return;
                }
            }

            // 获取所有的设备
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getdevs) > 0)
            {
                if (Hlp_getdevs(strRec))
                {
                    return;
                }
            }

            // 获取所有的卡信息
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getledcards) > 0)
            {
                if (Hlp_getledcards(strRec))
                {
                    return;
                }
            }

            // 更新卡信息
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_updateledcard) > 0)
            {
                if (Hlp_updateledcard(strRec))
                {
                    return;
                }
            }

            

            //设置ID
//         public const string strSendCmd_setcardid = "setcardid";
//         //查询ID
//         public const string strSendCmd_getcardid = "getcardid";
//         //获取设备参数
//         public const string strSendCmd_getcardcfg = "getcardcfg";
//         //设置设备参数
//         public const string strSendCmd_setcardcfg = "setcardcfg";
//         //发送内容
//         public const string strSendCmd_sendoilval = "sendoilval";
//         //读取价格内容
//         public const string strSendCmd_getoilval = "getoilval";
//         //设置小数点
//         public const string strSendCmd_setoildot = "setioldot";
//         //读取小数点
//         public const string strSendCmd_getoildot = "getoildot";

            // 设置卡内容
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_sendoilval) > 0)
            {
                if (Hlp_sendcardoilval(strRec))
                {
                    return;
                }
            }
            // 获取卡价格
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getoilval) > 0)
            {
                if (Hlp_getcardoilval(strRec))
                {
                    return;
                }
            }

            // 设置卡小数点
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_setoildot) > 0)
            {

                if (Hlp_sendcarddot(strRec))
                {
                    return;
                }
            }
            // 获取卡小数点
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getoildot) > 0)
            {
                if (Hlp_getcardDot(strRec))
                {
                    return;
                }
            }


            // 获取配置
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_getcardcfg) > 0)
            {

                if (Hlp_getcardcfg(strRec))
                {
                    return;
                }
            }
            // 设置配置
            if (strRec.IndexOf(DCGWCommStructs.strSendCmd_setcardcfg) > 0)
            {
                if (Hlp_sendcardcfg(strRec))
                {
                    return;
                }
            }

            FileLog.WriteLog("数据中心接收到网关发上来不明确的请求.... 内容如下:");
            FileLog.WriteLog(strRec);
        }


        void RecRun()
        {
            DateTime checkDownsocketDate = DateTime.Now;
            DateTime checkDownDate = DateTime.Now;
            while (m_bRun)
            {
                int iSecs = (int)((DateTime.Now - checkDownsocketDate).TotalSeconds);

                if (iSecs > 30)
                {
                    DataCenterObject.Get().m_pGwServerPort.RemoveOldTcpLisenterPort((int)m_org.ID);
                    return;
                }

                try
                {
                    string strRead = Read();
                    if (strRead!=null && strRead.Length > 0)
                    {
                        AnalyseRec(strRead);
                        checkDownsocketDate = DateTime.Now;
                    }

                    Thread.Sleep(10);
                }
                catch (System.Exception ex)
                {
                    FileLog.WriteLog("RecRun ex:" + ex.Message);
                    FileLog.WriteLog("RecRun ex stack:" + ex.StackTrace);
                    DataCenterObject.Get().m_pGwServerPort.RemoveOldTcpLisenterPort((int)m_org.ID);
                    return;
                }
            }
        }


		public bool Start()
		{
            //
            // 添加一次连接统计
            //
			if (!Open())
			{
				return false;
			}

			// 
            string strRec = null;
			try
			{
                //
                // 先读取数据网关名字和ID配置信息
                //
                strRec = Read(2000);
                if (strRec == null || strRec.Length == 0)
                {
                    strRec = Read(2000);
                }
                if (strRec == null || strRec.Length == 0)
                {
                    return false;
                }                
			}
			catch (System.Exception ex)
			{
				FileLog.WriteLog("socket " + ex.Message);
			}
            
            if (strRec == null || strRec.Length == 0)
            {
                return false;
            }

            if (!Hlp_getauthsn(strRec))
            {
                LogMgr.WriteLog("获取身份认证失败");
                return false;
            }

            if (m_org != null)
            {
                DataCenterObject.Get().SetConnStatus(m_org.ID, 1);
                DataCenterObject.Get().AddConnTime(m_org.ID);
            }

			m_thread = new Thread(new ThreadStart(RecRun));
			m_thread.IsBackground = true;
			m_bRun = true;
			m_thread.Start();
			return true;

		}

		public bool Stop()
		{
			if (m_thread == null)
			{
				return true;
			}

			m_bRun = false;
			try
			{
				m_thread.Join(1000);
                if (m_thread.IsAlive)
                {
                    m_thread.Abort();
                }
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("tcp stop"+ex.Message);
				System.Diagnostics.Trace.WriteLine("线程非正常结束，需要判断线程还会不会继续运行");
			}


			m_thread = null;
			return false;
		}

        // 写数据
        private bool Write(string strCmd)
        {

            Program.AddDevMsg(ConstDef.strLogDCClient, "analyse-write", "", "", DateTime.Now.ToString(), strCmd);

            try
            {
                if (m_tcpClient.Connected)
                {
                    NetworkStream netStream = m_tcpClient.GetStream();
                    Byte[] sendBytes = Encoding.UTF8.GetBytes(strCmd);
                    netStream.Write(sendBytes, 0, sendBytes.Length);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
               // LogMgr.WriteLog("数据端口发送数据失败：" + ex.Message, LogGrade.High);
                return false;
            }
            return false;
        }

		public bool Write(byte[] pMsg, int iOffset, int iLen)
		{
			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
				Open();
			}

			if (m_tcpClient == null || !m_tcpClient.Connected)
			{
				return false;
			}

			NetworkStream stream = m_tcpClient.GetStream();
			bool bSended = true;
			try
			{
				stream.Write(pMsg, iOffset, iLen);
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("tcp write" +ex.Message);
				bSended = false;
				return bSended;
			}
			if (m_org != null)
			{
                Program.AddDevMsg(
                     m_org.Name,
                    "write",
                     "",
                     "",
                     DateTime.Now.ToString(),
                     BitConverter.ToString(pMsg, iOffset, iLen)
                     );
			}
			return bSended;
		}

		public void OnRead()
		{
		}


		public TcpClient TCPCLIENT
        {
            set
            {
                m_tcpClient = value;
            }
			get
			{
				return m_tcpClient;
			}
		}

		//
		// 端口启动的采集与控制线程
		//
		private Thread m_thread;
		private bool m_bRun;

	}
}
