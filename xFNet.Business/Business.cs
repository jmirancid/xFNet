using System;
using System.Collections.Generic;
using System.Linq;
using xFNet.Entities;
using xFNet.Interfaces.Business;
using xFNet.Interfaces.Repositories;

namespace xFNet.Business
{
    public abstract class Business<TEntity, TRepository> : IBusiness<TEntity>
            where TEntity : Entity, new()
            where TRepository : IRepository<TEntity>
    {
        protected TRepository Repository { get; set; }

        public Business() { }

        public Business(TRepository repository)
        {
            this.Repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            try
            {
                this.Repository.Create(entity);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Create(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Repository.Create(entities);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                this.Repository.Update(entity);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Repository.Update(entities);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void CreateOrUpdate(TEntity entity)
        {
            try
            {
                this.Repository.CreateOrUpdate(entity);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void CreateOrUpdate(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Repository.CreateOrUpdate(entities);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                this.Repository.Delete(entity);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            try
            {
                this.Repository.Delete(entities);
                this.Repository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity Get(object id)
        {
            try
            {
                return this.Repository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Repository.GetBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> All()
        {
            try
            {
                return this.Repository.All().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> AllBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Repository.AllBy(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> Filter(int skip, int take)
        {
            try
            {
                return this.Repository.Filter(skip, take).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> FilterBy(int skip, int take, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Repository.FilterBy(skip, take, predicate).ToList();
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
                return this.Repository.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int CountBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.Repository.CountBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
