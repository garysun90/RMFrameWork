using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMFrameWork.Core
{
    /// <summary>
    /// 扩展方法类
    /// </summary>
    public static class ExtensionMethod
    {
        /// 格式化
        /// </summary>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static string FormatWith(this string target, params object[] args)
        {
            //Check.Argument.IsNotEmpty(target, "target");

            return string.Format(CultureInfo.CurrentCulture, target, args);
        }

    }
}
