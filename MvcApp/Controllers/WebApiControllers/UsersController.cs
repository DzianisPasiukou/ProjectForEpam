using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicLayer.Entities;

namespace MvcApp.Controllers.WebApiControllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        
        // GET api/<controller>
        [Route("")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.User;  
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}