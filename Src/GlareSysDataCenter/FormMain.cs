using GlareSysDataCenter.CommRW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    public partial class FormMain : Form
    {
        FormLog formLog;

        public FormMain()
        {
            InitializeComponent();
            formLog = new FormLog();
        }
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!TcpServerForGPRSDev.Get().Start())
            {
                timerRestartTcpServer.Enabled = true;            
            }

            CmdOp.Get().Start();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {            
            this.backgroundWorkerLoading.RunWorkerAsync();
            FormStartLoader form = new FormStartLoader(this.backgroundWorkerLoading);
            form.ShowDialog(this);
            formLog.Show();
        }

        private void backgroundWorkerLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpServerForGPRSDev.Get().Port = 7804;
            MemCfgInfo.MemDbMgr.Get().Load();            
        }

        private void buttonFunTest_Click(object sender, EventArgs e)
        {
            FormTest form = new FormTest();
            form.ShowDialog();
        }

        private void buttonShowLog_Click(object sender, EventArgs e)
        {

            timerRestartTcpServer.Enabled = true;

            formLog.Show();
            formLog.Visible = true;
            formLog.Activate();
        }

        private void timerRestartTcpServer_Tick(object sender, EventArgs e)
        {
            if (TcpServerForGPRSDev.Get().Start() )
            {
                timerRestartTcpServer.Enabled = false;
            }
        }

        private void buttonRefreshDbData_Click(object sender, EventArgs e)
        {
            MemCfgInfo.MemDbMgr.Get().Load();
        }        

        private void rbCommCardViewForTree_CheckedChanged(object sender, EventArgs e)
        {
            //treeViewForComm.Nodes.Clear();
            //foreach (var comm in MemCfgInfo.MemDbMgr.Get().dicMemCommWithAllInfo)
            //{
            //    string strNodeInfo = comm.Value.RefProject.Project.ProjectName + "-" + comm.Value.CommDev.Name;
            //    TreeNode tnCom = treeViewForComm.Nodes.Add(strNodeInfo);
            //    tnCom.Tag = comm.Value;

            //    foreach (var card in comm.Value.DicCards)
            //    {
            //        TreeNode tnCard = tnCom.Nodes.Add(card.Value.Card.CardName);
            //        tnCard.Tag = card.Value;
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCPLisenterPort port= TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(1);
            string strVal="";
            port.ReadOilValString(1, ref strVal);

            GLLedPublic.CardCfgByJson cfg = new GLLedPublic.CardCfgByJson();
            port.GetLedCfg(1, ref cfg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCPLisenterPort port = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient(1);
            string strVal = "";
            List<string> lstVals = new List<string>();
            lstVals.Add("222222");
            lstVals.Add("222222");
            lstVals.Add("222222");
            lstVals.Add("222222");
            lstVals.Add("222222");
            lstVals.Add("222222");
            port.SendOilContext(1, lstVals);
        }

        private void buttonCfgDbMgr_Click(object sender, EventArgs e)
        {
            FormInfoMgr dlg = new FormInfoMgr();
            dlg.ShowDialog();
        }
    }
}
