using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Infrastructure
{
    /// <summary>
    /// 公共断言
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// 必须为TRUE
        /// </summary>
        /// <param name="condition">条件</param>
        public static void IsTrue(bool condition)
        {
            IsTrue(condition, "条件为False");
        }

        /// <summary>
        /// 必须为TRUE
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="message">自定义消息</param>
        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// 必须为FALSE
        /// </summary>
        /// <param name="condition">条件</param>
        public static void IsFalse(bool condition)
        {
            IsFalse(condition, "条件为True");
        }

        /// <summary>
        /// 必须为FALSE
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="message">自定义消息</param>
        public static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// 不能为空
        /// </summary>
        /// <param name="obj">判断的对象</param>
        public static void IsNotNull(object obj)
        {
            IsNotNull(obj, "参数不能为空！");
        }

        /// <summary>
        /// 不能为空
        /// </summary>
        /// <param name="obj">判断的对象</param>
        /// <param name="message">自定义消息</param>
        public static void IsNotNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("", message);
            }
        }

        /// <summary>
        /// 为空
        /// </summary>
        /// <param name="obj">判断的对象</param>
        public static void IsNull(object obj)
        {
            IsNull(obj, "参数不能为空！");
        }

        /// <summary>
        /// 为空
        /// </summary>
        /// <param name="obj">判断的对象</param>
        /// <param name="message">自定义消息</param>
        public static void IsNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// 是否为其中之一
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">判断对象</param>
        /// <param name="possibles">列表集合</param>
        /// <returns></returns>
        public static bool IsOneOfSupplied<T>(T obj, List<T> possibles)
        {
            return IsOneOfSupplied<T>(obj, possibles, "列表不包含指定的集合");
        }

        /// <summary>
        /// 是否为其中之一
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">判断对象</param>
        /// <param name="possibles">列表集合</param>
        /// <param name="message">自定义消息</param>
        /// <returns></returns>
        public static bool IsOneOfSupplied<T>(T obj, List<T> possibles, string message)
        {
            foreach (T possible in possibles)
                if (possible.Equals(obj))
                    return true;
            throw new ArgumentException(message);
        }
    }
}
