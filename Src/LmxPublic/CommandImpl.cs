using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace LmxPublic
{
    public class CommandImpl
    {
        string sql = string.Empty;
       
        #region 指令下发

        public enum SendCommandType { CurrentPosition = 1, TextMessage = 2, TrackMonitor = 3, CarFlameOut = 4, CarResume = 5, CarCancelAlert = 6, CarSingleMonitor = 7, CarImage = 8 }

      
      

        #region 部标终端使用的方法
        /// <summary>
        /// 返回消息头中的消息体属性
        /// </summary>
        /// <param name="w">消息体长度</param>
        /// <returns>两个字符的字符串</returns>
        private string GetMsgHeadAttr(int w)
        {
            string result = "";
            string m = Convert.ToString(w, 2);
            int j = m.Length;
            string h = "";
            if (w < 1024)
            {
                BitArray k = new BitArray(16);
                for (int i = 0; i < 16; i++)
                {
                    if (i < (16 - j))
                    {
                        k[i] = false;
                    }
                    else
                    {
                        string t = m[j - 16 + i].ToString();
                        if (t == "1")
                        {
                            k[i] = true;
                        }
                        if (t == "0")
                        {
                            k[i] = false;
                        }
                    }


                }

                for (int l = 0; l < 16; l++)
                {
                    h += Convert.ToInt32(k[l]).ToString();
                }
                string st1 = h.Substring(0, 8);
                string st2 = h.Substring(8, 8);
                int i1 = Convert.ToInt32(st1, 2);
                int i2 = Convert.ToInt32(st2, 2);
                char c1 = (char)i1;
                char c2 = (char)i2;
                result = c1.ToString() + c2.ToString();

            }
            return result;



        }
        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 根据手机号返回6个字符的字符串
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>6个字符的字符串</returns>
        private string getphonestr(string phone)
        {
            string result = "";
            if (phone.Length < 12)
            {
                phone = "0" + phone;
            }
            if (phone.Length == 12)
            {
                string[] p = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    p[i] = phone.Substring(2 * i, 2);

                }
                char[] l = new char[6];

                for (int i = 0; i < 6; i++)
                {
                    int t = Convert.ToInt32(p[i], 16);//把16进制的p[i]转化成10进制的整形==              
                    l[i] = (char)t; //再转换成字符
                    result += l[i].ToString();

                }
            }


            return result;


        }
        /// <summary>
        ///根据objid获取终端手机号
        /// </summary>
        /// <param name="objid"></param>
        /// <returns></returns>
        private string getphoneByObj(string objid)
        {
            string phone = "";
            string sqlstr = "select SIM from std_ObjectInfo where ObjectID=" + objid;
            DataSet ds = DbHelperSQL.Query(sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                phone = ds.Tables[0].Rows[0]["SIM"].ToString();
            }

            return phone;

        }

        /// <summary>
        /// 字符串从首字符起与后一个字符进行异或运算
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回最后异或结果字符</returns>
        private char StrXor(string str)
        {

            char temp, stemp, result;
            if (str.Length < 2)
            {
                result = str[0];
            }
            else
            {
                temp = str[0];
                for (int i = 1; i < str.Length; i++)
                {
                    stemp = str[i];
                    temp = (char)(temp ^ stemp);
                }
                result = temp;
            }
            return result;
        }

        /// <summary>
        /// 字符串中字符转义处理
        /// 0x7e---0x7d后面紧跟一个0x02
        ///  0x7d---0x7d后面紧跟一个0x01
        /// </summary>
        /// <param name="ConverStr">待转义字符串</param>
        /// <returns>返回转义后字符串</returns>
        private string ConvertDataStr(string ConverStr)
        {
            string temp, stemp;
            temp = ConverStr;
            stemp = ConverStr;
            int j = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 0x7e)
                {
                    stemp.Remove(i + j);
                    stemp.Insert(i + j, Convert.ToString((char)0x7d) + Convert.ToString((char)0x02));
                    j++;

                }
                if (temp[i] == 0x7d)
                {
                    stemp.Remove(i + j);
                    stemp.Insert(i + j, Convert.ToString((char)0x7d) + Convert.ToString((char)0x01));
                    j++;

                }


            }
            return stemp;

        }




        //•char转化为byte
        private byte[] charToByte(char c)
        {
            byte[] b = new byte[2];
            b[0] = (byte)((c & 0xFF00) >> 8);
            b[1] = (byte)(c & 0xFF);
            return b;
        }

        //•byte转换为char
        private char byteToChar(byte[] b)
        {
            char c = (char)(((b[0] & 0xFF) << 8) | (b[1] & 0xFF));
            return c;
        }

        private byte[] intToByte(int i)
        {

            byte[] abyte0 = new byte[4];

            abyte0[0] = (byte)(0xff & i);

            abyte0[1] = (byte)((0xff00 & i) >> 8);

            abyte0[2] = (byte)((0xff0000 & i) >> 16);

            abyte0[3] = (byte)((0xff000000 & i) >> 24);

            return abyte0;

        }

        private string gethx(string s)
        {
            string r = "";
            int[] tm = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {

                tm[i] = s[i];

            }
            for (int i = 0; i < tm.Length; i++)
            {

                r += getHexStr(tm[i], 2);

            }
            return r;

        }


        #endregion

        /// <summary>
        /// 由2位十六进制数转换成每一个字符的字符串进行base64编码
        /// 2012-11-15by yangdawei
        /// </summary>
        /// <param name="Message">2位十六进制数转换成每一个字符的字符串</param>
        /// <returns>编码后的字符串</returns>
        private string Base64Code(string Message)
        {

            byte[] bt = new byte[Message.Length];
            for (int i = 0; i < Message.Length; i++)
            {
                bt[i] = (byte)Message[i];

            }
            return Convert.ToBase64String(bt);
        }

        private string photoEncode64(string Message)
        {
            //其中“=”为补位符号
            char[] Base64Code;

            Base64Code = new char[]
                {
                       'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
                        'O','P','Q','R','S','T','U','V','W','X','Y','Z',
                        'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                        'o','p','q','r','s','t','u','v','w','x','y','z',
                        '0','1','2','3','4','5','6','7','8','9','+','/','=',';'
                  };

            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new
              System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes
              (Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                int[] outstr = new int[4];
                outstr[0] = instr[0] >> 2;
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64Code[outstr[0]]);
                outmessage.Append(Base64Code[outstr[1]]);
                outmessage.Append(Base64Code[outstr[2]]);
                outmessage.Append(Base64Code[outstr[3]]);
            }

            outmessage = outmessage.Replace(";", "");
            return outmessage.ToString();
        }

        #region 将给定的数值转换为给定长度的十六进制串，不够长度的在前面加0  getHexStr(int p_nSourceNum,int nLen)
        /// <summary>
        /// 将给定的数值转换为给定长度的十六进制串，不够长度的在前面加0
        /// </summary>
        /// <param name="p_nSourceNum">待转换的数值</param>
        /// <param name="nLen">转换后十六进制数的长度</param>
        /// <returns>返回转换后的十六进制串</returns>
        private string getHexStr(int p_nSourceNum, int nLen)
        {
            string Hexstr = String.Format("{0:x}", p_nSourceNum);

            for (int i = Hexstr.Length; i < nLen; i++)
            {
                Hexstr = "0" + Hexstr;
            }
            return Hexstr.ToUpper();

        }
        #endregion

        private string Encode64(string Message, string strProVer)
        {
            //其中“=”为补位符号
            char[] Base64Code;
            if (strProVer == "2.0")//对应2.0的码表
            {
                Base64Code = new char[]
                   {
                    '0', '1', '2', '3','4', '5', '6', '7', '8', '9',':',';',
                             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
                             'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                             'a', 'b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                              'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '='
                   };
            }
            else if (strProVer == "2.1")//对应2.1的码表
            {
                Base64Code = new char[]
                    {
                        '9','8','7','6','5','4','3','2','1','0',';',':',
                        'Z','Y','X','W','V','U','T','S','R','Q','P','O',
                        'N','M','L','K','J','I','H','G','F','E','D','C','B','A',
                        'z','y','x','w','v','u','t','s','r','q','p','o',
                        'n','m','l','k','j','i','h','g','f','e','d','c','b','a', '='
                    };
            }
            else //对应2.2的码表
            {
                Base64Code = new char[]
                {
                       'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
                        'O','P','Q','R','S','T','U','V','W','X','Y','Z',
                        ':',';','a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                        'o','p','q','r','s','t','u','v','w','x','y','z',
                        '0','1','2','3','4','5','6','7','8','9','='
                  };
            }
            byte empty = (byte)0;
            System.Collections.ArrayList byteMessage = new
              System.Collections.ArrayList(System.Text.Encoding.Default.GetBytes
              (Message));
            System.Text.StringBuilder outmessage;
            int messageLen = byteMessage.Count;
            int page = messageLen / 3;
            int use = 0;
            if ((use = messageLen % 3) > 0)
            {
                for (int i = 0; i < 3 - use; i++)
                    byteMessage.Add(empty);
                page++;
            }
            outmessage = new System.Text.StringBuilder(page * 4);
            for (int i = 0; i < page; i++)
            {
                byte[] instr = new byte[3];
                instr[0] = (byte)byteMessage[i * 3];
                instr[1] = (byte)byteMessage[i * 3 + 1];
                instr[2] = (byte)byteMessage[i * 3 + 2];
                int[] outstr = new int[4];
                outstr[0] = instr[0] >> 2;
                outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                if (!instr[1].Equals(empty))
                    outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                else
                    outstr[2] = 64;
                if (!instr[2].Equals(empty))
                    outstr[3] = (instr[2] & 0x3f);
                else
                    outstr[3] = 64;
                outmessage.Append(Base64Code[outstr[0]]);
                outmessage.Append(Base64Code[outstr[1]]);
                outmessage.Append(Base64Code[outstr[2]]);
                outmessage.Append(Base64Code[outstr[3]]);
            }

            outmessage = outmessage.Replace("=", "");
            return outmessage.ToString();
        }

        #endregion

    }
}
