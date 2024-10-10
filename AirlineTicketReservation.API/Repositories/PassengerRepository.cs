using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Data;
using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketReservation.API.Repositories {
    public class PassengerRepository : IPassengerRepository {

        private readonly AppDataContext _context;
        public PassengerRepository(AppDataContext context) {
            _context = context;
        }

        public async Task Create(Passenger passenger) {
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task<Passenger> FindByEmail(string email) {
            var passenger = await _context.Passengers.FirstOrDefaultAsync(passenger => passenger.Email == email);
            return passenger;
        }

        public async Task<List<Passenger>> GetAll() {
            var passangers = await _context.Passengers.ToListAsync();
            return passangers;
        }
    }
}
