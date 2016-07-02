using StackExchange.Redis;

namespace ImcFramework.Core.RedisExt
{
    public class ConnectionManager
    {
        private static object _locker = new object();
        private static ConnectionMultiplexer _redis;
        public static ConnectionMultiplexer Redis
        {
            get
            {
                if (_redis == null)
                {
                    lock (_locker)
                    {
                        if (_redis != null) return _redis;
                        _redis = GetManager();
                        return _redis;
                    }
                }
                return _redis;
            }
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "localhost";// GetDefaultConnectionString();
            }
            return ConnectionMultiplexer.Connect(connectionString);
        }

        public static void Test()
        {
            var db = Redis.GetDatabase();
            var ret = db.ListGetByIndex("pzdn2", 0);
            System.Console.WriteLine(ret);
        }
    }
}
