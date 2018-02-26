using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RMFrameWork.Core
{
    /// <summary>
    /// 反射调用
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static T CreateObject<T>(string typeName, params Type[] typeArguments)
        {
            try
            {
                Type t = Type.GetType(typeName);
                if (t == null) return default(T);
                if (typeArguments.Length > 0)
                    t = t.MakeGenericType(typeArguments);
                return (T)Activator.CreateInstance(t);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentNullException("实例化[{0}]失败".FormatWith(typeName), ex);
            }
        }

        /// <summary>
        /// 实例化 带参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateObject<T>(string typeName, object[] args, params Type[] typeArguments)
        {
            try
            {
                Type t = Type.GetType(typeName);
                if (t == null) return default(T);
                if (typeArguments.Length > 0)
                    t = t.MakeGenericType(typeArguments);
                return (T)Activator.CreateInstance(t, args);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentNullException("实例化[{0}]失败".FormatWith(typeName), ex);
            }
        }

        /// <summary>
        /// 动态执行公开方法
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object InvokeMethod(string typeName, string methodName, params object[] parameters)
        {
            try
            {
                Type t = Type.GetType(typeName);
                object obj = Activator.CreateInstance(t);
                if (obj == null) throw new ApplicationException("对象[{0}]未找到".FormatWith(typeName));
                var m = t.GetMethod(methodName);
                if (m == null) throw new ApplicationException("方法[{0}]未找到".FormatWith(methodName));
                if (m.GetParameters().Length != parameters.Length) throw new ApplicationException("方法[{0}]入参数目不符".FormatWith(methodName));
                object result = m.Invoke(obj, parameters);
                obj = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentNullException("实例化[{0}]失败".FormatWith(typeName), ex);
            }
        }

        public static object InvokeMethod(object obj, string methodName, params object[] parameters)
        {
            try
            {
                var m = obj.GetType().GetMethod(methodName);
                if (m == null) throw new ApplicationException("方法[{0}]未找到".FormatWith(methodName));
                if (m.GetParameters().Length != parameters.Length) throw new ApplicationException("方法[{0}]入参数目不符".FormatWith(methodName));
                object result = m.Invoke(obj, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentNullException("实例化[{0}]失败".FormatWith(obj.GetType().Name), ex);
            }
        }

        public static Assembly CompileFromSource(string[] assemblies, string sourceCode)
        {
            // 1.CSharpCodePrivoder
            CodeDomProvider csc = CodeDomProvider.CreateProvider("CSharp");

            // 2.CompilerParameters
            CompilerParameters cp = new CompilerParameters();
            foreach (var reference in assemblies)
            {
                cp.ReferencedAssemblies.Add(reference);
            }
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;

            // 3.CompilerResults
            CompilerResults cr = csc.CompileAssemblyFromSource(cp, sourceCode);

            if (cr.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CompilerError err in cr.Errors)
                {
                    sb.AppendLine(err.ErrorText);
                }
                throw new ApplicationException(sb.ToString());
            }
            else
            {
                Assembly assembly = cr.CompiledAssembly;
                return assembly;
            }
        }
    }
}
