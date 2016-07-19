using ImcFramework.Repositories;
using System.Collections.Generic;

namespace ImcFramework.Core.RedisExt
{
    public class RedisSetRepository<TEntity> : RedisBaseRepository<TEntity>, IRepository<TEntity, string>
    {
        public RedisSetRepository(IRedisDatabaseProvider databaseProvider)
            : base(databaseProvider)
        {

        }

        public override RedisType RedisType
        {
            get
            {
                return RedisType.Set;
            }
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return null;
        }
    }
}
