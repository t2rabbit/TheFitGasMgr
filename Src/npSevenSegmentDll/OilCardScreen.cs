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
    public partial class OilCardScreen : UserControl
    {
        public OilCardScreen()
        {
            InitializeComponent();
            iMainDigHeigh = 64;
            iMainDigWidth = 32;
            iAppend99Width = 16;
            iAppend99Height = 32;
            iDecmialInMain = 1;
            iOilCardDigCount = 6;

            iShow99 = 0;
            bShow10_9 = true;
        }

        /// <summary>
        /// 是否可以修改,false :只读
        /// </summary>
        public bool bEnableMdy { get; set; }

        public int iMainDigWidth { get; set; }
        public int iMainDigHeigh { get; set; }
        public int iAppend99Width { get; set; }
        public int iAppend99Height { get; set; }

        /// <summary>
        /// 小数点在主节点的那个位置
        /// </summary>
        public int iDecmialInMain { get; set; }

        /// <summary>
        /// 主油价牌数量
        /// </summary>
        public int iOilCardDigCount
        {
            get { return m_iOilCardDigCount; }
            set
            {
                m_iOilCardDigCount = value;
                RemakeOilDig();
            }
        }

        private int m_iOilCardDigCount;

        /// <summary>
        /// 显示10/9
        /// </summary>
        public bool bShow10_9 { get; set; }

        /// <summary>
        /// 显示99
        /// </summary>
        public int iShow99 { get; set; }

        private List<SevenSegmentSplick> m_lstDig = new List<SevenSegmentSplick>();

        private string m_sDigValue;
        public string DigValue
        {
            set
            {
                m_sDigValue = value;
                for (int i = 0; i < m_sDigValue.Count(); i++)
                {
                    if (m_lstDig.Count<=i)
                    {
                        return;
                    }

                    m_lstDig[i].Value = m_sDigValue[i].ToString();
                }
            }

            get
            {
                string strValTmp = "";
                for (int i = 0; i < m_lstDig.Count(); i++)
                {
                    strValTmp += m_lstDig[i].Value;
                }
                return strValTmp;
            }
        }

        private void RemakeOilDig()
        {
            Controls.Clear();
            m_lstDig.Clear();

            int iPosx = 0;
            int iPosy = 0;
            Size szMain = new Size(iMainDigWidth, iMainDigHeigh);
            Size szApp = new Size(iAppend99Width, iAppend99Height);

            for (int i = 0; i < iOilCardDigCount; i++)
            {
                SevenSegmentSplick aitem = new SevenSegmentSplick();
                if (bEnableMdy)
                {
                    aitem.BSplickAble = true;
                }
                else
                {
                    aitem.BSplickAble = false;
                }

                aitem.Location = new Point(iPosx, iPosy);
                aitem.Size = szMain;
                aitem.Value = "8";
                Controls.Add(aitem);
                iPosx += iMainDigWidth;
                if (iDecmialInMain == i + 1)
                {
                    aitem.HadDot = true;
                }
                m_lstDig.Add(aitem);
            }

            if (iShow99 > 0)
            {
                for (int i = 0; i < iShow99; i++)
                {
                    SevenSegmentSplick aitem = new SevenSegmentSplick();
                    if (bEnableMdy)
                    {
                        aitem.BSplickAble = true;
                    }
                    else
                    {
                        aitem.BSplickAble = false;
                    }

                    aitem.Location = new Point(iPosx, iPosy);
                    aitem.Padding = new Padding(2, 2, 2, 2);
                    aitem.Size = szApp;
                    aitem.Value = "8";
                    Controls.Add(aitem);
                    iPosx += iAppend99Width;
                    m_lstDig.Add(aitem);
                }
            }
            else
            {
                if (bShow10_9)
                {

                    SevenSegmentSplick aitem = new SevenSegmentSplick();
                    aitem.Padding = new Padding(4, 4, 4, 4);
                    aitem.BSplickAble = false;
                    aitem.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
                    aitem.Location = new Point(iPosx + iAppend99Width, iPosy);
                    aitem.Size = szApp;
                    aitem.Value = "9";
                    Controls.Add(aitem);


                    Panel apline = new Panel();
                    apline.Location = new Point(iPosx + 6, iMainDigHeigh / 2);
                    apline.Size = new Size(iAppend99Width * 2 - 6, 2);
                    apline.BackColor = Color.Red;
                    Controls.Add(apline);

                    iPosy += iMainDigHeigh / 2 + 1;
                    aitem = new SevenSegmentSplick();
                    aitem.Padding = new Padding(4, 4, 4, 4);
                    aitem.BSplickAble = false;
                    aitem.Location = new Point(iPosx, iPosy);
                    aitem.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
                    aitem.Size = szApp;
                    aitem.Value = "1";
                    Controls.Add(aitem);

                    iPosx += iAppend99Width;
                    aitem = new SevenSegmentSplick();
                    aitem.Padding = new Padding(4, 4, 4, 4);
                    aitem.BSplickAble = false;
                    aitem.Location = new Point(iPosx, iPosy);
                    aitem.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
                    aitem.Size = szApp;
                    aitem.Value = "0";
                    Controls.Add(aitem);
                }
            }
        }

        private void OilCardScreen_Load(object sender, EventArgs e)
        {
            RemakeOilDig();
        }
    }
}
