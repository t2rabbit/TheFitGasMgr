using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DmitryBrant.CustomControls;

namespace Property
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SevenSegment asev = new SevenSegment();
            asev.ColorDark = Color.Black;
            asev.ColorBackground = Color.Black;
            asev.Location = new Point(100, 100);
            asev.Value = "-";
            asev.Size = new System.Drawing.Size(30, 30);

            this.Controls.Add(asev);

            asev = new SevenSegment();
            asev.ColorDark = Color.Black;
            asev.ColorBackground = Color.Black;
            asev.Location = new Point(130, 100);
            asev.Value = "";
            asev.HadDot = true;
            asev.DecimalShow = false;
            asev.DoubleDot = true;
            asev.Size = new System.Drawing.Size(20, 30);

            this.Controls.Add(asev);
        }
    }
}
