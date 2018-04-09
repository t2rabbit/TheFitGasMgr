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
    public partial class ClickAbleArr : UserControl
    {
        public ClickAbleArr()
        {
            InitializeComponent();
        }

        public int ISubCount { get; set; }
        public int ISubHeight { get; set; }
        public int ISubWidth { get; set; }

        private List<ClickAbleCtl> m_arr = new List<ClickAbleCtl>();

        private void ClickAbleArr_Load(object sender, EventArgs e)
        {
            int iPosX = 0;
            int iPosY = 0;
            Size asize = new Size(ISubWidth, ISubHeight);

            for (int i = 0; i < ISubCount; i++)
            {
                ClickAbleCtl aCtl = new ClickAbleCtl();
                aCtl.Location = new Point(iPosX, iPosY);
                aCtl.Size = asize;

                iPosX += ISubWidth;
                iPosY += ISubHeight;

                this.Controls.Add(aCtl);
            }
        }
    }
}
