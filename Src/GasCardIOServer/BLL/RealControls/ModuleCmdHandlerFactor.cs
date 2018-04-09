///<summary>
///Copyright (c) 2015, 珠海派诺科技股份有限公司
///Product: PiEMS
///
///文件名称: ModuleCmdHandlerFactor.cs
///开发环境: Microsoft Visual Studio 2010
///描    述：
///
///当前版本: V1.0
///作    者: Wudq
///完成日期: 2016-03-26 21:59:49
///
///修改记录 
/// 作者   时间    版本      修改描述
///
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOServer.BLL.RealControls
{
    /// <summary>
    /// 命令处理器工厂
    /// </summary>
    class ModuleCmdHandlerFactor
    {
        protected static ModuleCmdHandlerFactor m_pInst;
        protected ModuleCmdHandlerFactor() { }

        public static ModuleCmdHandlerFactor Get()
        {
            if (m_pInst == null)
            {
                m_pInst = new ModuleCmdHandlerFactor();
                m_pInst.Init();
            }
            return m_pInst;
        }
        public static void Release()
        {
            if (m_pInst == null)
            {
                return;
            }

            m_pInst.m_lstGetter.Clear();
        }

        protected void Init()
        {
            m_lstGetter.Clear();
            m_lstGetter.Add(new CellLabelDevCmdHandler());
        }

        public IModuleCmdHander GetNodeGetterByType(string strType)
        {
            strType = strType.ToUpper();
            foreach (IModuleCmdHander aGetter in m_lstGetter)
            {
                if (aGetter._GetType().IndexOf(strType) >= 0)
                {
                    return aGetter;
                }
            }
            return null;
        }

        protected List<IModuleCmdHander> m_lstGetter = new List<IModuleCmdHander>();
    }
}
