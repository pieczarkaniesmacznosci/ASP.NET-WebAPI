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
        [HttpGet]
        public IHttpActionResult LoadQuotes(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                    quotes = this.quotesDbContext.Quotes.OrderByDescending(q => q.CreatedAt); //http://localhost:55826/api/quotes?sort=desc
                    break;
                case "asc":
                    quotes = this.quotesDbContext.Quotes.OrderBy(q => q.CreatedAt);
                    break;
                default:
                    quotes = this.quotesDbContext.Quotes;
                    break;

            }
            return this.Ok(quotes);
        }
        
        // GET: api/Quotes/5
        [HttpGet]
        public IHttpActionResult LoadQuote(int id)
        {
            var entity = this.quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return this.BadRequest("No record found againt that id...");
            }

            return this.Ok(entity);
        }

        [HttpGet]
        [Route("api/Quotes/PagingQuote/{pageNumber=}/{pageSize=}")]//http://localhost:55826/api/quotes/pagingQuote?pageNumber=...&pagesize=...

        public IHttpActionResult PagingQuote(int pageNumber, int pageSize)
        {
            var quotes = this.quotesDbContext.Quotes.OrderBy(q => q.Id);// method OrderBy must be called before method Skip!
            return Ok(quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("api/Quotes/SearchQuote/{type=}")]//http://localhost:55826/api/quotes/searchQuote?type=...
        public IHttpActionResult SearchQuote(string type)
        {
            var quotes = this.quotesDbContext.Quotes.Where(q => q.Type.StartsWith(type));
            return this.Ok(quotes);
        }

        [HttpGet]
        [Route("api/Quotes/Test/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST: api/Quotes
        [HttpPost]
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.quotesDbContext.Quotes.Add(quote);
            this.quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        
        // PUT: api/Quotes/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

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
        [HttpDelete]
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
