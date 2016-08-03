using Quartz;
using System.Collections.Generic;
using System;

namespace ImcFramework.Core.Quartz
{
    /// <summary>
    /// Resolve the request parameters.
    /// </summary>
    public static class ResolveParameters
    {
        /// <summary>
        /// Get parameter value from the jobcontext by the parameter name.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="context">The job-context.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>return the parameter value.</returns>
        public static T GetParameter<T>(this IJobExecutionContext context, string paramName)
        {
            if (context.MergedJobDataMap != null)
            {
                return (T)context.MergedJobDataMap.Get(paramName);
            }

            return default(T);
        }

        /// <summary>
        /// Get comma parameter value list from the jobcontext by the parameter name.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="context">The job-context.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <returns>return the parameter value list.</returns>
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

            return new List<T>();
        }
    }
}
