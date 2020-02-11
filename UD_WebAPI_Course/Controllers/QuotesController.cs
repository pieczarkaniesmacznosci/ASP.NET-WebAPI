using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UD_WebAPI_Course.Controllers
{
    using UD_WebAPI_Course.Data;
    using UD_WebAPI_Course.Models;

    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();
        // GET: api/Quotes
        public IEnumerable<Quote> Get()
        {
            return this.quotesDbContext.Quotes;
        }

        // GET: api/Quotes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quotes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quotes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quotes/5
        public void Delete(int id)
        {
        }
    }
}
