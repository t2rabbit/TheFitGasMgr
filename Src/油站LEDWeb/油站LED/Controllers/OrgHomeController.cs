using GlareSysEfDbAndModels;
using LmxPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class OrgHomeController : Controller
    {
        //
        // GET: /OrgHome/
        public static OrgLoginedUserModel userInfo;
        public ActionResult Index()
        {
            if (Session["OrgUser"] == null )
            {
                return RedirectToAction("Index", "Login", null);
            }
            else
            {
                if (Session["OrgUser"] != null)
                {
                    userInfo = (OrgLoginedUserModel)(Session["OrgUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                    ViewBag.MgrOrgId = userInfo.UserInfo.MgrOrgId;
                }
            }
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            ResultHelper objResult = null;
            try
            {
                Session["SuperUser"] = null;
                Session["OrgUser"] = null;
                Session["GroupUser"] = null;
                Session["ProjectUser"] = null;
                Session["DevUser"] = null;
                objResult = new ResultHelper()
                {
                    Status = true,
                    Ret = 0,
                    Obj = null,
                    Msg = "Logout Scuess!",
                    Desc = "/Login"
                };
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
