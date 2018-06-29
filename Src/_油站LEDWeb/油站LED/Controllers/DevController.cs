using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmxPublic;
using GlareLedSysBll;
using GLLedPublic;
using System.Threading;
using GlareSysEfDbAndModels;

namespace OilStationLED.Controllers
{
    public class DevController : Controller
    {
        public static int iDevID = 0;
        //
        // GET: /Dev/

        public ActionResult Index()
        {
            if (Session["SuperUser"] == null && Session["OrgUser"] == null && Session["GroupUser"] == null && Session["ProjectUser"] == null && Session["DevUser"] == null)
            {
                return RedirectToAction("Index", "Login", null);
            }
            else
            {
                if (Session["SuperUser"] != null)
                {
                    SuperLoginedUserModel userInfo = (SuperLoginedUserModel)(Session["SuperUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["OrgUser"] != null)
                {
                    OrgLoginedUserModel userInfo = (OrgLoginedUserModel)(Session["OrgUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["GroupUser"] != null)
                {
                    GroupLoginedUserModel userInfo = (GroupLoginedUserModel)(Session["GroupUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["ProjectUser"] != null)
                {
                    ProjectLoginedUserModel userInfo = (ProjectLoginedUserModel)(Session["ProjectUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
                if (Session["DevUser"] != null)
                {
                    CommDevLoginedUserModel userInfo = (CommDevLoginedUserModel)(Session["DevUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                    iDevID = userInfo.UserInfo.MgrCommDevId.Value;
                }
            }
            return View();
        }


        /// <summary>
        ///  Get Station Information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetGasCardInfo(int id)
        {
            object objResult = null;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDb db = new LedDb())
                {
                    GasCardWithCommInfo aGasCardInfo = db.GasCardWithCommInfo.Where(p => p.Id == id && p.IsDel != 1).FirstOrDefault();
                    if (aGasCardInfo != null)
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Station Information Get Success",
                            Msg = " Station Information Get Success",
                            Obj = aGasCardInfo,
                            Ret = 1,
                            Status = true
                        };
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = "No such record exists",
                            Desc = "No such record exists"
                        };
                    }
                }
            }
            else
            {
                objResult = new ResultHelper()
                {
                    Status = false,
                    Ret = -1,
                    Obj = null,
                    Msg = "id is null,Please try again later",
                    Desc = "id is null,Please try again later"
                };
            }
            return Json(objResult);
        }

        private bool InsertCmdToMemcached(int id)
        {
            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd);
            if (strIds.Length == 0)
            {
                PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, id.ToString());
            }

            strIds += id.ToString();
            if (strIds.Length > 0)
            {
                strIds += ",";
            }

            return PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strIds);
        }

        private bool RemoveCmdHandledInMemcached(int id)
        {
            bool bFind = false;

            string strIds = PiPublic.MemcachedMgr.GetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyCmdResult);
            if (strIds.Length == 0)
            {
                return false;
            }


            string[] arrIds = strIds.Split(new char[] { '-', ',' });
            string strNewIds = "";
            foreach (var str in arrIds)
            {
                if (str == id.ToString())
                {
                    bFind = true;
                    continue;
                }

                strNewIds += str;
                if (strNewIds.Length > 0)
                {
                    strNewIds += ",";
                }
            }
            PiPublic.MemcachedMgr.SetVal(GLLedPublic.GlareLedSysDefPub.MemcachedKeyNewCmd, strNewIds);
            return bFind;
        }


        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SendCMD(int id, string value)
        {
            object objResult = null;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDb db = new LedDb())
                {
                    string strError = string.Empty;
                    GlareSysEfDbAndModels.CmdLogs aLog = new GlareSysEfDbAndModels.CmdLogs()
                    {
                        CardInfoId = id,
                        CmdInfo = value,
                        CmdType = GlareLedSysDefPub.CmdDefSetOilValue,
                        CommDevId = id,
                        CreateTime = DateTime.Now,
                        IsDetele = 0,
                        Result = 0,
                        ResultInfo = "",
                        UpdateTime = DateTime.Now
                    };
                    bool bSend = CmdLogsBll.AddCommDevInfo(ref aLog, out strError);

                    bSend = InsertCmdToMemcached(aLog.Id);
                    bool bRecived = false;
                    if (bSend)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            Thread.Sleep(1000);
                            if (RemoveCmdHandledInMemcached(aLog.Id))
                            {
                                bRecived = true;
                                break;
                            }
                        }
                    }

                    if (bRecived)
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = "Command issued Success",
                            Msg = "Command issued Success",
                            Obj = aLog,
                            Ret = 1,
                            Status = true
                        };
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = strError,
                            Desc = strError
                        };
                    }
                }
            }
            else
            {
                objResult = new ResultHelper()
                {
                    Status = false,
                    Ret = -1,
                    Obj = null,
                    Msg = "id is null,Please try again later",
                    Desc = "id is null,Please try again later"
                };
            }
            return Json(objResult);
        }


        /// <summary>
        /// Setcfg
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Setcfg(int id, int IsDouble, int ScreenCount, string CardModel, int CardPointCount)
        {
            object objResult = null;
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                using (LedDb db = new LedDb())
                {
                    string strError = string.Empty;

                    //1  			//双面显示（单面为0x00）  isdouble
                    //3  			//一面三个牌 screencount
                    //5  			//每个牌5个8（包含小8） 价格数字的数量(CardModel,例如:GL-88888,那就填写5,GL-88888-8(上标小字),填写6
                    //0  			//是否显示9/10(如果是GL-888-8-910,则为1,否则为0)
                    //8  			//亮度等级,永远写8
                    string CmdInfo = "";
                    if (IsDouble == 1)//双面显示
                    {
                        CmdInfo = "1";
                    }
                    else
                    {
                        CmdInfo = "0x00";
                    }
                    CmdInfo = CmdInfo + "-" + ScreenCount.ToString();//screencount

                    string strEightModel = CardModel.Replace("GL", "").Replace("-", "");
                    int iEightCount = strEightModel.Length;
                    CmdInfo = CmdInfo + "-" + iEightCount.ToString();//每个牌5个8（包含小8）

                    if (CardModel.Contains("910"))//是否显示9/10
                    {
                        CmdInfo = CmdInfo + "-1";
                    }
                    else
                    {
                        CmdInfo = CmdInfo + "-0";
                    }
                    CmdInfo = CmdInfo + "-8";//亮度
                    GlareSysEfDbAndModels.CmdLogs cmd = new GlareSysEfDbAndModels.CmdLogs()
                    {
                        CardInfoId = id,
                        CmdInfo = CmdInfo,
                        CmdType = GlareLedSysDefPub.CmdDefSetOilCfg,
                        CommDevId = id,
                        CreateTime = DateTime.Now,
                        Id = 0,
                        IsDetele = 0,
                        Result = 0,
                        ResultInfo = "",
                        UpdateTime = DateTime.Now
                    };
                    CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

                    bool bSend = InsertCmdToMemcached(cmd.Id);
                    bool bRecived = false;
                    if (bSend)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            Thread.Sleep(1000);
                            if (RemoveCmdHandledInMemcached(cmd.Id))
                            {
                                bRecived = true;
                                break;
                            }
                        }
                    }

                    if (bRecived)
                    {
                        bool bSetPoint = SetPoint(id, IsDouble, ScreenCount, CardModel, CardPointCount);
                        if (bSetPoint)
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Command issued Success",
                                Msg = "Command issued Success",
                                Obj = cmd,
                                Ret = 1,
                                Status = true
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Setcfg Success,Command issued Faile,please try again",
                                Msg = "Setcfg Success,Command issued Faile,please try again",
                                Obj = cmd,
                                Ret = -1,
                                Status = false
                            };
                        }

                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = strError,
                            Desc = strError
                        };
                    }
                }
            }
            else
            {
                objResult = new ResultHelper()
                {
                    Status = false,
                    Ret = -1,
                    Obj = null,
                    Msg = "id is null,Please try again later",
                    Desc = "id is null,Please try again later"
                };
            }
            return Json(objResult);
        }

        /// <summary>
        /// 设置小数点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool SetPoint(int id, int IsDouble, int ScreenCount, string CardModel, int CardPointCount)
        {
            string strCardPointCount = string.Format("{0}-{0}-{0}-{0}-{0}-{0}-{0}-{0}-{0}-{0}-{0}-{0}", CardPointCount);

            // 设置小数点位数
            GlareSysEfDbAndModels.CmdLogs cmd = new GlareSysEfDbAndModels.CmdLogs()
            {
                CardInfoId = 1,
                CmdInfo = strCardPointCount,//(默认重复12次,如果carkpoint是2,那么就是2-2-2-2....-2,如果是1则是1-1-1-1...-1),Web界面Add一个save界面
                CmdType = GlareLedSysDefPub.CmdDefSetOilDigiCfg,
                CommDevId = 1,
                CreateTime = DateTime.Now,
                Id = 0,
                IsDetele = 0,
                Result = 0,
                ResultInfo = "",
                UpdateTime = DateTime.Now
            };
            string strError = "";
            CmdLogsBll.AddCommDevInfo(ref cmd, out strError);

            bool bSend = InsertCmdToMemcached(cmd.Id);
            bool bRecived = false;
            if (bSend)
            {
                for (int i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    if (RemoveCmdHandledInMemcached(cmd.Id))
                    {
                        bRecived = true;
                        break;
                    }
                }
            }
            if (bRecived)
            {
                SaveDev(id, IsDouble, ScreenCount, CardModel, CardPointCount);
            }
            return bRecived;
        }
        /// <summary>
        /// Save配置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsDouble"></param>
        /// <param name="ScreenCount"></param>
        /// <param name="CardModel"></param>
        /// <param name="CardPointCount"></param>
        public void SaveDev(int id, int IsDouble, int ScreenCount, string CardModel, int CardPointCount)
        {
            using (LedDb db = new LedDb())
            {
                GasCardWithCommInfo aDev = db.GasCardWithCommInfo.Where(p => p.Id == id && p.IsDel != 1).FirstOrDefault();
                if (aDev != null)
                {
                    aDev.CardIsDouble = IsDouble;
                    aDev.CardScreenCount = ScreenCount;
                    aDev.CardModel = CardModel;
                    aDev.CardPointCount = CardPointCount;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Save当前配置
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(GasCardWithCommInfo subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        GasCardWithCommInfo aSubject = db.GasCardWithCommInfo.Where(p => p.Id == subject.Id).FirstOrDefault();
                        aSubject.Name = subject.Name;
                        aSubject.CommServerSn = subject.CommServerSn;
                        aSubject.CardModel = subject.CardModel;
                        aSubject.CardPointCount = subject.CardPointCount;
                        aSubject.CardIsDouble = subject.CardIsDouble;
                        aSubject.CardScreenCount = subject.CardScreenCount;
                        aSubject.CardContext = subject.CardContext;
                        aSubject.UpdateDt = DateTime.Now;
                        if (db.SaveChanges() > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = "Edit Success!",
                                Desc = "Edit Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Edit Faile,please try again.",
                                Msg = "Edit Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else
                    {
                        objResult = new ResultHelper()
                        {
                            Desc = " Faile,please try again",
                            Msg = " Faile,please try again",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objResult = new ResultHelper()
                {
                    Desc = ex.Message,
                    Msg = ex.Message,
                    Obj = null,
                    Ret = -1,
                    Status = false
                };
            }
            return Json(objResult);
        }
    }
}
