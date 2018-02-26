using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMFrameWork.Core
{
    /// <summary>
    /// 所有工具类集合 组合模式
    /// </summary>
    public static class Utility
    {
        private static IRMFile _file;
        /// <summary>
        /// 文件类
        /// </summary>
        public static IRMFile File
        {
            get
            {
                if (_file == null)
                    _file = ReflectionHelper.CreateObject<IRMFile>("RMFrameWork.Kernel.FileHelper,RMFrameWork.Kernel");
                return _file;
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        public static IRMEncrypt Encrypt { get; set; }

        /// <summary>
        /// 序列化类
        /// </summary>
        public static IRMSerializtion Serialize { get; set; }

        /// <summary>
        /// 缓存类
        /// </summary>
        public static IRMCache Cache { get; set; }
        /// <summary>
        /// WCF类
        /// </summary>
        public static IRMWcfService WcfService { get; set; }

        /// <summary>
        /// IOC封装类
        /// </summary>
        public static IRMIoc Ioc { get; set; }

        ///// <summary>
        ///// 反射类
        ///// </summary>
        //public static IRMReflection Reflecion { get; set; }

        /// <summary>
        /// 克隆类
        /// </summary>
        public static IRMClone Clone { get; set; }

        /// <summary>
        /// win32帮助类
        /// </summary>
        public static IRMWin32Api Win32Api { get; set; }


        /// <summary>
        /// 日志帮助类
        /// </summary>
        public static IRMLog Log { get; set; }

        /// <summary>
        /// 热键
        /// </summary>
        public static IRMHotKey HotKey { get; set; }

        /// <summary>
        /// 注册表
        /// </summary>
        public static IRMRegistry Registry { get; set; }

        /// <summary>
        /// 解压缩
        /// </summary>
        public static IRMCompress Compress { get; set; }


        /// <summary>
        /// 网络
        /// </summary>
        public static IRMNet Net { get; set; }

    }


    public static class Utility<T>
    {
        /// <summary>
        /// 比较相等
        /// </summary>
        public static IRMEquality<T> Equality { get; set; }


        /// <summary>
        /// 比较大小
        /// </summary>
        public static IRMComparison<T> Comparison { get; set; }
    }
}
