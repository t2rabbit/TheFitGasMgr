/*
*
* Filename: DBStringHlper
* Description: 
*
* Version: 1.0
* Created: 2015/1/19 11:29:06
* Compiler: Visual Studio 2010
*
* Author: Wudanquan
* Company: Pilot
*
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiPublic
{
    public class DBStringHlper
    {
        public static bool GetConnInfoByConnString(string strConn,
            ref string strDataSource,
            ref string strDb,
            ref string strUsId,
            ref string strPassword)
        {
            //Data Source=192.168.1.27;Initial Catalog=YQMCWDQ_TESTUPLOAD_BasicDB;User ID=PEMSUser;Password=ems120;
            //metadata=res://*/MSSqlServerModel.csdl|res://*/MSSqlServerModel.ssdl|res://*/MSSqlServerModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=192.168.1.27;Initial Catalog=YQMCWDQ_TESTUPLOAD_BasicDB;Persist Security Info=True;User ID=PEMSUser;Password=ems120;MultipleActiveResultSets=True&quot;           
            string strConnTmp = strConn;
            if (strConn.IndexOf("\"") > 0)
            {
                int iIndexQuot = strConn.IndexOf("\"");
                int iEndIndexQuot = strConn.IndexOf("\"", iIndexQuot + 1);
                strConnTmp = strConn.Substring(iIndexQuot+1, (iEndIndexQuot-iIndexQuot-1));
            }
            string[] strKeyVals = strConnTmp.Split(new char[] { ';' });
            if (strKeyVals.Length == 0)
            {
                return false;
            }

            foreach (string strKeyVal in strKeyVals)
            {
                string[] strArrKeyVal = strKeyVal.Split(new char[] {'=' });
                if (strArrKeyVal.Length != 2)
                {
                    continue;
                }

                if (string.Compare(strArrKeyVal[0], STR_KEY_DATA_SOURCE, true)==0 )
                {
                    strDataSource = strArrKeyVal[1];
                }
                else if (string.Compare(strArrKeyVal[0], STR_KEY_CATALOG) ==0)
                {
                    strDb = strArrKeyVal[1];
                }
                else if (string.Compare(strArrKeyVal[0], STR_KEY_USERID)==0)
                {
                    strUsId = strArrKeyVal[1];
                }
                else if (string.Compare(strArrKeyVal[0], STR_KEY_PASSWORD)==0)
                {
                    strPassword = strArrKeyVal[1];
                }
                else
                {

                }
            }
            return true;
        }



        private const string STR_KEY_DATA_SOURCE = "Data Source";
        private const string STR_KEY_CATALOG = "Initial Catalog";
        private const string STR_KEY_USERID = "User ID";
        private const string STR_KEY_PASSWORD = "Password";
    }
}
