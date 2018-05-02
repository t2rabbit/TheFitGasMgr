using PiPublic.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LogInfo log;
            int iRty = 30;
            bool bGetted = true;
            while(bGetted && iRty>0)
            {
                iRty--;
                bGetted = LogMgr.GetTopLog(out log);
                if(bGetted)
                {
                    if (checkBoxAll.Checked)
                    {
                        listBox1.Items.Add(log.LogSubSys + ":" +log.LogMsg);
                    }
                    else if (log.LogType == LogType.LogTypeError && checkBoxError.Checked)
                    {
                        listBox1.Items.Add(log.LogSubSys + ":" + log.LogMsg);
                    }
                    else if (log.LogType == LogType.LogTypeWarring && checkBoxWarring.Checked)
                    {
                        listBox1.Items.Add(log.LogSubSys + ":" + log.LogMsg);
                    }
                    else if (log.LogType == LogType.LogTypeDebug && checkBoxDebug.Checked)
                    {
                        listBox1.Items.Add(log.LogSubSys + ":" + log.LogMsg);
                    }
                    else if (log.LogType == LogType.LogTypeInfo && checkBoxInfo.Checked)
                    {
                        listBox1.Items.Add(log.LogSubSys + ":" + log.LogMsg);
                    }
                    else
                    {

                    }

                    if (listBox1.Items.Count > 1000)
                    {
                        listBox1.Items.RemoveAt(0);
                    }
                }
            }
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
