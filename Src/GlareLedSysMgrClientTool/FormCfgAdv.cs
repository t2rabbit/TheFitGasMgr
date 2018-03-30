using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Property.Devs;
using DBSqlite;
using YD_PUBLIC;
using YdPublic;

namespace Property
{
    public partial class FormCfgAdv : Form
    {
        public FormCfgAdv()
        {
            InitializeComponent();
            IArrDecs = new int[12];
        }

        private Devs.Rs485Port m_pPort485 = new Devs.Rs485Port();
        private Devs.TCPPort m_pPortTcp = new Devs.TCPPort();

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
                m_pPortTcp.Close();
                int iPort = 0;
                int.TryParse(textBoxDevPort.Text, out iPort);
                m_pPortTcp.SetDBDev(new GL_Dev()
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
                m_pPortTcp.Open();
            }
        }

        public int[] IArrDecs { get; set; }
        public string StrComm { get; set; }
        public int IComType { get; set; }
        public string StrTcpDevIp { get; set; }
        public string StrTcpDevPort { get; set; }
        public int IDefID { get; set; }
        public int IScreenCount{get;set;}
        public string StrModeType{get;set;}


        private void SetMaxDigCount(int iMainDig)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();
            comboBox10.Items.Clear();
            comboBox11.Items.Clear();
            comboBox12.Items.Clear();
            for (int i = 0; i < iMainDig; i++)
            {
                comboBox1.Items.Add((i + 1).ToString());
                comboBox2.Items.Add((i + 1).ToString());
                comboBox3.Items.Add((i + 1).ToString());
                comboBox4.Items.Add((i + 1).ToString());
                comboBox5.Items.Add((i + 1).ToString());
                comboBox6.Items.Add((i + 1).ToString());
                comboBox7.Items.Add((i + 1).ToString());
                comboBox8.Items.Add((i + 1).ToString());
                comboBox9.Items.Add((i + 1).ToString());
                comboBox10.Items.Add((i + 1).ToString());
                comboBox11.Items.Add((i + 1).ToString());
                comboBox12.Items.Add((i + 1).ToString());
            }
        }

        private void SetComboboxChecked(int iCount)
        {
            comboBox1.Enabled = iCount >= 1;
            comboBox2.Enabled = iCount >= 2;
            comboBox3.Enabled = iCount >= 3;
            comboBox4.Enabled = iCount >= 4;
            comboBox5.Enabled = iCount >= 5;
            comboBox6.Enabled = iCount >= 6;
            comboBox7.Enabled = iCount >= 7;
            comboBox8.Enabled = iCount >= 8;
            comboBox9.Enabled = iCount >= 9;
            comboBox10.Enabled = iCount >= 10;
            comboBox11.Enabled = iCount >= 11;
            comboBox12.Enabled = iCount >= 12;
        }

        private void FormCfgAdv_Load(object sender, EventArgs e)
        {
            InitCommCombobox();
            InitIDCombobox();




            comboBoxComm.Text = StrComm;
            comboBoxID.SelectedText = IDefID.ToString();
            radioButtonCom.Checked = IComType == 0;
            radioButtonTCP.Checked = IComType == 1;
            textBoxTcpDevIp.Text = StrTcpDevIp;
            textBoxDevPort.Text = StrTcpDevPort;
            radioButtonCom_CheckedChanged(null, null);

            SetDotValToView();
            LanguageMgr.ReloadLanguage(this);
            comboBoxAll.SelectedIndex = 0;


            int iDigCount;
            int iMainDigCount;
            int iAppCount;
            bool bApp1;
            bool bApp2;
            GSTypeHlper.GetTypeInfoByString(StrModeType,
                out iDigCount, out iMainDigCount, out iAppCount,
                out bApp1, out bApp2);
            SetMaxDigCount(iMainDigCount);

            SetComboboxChecked(IScreenCount);
        }
        
        private void InitCommCombobox()
        {
            string[] arr = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxComm.DataSource = arr;
        }

        private void InitIDCombobox()
        {
            for (int i = 1; i <= 255; i++)
            {
                comboBoxID.Items.Add(i.ToString());
            }
        }

        private void SetDotValToView()
        {
            bool bAllSame = true;

            for (int i = 0; i < 12; i++)
            {
                if (i > 0)
                {
                    if (IArrDecs[i] != IArrDecs[i - 1])
                    {
                        bAllSame = false;
                    }
                }

                int itmp = IArrDecs[i];
                string strComName = "comboBox" + i;
                foreach (object aObj in groupBoxEach.Controls)
                {
                    ComboBox aTxtbox = aObj as ComboBox;
                    if (aTxtbox != null)
                    {
                        if (aTxtbox.Name == strComName)
                        {
                            aTxtbox.SelectedIndex = itmp - 1;
                            break;
                        }
                    }
                }
            }

            checkBoxSameAllScreens.Checked = bAllSame;
            if(bAllSame)
            {
                comboBoxAll.SelectedIndex = IArrDecs[0] - 1;
            }
        }


        private string GetDotValToMem()
        {
            string strContext = "";
            int iAll = 0;
            if (checkBoxSameAllScreens.Checked)
            {
                iAll = (comboBoxAll.SelectedIndex + 1);
                for (int i = 0; i < 12; i++)
                {
                    if (strContext.Length > 0)
                    {
                        strContext += "-";
                    }
                    strContext += iAll.ToString();
                    IArrDecs[i] = iAll;
                }
                return strContext;
            }

            for (int i = 1; i <= 12; i++)
            {
                int itmp = 1;
                string strComName = "comboBox" + i;
                foreach (object aObj in groupBoxEach.Controls)
                {
                    ComboBox aTxtbox = aObj as ComboBox;
                    if (aTxtbox != null)
                    {
                        if (aTxtbox.Name == strComName)
                        {
                            itmp = aTxtbox.SelectedIndex + 1;
                            if (strContext.Length > 0)
                            {
                                strContext += "-";
                            }
                            strContext += itmp.ToString();
                            IArrDecs[i] = itmp;
                        }
                    }
                }
            }

            return strContext;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strdotval = GetDotValToMem();
            ConfigHlper.SetConfig(ConstDef.strKeyDefDecInfo, strdotval);

            InitPort();
            int iNewID = 0;
            int.TryParse(comboBoxID.Text, out iNewID);
            if (iNewID < 0 && iNewID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }
            if (radioButtonCom.Checked)
            {
                if (m_pPort485.SetCardDecmial(iNewID, IArrDecs))
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
                if (m_pPortTcp.SetCardDecmial(iNewID, IArrDecs))
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
                }
                m_pPortTcp.Close();
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {           
            int iOpID = 0;
            int.TryParse(comboBoxID.Text, out iOpID);

            InitPort();
            int iNewID = 0;
            int.TryParse(comboBoxID.Text, out iNewID);
            if (iNewID < 0 && iNewID > 255)
            {
                MessageBox.Show(LanguageMgr.GetKey("InputID1to254"));
                return;
            }
            bool bSuccess = false;
            int[] iArrTmp = new int[12];

            if (radioButtonCom.Checked)
            {
                if (m_pPort485.GetCardDecmial(iNewID, ref iArrTmp))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
                    bSuccess = true;
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                }
                m_pPort485.Close();
            }
            else
            {
                if (m_pPortTcp.GetCardDecmial(iNewID, ref iArrTmp))
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
                    bSuccess = true;
                }
                else
                {
                    MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
                }
                m_pPortTcp.Close();

            }

            if (bSuccess)
            {
                for (int i = 0; i < 12; i++)
                {
                    IArrDecs[i] = iArrTmp[i];
                }
                SetDotValToView();
            }

        }

        private void checkBoxSameAllScreens_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAll.Enabled = checkBoxSameAllScreens.Checked;
            groupBoxEach.Enabled = !checkBoxSameAllScreens.Checked;
            SetComboboxChecked(IScreenCount);
        }

        private void comboBoxAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox2.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox3.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox4.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox5.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox6.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox7.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox8.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox9.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox10.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox11.SelectedIndex = comboBoxAll.SelectedIndex;
            comboBox12.SelectedIndex = comboBoxAll.SelectedIndex;
            
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
