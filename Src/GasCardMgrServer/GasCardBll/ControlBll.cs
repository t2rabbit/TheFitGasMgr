///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ControlBll.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-26 19:24:46
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using GasCardEfDbDll.SqlServer;
using GasCardEfDbDll;

namespace GasCardBll
{
    public class ControlBll
    {
        public static bool AddANewCtrlCmd(ref RealControlModel aNewCmd, out string strError)
        {
            strError = "";
            try
            {
                using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
                {
                    RealControl cmd = new RealControl()
                    {
                        AddByUserId = aNewCmd.AddByUserId,
                        DevLineIndex = aNewCmd.DevLineIndex,
                        DevAddr = aNewCmd.DevAddr,
                        Cmd = aNewCmd.Cmd,
                        CmdFlag = aNewCmd.CmdFlag,
                        CmdType = aNewCmd.CmdType,
                        DevId = aNewCmd.DevId,
                        ControlUserId = aNewCmd.ControlUserId,
                        GatewayId = aNewCmd.GatewayId,
                        GroupAddr = aNewCmd.GroupAddr,
                        ID = aNewCmd.ID,
                        ProjectId = aNewCmd.ProjectId,
                        LogDt = DateTime.Now,
                        TypeProjGateDevGroup = aNewCmd.TypeProjGateDevGroup
                    };
                    ent.RealControl.AddObject(cmd);
                    ent.SaveChanges();
                    aNewCmd.ID = cmd.ID;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;                
            }
        }

        public static bool DelACtrlCmd(int iId)
        {
            // todo
            return false;
        }

        public static List<RealControlModel> GetCmdNotHanded()
        {
            List<RealControlModel> lstMods = new List<RealControlModel>();
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                int iFlag = (int)DbConstDefine.CmdFlag.NewCmd;
                List<RealControl> lstCmds = (from c in ent.RealControl
                                             where c.CmdFlag == iFlag
                                             select c).ToList();
                foreach (RealControl obj in lstCmds)
                {
                    lstMods.Add(new RealControlModel()
                    {
                        AddByUserId = (int)obj.AddByUserId,
                        Cmd = obj.Cmd,
                        CmdFlag = (int)obj.CmdFlag,
                        TypeProjGateDevGroup = (int)obj.TypeProjGateDevGroup,
                        CmdType = obj.CmdType,
                        ControlUserId = (int)obj.ControlUserId,
                        DevId = (int)obj.DevId,
                        GatewayId = (int)obj.GatewayId,
                        GroupAddr = (int)obj.GroupAddr,
                        ID = obj.ID,
                        //LogDt = obj.LogDt.Value,
                        DevAddr = (int)obj.DevAddr,
                        DevLineIndex = (int)obj.DevLineIndex
                    });
                }
            }
            return lstMods;
        }

        public static List<RealControlModel> GetAllCmd()
        {
            List<RealControlModel> lstMods = new List<RealControlModel>();
            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                int iFlag = (int)DbConstDefine.CmdFlag.NewCmd;
                List<RealControl> lstCmds = (from c in ent.RealControl
                                             select c).ToList();
                foreach (RealControl obj in lstCmds)
                {
                    lstMods.Add(new RealControlModel()
                    {
                        AddByUserId = (int)obj.AddByUserId,
                        Cmd = obj.Cmd,
                        CmdFlag = (int)obj.CmdFlag,
                        TypeProjGateDevGroup = (int)obj.TypeProjGateDevGroup,
                        CmdType = obj.CmdType,
                        ControlUserId = (int)obj.ControlUserId,
                        DevId = (int)obj.DevId,
                        GatewayId = (int)obj.GatewayId,
                        GroupAddr = (int)obj.GroupAddr,
                        ID = obj.ID,
                        //LogDt = obj.LogDt.Value,
                        DevAddr = (int)obj.DevAddr,
                        DevLineIndex = (int)obj.DevLineIndex
                    });
                }
            }
            return lstMods;
        }


    }
}
