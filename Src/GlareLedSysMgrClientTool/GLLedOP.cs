using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBSqlite;

namespace Property
{
    class GLLedOP
    {
//         static public  IList<GLLedDefine.CardOilValEachNumAByte> MakeLedContextByLedCard(GL_LedCard aCard)
//         {
//             string strContext = aCard.ScreentContext;
//             strContext = strContext.Replace(" ", "");
//             strContext = strContext.Replace(".", "");
//             string[] strArrScreen = strContext.Split(new char[] { '-', ',' });
//             IList<GLLedDefine.CardOilValEachNumAByte> lstCardNums = new List<GLLedDefine.CardOilValEachNumAByte>();
//             foreach (string strAScreen in strArrScreen)
//             {
//                 GLLedDefine.CardOilValEachNumAByte aCardNum = new GLLedDefine.CardOilValEachNumAByte();
//                 int iNumCount = strArrScreen.Length;
//                 for (int i = 0; i < 6; i++)
//                 {
//                     aCardNum.lstArr.Add(0);
//                 }
// 
//                 for (int i = 0; i < 6; i++)
//                 {
//                     int iTmp = 0;
//                     if (strArrScreen.Length <= i)
//                     {
//                         break;
//                     }
// 
//                     string strANum = strAScreen.Substring(i, 1);
//                     int.TryParse(strANum, out iTmp);
//                     aCardNum.lstArr[iNumCount] = (byte)iTmp;
//                 }
// 
//                 //lstCardNums.Add(new )
//             }
// 
//             return lstCardNums;
//         }
// 
// 
// 
//         //
//         //
//         //
//         private bool SendContextBySerialComm(GL_Dev aDev, GL_LedCard aCard)
//         {
//             Devs.Rs485Port aPort = new Devs.Rs485Port();
//             aPort.SetDBDev(aDev);
//             if (!aPort.Open())
//             {
//                 return false;
//             }
//             IList<string> lst = GLLedProtocol.MakeStringListByContext(aCard.ScreentContext);
//             return aPort.SendOilContext((int)aCard.Addr, lst);
// 
//         }
// 
//         //
//         // gprs send context
//         //
//         private bool SendContextGPRSClient(TCPLisenterPort aTcpPort, GL_LedCard acard)
//         {
// 
//         }
    }
}
