using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DmitryBrant.CustomControls;

namespace SevenSegTest
{
    public partial class TimeTemputer : UserControl
    {
        public TimeTemputer()
        {
            InitializeComponent();
            IDigWidth = 30;
            IDigHeight = 60;
            IsShowYear = true;
            YearCount = 4;
            IsShowMonth = true;
            IsShowDay = true;
            IsShowHour = true;
            IsShowMinute = true;
            IsShowSecond = true;

            BFiexZero = true;
            BShowDashDot = true;
            IDashDotWidth = 20;
            dtTime = DateTime.Now;
        }

        public void ResetSizeByVal()
        {
            this.Size = new Size(m_bWidthReset, m_bHeightReset);
        }
        public int m_bWidthReset = 0;
        private int m_bHeightReset = 0;


        public bool IsShowYear { get; set; }
        public int YearCount { get; set; }
        public bool IsShowDashAfterYear { get; set; }

        public bool IsShowMonth { get; set; }
        public bool IsShowDay { get; set; }

        public bool IsShowHour { get; set; }
        public bool IsShowMinute { get; set; }
        public bool IsShowSecond { get; set; }
        

        public int IDigWidth { get; set; }
        public int IDigHeight { get; set; }
        public int IDashDotWidth { get; set; }

        public DateTime dtTime { get; set; }

        /// <summary>
        /// 是否填充0, 如2010-01-01 00:00:00==>2010- 1- 1  0: 0: 0
        /// </summary>
        public bool BFiexZero { get; set; }

        /// <summary>
        /// 是否显示减号好双冒号
        /// </summary>
        public bool BShowDashDot { get; set; } 

        SevenSegment[] m_sevArrYear = new SevenSegment[4];
        SevenSegment[] m_sevArrMonth = new SevenSegment[4];
        SevenSegment[] m_sevArrDay = new SevenSegment[4];
        SevenSegment[] m_sevArrHour = new SevenSegment[4];
        SevenSegment[] m_sevArrMintue = new SevenSegment[4];
        SevenSegment[] m_sevArrSeconde = new SevenSegment[4];
        SevenSegment[] m_sevArrDash = new SevenSegment[4];
        SevenSegment[] m_sevArrShowDoubDot = new SevenSegment[4];

        public void SetVal(DateTime dt)
        {
            if (IsShowYear&&YearCount ==2 )
            {
                m_sevArrYear[0].Value = (dt.Year % 100 / 10).ToString();
                m_sevArrYear[0].Value = (dt.Year % 10).ToString();
            }
            if (IsShowYear&&YearCount == 4)
            {
                m_sevArrYear[0].Value = (dt.Year / 1000).ToString();
                m_sevArrYear[1].Value = (dt.Year % 1000 / 100).ToString();
                m_sevArrYear[2].Value = (dt.Year % 100 / 10).ToString();
                m_sevArrYear[3].Value = (dt.Year % 10).ToString();
            }

            if (IsShowMonth)
            {
                m_sevArrMonth[0].Value = (dt.Month / 10 < 0 ? "" : (dt.Month / 10).ToString());
                m_sevArrMonth[1].Value = (dt.Month % 10).ToString();
            }

            if (IsShowDay)
            {
                m_sevArrDay[0].Value = (dt.Day / 10 < 0 ? "" : (dt.Day / 10).ToString());
                m_sevArrDay[1].Value = (dt.Day % 10).ToString();
            }

            if (IsShowHour)
            {
                m_sevArrHour[0].Value = (dt.Hour / 10).ToString();
                m_sevArrHour[1].Value = (dt.Hour % 10).ToString();
            }
            if (IsShowMinute)
            {
                m_sevArrMintue[0].Value = (dt.Minute / 10).ToString();
                m_sevArrMintue[1].Value = (dt.Minute % 10).ToString();
            }
            if (IsShowSecond)
            {
                m_sevArrSeconde[0].Value = (dt.Second / 10).ToString();
                m_sevArrSeconde[1].Value = (dt.Second % 10).ToString();
            }

            this.Invalidate();
        }


