using RedisSession4Net.Core.Components;
using RedisSession4Net.Web.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace RedisSession4Net.Web.Controllers
{
    public class ValueController : BaseApiController<SessionModel>
    {
        // GET: api/Value
        public IEnumerable<string> Get()
        {
            return this.Session.SampleString.Split(';');
        }

        // GET: api/Value/5
        public string Get(int id)
        {
            this.Session.SampleString += id.ToString() + ";";
            return id.ToString();
        }

        // POST: api/Value
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Value/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Value/5
        public void Delete(int id)
        {
        }
    }
}
