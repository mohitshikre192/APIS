using Microsoft.EntityFrameworkCore;

namespace APIS.Models
{
    public class Context : DbContext
    {   
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Vehicle> Vehicles {get;set;}
        public DbSet<Route>  Routes {get;set;}
        public DbSet<Driver> Drivers {get;set;}

    }

}
