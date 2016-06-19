using ImcFramework.Infrastructure;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 清除日志服务
    /// </summary>
    public class RemoveLogFileEveryDay : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var rootDir = new DirectoryInfo(Defaults.RootDirectory);

                var twoWeeksAgo = DateTime.Now.AddDays(-14);

                foreach (var dir in rootDir.GetDirectories())
                {
                    foreach (var file in dir.GetFiles("*.txt").Where(zw => zw.CreationTime <= twoWeeksAgo))
                    {
                        file.Delete();
                    }
                }

                foreach (var file in rootDir.GetFiles("*.txt").Where(zw => zw.LastWriteTime <= twoWeeksAgo))
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message + ex.StackTrace);
            }
        }
    }
}
