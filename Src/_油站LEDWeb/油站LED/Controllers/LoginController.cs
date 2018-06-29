using GlareLedSysBll;
using GlareSysEfDbAndModels;
using GlareSysEfDbAndModels.Models;
using LmxPublic;
using PiPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string UserName, string UserPwd, string UserType)
        {
            ResultHelper objResult = null;
            try
            {
                if (ModelState.IsValid)
                {   
                    if (UserType == "SuperUser")
                    {
                        SuperLoginedUserModel userInfo = LoginBll.SuperLogin(UserName, UserPwd);
                        if (userInfo != null)
                        {
                            Session["SuperUser"] = userInfo;
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = userInfo,
                                Msg = "Login Success!",
                                Desc = "/Home"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Login Faile,please try again.",
                                Msg = "Login Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else if (UserType == "OrgUser")
                    {
                        OrgLoginedUserModel userInfo = LoginBll.OrgLogin(UserName, UserPwd);
                        if (userInfo != null)
                        {
                            Session["OrgUser"] = userInfo;
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = userInfo,
                                Msg = "Login Success!",
                                Desc = "/OrgHome"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Login Faile,please try again.",
                                Msg = "Login Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else if(UserType=="GroupUser")
                    {
                        GroupLoginedUserModel userInfo = LoginBll.GroupLogin(0,UserName, UserPwd);
                        if (userInfo != null)
                        {
                            Session["GroupUser"] = userInfo;
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = userInfo,
                                Msg = "Login Success!",
                                Desc = "/GroupHome"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Login Faile,please try again.",
                                Msg = "Login Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else if (UserType == "ProjectUser")
                    {
                        ProjectLoginedUserModel userInfo = LoginBll.ProjectLogin(0,UserName, UserPwd);
                        if (userInfo != null)
                        {
                            Session["ProjectUser"] = userInfo;
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = userInfo,
                                Msg = "Login Success!",
                                Desc = "/ProjectHome"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Login Faile,please try again.",
                                Msg = "Login Faile,please try again.",
                                Obj = null,
                                Ret = -1,
                                Status = false
                            };
                        }
                    }
                    else if (UserType == "DevUser")
                    {
                        CommDevLoginedUserModel userInfo = LoginBll.CommDevLogin(0, UserName, UserPwd);
                        if (userInfo != null)
                        {
                            Session["DevUser"] = userInfo;
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = userInfo,
                                Msg = "Login Success!",
                                Desc = "/DevHome"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Login Faile,please try again.",
                                Msg = "Login Faile,please try again.",
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
                            Desc = "Login Faile,please try again.",
                            Msg = "Login Faile,please try again.",
                            Obj = null,
                            Ret = -1,
                            Status = false
                        };
                    }
                    
                    //if (aUser != null)
                    //{
                    //    Session["UserInfo"] = aUser;
                    //    objResult = new ResultHelper()
                    //    {
                    //        Status = true,
                    //        Ret = 0,
                    //        Obj = aUser,
                    //        Msg = "Login Success!",
                    //        Desc = "Login Success!"
                    //    };
                    //}
                    //else
                    //{
                    //    objResult = new ResultHelper()
                    //    {
                    //        Desc = "Login Faile,please try again.",
                    //        Msg = "Login Faile,please try again.",
                    //        Obj = null,
                    //        Ret = -1,
                    //        Status = false
                    //    };
                    //}
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
