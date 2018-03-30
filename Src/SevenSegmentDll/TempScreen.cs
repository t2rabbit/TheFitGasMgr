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
    public partial class TempScreen : UserControl
    {
        public TempScreen()
        {
            InitializeComponent();
            bShowUint = true;
            iDigCount = 3;
            iDecmailIndex = 2;
            StrVal = "212";//21.2
            iDigWidth = 32;
            iUintFontSize = 40;
            iDigHeight = 64;
        }

        public bool bShowUint { get; set; }
        public int iDigCount { get; set; }
        public int iDecmailIndex { get; set; }
        public string StrVal { get; set; }

        public int iDigHeight { get; set; }
        public int iDigWidth { get; set; }
        public int iUintFontSize { get; set; }

        public List<SevenSegmentSplick> lstDig = new List<SevenSegmentSplick>();

        public void SetVal(string strVal)
        {
            strVal = strVal.Replace(".", "");
            for (int i = 0; i < strVal.Length; i++)
            {
                if (lstDig.Count > i)
                {
                    lstDig[i].Value = strVal.Substring(i, 1);
                }
            }

            Invalidate();
        }

        public int ReGetWidth()
        {
            int iPosx = 0;            
            for (int i = 0; i < iDigCount; i++)
            {
                iPosx += iDigWidth;                
            }

            if (bShowUint)
            {
                iPosx += iUintFontSize + iDigWidth;
            }
            return iPosx;

        }
        private void TempScreen_Load(object sender, EventArgs e)
        {
            int iPosx = 0;
            int iPosy = 0;
            Size szMain = new Size(iDigWidth, iDigHeight);

            labelUnit.Font = new System.Drawing.Font("7SEG", iUintFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            for (int i = 0; i < iDigCount; i++)
            {
                SevenSegmentSplick aItem = new SevenSegmentSplick();
                aItem.Location = new Point(iPosx, iPosy);
                aItem.Value = "8";
                aItem.Size = szMain;                
                iPosx += iDigWidth;
                Controls.Add(aItem);
                lstDig.Add(aItem);
                if (iDecmailIndex == i + 1)
                {
                    aItem.HadDot = true;
                }
            }

            labelUnit.Visible = bShowUint;
            if (bShowUint)
            {
                labelUnit.Location = new Point(iPosx, iPosy);
                iPosx += iUintFontSize + iDigWidth;
            }

            this.Size = new Size(iPosx, this.Height);

        }
    }
}
