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
    public partial class LedOilScreen : Form
    {
        public LedOilScreen()
        {
            InitializeComponent();
        }

        private void LedOilScreen_Load(object sender, EventArgs e)
        {

        }


        //
        // 设置显示
        //
        private int iMainWidth = 30;
        private int iMainPadd = 4;
        private void SetDisPlayByType(string strType)
        {
            string[] strInfo = strType.Split(new char[] { '-', ',' });
            if (strInfo.Count() != 3)
            {
                return;
            }

            int iCountMain = strInfo[0].Length;
            int iWidht = iCountMain * 30 + (iCountMain + 1) * iMainPadd;
            sevenSegmentArrayMain.Width = iWidht;
            int iStartY_1 = sevenSegmentArrayMain.Left + iWidht;
            panelAppend99.Left = iStartY_1;
            panelAppend910.Left = iStartY_1;
            //             sevenSegmentT1.Left = iStartY_1;
            //             sevenSegmentD1.Left = iStartY_1;
            //             sevenSegmentT2.Left = sevenSegmentT1.Right;
            //             sevenSegmentD2.Left = sevenSegmentD1.Right;

            int iPointIndex = 0;
            int.TryParse(strInfo[1], out iPointIndex);
            if (iPointIndex < 0)
            {
                iPointIndex = 0;
            }
            sevenSegmentArrayMain.IndexOfPoint = iPointIndex;

            if (strInfo[2] == "9")
            {
                panelAppend910.Visible = false;
                panelAppend99.Visible = true;
//                 sevenSegmentT1.Visible = true;
//                 sevenSegmentT2.Visible = false;
            }
            else if (strInfo[2] == "99")
            {
                panelAppend910.Visible = false;
                panelAppend99.Visible = true;
//                 sevenSegmentT1.Visible = true;
//                 sevenSegmentT2.Visible = true;
            }
            else if (strInfo[2] == "910")
            {
                panelAppend910.Visible = true;
                panelAppend99.Visible = false;
//                 sevenSegmentT1.Visible = false;
//                 sevenSegmentT2.Visible = false;

            }
            else
            {
                panelAppend99.Visible = false;
                panelAppend910.Visible = false;
            }


//             sevenSegment10_9_0.Value = "0";
//             sevenSegment10_9_1.Value = "1";
            sevenSegment_10_9_9.Value = "9";
        }

    }
}
