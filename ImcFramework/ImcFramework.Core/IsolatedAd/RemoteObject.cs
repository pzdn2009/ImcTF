using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// 隔离对象
    /// </summary>
    public class RemoteObject : MarshalByRefObject, IDisposable, ISponsor
    {
        public Assembly CurrAssembly
        {
            get;
            private set;
        }

        private object Instance
        {
            get;
            set;
        }

        private Type Type
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化对象信息
        /// </summary>
        /// <param name="assemblyFile">程序集文件</param>
        /// <param name="typeName">类型</param>
        public void Init(string assemblyFile, string typeName)
        {
            this.CurrAssembly = Assembly.LoadFrom(assemblyFile);
            this.Type = this.CurrAssembly.GetType(typeName);
            if (this.Type != null)
                this.Instance = Activator.CreateInstance(this.Type);
        }

        #region 调用方法

        /// <summary>
        /// 调用方法，并返回
        /// </summary>
        /// <typeparam name="T">返回值烈性</typeparam>
        /// <param name="methodName">方法名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public T ExecuteMethod<T>(string methodName, params object[] parameters)
        {
            return (T)this.Type.GetMethod(methodName).Invoke(this.Instance, parameters);
        }

        /// <summary>
        /// 调用方法，无返回
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="parameters">参数</param>
        public void ExecuteMethod(string methodName, params object[] parameters)
        {
            this.Type.GetMethod(methodName).Invoke(this.Instance, parameters);
        }
        #endregion

        ~RemoteObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.Instance != null)
            {
                var method = this.Type.GetMethod("Dispose");
                if (method != null)
                    method.Invoke(this.Instance, null);
            }
        }

        /// <summary>
        /// 远程对象续约
        /// </summary>
        public TimeSpan Renewal(ILease lease)
        {
#if DEBUG
            Console.WriteLine("续约");
#endif
            return TimeSpan.FromMinutes(5);
        }
    }
}
