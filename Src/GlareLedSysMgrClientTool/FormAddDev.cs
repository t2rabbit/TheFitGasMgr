using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YDesmsPublicDefDll;
using DBSqlite;
using Property.DB;
using YdPublic;

namespace Property
{
    public partial class FormAddDev : Form
    {

        public UIDefine.EUINewOrMdy m_NewMdy{get;set;}
        public GL_Dev m_oldItem { get; set; }
        public FormAddDev()
        {
            InitializeComponent();
        }

        private void FormAddDev_Load(object sender, EventArgs e)
        {
            ShowPanelByIndex(DBDefines.DevTransferType.E_SERIAL_COM);
            for (int i = 1; i < 255; i++)
            {
                comboBoxSerialCom.Items.Add("COM" + i);
            }
             
            
            InitComboboxOilStation();
            panelSerailInfo.Dock = DockStyle.Fill;
            panelTcpClientInfo.Dock = DockStyle.Fill;
            panelTcpServerInfo.Dock = DockStyle.Fill;
            if (m_NewMdy == UIDefine.EUINewOrMdy.E_MDY)
            {                
                panelSerailInfo.Visible = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_SERIAL_COM);
                panelTcpClientInfo.Visible = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_TCP_CLIENT);
                panelTcpServerInfo.Visible = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_TCP_SERVER);

                radioButtonSerial.Checked = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_SERIAL_COM);
                radioButtonTcpClient.Checked  = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_TCP_CLIENT);
                radioButtonTcpServer.Checked  = m_oldItem.CommType == (int)(DBDefines.DevTransferType.E_TCP_SERVER);
                
                comboBoxSelOilStation.SelectedValue = m_oldItem.OrgID;
                textBoxPortName.Text = m_oldItem.Name;
                textBoxTCPClientID.Text = m_oldItem.DevClientName;
                textBoxTcpServerIP.Text = m_oldItem.DevServerIP;
                textBoxTcpServerPort.Text = m_oldItem.DevServerPort.ToString();
                comboBoxSerialCom.Text = m_oldItem.SerialPort;
            }
            else
            {

            }

            LanguageMgr.ReloadLanguage(this);
        }

        private void InitComboboxOilStation()
        {
            comboBoxSelOilStation.DisplayMember = "Name";
            comboBoxSelOilStation.ValueMember = "ID";
            comboBoxSelOilStation.DataSource = DB.MemDB.Get().lstOrgWithNone;
        }


        private void ShowPanelByIndex(DBDefines.DevTransferType eType)
        {
            panelSerailInfo.Visible = (DBDefines.DevTransferType.E_SERIAL_COM == eType);
            panelTcpClientInfo.Visible = (DBDefines.DevTransferType.E_TCP_CLIENT == eType);
            panelTcpServerInfo.Visible = (DBDefines.DevTransferType.E_TCP_SERVER == eType);
        }

        private void radioButtonTcpClient_CheckedChanged(object sender, EventArgs e)
        {
            ShowPanelByIndex(DBDefines.DevTransferType.E_TCP_CLIENT);
        }

        private void radioButtonSerial_CheckedChanged(object sender, EventArgs e)
        {
            ShowPanelByIndex(DBDefines.DevTransferType.E_SERIAL_COM);
        }

        private void radioButtonTcpServer_CheckedChanged(object sender, EventArgs e)
        {
            ShowPanelByIndex(DBDefines.DevTransferType.E_TCP_SERVER);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int iOrg = 0;
            try
            {
                iOrg = (int)(long)(comboBoxSelOilStation.SelectedValue);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipSelOilStation"));
                return;
            }
            
            if (iOrg <= 0)
            {
                MessageBox.Show(LanguageMgr.GetKey("TipSelOilStation"));
                return;
            }

            int iPort = 0;
            int.TryParse(textBoxTcpServerPort.Text, out iPort);

            int CommType = radioButtonSerial.Checked?(int)DBDefines.DevTransferType.E_SERIAL_COM : 
                (radioButtonTcpServer.Checked?(int)DBDefines.DevTransferType.E_TCP_SERVER : (int)DBDefines.DevTransferType.E_TCP_CLIENT  );

            GL_Dev aDev = new GL_Dev()
            {
                CommType = CommType,
                DevServerIP = textBoxTcpServerIP.Text,
                DevServerPort = iPort,
                DevClientName = textBoxTCPClientID.Text,                
                Name = textBoxPortName.Text,
                OrgID = iOrg,
                Protocol = 0,
                SerialBaud = 9600,
                SerialDataBit = 8,
                SerialParity = 0,
                SerialPort = comboBoxSerialCom.Text,
                SerialStopBit = 1,
                Timeout = 2000,
                BEnable  = 1,
                Comment = "",
            };

            if (m_NewMdy == UIDefine.EUINewOrMdy.E_MDY)
            {
                MemDB.Get().UpdateDev((int)m_oldItem.ID, aDev);
            }
            else if (m_NewMdy == UIDefine.EUINewOrMdy.E_NEW)
            {
                MemDB.Get().AddDev(aDev);
            }
            else
            {

            }
            
        }

        private void groupBoxPortDetailInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
