using LmxPublic;
using OilStationLED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class OrgUserController : Controller
    {
        //
        // GET: /OrgUser/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 展示组织用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(string Method, string Key)
        {
            object objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    List<ModelForOrgUser> list = new List<ModelForOrgUser>();

                    if (Method == "FirstLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append(@"select
                                        g.*,
                                        g.Name MgrOrgName
                                        from OrgUser g
                                        where g.IsDel!=1 or g.IsDel is null");
                        list = db.Database.SqlQuery<ModelForOrgUser>(strSql.ToString()).ToList();
                    }
                    else if (Method == "SearchLoad")
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"select
                                            g.*,
                                            g.Name MgrOrgName
                                            from OrgUser g
                                            where (g.IsDel!=1 or g.IsDel is null)
                                            and g.name like '%{0}%'", Key);
                        list = db.Database.SqlQuery<ModelForOrgUser>(strSql.ToString()).ToList();
                    }
                    int page = string.IsNullOrWhiteSpace(Request["page"]) ? 1 : Int32.Parse(Request["page"]);
                    int rows = string.IsNullOrWhiteSpace(Request["rows"]) ? 1 : Int32.Parse(Request["rows"]);
                    string order = string.IsNullOrWhiteSpace(Request["order"]) ? "DESC" : Request["order"].ToUpper();
                    string sort = string.IsNullOrWhiteSpace(Request["sort"]) ? "Id" : Request["sort"];
                    IQueryable<ModelForOrgUser> query = CommonTools.DataSorting<ModelForOrgUser>(list.AsQueryable(), sort, order).Skip((page - 1) * rows).Take(rows);
                    objResult = new { total = list.Count, rows = query };
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
                //throw;
            }
            return Json(objResult);
        }


        /// <summary>
        /// Add 组织用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(OrgUser subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        subject.UpdateDt = DateTime.Now;
                        subject.CreateDt = DateTime.Now;
                        subject.IsDel = 0;
                        db.OrgUser.Add(subject);
                        if (db.SaveChanges() > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = subject,
                                Msg = "Add  Success!",
                                Desc = "Add  Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Add  Faile,please try again.",
                                Msg = "Add  Faile,please try again.",
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

        /// <summary>
        /// Upadate 组织用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Modify(OrgUser subject)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        OrgUser aSubject = db.OrgUser.Where(p => p.Id == subject.Id).FirstOrDefault();
                        //aSubject.CardName = subject.CardName;
                        //aSubject.CardModel = subject.CardModel;
                        //aSubject.ScreenCount = subject.ScreenCount;
                        //aSubject.ScreenNams = subject.ScreenNams;
                        aSubject = subject;
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


        /// <summary>
        /// Delete组织用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string SubjectIDs)
        {
            ResultHelper objResult = null;
            try
            {
                using (LedDb db = new LedDb())
                {
                    if (ModelState.IsValid)
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.AppendFormat(@"UPDATE OrgUser SET IsDel = 1 WHERE Id IN ({0})", SubjectIDs);
                        if (db.Database.ExecuteSqlCommand(strSql.ToString()) > 0)
                        {
                            objResult = new ResultHelper()
                            {
                                Status = true,
                                Ret = 0,
                                Obj = SubjectIDs,
                                Msg = "Delete Success!",
                                Desc = "Delete Success!"
                            };
                        }
                        else
                        {
                            objResult = new ResultHelper()
                            {
                                Desc = "Delete Faile,please try again.",
                                Msg = "Delete Faile,please try again.",
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

