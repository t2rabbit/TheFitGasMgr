using GlareSysEfDbAndModels;
using LmxPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

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
