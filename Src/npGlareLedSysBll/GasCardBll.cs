using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels;
using PiPublic.Log;

namespace GlareLedSysBll
{
    /// <summary>
    /// 设备管理,增删改查
    /// </summary>
    public class CardDevBll
    {
        //public static List<GasCardInfo> GetAllCardInfo()
        //{
        //    try
        //    {
        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            List<GasCardInfo> devs = (from c in ent.GasCardInfo
        //                                      select c).ToList<GasCardInfo>();

        //            return devs;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMgr.WriteErrorDefSys("GetAllCardInfo error " + ex.Message);
        //        throw;
        //    }
        //}

        //public static List<GasCardInfo> GetCardByGwId(int iGwId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<GasCardInfo> devs = (from c in ent.GasCardInfo
        //                                  where c.CommDevId == iGwId
        //                                  select c).ToList<GasCardInfo>();
        //        return devs;
        //    }
        //}

        //public static List<GasCardInfo> GetDevByGroupId(int iGwId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<GasCardInfo> devs = (from c in ent.GasCardInfo
        //                                  where c.GroupId == iGwId
        //                                  select c).ToList<GasCardInfo>();
        //        return devs;
        //    }
        //}

        //public static List<GasCardInfo> GetDevByProjectId(int iProjId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<GasCardInfo> devs = (from c in ent.GasCardInfo
        //                                  where c.ProjectId == iProjId
        //                                  select c).ToList<GasCardInfo>();
        //        return devs;
        //    }
        //}

        //public static List<GasCardInfo> GetDevByOrgId(int iOrgId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<GasCardInfo> devs = (from c in ent.GasCardInfo
        //                                  where c.OrgId == iOrgId
        //                                  select c).ToList<GasCardInfo>();
        //        return devs;
        //    }
        //}

        //public static bool AddCard(ref GasCardInfo model, out string strError)
        //{
        //    strError = "";
        //    try
        //    {
        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            GasCardInfo objdev = new GasCardInfo()
        //            {
        //                Id = 0,
        //                CardName = model.CardName,
        //                ProtocolAddr = model.ProtocolAddr,
        //                CardModel = model.CardModel,
        //                IsDouble = model.IsDouble,
        //                Brightness = model.Brightness,
        //                PointCount = model.PointCount,
        //                NumberCount = model.NumberCount,
        //                ScreenCount = model.ScreenCount,
        //                CommDevId = model.CommDevId,
        //                ProjectId = model.ProjectId,
        //                GroupId = model.GroupId,
        //                OrgId = model.OrgId,
        //                Context = model.Context,
        //                ScreenNams = model.ScreenNams,
        //                CreateDt = DateTime.Now,
        //                UpdateDt = DateTime.Now
        //            };

        //            ent.GasCardInfo.Add(objdev);
        //            ent.SaveChanges();
        //            model.Id = objdev.Id;
        //            return true;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool UpdateCard(GasCardInfo model, out string strError)
        //{
        //    strError = "";
        //    try
        //    {
        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            int id = model.Id;
        //            GasCardInfo objdev = (from c in ent.GasCardInfo where c.Id == id select c).FirstOrDefault();
        //            if(objdev == null)
        //            {
        //                strError = ConstDefineBll.InfoCanNotFind;
        //                return false;
        //            }

        //            objdev.CardName = model.CardName; 
        //            objdev.ProtocolAddr = model.ProtocolAddr;
        //            objdev.CardModel = model.CardModel;
        //            objdev.IsDouble = model.IsDouble;
        //            objdev.Brightness = model.Brightness;
        //            objdev.PointCount = model.PointCount;
        //            objdev.NumberCount = model.NumberCount;
        //            objdev.ScreenCount = model.ScreenCount;
        //            objdev.CommDevId = model.CommDevId;
        //            objdev.ProjectId = model.ProjectId;
        //            objdev.GroupId = model.GroupId;
        //            objdev.OrgId = model.OrgId;
        //            objdev.Context = model.Context;
        //            objdev.ScreenNams = model.ScreenNams;
        //            objdev.UpdateDt = DateTime.Now;
        //            ent.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool DelACard(int id)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        var delItem = (from c in ent.GasCardInfo where c.Id == id select c).FirstOrDefault();
        //        if (delItem == null)
        //        {
        //            return true;
        //        }

        //        ent.GasCardInfo.Remove(delItem);
        //        ent.SaveChanges();
        //        return true;
        //    }
        //}

    }   
}
