using Common.Logging;

namespace ImcFramework.LogPool
{
    public interface IFileAppender
    {
        string GetFileName(string user, LogLevel LogLevel);

        string GetAppenderName(string user, LogLevel LogLevel);
    }
}
