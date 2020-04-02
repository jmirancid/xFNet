using System;
using System.Collections.Generic;
using System.Web.Http;
using xFNet.Entities;
using xFNet.Interfaces.Business;

namespace xFNet.Web.Http
{
    public abstract class ApiController<TEntity, TBusiness> : System.Web.Http.ApiController
            where TEntity : Entity, new()
            where TBusiness : IBusiness<TEntity>, new()
    {
        readonly TBusiness bizEntity;

        public ApiController() { }

        public ApiController(TBusiness bizEntity)
        {
            this.bizEntity = bizEntity;
        }

        [HttpGet]
        public IEnumerable<TEntity> All()
        {
            try
            {
                return bizEntity.All();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public TEntity Get(int id)
        {
            try
            {
                return bizEntity.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody]TEntity value)
        {
            try
            {
                if (value == null)
                    BadRequest();

                bizEntity.Create(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody]TEntity value)
        {
            try
            {
                if (value == null)
                    BadRequest();

                bizEntity.Update(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                bizEntity.Delete(new TEntity { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
