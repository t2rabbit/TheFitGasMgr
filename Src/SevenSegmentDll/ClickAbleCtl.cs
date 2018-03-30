using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SevenSegTest
{
    public partial class ClickAbleCtl : UserControl
    {
        public ClickAbleCtl()
        {
            InitializeComponent();
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
        }

        private void ClickAbleCtl_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.Selectable, true);
            //Click += new EventHandler(btn_Click);
        }
        System.Timers.Timer t;
        private void ClickAbleCtl_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("ClickAbleCtl_Enter");
            if (Focused)
            {
                if (t == null)
                {
                    t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
                    t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
                }
                t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
                t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                t.SynchronizingObject = this;
            }
            else
            {
                if (t != null)
                {
                    t.Enabled = false;
                }
            }
        }

        bool m_bSpik = true;
        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {            
            label1.Visible = m_bSpik;
            label2.Visible = !m_bSpik;
            m_bSpik = !m_bSpik;
        }

        private void ClickAbleCtl_Leave(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("ClickAbleCtl_Leave");
            if (t != null)
            {
                t.Enabled = false;
                m_bSpik = true;

                theout(null, null);
            }
        }
    }
}
