using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Repositories {
    public interface IPassengerRepository {

        Task Create(PassengerEntity passenger);
        Task<List<PassengerEntity>> GetAll();
        Task<PassengerEntity> FindByEmail(string email);
    }
}
