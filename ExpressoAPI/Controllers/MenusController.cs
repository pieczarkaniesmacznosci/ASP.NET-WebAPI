using System.Web.Http;

namespace ExpressoAPI.Controllers
{
    using System.Linq;

    using ExpressoAPI.Data;

    public class MenusController : ApiController
    {
        public MenusController()
        {
            this.EspressoDbContext = new EspressoDbContext();
        }

        public EspressoDbContext EspressoDbContext { get; private set; }

        [HttpGet]
        public IHttpActionResult GetMenus()
        {
            var menus = this.EspressoDbContext.Menus.Include("SubMenus");
            // Include to have SubMenus in our menu results. This way is EAGER LOADING
            return this.Ok(menus);
        }

        [HttpGet]
        [Route("api/Menus/{id}")]
        public IHttpActionResult GetMenu(int id)
        {
            var menu = this.EspressoDbContext.Menus.Include("SubMenus").FirstOrDefault(m => m.MenuId == id);

            if (menu == null)
            {
                this.BadRequest("Not found menu against that id");
            }

            return this.Ok(menu);
        }
    }
}
