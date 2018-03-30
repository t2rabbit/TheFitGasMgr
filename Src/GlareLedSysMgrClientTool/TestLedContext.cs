using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Property
{
    public partial class TestLedContext : Form
    {
        public TestLedContext()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oilScreenEx1.strValue = "111.22";
        }
    }
}
