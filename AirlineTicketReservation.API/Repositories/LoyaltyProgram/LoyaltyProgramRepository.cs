using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Repositories.LoyaltyProgramRepository;
using AirlineTicketReservation.Data;
using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketReservation.API.Repositories.LoyaltyProgram {
    public class LoyaltyProgramRepository : ILoyaltyProgramRepository {

        private readonly AppDataContext _context;

        public LoyaltyProgramRepository(AppDataContext context) {
            _context = context;
        }
        public async Task create(LoyaltyProgramEntity loyaltyProgram) {
            _context.Add(loyaltyProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<LoyaltyProgramEntity> findByPassengerId(Guid id) {
            var loyaltyProgram = await _context.LoyaltyProgram.FirstOrDefaultAsync(l => l.Id == id);
            return loyaltyProgram;
        }

        public async Task<List<LoyaltyProgramEntity>> GetAll() {
            var loyaltyPrograms = await _context.LoyaltyProgram.ToListAsync();
            return loyaltyPrograms;
        }
    }
}
