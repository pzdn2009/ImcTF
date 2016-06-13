using ImcFramework.Core.TaskPriorityQueue;
using ImcFramework.WcfInterface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 多线程分页执行
    /// </summary>
    public class MutilTaskPaging
    {
        public static void RunBySimplePaging(List<Task> tasks, int maxRunNumbers = 5)
        {
            int pages = tasks.Count / maxRunNumbers + (tasks.Count % maxRunNumbers == 0 ? 0 : 1);

            int i = 0;
            while (i < pages)
            {
                var takeSome = tasks.Skip(maxRunNumbers * i++).Take(maxRunNumbers).ToList();
                Parallel.ForEach(takeSome, (t) => { t.Start(); });
                Task.WaitAll(takeSome.ToArray());
            }
        }

        public static TaskFactory GetTaskScheduler(int maxRunNumbers = 5)
        {
            var limitScheduler = new LimitedConcurrencyLevelTaskScheduler(maxRunNumbers);
            TaskFactory factory = new TaskFactory(limitScheduler);
            return factory;
        }
    }
}
