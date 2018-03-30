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
using Property.Devs;
using YdPublic;

namespace Property
{
    public partial class FormDecimalSetting : Form
    {
        public GL_LedCard glLedCard{get;set;}
        public FormDecimalSetting()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAll.Enabled = checkBoxAllTheSame.Checked;
            groupBoxEach.Enabled = !checkBoxAllTheSame.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool bSendResult = false;
            string strVals = "";
            List<GLLedDefine.CardOilValEachNumAByte> lstCardVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)glLedCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }
                bSendResult = aPort.ReadLedDotValString((int)glLedCard.Addr, ref strVals);

            }
            else if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT)
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }
                bSendResult = pTcp.ReadLedDotValString((int)glLedCard.Addr, ref strVals);
            }
            else
            {

            }

            if (bSendResult)
            {
                SetDotValToView(strVals);
                MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
            }
        }

        private void SetDotValToView(string strVal)
        {
            string[] dotarr = strVal.Split(new char[]{'-',',','.'});
            bool bAllSame = true;
            
            for (int i=1; i<=12; i++)
            {
                if (i>1)
                {
                    if (dotarr[i-1]!=dotarr[i-2])
                    {
                        bAllSame = false;
                    }
                }

                int itmp = 1;
                try
                {
                    if (dotarr.Count()>=i)
                    {
                        int.TryParse(dotarr[i-1], out itmp);
                    }
                }
                catch (System.Exception ex)
                {
                	itmp = 1;
                }
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

            checkBoxAllTheSame.Checked = bAllSame;
        }


        private string GetDotValToMem()
        {
            string strContext = "";
            int iAll = 0;
            if (checkBoxAllTheSame.Checked)
            {
                iAll = (comboBoxAll.SelectedIndex + 1);
                for (int i=0; i<12; i++)
                {
                    if (strContext.Length > 0)
                    {
                        strContext += "-";
                    }
                    strContext += iAll.ToString();
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
                            if (strContext.Length >0)
                            {
                                strContext += "-";
                            }
                            strContext += itmp.ToString();
                        }
                    }
                }
            }

            return strContext;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strDot = GetDotValToMem();
            string[] strDotStrs = strDot.Split(new char[] { '-', ',' });
            int[] arr = new int[12];
            for (int i = 0; i < 12; i++)
            {
                if (strDotStrs.Length > i)
                {
                    int iTmp = 0;
                    int.TryParse(strDotStrs[i], out iTmp);
                    arr[i] = iTmp;
                }
            }

            bool bSendResult = false;
            List<GLLedDefine.CardOilValEachNumAByte> lstCardVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)glLedCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }
                bSendResult = aPort.SetCardDecmial((int)glLedCard.Addr, arr);

            }
            else if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT)
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }
                bSendResult = pTcp.SendOilDot((int)glLedCard.Addr, strDot);
            }
            else
            {

            }

            if (bSendResult)
            {
                MessageBox.Show(LanguageMgr.GetKey("CfgSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("CfgFailed"));
            }
        }

        private void FormDecimalSetting_Load(object sender, EventArgs e)
        {
            textBox1.Text = glLedCard.Name;
            checkBoxAllTheSame.Checked = true;

            comboBoxAll.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            string strDot = GetDotValToMem();
            glLedCard.DecimalInfo = strDot;
            if (!DB.MemDB.Get().UpdateCard((int)glLedCard.ID, glLedCard))
            {
                MessageBox.Show(LanguageMgr.GetKey("GetCfgSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("GetCfgFailed"));
            }
        }

        private void comboBoxAll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
