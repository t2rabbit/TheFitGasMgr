using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using PiPublic.Log;

namespace PiPublic
{
	public class JsonStrObjConver
	{
		static public object JsonStr2Obj(string strJson, System.Type t)
		{
			try
			{

                if (strJson == "")
                {
                    return null;
                }
				if (t == null)
					return null;

				object ff = Activator.CreateInstance(t, null);

				DataContractJsonSerializer outDs = new DataContractJsonSerializer(t);
				using (MemoryStream outMs = new MemoryStream(Encoding.UTF8.GetBytes(strJson)))
				{
					ff = outDs.ReadObject(outMs);
				}

				return ff;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
                //System.Diagnostics.Trace.Write(strJson);
                LogMgr.WriteErrorDefSys(string.Format("ex:json conver error:{0} {1} ", strJson, ex.Message));
                LogMgr.WriteErrorDefSys(string.Format("ex:json conver error:{0} {1} ", strJson, 
                    ex.StackTrace));
				
				return null;
			}
		}

		static public string Obj2JsonStr(object aObj, System.Type t)
		{
			try
			{
				string output = null;
				DataContractJsonSerializer ds = new DataContractJsonSerializer(t);
				using (MemoryStream ms = new MemoryStream())
				{
					ds.WriteObject(ms, aObj);
					output = Encoding.UTF8.GetString(ms.ToArray());
				}
				return output;
			}
			catch (Exception ex)
			{
                LogMgr.WriteErrorDefSys(string.Format("ex:json conver error {0}, {1}", aObj.ToString(), ex.Message));
                LogMgr.WriteErrorDefSys(string.Format("ex:json conver error:{0} {1} ", aObj.ToString(),
                    ex.StackTrace));
				return "";
			}
		}
	}
}
