using System;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;

namespace ImcFramework.Core.IsolatedAd
{
    /// <summary>
    /// Remote object for a new appdomain call.
    /// </summary>
    public class RemoteObject : MarshalByRefObject, IDisposable, ISponsor
    {
        /// <summary>
        /// The instance of the input type.
        /// </summary>
        private object m_Instance;

        /// <summary>
        /// The input type
        /// </summary>
        private Type m_Type;

        /// <summary>
        /// The assemly of the input type.
        /// </summary>
        public Assembly CurrAssembly
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Initialize the assembly & instance & type.
        /// </summary>
        /// <param name="assemblyFile">the asembly file</param>
        /// <param name="typeName">the full type of the isolated job.</param>
        public void Init(string assemblyFile, string typeName)
        {
            CurrAssembly = Assembly.LoadFrom(assemblyFile);
            m_Type = CurrAssembly.GetType(typeName);
            if (m_Type != null)
            {
                m_Instance = Activator.CreateInstance(m_Type);
            }
        }

        #region executions.

        /// <summary>
        /// Execute method in a appdomain with a return .
        /// </summary>
        /// <typeparam name="T">the generic instance of the execution.</typeparam>
        /// <param name="methodName">the invoking method name.</param>
        /// <param name="parameters">the invoking parameters.</param>
        /// <returns></returns>
        public T ExecuteMethod<T>(string methodName, params object[] parameters)
        {
            return (T)m_Type.GetMethod(methodName).Invoke(this.m_Instance, parameters);
        }

        /// <summary>
        /// Execute method in a appdomain without any return.
        /// </summary>
        /// <typeparam name="T">the generic instance of the execution.</typeparam>
        /// <param name="methodName">the invoking method name.</param>
        /// <param name="parameters">the invoking parameters.</param>
        /// <returns></returns>
        public void ExecuteMethod(string methodName, params object[] parameters)
        {
            m_Type.GetMethod(methodName).Invoke(this.m_Instance, parameters);
        }

        #endregion

        ~RemoteObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && m_Instance != null)
            {
                var method = m_Type.GetMethod("Dispose");
                if (method != null)
                    method.Invoke(m_Instance, null);
            }
        }

        /// <summary>
        /// Renewal for the remote object in a appdomain.
        /// </summary>
        public TimeSpan Renewal(ILease lease)
        {
#if DEBUG
            Console.WriteLine("Renewal");
#endif
            return TimeSpan.FromMinutes(5);
        }
    }
}
