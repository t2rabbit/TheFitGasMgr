using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    /// <summary>
    /// 网关的增删改查
    /// </summary>
    public class CardWithCommDevBll
    {
        public static List<GasCardWithCommInfo> GetAllDevList()
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<GasCardWithCommInfo> lsts = (from c in ent.GasCardWithCommInfo select c).ToList();
                return lsts;
            }
        }

        public static List<GasCardWithCommInfo> GetDevListByProjectId(int iProjectId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<GasCardWithCommInfo> lsts = (from c in ent.GasCardWithCommInfo
                                                  where c.ProjectId == iProjectId
                                          select c).ToList();
                return lsts;
            }
        }

        public static List<GasCardWithCommInfo> GetDevListByGroupId(int iGroupId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<GasCardWithCommInfo> lsts = (from c in ent.GasCardWithCommInfo
                                                  where c.GroupId == iGroupId
                                          select c).ToList();
                return lsts;
            }
        }

        public static List<GasCardWithCommInfo> GetDevListByOrgId(int iOrgId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<GasCardWithCommInfo> lsts = (from c in ent.GasCardWithCommInfo
                                                  where c.OrgId == iOrgId
                                          select c).ToList();
                return lsts;
            }
        }

        public static List<GasCardWithCommInfo> GetDevByCondtion(string strCond, string strOrder)
        {
            // todo
            return null;
        }

        public static bool AddDev(ref GasCardWithCommInfo model, out string strError)
        {
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    GasCardWithCommInfo newinfo = new GasCardWithCommInfo()
                    {
                        Id = model.Id,
                        DefName = model.DefName,
                        DefPassword = model.DefPassword,
                        Name = model.Name,
                        Password = model.Password,
                        CityId = model.CityId,
                        Address = model.Address,
                        PosLongitude = model.PosLongitude,
                        PosLatitude = model.PosLatitude,
                        ProjectId = model.ProjectId,
                        GroupId = model.GroupId,
                        OrgId = model.OrgId,
                        CommType = model.CommType,
                        ProtocolType = model.ProtocolType,
                        CommServerIp = model.CommServerIp,
                        CommServerPort = model.CommServerPort,
                        CommServerSn = model.CommServerSn,
                        CommSerialPort = model.CommSerialPort,
                        CommSerialBaud = model.CommSerialBaud,
                        CommSerialDataBit = model.CommSerialDataBit,
                        CommSerialStopBit = model.CommSerialStopBit,
                        CommSerialParity = model.CommSerialParity,
                        CommTimeoutMs = model.CommTimeoutMs,
                        CommExtConnInfo = model.CommExtConnInfo,
                        BEnable = model.BEnable,
                        CardBrightness = model.CardBrightness,
                        CardContext = model.CardContext,
                        CardIsDouble = model.CardIsDouble,
                        CardModel = model.CardModel,
                        CardNumberCount = model.CardNumberCount,
                        CardPointCount = model.CardPointCount,
                        CardScreenCount = model.CardScreenCount,
                        IsDel = 0,
                        ScreenNams = model.ScreenNams,
                        Comment = model.Comment,
                        UpdateDt = DateTime.Now,
                        CreateDt = DateTime.Now
                    };
                    ent.GasCardWithCommInfo.Add(newinfo);
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



        public static bool UpdateDev(GasCardWithCommInfo model, out string strError)
        {
            strError = "";
            try
            {

                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    var oldinfo = (from c in ent.GasCardWithCommInfo where c.Id == model.Id select c).FirstOrDefault();
                    if (oldinfo == null)
                    {
                        strError = ConstDefineBll.InfoCanNotFind;
                        return false;
                    }
                    oldinfo.Id = model.Id;
                    oldinfo.DefName = model.DefName;
                    oldinfo.DefPassword = model.DefPassword;
                    oldinfo.Name = model.Name;
                    oldinfo.Password = model.Password;
                    oldinfo.CityId = model.CityId;
                    oldinfo.Address = model.Address;
                    oldinfo.PosLongitude = model.PosLongitude;
                    oldinfo.PosLatitude = model.PosLatitude;
                    oldinfo.ProjectId = model.ProjectId;
                    oldinfo.GroupId = model.GroupId;
                    oldinfo.OrgId = model.OrgId;
                    oldinfo.CommType = model.CommType;
                    oldinfo.ProtocolType = model.ProtocolType;
                    oldinfo.CommServerIp = model.CommServerIp;
                    oldinfo.CommServerPort = model.CommServerPort;
                    oldinfo.CommServerSn = model.CommServerSn;
                    oldinfo.CommSerialPort = model.CommSerialPort;
                    oldinfo.CommSerialBaud = model.CommSerialBaud;
                    oldinfo.CommSerialDataBit = model.CommSerialDataBit;
                    oldinfo.CommSerialStopBit = model.CommSerialStopBit;
                    oldinfo.CommSerialParity = model.CommSerialParity;
                    oldinfo.CommTimeoutMs = model.CommTimeoutMs;
                    oldinfo.CommExtConnInfo = model.CommExtConnInfo;
                    oldinfo.BEnable = model.BEnable;
                    oldinfo.CardBrightness = model.CardBrightness;
                    oldinfo.CardContext = model.CardContext;
                    oldinfo.CardIsDouble = model.CardIsDouble;
                    oldinfo.CardModel = model.CardModel;
                    oldinfo.CardNumberCount = model.CardNumberCount;
                    oldinfo.CardPointCount = model.CardPointCount;
                    oldinfo.CardScreenCount = model.CardScreenCount;
                    oldinfo.IsDel = model.IsDel;

                    oldinfo.Comment = model.Comment;
                    oldinfo.UpdateDt = DateTime.Now;
                    ent.SaveChanges();
                }

                return true;

            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public static bool UpdateDefNamePassword(int Id, string strName, string strPassword, out string strError)
        {
            strError = "";
            try
            {

                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    var oldinfo = (from c in ent.GasCardWithCommInfo where c.Id == Id select c).FirstOrDefault();
                    if (oldinfo == null)
                    {
                        strError = ConstDefineBll.InfoCanNotFind;
                        return false;
                    }
                    oldinfo.Password = strPassword;
                    oldinfo.Name = strPassword;
                    oldinfo.UpdateDt = DateTime.Now;
                    ent.SaveChanges();
                }

                return true;

            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public static bool DelDev(int Id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.GasCardWithCommInfo where c.Id == Id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.GasCardWithCommInfo.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }

        public static bool IsNameExist(string strName)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.GasCardWithCommInfo
                     where c.Name == strName || c.DefName == strName
                     select c).FirstOrDefault() != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSnExise(string strSn)
        {

            using (GLedDbEntities ent = new GLedDbEntities())
            {
                if ((from c in ent.GasCardWithCommInfo
                     where c.CommServerSn == strSn
                     select c).FirstOrDefault() != null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
