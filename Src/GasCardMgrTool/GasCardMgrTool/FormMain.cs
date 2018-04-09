using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlareLedSysEfDb;


namespace GasCardMgrTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonMakefMgr_Click(object sender, EventArgs e)
        {
            test001.DelCommDev(3);
        }
    }
}
