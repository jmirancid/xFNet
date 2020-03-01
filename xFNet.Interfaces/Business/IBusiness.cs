using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFNet.Entities;

namespace xFNet.Interfaces.Business
{
    public interface IBusiness<TEntity>
        where TEntity : Entity, new()
    {
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

        IEnumerable<TEntity> All();
        IEnumerable<TEntity> AllBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Filter(int skip, int take);
        IEnumerable<TEntity> FilterBy(int skip, int take, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        int Count();
        int CountBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
    }
}
