using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBSqlite;
using YDesmsPublicDefDll;
using Property.Devs;
using YdPublic;

namespace Property
{
    public partial class ViewOliCard : Form
    {
        public int CardIDSeled{get;set;}
        private GL_LedCard m_ledCard;

        IList<Label> labelAdded = new List<Label>();
        IList<TextBox> textAdded = new List<TextBox>();

        public ViewOliCard()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            buttonSaveToDb_Click(null, null);
            bool bSendResult = false;

            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)m_ledCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }

                bSendResult = aPort.SendOilContext((int)m_ledCard.Addr, m_lstContextOfView);                           
            }
            else if ( (DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT )
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }

                buttonSaveToDb_Click(null, null);
                bSendResult = pTcp.SendOilContext((int)m_ledCard.Addr, m_lstContextOfView);                               
            }
            else
            {

            }

            if (bSendResult)
            {                                
                MessageBox.Show(LanguageMgr.GetKey("OpSuccess"));
            }
            else
            {
                MessageBox.Show("OpFailed");
            }


        }


        private void ViewOliCard_Load(object sender, EventArgs e)
        {
           
        }

        private void MakeLedText()
        {

            foreach (Label labcl in labelAdded)
            {
                Controls.Remove(labcl);
            }
            labelAdded.Clear();

            foreach (TextBox txtb in textAdded)
            {
                Controls.Remove(txtb);
            }
            textAdded.Clear();

            if (m_ledCard == null)
            {
                return;
            }

            int iRowCount = 4;
            int iLabStartX = label_S1.Location.X;
            int iLabStartY = label_S1.Location.Y;
            int iTxtStartX = textBox_S1.Location.X;
            int iTxtStartY = textBox_S1.Location.Y;
            int iLabWidth = label_S1.Width;
            int iLabHeight = label_S1.Height;
            int iTxtWidth = textBox_S1.Width;
            int iTxtHeight = textBox_S1.Height;

            int iNextTxWidthPos = textBox_S1.Location.X + textBox_S1.Width - label_S1.Location.X + 10;

            for (int i=1; i<=m_ledCard.ScreenCount; i++)
            {
                if (m_ledCard.IsDouble == 1 )
                {
                    iRowCount = 2;
                }

                if (i==1)
                {
                    continue;
                }

                int iLSCurX = iLabStartX + (i % iRowCount == 0 ? iRowCount - 1 : (i % iRowCount)-1) * iNextTxWidthPos ;
                int iLSCurY = iLabStartY + ((i-1) /iRowCount) * (iTxtHeight + 10);



                System.Diagnostics.Trace.WriteLine("x:" + iLSCurX + "  y:" + iLSCurY);
                Label labeltmp = new Label();
                labeltmp.AutoSize = true;
                labeltmp.Location = new System.Drawing.Point(iLSCurX, iLSCurY);
                labeltmp.Name = "label_S" + i;
                labeltmp.Size = new System.Drawing.Size(23, 12);                
                if (i<10)
                {
                    labeltmp.Text = "# "+i;
                }
                else
                {
                    labeltmp.Text = "#" + i;
                }

                this.Controls.Add(labeltmp);
                labelAdded.Add(labeltmp);

                //
                // textbox
                //
                int iTXCurX = iTxtStartX + (i % iRowCount == 0 ? iRowCount - 1 : (i % iRowCount) - 1) * iNextTxWidthPos;
                int iTXCurY = iTxtStartY + ((i - 1) / iRowCount) * (iTxtHeight + 10);

                TextBox txtbTmp = new TextBox();
                txtbTmp.AutoSize = true;
                txtbTmp.Location = new System.Drawing.Point(iTXCurX, iTXCurY);
                txtbTmp.Name = "textBox_S" + i;
                txtbTmp.Size = new System.Drawing.Size(100, 21);


                this.Controls.Add(txtbTmp);
                textAdded.Add(txtbTmp);
            }



        }

        public void SelectedFire()
        {
            ViewOliCard_VisibleChanged(null, null);

        }

        private void LoadBaseInfo()
        {
            if (m_ledCard == null)
            {
                return;
            }

            string strDevName = "";
            using (GLedDBEntities ent = new GLedDBEntities())
            {
                GL_Dev aDev = (from c in ent.GL_Dev where c.ID == m_ledCard.DevID select c).FirstOrDefault();
                if (aDev != null)                   
                {
                    strDevName = aDev.Name;
                }
            }

            textBox_bls.Text = m_ledCard.Brightness.ToString();
            textBox_isdouble.Text = m_ledCard.IsDouble==0?"单面":"双面";
            //textBox_commStatus.Text = "未检测";
            textBox_commtype.Text = strDevName;
            textBox_ScreenCount.Text = m_ledCard.ScreenCount.ToString();
            textBox_Module.Text = m_ledCard.CardModule;
            textBox_ID.Text = m_ledCard.Addr.ToString();
        }

        private void LoadOilValFromDB()
        {

        }


        private void ViewOliCard_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (CardIDSeled <= 0)
                {
                    return;
                }

                using (GLedDBEntities ent = new GLedDBEntities())
                {
                    m_ledCard = (from c in ent.GL_LedCard where c.ID == CardIDSeled select c).FirstOrDefault();
                }

                MakeLedText();

                LoadBaseInfo();
            }
        }

        private void textBox_S1_TextChanged(object sender, EventArgs e)
        {
            if (m_ledCard == null)
            {
                return;
            }
        }

        private void textBox_S1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 && e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != 46) e.Handled = true;
            int a = textBox_S1.Text.IndexOf('.');
            if (e.KeyChar == 46 && a > 0) e.Handled = true;
        }

        IList<string> m_lstContextOfView = new List<string>();
        private void buttonSaveToDb_Click(object sender, EventArgs e)
        {
            m_lstContextOfView.Clear();
            for(int i=1; i<=GLLedDefine.MaxScreen; i++)
            {
                foreach (object aObj in Controls)
                {
                    TextBox aTxtbox = aObj as TextBox;
                    if (aTxtbox != null)
                    {
                        if (aTxtbox.Name == "textBox_S"+i)
                        {
                            m_lstContextOfView.Add(aTxtbox.Text);
                            continue;
                        }
                    }
                }
            }


            string strContext = "";
            foreach (string astr in m_lstContextOfView)
            {
                if (strContext.Length > 0)
                {
                    strContext += "-";
                }
                strContext += astr;                
            }

            GL_LedContent aContext = new GL_LedContent()
            {
                CardID = m_ledCard.ID,
                Context = strContext,
                DevID = m_ledCard.DevID,
                LogDt = DateTime.Now,
                Status = (int)DBDefines.LedContextStatus.E_NEW_SET_NO_SEND,
            };

            DB.MemDB.Get().AddContext(aContext);

            m_ledCard.ScreentContext = strContext;
            DB.MemDB.Get().UpdateCard((int)m_ledCard.ID, m_ledCard);
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            bool bSendResult = false;
            List<GLLedDefine.CardOilValEachNumAByte> lstCardVal = new List<GLLedDefine.CardOilValEachNumAByte>();
            GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)m_ledCard.DevID);
            if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_SERIAL_COM)
            {
                Rs485Port aPort = new Rs485Port();
                aPort.SetDBDev(aDev);
                if (!aPort.Open())
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipOpCommFailed"));
                    return;
                }

                
                bSendResult = aPort.ReadOilVal((int)m_ledCard.Addr, ref lstCardVal);

            }
            else if ((DBDefines.DevTransferType)aDev.CommType == DBDefines.DevTransferType.E_TCP_CLIENT)
            {
                TCPLisenterPort pTcp = (TCPLisenterPort)TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                if (pTcp == null)
                {
                    MessageBox.Show(LanguageMgr.GetKey("TipConnTcpFailed"));
                    return;
                }

                buttonSaveToDb_Click(null, null);
                bSendResult = pTcp.ReadOilVal((int)m_ledCard.Addr, ref lstCardVal);
            }
            else
            {

            }

            if (bSendResult)
            {
                SetOilValToScreen(lstCardVal);
                MessageBox.Show(LanguageMgr.GetKey("OpSuccess"));
            }
            else
            {
                MessageBox.Show(LanguageMgr.GetKey("OpFailed"));
            }

        }

        private void SetOilValToScreen(List<GLLedDefine.CardOilValEachNumAByte> lstCardVal)
        {            
            for (int iSC = 1; iSC <= GLLedDefine.MaxScreen; iSC++)
            {
                foreach (object aObj in Controls)
                {
                    TextBox aTxtbox = aObj as TextBox;
                    if (aTxtbox != null)
                    {
                        if (aTxtbox.Name == "textBox_S" + iSC)
                        {
                            string strTmp = "";
                            for (int iNum=0; iNum<6; iNum++)
                            {
                                if (lstCardVal[iSC-1].lstArr.Count > iNum)
                                {
                                    strTmp += lstCardVal[iSC-1].lstArr[iNum].ToString();
                                }
                                else
                                {
                                    strTmp += "0";
                                }
                            }
                            aTxtbox.Text = strTmp;
                        }
                    }
                }
            }


            string strContext = "";
            foreach (string astr in m_lstContextOfView)
            {
                if (strContext.Length > 0)
                {
                    strContext += "-";
                }
                strContext += astr;
            }
        }
    }
}
