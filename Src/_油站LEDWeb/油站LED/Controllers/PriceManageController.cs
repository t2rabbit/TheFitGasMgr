using GlareSysEfDbAndModels;
using OilStationLED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LmxPublic;

namespace OilStationLED.Controllers
{
    public class PriceManageController : Controller
    {
       
        //
        // GET: /PriceManage/

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
        /// Add 产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoadTree()
        {
            object objResult = null;
            string strNodeID = Request["id"];
            if (string.IsNullOrWhiteSpace(strNodeID))
            {               
                objResult=LoadOrg();
            }
            else
            {
                string[] NodeID = strNodeID.Split('_');
                if (NodeID.Length > 0)
                {
                    string strPre = NodeID[0];
                    string strID = NodeID[1];
                    if (strPre == "org")
                    {
                        objResult = LoadGroup(strID);
                    }
                    else if (strPre == "group")
                    {
                        objResult = LoadProject(strID);
                    }
                    else if (strPre == "project")
                    {
                        objResult = LoadGasCardWithCommInfo(strID);
                    }
                }
            }
            return Json(objResult);
        }

        /// <summary>
        /// 加载Org
        /// </summary>
        /// <returns></returns>
        public List<TreeSelectorEntity> LoadOrg()
        {
            string strJson=string.Empty;
            List<TreeSelectorEntity> mList = DataLoader.LoadOrg();
            foreach (var m in mList)
            {
                m.state = m.state == "0" ? "open" : "closed";//这里是看如果参数是0,则代表没有下属展开,如果为其他,则为闭合,可展开
                m.attributes = new { showTitle = m.text };
            }
            //strJson=JsonHelper.Serialize(mList);
            return mList;
        }
        /// <summary>
        /// 加载Group
        /// </summary>
        /// <returns></returns>
        public List<TreeSelectorEntity> LoadGroup(string strOrgID)
        {
            string strJson = string.Empty;
            List<TreeSelectorEntity> mList = DataLoader.LoadGroup(strOrgID);
            foreach (var m in mList)
            {
                m.state = m.state == "0" ? "open" : "closed";//这里是看如果参数是0,则代表没有下属展开,如果为其他,则为闭合,可展开
                m.attributes = new { showTitle = m.text };
            }
            //strJson=JsonHelper.Serialize(mList);
            return mList;
        }

        /// <summary>
        /// 加载Project
        /// </summary>
        /// <returns></returns>
        public List<TreeSelectorEntity> LoadProject(string strGroupID)
        {
            string strJson = string.Empty;
            List<TreeSelectorEntity> mList = DataLoader.LoadProject(strGroupID);
            foreach (var m in mList)
            {
                m.state = m.state == "0" ? "open" : "closed";//这里是看如果参数是0,则代表没有下属展开,如果为其他,则为闭合,可展开
                m.attributes = new { showTitle = m.text };
            }
            //strJson=JsonHelper.Serialize(mList);
            return mList;
        }

        /// <summary>
        /// 加载GasCardWithCommInfo
        /// </summary>
        /// <returns></returns>
        public List<TreeSelectorEntity> LoadGasCardWithCommInfo(string strProjectID)
        {
            string strJson = string.Empty;
            List<TreeSelectorEntity> mList = DataLoader.LoadGasCardWithCommInfo(strProjectID);
            foreach (var m in mList)
            {
                m.state = m.state == "0" ? "open" : "closed";//这里是看如果参数是0,则代表没有下属展开,如果为其他,则为闭合,可展开
                m.attributes = new { showTitle = m.text };
            }
            //strJson=JsonHelper.Serialize(mList);
            return mList;
        }
        /*
        /// <summary>
        /// 加载GasCard
        /// </summary>
        /// <returns></returns>
        public List<TreeSelectorEntity> LoadGasCard(string strCommDevID)
        {
            string strJson = string.Empty;
            List<TreeSelectorEntity> mList = DataLoader.LoadGasCard(strCommDevID);
            foreach (var m in mList)
            {
                m.state = m.state == "0" ? "open" : "closed";//这里是看如果参数是0,则代表没有下属展开,如果为其他,则为闭合,可展开
                m.attributes = new { showTitle = m.text };
            }
            //strJson=JsonHelper.Serialize(mList);
            return mList;
        }
        */
    }
}
