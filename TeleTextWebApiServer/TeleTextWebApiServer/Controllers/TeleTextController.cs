using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeleTextWebApiServer.Controllers
{
    public class TeleTextController : ApiController
    {
        // GET: api/TeleText
        public IEnumerable<string> Get()
        {
            return new string[] { "TeleText1", "TeleText2" };
        }

        // GET: api/TeleText/5
        public string Get(int id)
        {
            return "TeleText" + id;
        }

        // POST: api/TeleText
        public void Post([FromBody]string value)
        {

        }
        
    }
}
