using ImcFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using StackExchange.Redis;

namespace ImcFramework.Core.RedisExt
{
    public abstract class RedisBaseRepository<TEntity> : IDisposable, IRepository<TEntity, string>
    {
        private readonly IRedisDatabaseProvider _databaseProvider;

        public RedisBaseRepository(IRedisDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;

            RedisKey = typeof(TEntity).FullName;
        }

        protected IDatabase Database
        {
            get { return _databaseProvider.Database; }
        }

        public abstract RedisType RedisType { get; }

        public RedisKey RedisKey { get; set; }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual bool Contain(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(string primaryKey)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(string primaryKey)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
