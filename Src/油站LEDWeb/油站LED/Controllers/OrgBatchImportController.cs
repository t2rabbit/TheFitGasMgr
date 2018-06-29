using GlareLedSysBll;
using GlareSysEfDbAndModels;
using LmxPublic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OilStationLED.Controllers
{
    public class OrgBatchImportController : Controller
    {
        //
        // GET: /OrgBatchImport/
        public static OrgLoginedUserModel userInfo;
        public ActionResult Index()
        {
            if (Session["OrgUser"] == null)
            {
                return RedirectToAction("Index", "Login", null);
            }
            else
            {

                if (Session["OrgUser"] != null)
                {
                    userInfo = (OrgLoginedUserModel)(Session["OrgUser"]);
                    ViewBag.Name = userInfo.UserInfo.Name;
                }
            }
            return View();
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFile()
        {
            ResultHelper objResult = null;
            try
            {
                HttpPostedFileBase files = Request.Files["file"];
                byte[] b = new byte[files.ContentLength];
                System.IO.Stream fs = (System.IO.Stream)files.InputStream;
                fs.Read(b, 0, files.ContentLength);
                ///定义并实例化一个内存流，以存放提交上来的字节数组。
                MemoryStream m = new MemoryStream(b);
                ///定义实际文件对象，Save上载的文件。
                string strTempName = DateTime.Now.ToString("yyyyMMddHHmmss");
                string path = "\\UploadFile";
                if (!Directory.Exists(Server.MapPath(path)))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(path));
                }
                FileStream f = new FileStream(Server.MapPath(path) + "\\" + strTempName + files.FileName, FileMode.Create);
                ///把内内存里的数据写入物理文件
                m.WriteTo(f);
                m.Close();
                f.Close();
                f = null;
                m = null;
                string strFilePath = Server.MapPath("\\UploadFile") + "\\" + strTempName + files.FileName;
                objResult = new ResultHelper()
                {
                    Status = true,
                    Ret = 0,
                    Obj = strFilePath,
                    Msg = "Importing!",
                    Desc = "Importing!"
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
                //throw;
            }
            return Json(objResult);
        }

        /// <summary>
        /// 导入题库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BathImport(string path)
        {
            ResultHelper objResult = null;
            try
            {
                string fileSuffix = System.IO.Path.GetExtension(path);
                if (string.IsNullOrEmpty(fileSuffix))
                {
                    objResult = new ResultHelper()
                    {
                        Status = false,
                        Ret = -1,
                        Obj = null,
                        Msg = " Faile,please try again",
                        Desc = " Faile,please try again"
                    };
                }

                using (DataSet dsGroup = new DataSet())
                using (DataSet dsProject = new DataSet())
                using (DataSet dsCard = new DataSet())
                {
                    //判断Excel文件是2003版本还是2007版本
                    string connString = "";
                    if (fileSuffix == ".xls")
                        connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                    else
                        connString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

                    //读取文件
                    string sql_select2 = " SELECT * FROM [Group$]";
                    string sql_select3 = " SELECT * FROM [Project$]";
                    string sql_select4 = " SELECT * FROM [Card$]";
                    using (OleDbConnection conn = new OleDbConnection(connString))
                    using (OleDbDataAdapter cmdGroup = new OleDbDataAdapter(sql_select2, conn))
                    using (OleDbDataAdapter cmdProject = new OleDbDataAdapter(sql_select3, conn))
                    using (OleDbDataAdapter cmdCard = new OleDbDataAdapter(sql_select4, conn))
                    {
                        conn.Open();
                        cmdGroup.Fill(dsGroup);
                        cmdProject.Fill(dsProject);
                        cmdCard.Fill(dsCard);
                    }

                    if (dsGroup == null || dsGroup.Tables.Count <= 0)
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = "GroupList is null,Please try again later",
                            Desc = "GroupList is null,Please try again later"
                        };
                    };
                    if (dsProject == null || dsProject.Tables.Count <= 0)
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = "ProjectList is null,Please try again later",
                            Desc = "ProjectList is null,Please try again later"
                        };
                    };
                    if (dsCard == null || dsCard.Tables.Count <= 0)
                    {
                        objResult = new ResultHelper()
                        {
                            Status = false,
                            Ret = -1,
                            Obj = null,
                            Msg = "CardList is null,Please try again later",
                            Desc = "CardList is null,Please try again later"
                        };
                    };

                    InsertGroup(dsGroup.Tables[0]);
                    InsertProject(dsProject.Tables[0]);
                    InsertNewCard(dsCard.Tables[0]);

                    objResult = new ResultHelper()
                    {
                        Status = true,
                        Ret = 0,
                        Obj = "Batch import Success",
                        Msg = "Batch import Success!",
                        Desc = "Batch import Success!"
                    };
                }
            }
            catch (Exception ex)
            {
                //throw;
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


        private void InsertGroup(DataTable dtGroup)
        {
            foreach (DataRow row in dtGroup.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["Name"].ToString();
                string strManager = row["ManagerName"].ToString();
                string strManagerTel = row["ManagerTel"].ToString();
                string strAddress = row["Address"].ToString();
                string strRefOrg = row["RefOrgName"].ToString();

                if (GroupBll.IsNameExist(strName))
                    continue;

                GlareSysEfDbAndModels.GroupInfo group = new GlareSysEfDbAndModels.GroupInfo()
                {
                    CreateDt = DateTime.Now,
                    Id = 0,
                    IsDel = 0,
                    ManageName = strManager,
                    ManageTel = strManagerTel,
                    UpdateDt = DateTime.Now,
                    GroupAddress = strAddress,
                    GroupName = strName,
                    OrgId = userInfo.UserInfo.MgrOrgId
                };
                string strError;
                GroupBll.AddAGroup(ref group, out strError);
            }

        }


        private void InsertProject(DataTable dtProject)
        {
            foreach (DataRow row in dtProject.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["Name"].ToString();
                string strManager = row["ManagerName"].ToString();
                string strManagerTel = row["ManagerTel"].ToString();
                string strAddress = row["Address"].ToString();
                string strRefGroupName = row["RefGroupName"].ToString();

                if (GroupBll.IsNameExist(strName))
                    continue;

                GlareSysEfDbAndModels.ProjectInfo project = new GlareSysEfDbAndModels.ProjectInfo()
                {
                    Address = strAddress,
                    CreateDt = DateTime.Now,
                    Id = 0,
                    IsDel = 0,
                    UpdateDt = DateTime.Now,
                    GroupId = DataLoader.GetProjectIDByProjectName(strRefGroupName),
                    ManagerName = strManager,
                    ManagerTel = strManagerTel,
                    OrgId = userInfo.UserInfo.MgrOrgId,
                    ProjectName = strName
                };
                string strError;
                ProjectBll.AddAProject(ref project, out strError);
            }

        }

        private void InsertNewCard(DataTable dwCard)
        {
            foreach (DataRow row in dwCard.Rows)
            {
                string strId = row["Index"].ToString();
                string strName = row["CardName"].ToString();
                string strPass = row["CardPassword"].ToString();
                string strSn = row["CardSn"].ToString();
                string strMod = row["CardModel"].ToString();
                string strIsDoub = row["IsDouble"].ToString();
                string strPointCount = row["PointCount"].ToString();
                string strRefProject = row["RefProject"].ToString();
                string strScreenCount = row["ScreenCount"].ToString();

                if (CardWithCommDevBll.IsNameExist(strName))
                    continue;

                if (CardWithCommDevBll.IsSnExise(strSn))
                    continue;

                int iPointIdx = 0;
                int iScreenCount = 0;
                int.TryParse(strPointCount, out iPointIdx);
                int.TryParse(strScreenCount, out iScreenCount);
                //MemCfgInfo.MemProjectInfo prj = GlareSysDataCenter.MemCfgInfo.MemDbMgr.Get().GetMemProjectByName(strRefProject);
                //if (prj == null)
                //{ continue; }
                int iProjectID = DataLoader.GetProjectIDByProjectName(strRefProject);
                if (!string.IsNullOrWhiteSpace(iProjectID.ToString()))
                {
                    int iGroupID = DataLoader.GetGroupIDByProjectID(iProjectID);
                    int iOrgID = DataLoader.GetOrgIDByProjectID(iProjectID);
                    GlareSysEfDbAndModels.GasCardWithCommInfo card = new GlareSysEfDbAndModels.GasCardWithCommInfo()
                    {
                        Address = "",
                        BEnable = 1,
                        CardBrightness = 9,
                        CardContext = "",
                        CardIsDouble = strIsDoub == "1" ? 1 : 0,
                        CardModel = strMod,
                        CardNumberCount = GetDigNumByModel(strMod),
                        CardPointCount = iPointIdx,
                        CardScreenCount = iScreenCount,
                        CityId = "",
                        Comment = "",
                        CommServerSn = strSn,
                        CommExtConnInfo = "",
                        CommSerialBaud = 0,
                        CommSerialDataBit = 0,
                        CommSerialParity = 0,
                        CommSerialPort = "",
                        CommSerialStopBit = 0,
                        CommServerIp = "",
                        CommServerPort = 0,
                        CommTimeoutMs = 2000,
                        CommType = 0,
                        CreateDt = DateTime.Now,
                        DefName = strName,
                        DefPassword = strPass,
                        GroupId = iGroupID,
                        Id = 0,
                        IsDel = 0,
                        OrgId = iOrgID,
                        Password = strPass,
                        PosLatitude = "",
                        PosLongitude = "",
                        ProjectId = iProjectID,
                        ProtocolType = 1,
                        ScreenNams = "1#-2#-3#-4#-5#-6#",
                        Name = strName,
                        UpdateDt = DateTime.Now

                    };
                    string strError;
                    CardWithCommDevBll.AddDev(ref card, out strError);
                }


            }
        }

        private int GetDigNumByModel(string strMod)
        {
            string[] strArr = strMod.Split(new char[] { '-' });
            if (strArr.Length < 2)
            { return 0; }

            if (strArr[strArr.Length - 1] == "910")
            {
                if (strArr.Length != 3)
                {
                    return 0;
                }
                return strArr[1].Length;
            }
            else
            {
                if (strArr.Length == 2)
                {
                    return strArr[1].Length;
                }
                else if (strArr.Length == 3)
                {
                    return strArr[1].Length + strArr[2].Length;
                }
                else
                {
                    return 0;
                }
            }

        }
    }
}