using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UD_WebAPI_Course.Controllers
{
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography.X509Certificates;

    using UD_WebAPI_Course.Models;

    public class QuotesController : ApiController
    {
        static List<Quote> _quotes = new List<Quote>()
                                 {
                                     new Quote(){Author = "Author1", Description = "Desc1", Id = 1,Title = "Title1"},
                                     new Quote(){Author = "Author2", Description = "Desc2", Id = 2,Title = "Title2"}
                                 };


        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }
        [HttpPut]
        public void Put(int id, [FromBody]Quote quote)
        {
            _quotes[id] = quote;
        }

        public void Delete(int id)
        {
            _quotes.Remove(_quotes.SingleOrDefault(x => x.Id == id));
        }
    }
}