        private void Init(SevenSegment[] arr)
        {
            for (int i = 0; i < 4; i++)
            {
                arr[i] = new SevenSegment();
                arr[i].ColorBackground = Color.Black;
                arr[i].ColorDark = Color.Black;
                arr[i].ColorLight = Color.Red;
                arr[i].Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            }
        }


        public int ReGetWidth()
        {

            int ix = 0;
            if (IsShowYear)
            {
                for (int i = 0; i < YearCount; i++)
                {
                    ix += IDigWidth;
                }

                if (BShowDashDot && IsShowMonth)
                {
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }
            }

            if (IsShowMonth)
            {
                for (int i = 0; i < 2; i++)
                {
                    
                    ix += IDigWidth;
                }

                if (BShowDashDot && IsShowDay)
                {
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }
            }

            if (IsShowDay)
            {
                for (int i = 0; i < 2; i++)
                {
                    ix += IDigWidth;
                }

                ix += IDigWidth;
            }

            if (IsShowHour)
            {
                for (int i = 0; i < 2; i++)
                {
                   
                    ix += IDigWidth;
                }

                if (BShowDashDot && IsShowMinute)
                {
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }


            }

            if (IsShowMinute)
            {
                for (int i = 0; i < 2; i++)
                {
                    ix += IDigWidth;
                }

                if (BShowDashDot && IsShowSecond)
                {
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }

            }
            if (IsShowSecond)
            {
                for (int i = 0; i < 2; i++)
                {
                    ix += IDigWidth;
                }

            }

            return ix + IDigWidth;
        }

        private void TimeTemputer_Load(object sender, EventArgs e)
        {
            m_bHeightReset = IDigHeight + 4;
            Init(m_sevArrYear);
            Init(m_sevArrMonth);
            Init(m_sevArrDay);
            Init(m_sevArrHour);
            Init(m_sevArrMintue);
            Init(m_sevArrSeconde);
            Init(m_sevArrDash);
            Init(m_sevArrShowDoubDot);
            

            int ix = 0;
            int iy = 0;
            Point pt = new Point(ix, iy);
            Size st = new Size(IDigWidth, IDigHeight);
            if (IsShowYear)
            {
                for (int i = 0; i < YearCount; i++)
                {
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);                    
                    m_sevArrYear[i].Location = pt;
                    m_sevArrYear[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrYear[i].Value = (dtTime.Year/1000).ToString();
                    }
                    else if (i == 1)
                    {
                        m_sevArrYear[i].Value = ((dtTime.Year % 1000) / 100).ToString();
                    }
                    else if (i == 2)
                    {
                        m_sevArrYear[i].Value = ((dtTime.Year % 100) / 10).ToString();
                    }
                    else 
                    {
                        m_sevArrYear[i].Value = (dtTime.Year % 10).ToString();
                    }
                    
                    this.Controls.Add(m_sevArrYear[i]);
                    ix += IDigWidth;
                }

                if (BShowDashDot&&IsShowMonth)
                {
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrDash[0].Location = pt;
                    m_sevArrDash[0].Size = st;
                    m_sevArrDash[0].Value = "-";
                    ix += IDigWidth;
                    this.Controls.Add(m_sevArrDash[0]);
                }
                else
                {
                    ix += IDashDotWidth;
                }


            }
            
            if (IsShowMonth)
            {
                for (int i = 0; i < 2; i++)
                {
                    
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrMonth[i].Location = pt;
                    m_sevArrMonth[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrMonth[i].Value = (dtTime.Month / 10).ToString();
                    }
                    else
                    {
                        m_sevArrMonth[i].Value = (dtTime.Month % 10).ToString();
                    }
                    this.Controls.Add(m_sevArrMonth[i]);
                    ix += IDigWidth;
                }
                            
                if (BShowDashDot&&IsShowDay)
                {
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrDash[1].Location = pt;
                    m_sevArrDash[1].Size = st;
                    m_sevArrDash[1].Value = "-";
                    ix += IDigWidth;
                    this.Controls.Add(m_sevArrDash[1]);
                }
                else
                {
                    ix += IDashDotWidth;
                }
            }

