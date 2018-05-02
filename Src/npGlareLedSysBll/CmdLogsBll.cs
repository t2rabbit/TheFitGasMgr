using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    public class CmdLogsBll
    {
        public static List<CmdLogs> GetAllCmds()
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                return ent.CmdLogs.ToList();
            }
        }

        public static List<CmdLogs> GetNewCmdsByMinutes(int iMinutes)
        {
            DateTime dtCheck = DateTime.Now.AddMinutes(-iMinutes);
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                return (from c in ent.CmdLogs where c.Result == 0 && c.IsDetele!=1  && c.CreateTime > dtCheck select c).ToList();
            }
        }

        public static bool UpdateACmdResult(int id, int iResult, string strResultInfo)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                CmdLogs mdyMod = (from c in ent.CmdLogs where c.Id == id select c).FirstOrDefault();
                if (mdyMod == null)
                {
                    return false;
                }

                mdyMod.Result = iResult;
                mdyMod.ResultInfo = strResultInfo;
                mdyMod.UpdateTime = DateTime.Now;
                ent.SaveChanges();
                return true;
            }
        }

        public static CmdLogs GetACmdLogsById(int id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                return (from c in ent.CmdLogs where c.Id == id select c).FirstOrDefault();
            }
        }


        public static bool AddCommDevInfo(ref CmdLogs model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    CmdLogs newinfo = new CmdLogs()
                    {
                        Id = model.Id,
                        CardInfoId = model.CardInfoId,
                        CmdInfo = model.CmdInfo,
                        CmdType = model.CmdType,
                        CommDevId = model.CommDevId,
                        CreateTime = DateTime.Now,
                        IsDetele = 0,
                        Result = 0,
                        ResultInfo = model.ResultInfo,
                        UpdateTime = DateTime.Now
                    };
                    ent.CmdLogs.Add(newinfo);
                    ent.SaveChanges();
                    model.Id = newinfo.Id;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }


    }
}
