using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOServer.BLL;
using System.Threading;
using Models;

namespace IOServer.BLL
{
    class IModuleCmdHander
    {
        public virtual bool _HandleCmd(IPort iPort,            
            RealControlModel aCmd, 
            ref string strCmdHandedMsg)
        {
            return false;
        }

        public virtual string _GetType()
        {
            return "";
        }
    }

  
}
