using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;
using YD_PUBLIC;
using YdPublic;
using System.Threading;

namespace Property
{
    public partial class FormMdyID : Form
    {
        public FormMdyID()
        {
            InitializeComponent();
        }

        public string StrComm { get; set; }
        public string strDefID { get; set; }
        public int IComType { get; set; }
        public string StrTcpDevIp { get; set; }
        public string StrTcpDevPort { get; set; }
        public int IDefID { get; set; }

        private void FormMdyID_Load(object sender, EventArgs e)
        {
            InitComm();
            comboBoxComm.Text = StrComm;
            textBoxNewID.Text = strDefID;
            radioButtonCom.Checked = IComType == 0;
            radioButtonTCP.Checked = IComType == 1;
            textBoxTcpDevIp.Text = StrTcpDevIp;
            textBoxDevPort.Text = StrTcpDevPort;
            radioButtonCom_CheckedChanged(null, null);
            LanguageMgr.ReloadLanguage(this);
        }

        private void InitComm()
        {
            string[] arr = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxComm.DataSource = arr;
        }


        private Devs.Rs485Port m_pPort485 = new Devs.Rs485Port();
        private Devs.TCPPort m_pTcpPort = new Devs.TCPPort();

        private void InitPort()
        {
            if (radioButtonCom.Checked)
            {
                m_pPort485.Close();
                m_pPort485.SetDBDev(new GL_Dev()
                {
                    CommType = 1,
                    DevClientName = "",
                    DevServerIP = "",
                    Name = "",
                    DevServerPort = 0,
                    OrgID = 0,
                    Protocol = 0,
                    SerialBaud = 9600,
                    SerialDataBit = 8,
                    SerialParity = 0,
                    SerialPort = comboBoxComm.Text,
                    SerialStopBit = 1,
                    Timeout = 300
                });
                m_pPort485.Open();
            }
            else
            {
                m_pTcpPort.Close();
                int iPort = 0;
                int.TryParse(textBoxDevPort.Text, out iPort);
                m_pTcpPort.SetDBDev(new GL_Dev()
                {
                    CommType = 0,
                    DevClientName = "",
                    DevServerIP = textBoxTcpDevIp.Text,
                    Name = "",
                    DevServerPort = iPort,
                    OrgID = 0,
                    Protocol = 0,
                    SerialBaud = 9600,
                    SerialDataBit = 8,
                    SerialParity = 0,
                    SerialPort = comboBoxComm.Text,
                    SerialStopBit = 1,
                    Timeout = 1000

                });
                m_pTcpPort.Open();
            }
        }


        private void buttonSetID_Click(object sender, EventArgs e)
        {
            ConfigHlper.SetConfig(ConstDef.strKeyID, textBoxNewID.Text);

            InitPort();
            int iNewID = 0;
            int.TryParse(textBoxNewID.Text, out iNewID);
            if (iNewID < 0 && iNewID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                m_pTcpPort.Close();
                return;
            }
            if (radioButtonCom.Checked)
            {
                if (m_pPort485.SetID(0, iNewID))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                }
                m_pPort485.Close();
            }
            else
            {
                Thread.Sleep(10);
                if (m_pTcpPort.SetID(0, iNewID))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                }
                m_pTcpPort.Close();

            }
        }

        private void radioButtonTCP_CheckedChanged(object sender, EventArgs e)
        {

            textBoxDevPort.ReadOnly = radioButtonCom.Checked;
            textBoxTcpDevIp.ReadOnly = radioButtonCom.Checked;
            comboBoxComm.Enabled = radioButtonCom.Checked;
        }

        private void radioButtonCom_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDevPort.ReadOnly = radioButtonCom.Checked;
            textBoxTcpDevIp.ReadOnly = radioButtonCom.Checked;
            comboBoxComm.Enabled = radioButtonCom.Checked;
        }
    }
}
