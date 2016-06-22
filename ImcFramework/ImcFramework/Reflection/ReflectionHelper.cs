using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Reflection
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// 获取自己的类型，或者Nullable的实际类型
        /// </summary>
        /// <param name="propertyType">属性的类型</param>
        /// <returns></returns>
        public static Type GetUnderlyingTypeOrSelf(this Type propertyType)
        {
            if (propertyType == null)
            {
                return null;
            }

            var currentType = Nullable.GetUnderlyingType(propertyType);
            if (currentType == null)
            {
                currentType = propertyType;
            }

            return currentType;
        }

        /// <summary>
        /// 是否为复杂类型
        /// </summary>
        /// <param name="propertyType">属性的类型</param>
        /// <returns>true：是；false：不是</returns>
        public static bool IsComplexType(this Type propertyType)
        {
            if ((propertyType.IsPrimitive || propertyType.IsValueType || propertyType == typeof(string)) || propertyType == typeof(DateTime))
            {
                return false;
            }

            return true;
        }
    }
}
