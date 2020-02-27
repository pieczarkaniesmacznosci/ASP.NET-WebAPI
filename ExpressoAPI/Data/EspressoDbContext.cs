namespace ExpressoAPI.Data
{
    using System.Data.Entity;

    using ExpressoAPI.Models;

    public class EspressoDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}