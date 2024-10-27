using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Repositories.LoyaltyProgramRepository {
    public interface ILoyaltyProgramRepository {

        Task create(LoyaltyProgramEntity loyaltyProgram);
        Task<List<LoyaltyProgramEntity>> GetAll();

        Task<LoyaltyProgramEntity> findByPassengerId(Guid id);
    }
}
