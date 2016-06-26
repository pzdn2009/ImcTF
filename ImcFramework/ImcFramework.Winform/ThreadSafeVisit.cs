using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImcFramework.Winform
{
    public static class ThreadSafeVisit
    {
        public static void SetValue<T, TReturn>(this T control, SynchronizationContext uiContext,
            Expression<Func<T, TReturn>> property, TReturn value) where T : Control
        {
            var propertyName = (property.Body as MemberExpression).Member.Name;
            uiContext.Send((obj) =>
            {
                control.GetType().GetProperty(propertyName).SetValue(control, value);
            }, null);
        }
    }
}
