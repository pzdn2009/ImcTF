using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core
{
    /// <summary>
    /// 模块扩展
    /// </summary>
    public interface IModuleExtension
    {
        /// <summary>
        /// 服务上下文
        /// </summary>
        ServiceContext ServiceContext { get; set; }

        /// <summary>
        /// 扩展的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 启动
        /// </summary>
        void Start();

        /// <summary>
        /// 停止
        /// </summary>
        void Stop();
    }
}
