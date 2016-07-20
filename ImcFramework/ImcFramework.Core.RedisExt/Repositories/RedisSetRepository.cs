using ImcFramework.Repositories;
using System.Collections.Generic;
using ImcFramework.Core.RedisExt.Extension;

namespace ImcFramework.Core.RedisExt.Repositories
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
            var ret = new List<TEntity>();

            var vals = Database.SetMembers(RedisKey);
            foreach (var val in vals)
            {
                ret.Add(val.FromJson<TEntity>());
            }

            return ret;
        }

        public override void Add(TEntity entity)
        {
            Database.SetAdd(RedisKey, entity.ToJson());
        }

        public override void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public override void Clear()
        {

        }

        public override bool Contain(TEntity entity)
        {
            return Database.SetContains(RedisKey, entity.ToJson());
        }

        public override void Delete(TEntity entity)
        {
            Database.SetRemove(RedisKey, entity.ToJson());
        }
    }
}
