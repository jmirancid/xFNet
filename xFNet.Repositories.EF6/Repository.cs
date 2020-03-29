using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using xFNet.Entities;
using xFNet.Interfaces.Repositories;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace xFNet.Repositories.EF6
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
            where TEntity : Entity, new()
    {
        protected DbContext Context { get; set; }

        public virtual void Create(TEntity entity)
        {
            try
            {
                this.Context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Create(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Context.Set<TEntity>().AddRange(entities);
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
                TEntity aux = this.Get(entity.Id);
                if (aux == null) return;

                this.Context.Entry<TEntity>(aux).CurrentValues.SetValues(entity);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach(TEntity entity in entities)
                {
                    this.Update(entity);
                }
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void CreateOrUpdate(TEntity entity)
        {
            try
            {
                this.Context.Set<TEntity>().AddOrUpdate(entity);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void CreateOrUpdate(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach(TEntity entity in entities)
                {
                    this.CreateOrUpdate(entity);
                }
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
                this.Context.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual TEntity Get(object id)
        {
            try
            {
                return this.Context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                //throw ObjectNotFoundException(ex);
                throw ex;
            }
        }

        public virtual TEntity GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Context.Set<TEntity>().FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                //throw ObjectNotFoundException(ex);
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> All()
        {
            try
            {
                return this.Context.Set<TEntity>().AsQueryable();
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
                return this.Context.Set<TEntity>().Where(predicate);
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
                return this.Context.Set<TEntity>().Skip(skip).Take(take);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual IQueryable<TEntity> FilterBy(int skip, int take, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Context.Set<TEntity>().Where(predicate).Skip(skip).Take(take);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual int Count()
        {
            try
            {
                return this.Context.Set<TEntity>().Count();
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
                return this.Context.Set<TEntity>().Count(predicate);
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }

        public virtual void Save()
        {
            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw RepositoryExceptionHandler.GetException(ex);
                throw ex;
            }
        }
    }
}
