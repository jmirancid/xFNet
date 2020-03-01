using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using xFNet.Entities;
using xFNet.Interfaces.Business;

namespace xFNet.Web.Http
{
    public abstract class ApiController<TBusiness, TEntity> : System.Web.Http.ApiController
            where TBusiness : IBusiness<TEntity>, new()
            where TEntity : Entity, new()
    {
        protected Lazy<TBusiness> Business { get; set; }

        public ApiController() { }

        public ApiController(TBusiness business)
        {
            this.Business = new Lazy<TBusiness>(() => business);
        }

        [HttpGet]
        // GET: api/student
        public IEnumerable<TEntity> All()
        {
            try
            {
                return this.Business.Value.All();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/student/5
        public TEntity Get(int id)
        {
            try
            {
                return this.Business.Value.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/student
        public void Post([FromBody]TEntity value)
        {
            try
            {
                if (value == null)
                    BadRequest();

                this.Business.Value.Create(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/student/5
        public void Put(int id, [FromBody]TEntity value)
        {
            try
            {
                if (value == null)
                    BadRequest();

                this.Business.Value.Update(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/student/5
        public void Delete(int id)
        {
            try
            {
                this.Business.Value.Delete(new TEntity());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
