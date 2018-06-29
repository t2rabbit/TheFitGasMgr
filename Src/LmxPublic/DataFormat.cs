using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmxPublic
{
    public class DataFormat
    {
        /// <summary>
        /// 轉換DBNull to string
        /// </summary>
        /// <param name="obj1"></param>
        /// <returns></returns>
        public static string ConvertDBNullToString(Object obj1)
        {
            if (Convert.IsDBNull(obj1) || obj1 == null)
            {
                return "";
            }
            else
            {
                return obj1.ToString().Trim();
            }
        }

        /// <summary>
        /// 轉換DBNull to Int
        /// </summary>
        /// <param name="obj1"></param>
        /// <returns></returns>
        public static Int32 ConvertDBNullToInt32(Object obj1)
        {
            Int32 rtn1 = 0;
            if (Convert.IsDBNull(obj1) || obj1 == null)
            {
                rtn1 = 0;
            }
            else
            {
                if (obj1.ToString().Trim().Length > 0)
                {
                    Int32.TryParse(obj1.ToString(), out rtn1);
                }
            }
            return rtn1;
        }

        /// <summary>
        /// 轉換DBNull to Decimal
        /// </summary>
        /// <param name="obj1"></param>
        /// <returns></returns>
        public static Decimal ConvertDBNullToDecimal(Object obj1)
        {
            Decimal rtn1 = 0;
            if (Convert.IsDBNull(obj1) || obj1 == null)
            {
                rtn1 = 0;
            }
            else
            {
                if (obj1.ToString().Trim().Length > 0)
                {
                    Decimal.TryParse(obj1.ToString(), out rtn1);
                }
            }
            return rtn1;
        }

        /// <summary>
        /// 轉換DBNull to Double
        /// </summary>
        /// <param name="obj1"></param>
        /// <returns></returns>
        public static Double ConvertDBNullToDouble(Object obj1)
        {
            Double rtn1 = 0;
            if (Convert.IsDBNull(obj1) || obj1 == null)
            {
                rtn1 = 0;
            }
            else
            {
                if (obj1.ToString().Trim().Length > 0)
                {
                    Double.TryParse(obj1.ToString(), out rtn1);
                }
            }
            return rtn1;
        }

        /// <summary>
        /// 轉換DBNull to Datetime
        /// </summary>
        /// <param name="obj1"></param>
        /// <returns></returns>
        public static DateTime ConvertDBNullToDateTime(Object obj1)
        {
            DateTime rtn1 = new DateTime();
            if (Convert.IsDBNull(obj1) || obj1 == null || ConvertDBNullToString(obj1) == "")
            {
                rtn1 = new DateTime(1900, 1, 1);
            }
            else
            {
                if (obj1.ToString().Trim().Length > 0)
                {
                    DateTime.TryParse(obj1.ToString(), out rtn1);
                }
            }
            return rtn1;
        }

        /// <summary> 
        /// 是否是浮点数 可带正负号 
        /// </summary> 
        /// <param name="inputData">输入字符串 </param> 
        /// <returns> </returns> 
        //public static bool IsDecimalSign(string inputData)
        //{
        //    Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        //    Match m = RegDecimalSign.Match(inputData);
        //    return m.Success;
        //}
        /// <summary>
        /// 小数转人民币大写
        /// </summary>
        /// <param name="decMoney"></param>
        /// <returns></returns>
        static public string convertMoneytoRMB(decimal decMoney)
        {
            string qz = "";
            if (decMoney < 0)
            {
                qz = "负";
                decMoney = Math.Abs(decMoney);
            }
            decMoney = ConvertDBNullToDecimal(decMoney.ToString("f2"));
            string strMoney, strOneNum, strTemp, strConverted;
            int i, iLen;

            //设初值
            strConverted = "";
            strMoney = decMoney.ToString();
            iLen = strMoney.Length;

            //先取小数位
            if (strMoney.IndexOf(".") > 0)
            {
                strTemp = strMoney.Substring(strMoney.IndexOf(".") + 1, strMoney.Length - strMoney.IndexOf(".") - 1);
                if (strTemp.Length > 2)
                {
                    //Console.WriteLine("错误：无法计算超过2位的小数");
                    return strConverted;
                }
                else if (strTemp == "0" || strTemp == "00" || strTemp == "")
                    strTemp = "";
                else
                {
                    if (strTemp.Length == 1 && strTemp != "0")
                    {
                        strConverted = converNumtoCapital(strTemp) + "角" + strConverted;
                    }
                    else
                    {
                        strOneNum = strTemp.Substring(0, 1);
                        strConverted = converNumtoCapital(strOneNum) + (strOneNum != "0" ? "角" : "") + strConverted;
                        strOneNum = strTemp.Substring(1, 1);
                        strConverted = strConverted + (strOneNum != "0" ? converNumtoCapital(strOneNum) + "分" : "");
                    }
                }
            }

            //取整数部分
            if (strMoney.IndexOf(".") < 0)
                strTemp = strMoney;
            else
                strTemp = strMoney.Substring(0, strMoney.IndexOf("."));

            iLen = strTemp.Length;
            if (iLen > 0 && decimal.Parse(strTemp) != 0)
            {
                strConverted = "元" + strConverted;

                for (i = 0; i < iLen; ++i)
                {
                    strOneNum = strTemp.Substring(iLen - 1 - i, 1);
                    //if (strOneNum == "0")
                    //{
                    //    //Console.WriteLine(strConverted.Substring(0, 1));
                    //    if ((strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿") && !((i + 1) % 12 == 0 || (i + 1) == 5 || (i + 1) % 9 == 0))
                    //        continue;
                    //    else
                    //        strConverted = converNumtoCapital(strOneNum) + strConverted;
                    //}

                    //Console.WriteLine((i + 1) % 4);

                    if ((i + 1) == 1)
                    {
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + strConverted;
                    }
                    else if (((i + 1) % 4 == 2 || (i + 1) == 2) && i % 4 != 0 && i % 8 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "拾" + strConverted;
                    }
                    else if (((i + 1) % 4 == 3 || (i + 1) == 3) && i % 4 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "佰" + strConverted;
                    }
                    else if ((i + 1) % 4 == 0 && i % 4 != 0)
                    {
                        if (strOneNum == "0")
                        {
                            if (strConverted.Substring(0, 1) == "零" || strConverted.Substring(0, 1) == "元" || strConverted.Substring(0, 1) == "万" || strConverted.Substring(0, 1) == "亿")
                                continue;
                            else
                                strConverted = "零" + strConverted;
                        }
                        else
                            strConverted = converNumtoCapital(strOneNum) + "千" + strConverted;
                    }
                    else if (i % 4 == 0 && i % 8 != 0)
                    {
                        //Console.WriteLine("万位{0}", i);
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + "万" + strConverted;
                    }
                    else if (i % 8 == 0)
                    {
                        //Console.WriteLine("亿位{0}", i);
                        if (strConverted.Substring(0, 1) == "万") strConverted = strConverted.Substring(1, strConverted.Length - 1);
                        strConverted = (strOneNum == "0" ? "" : converNumtoCapital(strOneNum)) + "亿" + strConverted;
                    }
                    else
                    {
                        //Console.WriteLine(i);
                        strConverted = converNumtoCapital(strOneNum) + strConverted;
                    }
                }
            }

            return qz + strConverted;
        }

        private static string converNumtoCapital(string strNum)
        {
            string strCapital = "";
            switch (strNum)
            {
                case "0":
                    strCapital = "零";
                    break;
                case "1":
                    strCapital = "壹";
                    break;
                case "2":
                    strCapital = "贰";
                    break;
                case "3":
                    strCapital = "叁";
                    break;
                case "4":
                    strCapital = "肆";
                    break;
                case "5":
                    strCapital = "伍";
                    break;
                case "6":
                    strCapital = "陆";
                    break;
                case "7":
                    strCapital = "柒";
                    break;
                case "8":
                    strCapital = "捌";
                    break;
                case "9":
                    strCapital = "玖";
                    break;
                default:
                    strCapital = "";
                    break;
            }
            return strCapital;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rate"></param>
        public static void ConvertRateToDouble(string rate)
        {
            if (rate.Trim().Length != 32) return;
            List<int> m1 = new List<int>();
            List<double> m2 = new List<double>();
            double[] seed = new double[8] { 0.001, 0.0001, 0.1, 0.01, 10, 1, 100, 1000 };

            string[] arr = System.Text.RegularExpressions.Regex.Split(rate.ToString().Trim(), "(?<=\\G.{8})(?!$)");/*平均8位截取字符串*/
            foreach (string s1 in arr)
            {
                m1.Clear();
                s1.ToArray().ToList().ForEach(x => m1.Add(int.Parse(x.ToString())));
                m2.Add(m1.ToArray().Zip(seed, (x, y) => (x * y)).Sum(x => x));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrDoule"></param>
        public static void ConvertDoubleToRate(double[] arrDoule)
        {
            if (arrDoule.Length != 4) return;
            long[] rtn = new long[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (double d in arrDoule)
            {
                long ud = (long)Math.Floor(d);
                long result = ud;
                long sd = 1000;
                while (result != 0)
                {
                    long r1 = Math.DivRem(result, sd, out result);
                    if (sd == 1000) rtn[7] = r1;
                    else if (sd == 100) rtn[6] = r1;
                    else if (sd == 10) rtn[4] = r1;
                    else if (sd == 1) rtn[5] = r1;
                    sd = sd / 10;
                }
                //小数

            }
        }
    }
}
