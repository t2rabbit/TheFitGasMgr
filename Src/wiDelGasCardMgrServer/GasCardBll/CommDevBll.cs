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
    public class CommDevBll
    {
        public static List<CommDevInfo> GetAllCommDevList()
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {          
                List<CommDevInfo> lsts = (from c in ent.CommDevInfo select c).ToList();                
                return lsts;
            }
        }

        public static List<CommDevInfo> GetCommDevListByProjectId(int iProjectId)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                List<CommDevInfo> lsts = (from c in ent.CommDevInfo
                                          where c.ProjectId == iProjectId
                                          select c).ToList();
                return lsts;
            }
        }

        public static List<CommDevInfo> GetCommDevByCondtion(string strCond, string strOrder)
        {
            // todo 
            return null;
        }


        public static bool AddCommDevInfo(ref CommDevInfo model, out string strError)
        {
            // todo 检查名字是否重复
            strError = "";
            try
            {
                using (GLedDbEntities ent = new GLedDbEntities())
                {
                    CommDevInfo newinfo = new CommDevInfo()
                    {
                        ID = model.ID,
                        DefName = model.DefName,
                        DefPassword = model.DefPassword,
                        CardName = model.CardName,
                        UpdateName = model.UpdateName,
                        UpdatePassword = model.UpdatePassword,
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
                        BUseDefName = model.BUseDefName,
                        Comment = model.Comment
                    };
                    ent.CommDevInfo.Add(newinfo);
                    ent.SaveChanges();
                    model.ID = newinfo.ID;
                    return true;
                }

            }
            catch (System.Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public static bool DelCommDev(int id)
        {
            using (GLedDbEntities ent = new GLedDbEntities())
            {
                var delItem = (from c in ent.CommDevInfo where c.ID == id select c).FirstOrDefault();
                if (delItem == null)
                {
                    return true;
                }

                ent.CommDevInfo.Remove(delItem);
                ent.SaveChanges();
                return true;
            }
        }


    }
}
