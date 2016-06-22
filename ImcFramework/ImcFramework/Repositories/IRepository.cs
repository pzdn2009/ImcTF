using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey primaryKey);
        void Clear();

        TEntity Get(TKey primaryKey);
        bool Contain(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
