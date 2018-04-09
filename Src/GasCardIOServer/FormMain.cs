using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IOServer.BLL;
using System.Collections;
using System.Configuration;
using Models;
using NetLabelEfDbDll.SqlServer;
using IOServer.BLL.RealControls;
using PiPublic.Log;
using PiPublic;

namespace IOServer
{
	public partial class FormMain : Form
	{

        int iPort = 7802;
		public FormMain()
		{
			InitializeComponent();
		}


		private void buttonStart_Click(object sender, EventArgs e)
		{
            
			IOServerObject.Get().Init(iPort);
            
			IOServerObject.Get().Start();
			UpdateButtons();
		}

		private void UpdateButtons()
		{
			buttonStart.Enabled = !IOServerObject.Get().ISRun();
			buttonStop.Enabled = IOServerObject.Get().ISRun();
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			IOServerObject.Get().Stop();

			UpdateButtons();
		}

	
        public void Restart(int a)
        {
         
        }

		private void FormMain_Load(object sender, EventArgs e)
        {
            LogMgr.InitFileTraceLog();

            string strPort = ConfigurationManager.AppSettings["TCPPort"];
            if (!int.TryParse(strPort, out iPort))
            {
                iPort = 7802;
            }
            textBox2.Text = iPort.ToString();

			InitDevConnectStatus();
			buttonStart_Click(null, null);

            timerUpdateStatus.Enabled = true;
		}

        public void InsertDevCmd(MsgDirect iDirect, string strMsg, string strDevName)
        {
            if (checkBoxDevCmd.Checked)
                return;

            listViewDevModuleCmd.Items.Add(new ListViewItem(new string[]{iDirect==MsgDirect.E_READ?"接收":"发送",			
				strDevName, DateTime.Now.ToString(), strMsg}));
        }

        public void InsertLogMsgToFrom(string strMsg, string strType1, string strType2)
        {
            if (checkBoxDevCmd.Checked)
                return;

            listViewDevModuleCmd.Items.Add(new ListViewItem(new string[]
                {strType1,strType2, DateTime.Now.ToString(), strMsg}));
        }


		// 更新状态
		private void timerUpdateStatus_Tick(object sender, EventArgs e)
		{
			if (!IOServerObject.Get().ISRun())
			{
				return;
			}

// 			if (GatewayObject.Get().IsRunAtDC)
// 			{
// 			}

			CheckConnectOfDev();
		}

		private void CheckConnectOfDC()
		{

		}

        int m_iCurIndex = 0;
		private void CheckConnectOfDev()
		{
            DateTime dtLastComm = DateTime.Now;

            for(int i=m_iCurIndex; i<listViewDeviceStatus.Items.Count; i++)
            {
                ListViewItem aItem = listViewDeviceStatus.Items[i];

                if (aItem.Tag is GatewayModel)
                {
                    GatewayModel aDev = (GatewayModel)(aItem.Tag);
                    LastStatusInfo.EStatus stat = LastStatusMgr.Get().GetGwStatus(
                        aDev.ID,
                            out dtLastComm);

                    aItem.SubItems[5].Text = dtLastComm.ToString();
                    aItem.SubItems[4].Text = EnumTextByDescription.GetEnumDesc(stat);
                    
                }
                else if (aItem.Tag is DevInfo)
                {
                    DevInfoModel aDev = (DevInfoModel)(aItem.Tag);
                    LastStatusInfo.EStatus stat = LastStatusMgr.Get().GetGwStatus(
                        aDev.ID,
                            out dtLastComm);

                    aItem.SubItems[5].Text = dtLastComm.ToString();
                    aItem.SubItems[4].Text = EnumTextByDescription.GetEnumDesc(stat);
                }
                else
                {

                }
                m_iCurIndex++;
                if (m_iCurIndex % 100 == 0)
                {
                    break;
                }
            }
            if (m_iCurIndex >= listViewDeviceStatus.Items.Count)
            {
                m_iCurIndex = 0;
            }
		}

		private void InitDCConnect()
		{

		}

		private void InitDevConnectStatus()
		{
			// 
			listViewDeviceStatus.Items.Clear();

            foreach (GatewayModel DevStat in DBMgr.Get().LstPortGaweway)
			{
                string strName = string.Format("name:{0}; id:{1};", DevStat.Name, DevStat.ID);
                string strIpPOrt = null;
                strIpPOrt = string.Format("clientInfo:{0}", DevStat.ProtocolSN);

				ListViewItem item = new ListViewItem(new string[] 
                                                         {
                                                            strName,
                                                            "-----------",
                                                            strIpPOrt,
                                                            "",
                                                            "***********",
                                                            "正在连接..."
                                                         });
				item.Tag = DevStat;
				listViewDeviceStatus.Items.Add(item);
			}

            //string strModName;
			foreach (DevInfoModel ModStat in DBMgr.Get().ListDev)
			{
                //strModName = string.Format("Name:%s; id:%d; addr:%d", ModStat.Name, ModStat.ID, ModStat.Addr);
                GatewayModel aDev = (from c in DBMgr.Get().LstPortGaweway where c.ID == ModStat.GatewayId select c).FirstOrDefault();
				if (aDev == null)
				{
					continue;
				}
				ListViewItem item = new ListViewItem(new string[] 
                                                         {
                                                            aDev.Name,
 														   ModStat.Name,
 														   ModStat.DevAddr,
                                                            ModStat.DevLineIndex.ToString(),
                                                            "正在连接..."
                                                         });

				item.Tag = ModStat;
				listViewDeviceStatus.Items.Add(item);
			}

		}

		private void checkBoxDevCmd_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void buttonDevCmdClear_Click(object sender, EventArgs e)
		{
			listViewDevModuleCmd.Items.Clear();
		}

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            IOServerObject.Get().Stop();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void 调光的命令_Click(object sender, EventArgs e)
        {
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                RealControl ctl = new RealControl()
                {
                    AddByUserId = 1,
                    Cmd = "1",
                    CmdFlag = 1,
                    CmdType = "SetPwm",
                    ControlUserId = 1,
                    DevAddr = 0x8001,
                    DevId = 1,
                    DevLineIndex = 0,
                    GatewayId = 1,
                    GroupAddr = 1,
                    ID = 1,
                    LogDt = new DateTime(2001, 1, 1),
                    ProjectId = 1,
                    TypeProjGateDevGroup = 1,
                };
                ent.RealControl.AddObject(ctl);
                ent.SaveChanges();
            }
        }

        private void timerGetTopLog_Tick(object sender, EventArgs e)
        {
            LogInfo log;
            for (int i = 0; i < 100; i++)
            {
                if (!LogMgr.GetTopLog(out log))
                {
                    return;
                }

                InsertLogMsgToFrom(log.LogMsg, log.LogType.ToString(), log.LogExt2);
            }
        }
	}
}
