using AirlineTicketReservation.API.Models;

namespace AirlineTicketReservation.API.Repositories {
    public interface LoyaltyRepository {

        Task create(LoyaltyProgramEntity l);
    }
}
