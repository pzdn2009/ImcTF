using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ImcFramework.Infrastructure
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="value">枚举成员</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();

        }
        /// <summary>
        /// 获取枚举的描述文本
        /// </summary>
        /// <param name="e">枚举成员</param>
        /// <returns></returns>
        public static string GetDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();
            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {
                //判断名称是否相等
                if (f.Name != e.ToString()) continue;
                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    DescriptionAttribute dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }
            }
            //如果没有检测到合适的注释，则用默认名称
            return e.ToString();
        }
        /// <summary>
        /// 根据名字得到描述文本
        /// </summary>
        public static string GetDescription(Type enumType, string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                foreach (object etype in Enum.GetValues(enumType))
                {
                    if (etype.ToString() == name) return GetDescription(etype);
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 根据值得到描述文本
        /// </summary>
        public static string GetDescription(Type enumType, int? value)
        {
            if (value.HasValue)
            {
                foreach (object etype in Enum.GetValues(enumType))
                {
                    if ((int)etype == value.Value) return GetDescription(etype);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据描述文本得到值
        /// </summary>
        /// <param name="enumType">typeof()</param>
        /// <param name="description">描述文本</param>
        /// <param name="isValidityCheck">是否验证描述包含在枚举内</param>
        /// <param name="checkEmpty">是否检查空</param>
        /// <returns></returns>
        public static int? GetValue(Type enumType, string description, bool isValidityCheck = false, bool checkEmpty = false)
        {
            var topAttr = ((DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute)));
            string topDescription = (topAttr == null ? enumType.Name : topAttr.Description);

            if (string.IsNullOrWhiteSpace(description))
            {
                if (checkEmpty) throw new Exception(string.Format("{0}不能为空", topDescription));
            }
            else
            {
                foreach (object etype in Enum.GetValues(enumType))
                {
                    if (GetDescription(etype) == description || etype.ToString().Equals(description, StringComparison.CurrentCultureIgnoreCase) || ((int)etype).ToString() == description)
                        return (int)etype;
                }

                if (isValidityCheck) throw new Exception(string.Format("{0}错误[{1}]", topDescription, description));
            }
            return null;
        }
        /// <summary>
        /// 根据描述文本得到名字
        /// </summary>
        public static string GetName(Type enumType, string description, bool isValidityCheck = false, bool checkEmpty = false)
        {
            var topAttr = ((DescriptionAttribute)Attribute.GetCustomAttribute(enumType, typeof(DescriptionAttribute)));
            string topDescription = (topAttr == null ? enumType.Name : topAttr.Description);

            if (string.IsNullOrWhiteSpace(description))
            {
                if (checkEmpty) throw new Exception(string.Format("{0}不能为空", topDescription));
            }
            else
            {
                foreach (object etype in Enum.GetValues(enumType))
                {
                    if (GetDescription(etype) == description || etype.ToString().Equals(description, StringComparison.CurrentCultureIgnoreCase) || ((int)etype).ToString() == description)
                        return etype.ToString();
                }

                if (isValidityCheck) throw new Exception(string.Format("{0}错误[{1}]", topDescription, description));
            }
            return description;
        }

        /// <summary>
        ///  把枚举的描述和值绑定到DropDownList
        /// </summary>
        /// <param name="isNameValue">是否使用枚举名做为值(value)</param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetList(Type enumType, string emptyKey, string emptyValue, bool isNameValue = false)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            if (emptyKey != null) result.Add(new KeyValuePair<string, string>(emptyKey, emptyValue));
            foreach (object e in Enum.GetValues(enumType))
            {
                result.Add(new KeyValuePair<string, string>(isNameValue ? e.ToString() : ((int)e).ToString(), GetDescription(e)));
            }
            return result;
        }
        public static List<KeyValuePair<string, string>> GetList(Type enumType, bool includeEmpty = false, bool isNameValue = false)
        {
            if (includeEmpty)
            {
                return GetList(enumType, "", "", isNameValue);
            }
            else
            {
                return GetList(enumType, null, null, isNameValue);
            }
        }
    }
}
