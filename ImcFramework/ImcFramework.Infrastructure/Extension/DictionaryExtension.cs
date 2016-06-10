using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImcFramework.Infrastructure
{
    /// <summary>
    /// 字典扩展
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 获取或者添加获取
        /// </summary>
        /// <param name="dict">字典</param>
        /// <param name="key">字符串键</param>
        /// <param name="value">字符串值</param>
        /// <returns>值</returns>
        public static string GetOrAddGet(this Dictionary<string, string> dict, string key, Func<string> value)
        {
            return GetOrAddGet<string>(dict, key, value);
        }

        /// <summary>
        /// 获取或者添加获取
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dict">字典</param>
        /// <param name="key">字符串键</param>
        /// <param name="value">字符串值</param>
        /// <returns>值</returns>
        public static T GetOrAddGet<T>(this Dictionary<string, T> dict, string key, Func<T> value)
        {
            Guard.IsNotNull(dict);
            Guard.IsFalse(key.IsNullOrEmpty(), "key为空置！");

            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            dict[key] = value();
            return dict[key];
        }
    }
}
