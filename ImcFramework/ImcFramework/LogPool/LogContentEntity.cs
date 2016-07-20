using System.Diagnostics;
using System.Text;

namespace ImcFramework.LogPool
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogContentEntity
    {
        public LogContentEntity() : this(string.Empty)
        {

        }

        public LogContentEntity(string message)
        {
            var sf = new StackFrame(2);
            var method = sf.GetMethod();

            Class = method.DeclaringType.Name;
            Method = method.Name;
            Level = "Info";
        }

        public LogContentEntity(string message, string @class, string method, string level)
        {
            Message = message;

            Class = @class;
            Method = method;
            Level = level;
        }

        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 自定义消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 消息级别
        /// </summary>
        public string Level { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");
            sb.Append("ClassName:" + Class + "\r\n");
            sb.Append("MethodName:" + Method + "\r\n");
            sb.Append("Message:" + Message + "\r\n");
            return sb.ToString();
        }
    }
}
