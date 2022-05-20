using Microsoft.EntityFrameworkCore;
using SharedClassModels.Models;

namespace SharedClassModels.DBContext
{
    public class FlightServiceContext: DbContext
    {
        public FlightServiceContext(DbContextOptions<FlightServiceContext> options):base(options)
        {

        }
        public DbSet<Adminlogins> adminlogins { get; set; }

        public DbSet<AirlineRegister> airlineRegisters { get; set; }

        public DbSet<UserDetails> userDetails { get; set; }

        public DbSet<Flightdetails> flightdetails { get; set; }

        public DbSet<Bookingdetails> bookingdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AirlineDB;Integrated Security=True");// hard coded 
                                                                      // connection string
            }
        }
    }

}
