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
    public partial class OilScreenEx : UserControl
    {
        public bool m_BAppend10_9;
        public bool m_BAppend99;

        public bool BAppend10_9 
        {
            get 
            { 
                return m_BAppend10_9; 
            }
            set 
            {
                m_BAppend10_9 = value;
                this.Invalidate();
            }
        }

        public bool BAppend99
        {
            get
            {
                return m_BAppend99;
            }

            set
            {
                m_BAppend99 = value;

                this.Invalidate();
            }
        }
        public int iAppendCount 
        {
            get { return sevenSegmentArray_99.ArrayCount; }
            set 
            {
                sevenSegmentArray_99.ArrayCount = value;
                if (value == 1)
                {
                    sevenSegmentArray_99.Width = 15;
                }
                else
                {
                    sevenSegmentArray_99.Width = 30;
                }

                sevenSegmentArray_99.Value = "88";
            } 
        }
        public int iMainCount
        {
            get 
            {
                return sevenSegmentArrayMain.ArrayCount; 
            }
            set 
            {
                sevenSegmentArrayMain.ArrayCount = value;
                sevenSegmentArrayMain.Width = 34 * value;
                panelAppend99.Location = new Point(34 * value, panelAppend99.Location.Y);
                panelAppend910.Location = new Point(34 * value, panelAppend910.Location.Y);
            }
        }
        
        public int iIndexOfPoint
        {
            get { return sevenSegmentArrayMain.IndexOfPoint; }
            set { sevenSegmentArrayMain.IndexOfPoint = value; }
        }

        public string strValue 
        {
            get {
                if (BAppend99)
                    return sevenSegmentArrayMain.Value + sevenSegmentArray_99.Value;
                else
                    return sevenSegmentArrayMain.Value;
            }

            set 
            {
                if (!m_BAppend99)
                {
                    sevenSegmentArrayMain.Value = value; 
                }
                else
                {
                    if (value.Length <= iAppendCount)
                    {
                        sevenSegmentArrayMain.Value = "";
                        sevenSegmentArray_99.Value = value;
                    }
                    else
                    {

                        sevenSegmentArrayMain.Value = value.Substring(0, value.Length-iAppendCount);
                        sevenSegmentArray_99.Value = value.Substring(value.Length-iAppendCount);
                    }
                }
            }
        }

        public OilScreenEx()
        {
            InitializeComponent();
        }

        private void OilScreen_Load(object sender, EventArgs e)
        {
            panelAppend99.Visible = BAppend99;
            panelAppend910.Visible = BAppend10_9;            
        }

        private void OilScreen_Paint(object sender, PaintEventArgs e)
        {
            panelAppend99.Visible = BAppend99;
            panelAppend910.Visible = BAppend10_9;            
        }

    

    }
}
