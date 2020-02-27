namespace ExpressoAPI.Controllers
{
    using System.Net;
    using System.Web.Http;
    using ExpressoAPI.Data;
    using ExpressoAPI.Models;

    public class ReservationsController : ApiController
    {
        EspressoDbContext espressoDbContext = new EspressoDbContext();

        public IHttpActionResult Post(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            this.espressoDbContext.Reservations.Add(reservation);
            this.espressoDbContext.SaveChangesAsync();
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
