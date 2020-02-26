namespace QuotesWebApi.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using QuotesWebApi.Models;

    using WebApi.OutputCache.V2;

    [Authorize] //Protects API from any external access 
    public class QuotesController : ApiController
    {
        ApplicationDbContext quotesDbContext = new ApplicationDbContext();
        // GET: api/Quotes
        [AllowAnonymous] // GIves access to any request 
        [HttpGet]
        [CacheOutput(ClientTimeSpan = 60,ServerTimeSpan = 60)] 
        //Client side caching - the time that client browser cache will store data for. If server is connected request will forward to the server anyway
        //Server side caching - only one request to the server in the perticular time 
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

        [HttpGet]
        [Route("api/Quotes/MyQuotes")]
        public IHttpActionResult MyQuotes() // method to show only quotes of a specific user
        {
            string userId = User.Identity.GetUserId();
            var quotes = this.quotesDbContext.Quotes.Where(q=>q.UserId == userId).ToList();
            return Ok(quotes);
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
            string userId = User.Identity.GetUserId(); // gets user identity and includes it in the quotes table
            quote.UserId = userId;

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.quotesDbContext.Quotes.Add(quote);
            this.quotesDbContext.SaveChanges();
            return this.StatusCode(HttpStatusCode.Created);
        }
        
        // PUT: api/Quotes/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var entity = this.quotesDbContext.Quotes.SingleOrDefault(i => i.Id == id);
            if (entity == null)
            {
                return this.BadRequest("No record found against that id...");
            }
            
            string userId = User.Identity.GetUserId();

            if (userId != entity.UserId)
            {
                return this.BadRequest("You do not have rights to update this record");
            }

            entity.Author = quote.Author;
            entity.Description = quote.Description;
            entity.Title = quote.Title;
            this.quotesDbContext.SaveChanges();
            return this.Ok("Record updated sucessfully...");
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
            
            string userId = User.Identity.GetUserId();

            if (userId != entity.UserId)
            {
                return this.BadRequest("You do not have rights to update this record");
            }

            this.quotesDbContext.Quotes.Remove(entity);
            this.quotesDbContext.SaveChanges();
            return this.Ok("Quote dleted");
        }
    }
}
