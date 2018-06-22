using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using xFNet.Entities;
using xFNet.Interfaces.Repositories;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace xFNet.Repositories.EF6
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
            where TEntity : Entity, new()
            where TContext : ObjectContext, new()
    {
        private TContext _context;

        protected TContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                    _context.ContextOptions.LazyLoadingEnabled = false;
                    _context.ContextOptions.ProxyCreationEnabled = false;
                }
                return _context;
            }
        }

        public virtual void Create(TEntity entity)
        {
            try
            {
                Context.CreateObjectSet<TEntity>().AddObject(entity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                EntityKey key =
                    Context.CreateEntityKey(Context.CreateObjectSet<TEntity>().EntitySet.Name, entity);

                TEntity aux = null;
                aux = (TEntity)Context.GetObjectByKey(key);

                Context.CreateObjectSet<TEntity>().ApplyCurrentValues(entity);
                Context.ObjectStateManager.GetObjectStateEntry(aux).ChangeState(EntityState.Modified);
                Context.ObjectStateManager.ChangeObjectState(aux, EntityState.Modified);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                Context.CreateObjectSet<TEntity>().DeleteObject(entity);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual TEntity Get(object id)
        {
            var entity = new TEntity();
            (entity as Entity).Id = id;

            EntityKey key =
                Context.CreateEntityKey(Context.CreateObjectSet<TEntity>().EntitySet.Name, entity);

            try
            {
                entity = (TEntity)Context.GetObjectByKey(key);
                return entity;
            }
            catch (ObjectNotFoundException ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().FirstOrDefault(predicate);
            }
            catch (ObjectNotFoundException ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> All()
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().AsQueryable();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> AllBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().Where(predicate).AsQueryable();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> Filter(int skip, int take)
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().Skip(skip).Take(take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> FilterBy(int skip, int take, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().Where(predicate).Skip(skip).Take(take);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Count()
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().Count();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual int CountBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.CreateObjectSet<TEntity>().Count(predicate);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }
    }
}
