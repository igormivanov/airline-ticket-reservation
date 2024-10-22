using AirlineTicketReservation.API.Data.Configurations;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketReservation.Data {
    public class AppDataContext : DbContext {

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<PassengerEntity> Passengers { get; set; }
        public DbSet<LoyaltyProgramEntity> LoyaltyProgram { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PassengerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LoyaltyProgramEntityConfiguration());
        }
    }
}
