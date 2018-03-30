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
using YDesmsPublicDefDll.Public;
using Property.DB;


namespace Property
{
    public partial class ViewListCards : Form
    {
        public ViewListCards()
        {
            InitializeComponent();
        }
        public enum EListType
        {
            E_ALL_CARDS,
            E_ALL_ITF_COMM_ALL_ORG,
            E_ALL_ITF_TCPSERVER_ALL_ORG,
            E_ALL_ITF_TCPCLIENT_ALL_ORG,
            E_CARD_OF_ADEV,
            E_CARD_OF_A_ORG_ALL_ITF,
            E_CARD_OF_A_ORG_A_COMM,
            E_CARD_OF_A_ORG_A_TCPSERVER,
            E_CARD_OF_A_ORG_A_TCPCLIENT,            
        }

        public EListType eListType { get; set; }
        public int iSelOrgID { get; set; }
        public int iSelDevID { get; set; }
        public string strTipCurSel { get; set; }
        
        private void ViewListCards_Load(object sender, EventArgs e)
        {
            eListType = EListType.E_ALL_CARDS;
            datagridviewCheckboxHeaderCell chCard = new datagridviewCheckboxHeaderCell();
            chCard.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(chDev_OnCheckBoxClicked);//关联单击事件
            DataGridViewCheckBoxColumn checkboxColCard = this.dataGridViewCards.Columns[0] as DataGridViewCheckBoxColumn;
            checkboxColCard.HeaderCell = chCard;
            checkboxColCard.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字
        }

        private void chDev_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.dataGridViewCards.Rows)
            {
                if (e.CheckedState)
                {
                    dgvRow.Cells[0].Value = true;
                }
                else
                {
                    dgvRow.Cells[0].Value = false;
                }
            }
        }


        public void SelectFire()
        {
            ViewListCards_VisibleChanged(null, null);
        }

        private void ViewListCards_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == false)
            {
                return;
            }
            IList<GL_LedCard> lstcards = new List<GL_LedCard>();
            switch (eListType)
            {
                case EListType.E_ALL_CARDS:
                    foreach(GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        lstcards.Add(aCard);
                    }
                    break;
                case EListType.E_ALL_ITF_COMM_ALL_ORG:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM)
                            {
                                lstcards.Add(aCard);
                            }
                        }                        
                    }
                    break;

                case EListType.E_ALL_ITF_TCPSERVER_ALL_ORG:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_SERVER)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
                case EListType.E_ALL_ITF_TCPCLIENT_ALL_ORG:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
                case EListType.E_CARD_OF_ADEV:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.ID == iSelDevID)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
//                 case EListType.E_CARD_OF_ATCPSERVER_ALL_ORG:
//                     foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
//                     {
//                         GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
//                         if (aDev != null)
//                         {
//                             if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_SERVER && aDev.ID == iSelDevID)
//                             {
//                                 lstcards.Add(aCard);
//                             }
//                         }
//                     }
//                     break;
//                 case EListType.E_CARD_OF_ATCPCLIENT_ALL_ORG:
//                     foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
//                     {
//                         GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
//                         if (aDev != null)
//                         {
//                             if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT && aDev.ID == iSelDevID)
//                             {
//                                 lstcards.Add(aCard);
//                             }
//                         }
//                     }
//                     break;
                case EListType.E_CARD_OF_A_ORG_ALL_ITF:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        if (aCard.OrgID== (int)iSelOrgID)
                        {
                            lstcards.Add(aCard);
                        }                        
                    }
                    break;
//                 case EListType.E_CARD_OF_A_ORG_ALL_COMM_ITF:
//                     foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
//                     {
//                         GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
//                         if (aDev != null)
//                         {
//                             if (aDev.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM && aCard.OrgID == iSelOrgID)
//                             {
//                                 lstcards.Add(aCard);
//                             }
//                         }
//                     }
//                     break;
//                 case EListType.E_CARD_OF_A_ORG_ALL_TCPSERVER_ITF:
//                     foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
//                     {
//                         GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
//                         if (aDev != null)
//                         {
//                             if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_SERVER && aCard.OrgID == iSelOrgID)
//                             {
//                                 lstcards.Add(aCard);
//                             }
//                         }
//                     }
//                     break;
//                 case EListType.E_CARD_OF_A_ORG_ALL_TCPCLIENT_ITF:
//                     foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
//                     {
//                         GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
//                         if (aDev != null)
//                         {
//                             if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT && aCard.OrgID == iSelOrgID)
//                             {
//                                 lstcards.Add(aCard);
//                             }
//                         }
//                     }
//                     break;
                case EListType.E_CARD_OF_A_ORG_A_COMM:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.ID == iSelDevID && aCard.OrgID == iSelOrgID)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
                case EListType.E_CARD_OF_A_ORG_A_TCPSERVER: 
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.ID == iSelDevID && aCard.OrgID == iSelOrgID)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
                case EListType.E_CARD_OF_A_ORG_A_TCPCLIENT:
                    foreach (GL_LedCard aCard in DB.MemDB.Get().lstCard)
                    {
                        GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                        if (aDev != null)
                        {
                            if (aDev.ID == iSelDevID && aCard.OrgID == iSelOrgID)
                            {
                                lstcards.Add(aCard);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }


            dataGridViewCards.Rows.Clear();
            foreach (GL_LedCard aCard in lstcards)
            {
                GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                GL_Org aOrg = DB.MemDB.Get().GetOrgByOrgID((int)aCard.OrgID);
                if (aDev == null || aOrg == null)
                {
                   // MessageBox.Show("infomation is wrong");
                    continue;
                }
                string strIsConn = "未检测";
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT)
                {
                    bool bConned = TcpServerForGPRSDev.Get().GetDevIsConnected((int)aDev.ID);
                    strIsConn = bConned?"在线":"不在线";
                }

                int i = dataGridViewCards.Rows.Add(new object[]{
                    false,
                    aCard.Name,
                    aCard.CardModule,
                    aCard.Addr,
                    aDev.Name,
                    DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                    aOrg.Name,
                    aCard.ScreenCount,
                    aCard.ScreentContext,
                    strIsConn,
                });

                dataGridViewCards.Rows[i].Tag = aCard;
            }

            textBox1.Text = strTipCurSel;
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetContext_Click(object sender, EventArgs e)
        {
            int iSeled = 0;
            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    iSeled++;
                }
            }

            if (iSeled <= 0)
            {
                return;
            }

            FormSetContextVal dlg = new FormSetContextVal();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    GL_LedCard aCard = aRow.Tag as GL_LedCard;
                    aCard.ScreentContext = dlg.strContext;
                    MemDB.Get().UpdateCard((int)aCard.ID, aCard);
                }
            }
            
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            IList<GL_LedCard> lstCard = new List<GL_LedCard>();
            foreach (DataGridViewRow aRow in dataGridViewCards.Rows)
            {
                if (aRow.Cells[0].Value.ToString().CompareTo("True") == 0)
                {
                    lstCard.Add((GL_LedCard)aRow.Tag);
                }
            }

            FormSendToCardTip dlg = new FormSendToCardTip();
            dlg.lstCardToSend = lstCard;
            dlg.ShowDialog();
        }


    }
}
