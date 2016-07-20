using StackExchange.Redis;

namespace ImcFramework.Core.RedisExt.Extension
{
    public static class RedisValueExtension
    {
        public static string ToJson<T>(this T entity)
        {
            return JsonUtils.ToJson(entity);
        }

        public static T FromJson<T>(this RedisValue redisValue)
        {
            return JsonUtils.ToObject<T>(redisValue);
        }
    }
}
