using AirlineTicketReservation.API.Models;

namespace AirlineTicketReservation.API.Repositories.LoyaltyProgramRepository {
    public interface ILoyaltyProgramRepository {

        Task create(LoyaltyProgramEntity loyalty);
    }
}
