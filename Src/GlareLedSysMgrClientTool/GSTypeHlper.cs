using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Property
{
    class GSTypeHlper
    {

        static public void GetTypeInfoByString(string strType,
            out int iDigCount,
            out int iMainDigCount,
            out int iAppendDigCount,
            out bool bAppend99,
            out bool bIsShowAppend910)
        {
            iDigCount = 0;
            iMainDigCount = 0;
            iAppendDigCount = 0;
            bAppend99 = false;
            bIsShowAppend910 = false;

            //"GS-8888-99"
            string[] strInfo = strType.Split(new char[] { '-', ',' });
            if (strInfo.Count() < 1)
            {
                return;
            }

            int iCountMain = strInfo[1].Length;
            iMainDigCount = iCountMain;

            if (strInfo.Length < 3)
            {
                bAppend99 = false;
                bIsShowAppend910 = false;
            }
            else
            {
                if (strInfo[2] == "910")
                {
                    bIsShowAppend910 = true;
                    bAppend99 = false;
                }
                else if (strInfo[2] == "99")
                {
                    bIsShowAppend910 = false;
                    bAppend99 = true;
                    iAppendDigCount = 2;
                }
                else if (strInfo[2] == "9")
                {
                    bIsShowAppend910 = false;
                    bAppend99 = true;
                    iAppendDigCount = 1;
                }
                else
                {
                    bIsShowAppend910 = false;
                    bAppend99 = false;
                }
            }

            iDigCount = iMainDigCount + iAppendDigCount;
        }

        static public int[] GetDecArrByString(string strDecInfo)
        {
            string[] strArrDecInfo = strDecInfo.Split(new char[] { ' ', ',', '-' });
            int[] arrD = new int[12];
            for (int i = 0; i < 12; i++)
            {
                int iTmp = 0;
                if (strArrDecInfo.Length > i)
                {
                    int.TryParse(strArrDecInfo[i], out iTmp);
                    arrD[i] = iTmp;
                }
                else
                {
                    arrD[i] = 0;
                }
            }
            return arrD;
        }

        static public void  GetDecArrByString(string strDecInfo, int[] arrD)
        {
            string[] strArrDecInfo = strDecInfo.Split(new char[] { ' ', ',', '-' });            
            for (int i = 0; i < 12; i++)
            {
                int iTmp = 0;
                if (strArrDecInfo.Length > i)
                {
                    int.TryParse(strArrDecInfo[i], out iTmp);
                    arrD[i] = iTmp;
                }
                else
                {
                    arrD[i] = 0;
                }
            }
        }


        /// <summary>
        /// 根据类型串获取时间温度屏信息
        /// </summary>
        static public bool GetTypeInfoByString(string strType,
            out int iYearCount,
            out int iMonthCount,
            out int iDayCount,
            out int iHourCount,
            out int iMinuteCount,
            out int iSecCount,
            out int iTempCount,
            out int iTempDecIndex,
            out int iTemUint,
            out int iTempShowType)
        {
            iYearCount = 0;
            iMonthCount = 0;
            iDayCount = 0;
            iHourCount = 0;
            iMinuteCount = 0;
            iSecCount = 0;
            iTempCount = 0;
            iTempDecIndex = 0;
            iTempShowType = 0;
            iTemUint = 0;

            string[] strArr = strType.Split(new char[] { '-' });
            if (strArr.Length < 2)
            {
                return false;
            }

            string strTime = strArr[1];
            if (strTime.IndexOf("YY") >= 0)
            {
                iYearCount = 2;
            }
            if (strTime.IndexOf("YYYY") >= 0)
            {
                iYearCount = 4;
            }
            if (strTime.IndexOf("mm") >= 0)
            {
                iMonthCount = 2;
            }
            if (strTime.IndexOf("DD") >= 0)
            {
                iDayCount = 2;
            }
            if (strTime.IndexOf("HH") >= 0)
            {
                iHourCount = 2;
            }
            if (strTime.IndexOf("MM") >= 0)
            {
                iMinuteCount = 2;
            }
            if (strTime.IndexOf("SS") >= 0)
            {
                iSecCount= 2;
            }

            if (strTime.IndexOf("TT") >= 0)
            {
                iTempCount = 2;
                iTempDecIndex = 0;
            }
            if (strTime.IndexOf("TTT") >= 0)
            {
                iTempCount = 3;
                iTempDecIndex = 2;    
            }

            // 预先设定交替
            iTempShowType = 1;

            //
            // 是否在末尾显示
            //
            if (strArr.Length > 2)
            {
                if (strArr[2].IndexOf("TT") >= 0)
                {
                    iTempShowType = 2;
                    iTempCount = 2;
                    iTempDecIndex = 0;
                }
                else if (strArr[2].IndexOf("TTT") >= 0)
                {
                    iTempShowType = 2;
                    iTempCount = 3;
                    iTempDecIndex = 2;
                }
                else
                {
                }
            }

            if (iTempCount == 0)
            {
                iTempShowType = 0;
            }

            if (strType.IndexOf("U") >= 0)
            {
                iTemUint = 1;
            }

            return true;
        }
    }
}
