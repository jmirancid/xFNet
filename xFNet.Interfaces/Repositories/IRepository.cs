using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFNet.Entities;

namespace xFNet.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity, new()
    {
        // TODO: 
        //  - Add include properties (maybe with lambda property navigator)
        //  - order by (maybe with lambda property navigator)
        //  - implement async methods

        void Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);

        void CreateOrUpdate(TEntity entity);
        void CreateOrUpdate(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entites);

        TEntity Get(object id);
        TEntity GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> All();
        IQueryable<TEntity> AllBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Filter(int skip, int take);
        IQueryable<TEntity> FilterBy(int skip, int take, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        int Count();
        int CountBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        void Save();
    }
}
