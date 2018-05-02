﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlareSysEfDbAndModels;

namespace GlareLedSysBll
{
    /// <summary>
    /// 网关的增删改查
    /// </summary>
    public class CommDevBll
    {
        //public static List<CommDevInfo> GetAllCommDevList()
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<CommDevInfo> lsts = (from c in ent.CommDevInfo select c).ToList();
        //        return lsts;
        //    }
        //}

        //public static List<CommDevInfo> GetCommDevListByProjectId(int iProjectId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<CommDevInfo> lsts = (from c in ent.CommDevInfo
        //                                  where c.ProjectId == iProjectId
        //                                  select c).ToList();
        //        return lsts;
        //    }
        //}

        //public static List<CommDevInfo> GetCommDevListByGroupId(int iGroupId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<CommDevInfo> lsts = (from c in ent.CommDevInfo
        //                                  where c.GroupId == iGroupId
        //                                  select c).ToList();
        //        return lsts;
        //    }
        //}

        //public static List<CommDevInfo> GetCommDevListByOrgId(int iOrgId)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        List<CommDevInfo> lsts = (from c in ent.CommDevInfo
        //                                  where c.OrgId == iOrgId
        //                                  select c).ToList();
        //        return lsts;
        //    }
        //}

        //public static List<CommDevInfo> GetCommDevByCondtion(string strCond, string strOrder)
        //{
        //    // todo
        //    return null;
        //}

        //public static bool AddDev(ref CommDevInfo model, out string strError)
        //{
        //    strError = "";
        //    try
        //    {
        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            CommDevInfo newinfo = new CommDevInfo()
        //            {
        //                Id = model.Id,
        //                DefName = model.DefName,
        //                DefPassword = model.DefPassword,
        //                Name = model.Name,                        
        //                Password = model.Password,
        //                CityId = model.CityId,
        //                Address = model.Address,
        //                PosLongitude = model.PosLongitude,
        //                PosLatitude = model.PosLatitude,
        //                ProjectId = model.ProjectId,
        //                GroupId = model.GroupId,
        //                OrgId = model.OrgId,
        //                CommType = model.CommType,
        //                ProtocolType = model.ProtocolType,
        //                CommServerIp = model.CommServerIp,
        //                CommServerPort = model.CommServerPort,
        //                CommServerSn = model.CommServerSn,
        //                CommSerialPort = model.CommSerialPort,
        //                CommSerialBaud = model.CommSerialBaud,
        //                CommSerialDataBit = model.CommSerialDataBit,
        //                CommSerialStopBit = model.CommSerialStopBit,
        //                CommSerialParity = model.CommSerialParity,
        //                CommTimeoutMs = model.CommTimeoutMs,
        //                CommExtConnInfo = model.CommExtConnInfo,
        //                BEnable = model.BEnable,
        //                BUseDefName = model.BUseDefName,
        //                Comment = model.Comment,
        //                UpdateDt = DateTime.Now,
        //                CreateDt = DateTime.Now
        //            };
        //            ent.CommDevInfo.Add(newinfo);
        //            ent.SaveChanges();
        //            model.Id = newinfo.Id;
        //            return true;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}



        //public static bool UpdateCommDevInfo(CommDevInfo model, out string strError)
        //{
        //    strError = "";
        //    try
        //    {

        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            var oldinfo = (from c in ent.CommDevInfo where c.Id == model.Id select c).FirstOrDefault();
        //            if (oldinfo == null)
        //            {
        //                strError = ConstDefineBll.InfoCanNotFind;
        //                return false;
        //            }
        //            oldinfo.Id = model.Id;
        //            oldinfo.DefName = model.DefName;
        //            oldinfo.DefPassword = model.DefPassword;
        //            oldinfo.Name = model.Name;
        //            oldinfo.Password = model.Password;
        //            oldinfo.CityId = model.CityId;
        //            oldinfo.Address = model.Address;
        //            oldinfo.PosLongitude = model.PosLongitude;
        //            oldinfo.PosLatitude = model.PosLatitude;
        //            oldinfo.ProjectId = model.ProjectId;
        //            oldinfo.GroupId = model.GroupId;
        //            oldinfo.OrgId = model.OrgId;
        //            oldinfo.CommType = model.CommType;
        //            oldinfo.ProtocolType = model.ProtocolType;
        //            oldinfo.CommServerIp = model.CommServerIp;
        //            oldinfo.CommServerPort = model.CommServerPort;
        //            oldinfo.CommServerSn = model.CommServerSn;
        //            oldinfo.CommSerialPort = model.CommSerialPort;
        //            oldinfo.CommSerialBaud = model.CommSerialBaud;
        //            oldinfo.CommSerialDataBit = model.CommSerialDataBit;
        //            oldinfo.CommSerialStopBit = model.CommSerialStopBit;
        //            oldinfo.CommSerialParity = model.CommSerialParity;
        //            oldinfo.CommTimeoutMs = model.CommTimeoutMs;
        //            oldinfo.CommExtConnInfo = model.CommExtConnInfo;
        //            oldinfo.BEnable = model.BEnable;
        //            oldinfo.BUseDefName = model.BUseDefName;
        //            oldinfo.Comment = model.Comment;
        //            oldinfo.UpdateDt = DateTime.Now;
        //            ent.SaveChanges();
        //        }

        //        return true;

        //    }
        //    catch (System.Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool UpdateDefPassword(int Id, string strPassword, out string strError)
        //{
        //    strError = "";
        //    try
        //    {

        //        using (GLedDbEntities ent = new GLedDbEntities())
        //        {
        //            var oldinfo = (from c in ent.CommDevInfo where c.Id == Id select c).FirstOrDefault();
        //            if (oldinfo == null)
        //            {
        //                strError = ConstDefineBll.InfoCanNotFind;
        //                return false;
        //            }
        //            oldinfo.Password = strPassword;
        //            oldinfo.UpdateDt = DateTime.Now;
        //            ent.SaveChanges();
        //        }

        //        return true;

        //    }
        //    catch (System.Exception ex)
        //    {
        //        strError = ex.Message;
        //        return false;
        //    }
        //}

        //public static bool DelCommDev(int Id)
        //{
        //    using (GLedDbEntities ent = new GLedDbEntities())
        //    {
        //        var delItem = (from c in ent.CommDevInfo where c.Id == Id select c).FirstOrDefault();
        //        if (delItem == null)
        //        {
        //            return true;
        //        }

        //        ent.CommDevInfo.Remove(delItem);
        //        ent.SaveChanges();
        //        return true;
        //    }
        //}


    }
}
