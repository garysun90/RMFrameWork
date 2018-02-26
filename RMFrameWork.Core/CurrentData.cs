using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMFrameWork.Core
{
    /// <summary>
    /// 记录当前登录系统的一些基本信息
    /// </summary>
    public class CurrentData
    {
       
        public UserInfo User { get; set; }

        public VersionInfo Version { get; set; }

    }
}
