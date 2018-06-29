using GlareSysEfDbAndModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlareLedSysBll
{
    public class CfgVersionBll
    {
        public static List<CfgVersion> GetAllCfg()
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                return ent.CfgVersion.ToList();
            }
        }

        public static CfgVersion GetFirstCfg()
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                return ent.CfgVersion.FirstOrDefault();
            }
        }

        public static bool VersionInc(ref int iNewVer)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                CfgVersion mdyMod = (from c in ent.CfgVersion select c).FirstOrDefault();
                if (mdyMod == null)
                {
                    mdyMod = new CfgVersion()
                    {
                        Id = 0,
                        UpdateDt = DateTime.Now,
                        Version = 1
                    };
                    ent.CfgVersion.Add(mdyMod);
                    ent.SaveChanges();
                    iNewVer = 1;
                    return true;
                }

                mdyMod.Version = mdyMod.Version + 1;
                iNewVer = mdyMod.Version.Value;
                mdyMod.UpdateDt = DateTime.Now;
                ent.SaveChanges();
                return true;
            }
        }


        public static bool AddVersion(ref CfgVersion model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    CfgVersion newinfo = new CfgVersion()
                    {
                        Id = model.Id,
                        UpdateDt = DateTime.Now,
                        Version = model.Version
                    };
                    ent.CfgVersion.Add(newinfo);
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
