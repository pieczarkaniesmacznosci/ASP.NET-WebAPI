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
        public Quote Get(int id)
        {
            return this.quotesDbContext.Quotes.Find(id); 
        }
        // POST: api/Quotes
        public void Post([FromBody]Quote quote)
        {
            this.quotesDbContext.Quotes.Add(quote);
            this.quotesDbContext.SaveChanges();
        }
        
        // PUT: api/Quotes/5
        public void Put(int id, [FromBody]Quote quote)
        {
            var entity = this.quotesDbContext.Quotes.SingleOrDefault(i => i.Id == id);
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            entity.Title = quote.Title;
            this.quotesDbContext.SaveChanges();
        }

        // DELETE: api/Quotes/5
        public void Delete(int id)
        {
            var quote = this.quotesDbContext.Quotes.Find(id);
            this.quotesDbContext.Quotes.Remove(quote);
            this.quotesDbContext.SaveChanges();
        }
    }
}
