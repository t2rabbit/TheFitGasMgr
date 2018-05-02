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
                                Msg = "登陆成功!",
                                Desc = "登陆成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "登陆失败,请确认账号或者密码.",
                                Msg = "登陆失败,请确认账号或者密码.",
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
                                Msg = "登陆成功!",
                                Desc = "登陆成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "登陆失败,请确认账号或者密码.",
                                Msg = "登陆失败,请确认账号或者密码.",
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
                                Msg = "登陆成功!",
                                Desc = "登陆成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "登陆失败,请确认账号或者密码.",
                                Msg = "登陆失败,请确认账号或者密码.",
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
                                Msg = "登陆成功!",
                                Desc = "登陆成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "登陆失败,请确认账号或者密码.",
                                Msg = "登陆失败,请确认账号或者密码.",
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
                                Msg = "登陆成功!",
                                Desc = "登陆成功!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "登陆失败,请确认账号或者密码.",
                                Msg = "登陆失败,请确认账号或者密码.",
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
                            Desc = "登陆失败,请确认账号或者密码.",
                            Msg = "登陆失败,请确认账号或者密码.",
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
                    //        Msg = "登陆成功!",
                    //        Desc = "登陆成功!"
                    //    };
                    //}
                    //else
                    //{
                    //    objResult = new ResultHelper()
                    //    {
                    //        Desc = "登陆失败,请确认账号或者密码.",
                    //        Msg = "登陆失败,请确认账号或者密码.",
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
                        Desc = "系统出错,请重试.",
                        Msg = "系统出错,请重试.",
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
