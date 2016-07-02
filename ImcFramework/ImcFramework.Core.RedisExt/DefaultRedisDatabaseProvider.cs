using StackExchange.Redis;

namespace ImcFramework.Core.RedisExt
{
    public class DefaultRedisDatabaseProvider : IRedisDatabaseProvider
    {
        public DefaultRedisDatabaseProvider()
        {
        }

        public IDatabase Database
        {
            get
            {
                return ConnectionManager.Redis.GetDatabase();
            }
        }
    }
}
