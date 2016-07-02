using StackExchange.Redis;

namespace ImcFramework.Core.RedisExt
{
    public interface IRedisDatabaseProvider
    {
        IDatabase Database { get; }
    }
}
