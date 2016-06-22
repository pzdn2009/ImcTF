using ImcFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ImcFramework.Core.RedisExt
{
    public class RedisSetRepository<TEntity> : IDisposable, IRepository<TEntity, string>
    {
        public void Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contain(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string primaryKey)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(string primaryKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
