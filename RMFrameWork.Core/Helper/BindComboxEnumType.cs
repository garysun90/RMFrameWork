using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMFrameWork.Core
{
    /// <summary>
    /// 用于Combox显示绑定的对象,将枚举转换成一个List集合
    /// </summary>
    public class BindComboxEnumType<T>
    {
        /// <summary>
        /// 类型的名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        private static readonly List<BindComboxEnumType<T>> bindTypes;

        static BindComboxEnumType()
        {
            bindTypes = new List<BindComboxEnumType<T>>();

            foreach (var name in System.Enum.GetNames(typeof(T)))
            {
                bindTypes.Add(new BindComboxEnumType<T>()
                {
                    Name = name,
                    Type = (int)(System.Enum.Parse(typeof(T), name))
                });
            }
        }

        /// <summary>
        /// 绑定的类型数据
        /// </summary>
        public static List<BindComboxEnumType<T>> BindTypes
        {
            get { return bindTypes; }
        }
    }
}
