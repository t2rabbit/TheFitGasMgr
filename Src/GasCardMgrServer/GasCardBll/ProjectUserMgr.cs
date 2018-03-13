///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ProjectUserMgr.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-21 23:22:28
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

#if SQL_SERVER
using NetLabelEfDbDll.SqlServer;
#else
// mysql
// sqlite
#endif

    

namespace NetLabelBll
{
    /// <summary>
    /// 工程用户管理
    /// </summary>
    public class ProjectUserMgr
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="strErrorMsg"></param>
        /// <returns></returns>
        public bool AddUser(ref ProjectUserModel mod, out string strErrorMsg)
        {
            // todo
            if (IsProjectUserNameExist(mod.Name))
            {
                strErrorMsg = ConstStringDefine.NameExist;
                return false;
            }
            strErrorMsg = "";

            using (CellLedLabelMgrDBEntities ent = new CellLedLabelMgrDBEntities())
            {
                
            }

            return false;
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        private bool IsProjectUserNameExist(string strName)
        {
            // todo
            return false;
        }
    }
}
