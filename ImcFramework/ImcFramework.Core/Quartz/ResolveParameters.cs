using Quartz;
using System.Collections.Generic;
using System;

namespace ImcFramework.Core.Quartz
{
    public static class ResolveParameters
    {
        public static T GetParameter<T>(this IJobExecutionContext context, string paramName)
        {
            if (context.MergedJobDataMap != null)
            {
                return (T)context.MergedJobDataMap.Get(paramName);
            }

            return default(T);
        }

        public static IEnumerable<T> GetParameters<T>(this IJobExecutionContext context, string paramName)
        {
            if (context.MergedJobDataMap != null)
            {
                var str = context.MergedJobDataMap.GetString(paramName);
                if (!string.IsNullOrEmpty(str))
                {
                    var list = new List<T>();
                    var vals = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var val in vals)
                    {
                        list.Add((T)Convert.ChangeType(val, typeof(T)));
                    }

                    return list;
                }
            }

            return default(List<T>);
        }
    }
}
