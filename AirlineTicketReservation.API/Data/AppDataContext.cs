using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketReservation.Data {
    public class AppDataContext : DbContext {

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyProgram { get; set; }
    }
}