            if (IsShowDay)
            {
                for (int i = 0; i < 2; i++)
                {

                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrDay[i].Location = pt;
                    m_sevArrDay[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrDay[i].Value = (dtTime.Day / 10).ToString();
                    }
                    else
                    {
                        m_sevArrDay[i].Value = (dtTime.Day % 10).ToString();
                    }
                    this.Controls.Add(m_sevArrDay[i]);
                    ix += IDigWidth;
                }

                ix += IDigWidth;
            }

            if (IsShowHour)
            {
                for (int i = 0; i < 2; i++)
                {

                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrHour[i].Location = pt;
                    m_sevArrHour[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrHour[i].Value = (dtTime.Hour/10).ToString();
                    }
                    else
                    {
                        m_sevArrHour[i].Value = (dtTime.Hour % 10).ToString();
                    }
                    this.Controls.Add(m_sevArrHour[i]);
                    ix += IDigWidth;
                }

                if (BShowDashDot &&IsShowMinute)
                {
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrDash[2].Location = pt;
                    m_sevArrDash[2].Size = st;
                    m_sevArrDash[2].HadDot = true;
                    m_sevArrDash[2].DoubleDot = true;
                    m_sevArrDash[2].DecimalShow = false;
                    m_sevArrDash[2].Value = "";
                    this.Controls.Add(m_sevArrDash[2]);
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }
                

            }

            if (IsShowMinute)
            {
                for (int i = 0; i < 2; i++)
                {

                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrMintue[i].Location = pt;
                    m_sevArrMintue[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrMintue[i].Value = (dtTime.Minute / 10).ToString();
                    }
                    else
                    {
                        m_sevArrMintue[i].Value = (dtTime.Minute % 10).ToString();
                    }
                    this.Controls.Add(m_sevArrMintue[i]);
                    ix += IDigWidth;
                }

                if (BShowDashDot && IsShowSecond)
                {
                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrDash[3].Location = pt;
                    m_sevArrDash[3].Size = st;
                    m_sevArrDash[3].HadDot = true;
                    m_sevArrDash[3].DoubleDot = true;
                    m_sevArrDash[3].DecimalShow = false;
                    m_sevArrDash[3].ColorDark = Color.Black;

                    m_sevArrDash[3].Value = "";
                    this.Controls.Add(m_sevArrDash[3]);
                    ix += IDigWidth;
                }
                else
                {
                    ix += IDashDotWidth;
                }

            }
            if (IsShowSecond)
            {
                for (int i = 0; i < 2; i++)
                {

                    pt = new Point(ix, iy);
                    st = new Size(IDigWidth, IDigHeight);
                    m_sevArrSeconde[i].Location = pt;
                    m_sevArrSeconde[i].Size = st;
                    if (i == 0)
                    {
                        m_sevArrSeconde[i].Value = (dtTime.Second / 10).ToString();
                    }
                    else
                    {
                        m_sevArrSeconde[i].Value = (dtTime.Second % 10).ToString();
                    }
                    this.Controls.Add(m_sevArrSeconde[i]);
                    ix += IDigWidth;
                }

            }



            m_bWidthReset = ix + 4;

            ResetSizeByVal();
        }

        private void TimeTemputer_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.Assert(false);
        }
        public delegate void MyDelegate(object sender, EventArgs e);
        public event MyDelegate myEvent;
        private void TimeTemputer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Assert(false);
        }

        private void TimeTemputer_MouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.Assert(false);
        }

        private void TimeTemputer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
    }
}
