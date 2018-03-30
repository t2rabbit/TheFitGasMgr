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
using System.Threading;
using Property.DB;

namespace Property
{
    public partial class FormSendToCardTip : Form
    {
        public FormSendToCardTip()
        {
            InitializeComponent();
        }

        public IList<GL_LedCard> lstCardToSend{get;set;}

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow aRow in dataGridViewCardList.Rows)
            {
                GL_LedCard aCard = (aRow.Tag as GL_LedCard);
                if (aCard == null)
                {
                    continue;
                }

                IList<string> lstStrConext = GLLedProtocol.MakeStringListByContext(aCard.ScreentContext);

                GL_Dev aDev = DB.MemDB.Get().GetDevByID((int)aCard.DevID);
                if (aDev.CommType == (int)DBDefines.DevTransferType.E_TCP_CLIENT) 
                {
                    TCPLisenterPort aTcpClient = TcpServerForGPRSDev.Get().GetDevConnectedTcpClient((int)aDev.ID);
                    if (aTcpClient == null)
                    {
                        aRow.Cells[0].Value = "失败-未连接";
                    }
                    else
                    {
                        if (aTcpClient.SendOilContext((int)aCard.Addr, lstStrConext))
                        {
                            aRow.Cells[0].Value = "成功";
                        }
                        else
                        {
                            aRow.Cells[0].Value = "失败-代号未知";
                        }
                    }
                }

                if (aDev.CommType == (int)DBDefines.DevTransferType.E_SERIAL_COM)
                {
                    Devs.Rs485Port aPort = new Devs.Rs485Port();
                    aPort.SetDBDev(aDev);
                    if (!aPort.Open())
                    {
                        aRow.Cells[0].Value = "失败-串口";                        
                    }
                    else
                    {
                        if (aPort.SendOilContext((int)aCard.Addr, lstStrConext) )
                        {
                            aRow.Cells[0].Value = "成功";
                        }
                        else
                        {
                            aRow.Cells[0].Value = "失败-代号未知";
                        }
                    }

                    aPort.Close();
                    
                }
            }
        }

        private void FormSendToCardTip_Load(object sender, EventArgs e)
        {
            if (lstCardToSend == null)
            {
                return;
            }

            foreach (GL_LedCard aCard in lstCardToSend)
            {
                GL_Dev aDev = MemDB.Get().GetDevByID((int)aCard.DevID);
                int iID = dataGridViewCardList.Rows.Add(new object[]{                                                         
                    "-未执行-",
                            aCard.Name + ":"  + aCard.Addr,
                            aDev.Name,
                            DBDefines.GetCommTypeString((DBDefines.DevTransferType)aDev.CommType),
                            aCard.ScreenCount,                              
                        });
                dataGridViewCardList.Rows[iID].Tag = aCard;
            }
        }


    }
}
