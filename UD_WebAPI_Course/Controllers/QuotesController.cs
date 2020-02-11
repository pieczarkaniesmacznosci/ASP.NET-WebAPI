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
        public IHttpActionResult Get()
        {
            var quote = this.quotesDbContext.Quotes;
            return this.Ok(quote);
        }
        
        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var entity = this.quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return this.BadRequest("No record found againt that id...");
            }

            return this.Ok(entity);
        }
        // POST: api/Quotes
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            this.quotesDbContext.Quotes.Add(quote);
            this.quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        
        // PUT: api/Quotes/5
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            var entity = this.quotesDbContext.Quotes.SingleOrDefault(i => i.Id == id);
            if (entity == null)
            {
                return this.BadRequest("No record found againt that id...");
            }
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            entity.Title = quote.Title;
            this.quotesDbContext.SaveChanges();
            return Ok("Record updated sucessfully...");
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var entity = this.quotesDbContext.Quotes.Find(id);

            if (entity == null)
            {
                return this.BadRequest("No record found againt that id...");
            }
            this.quotesDbContext.Quotes.Remove(entity);
            this.quotesDbContext.SaveChanges();
            return this.Ok("Quote dleted");
        }
    }
}
