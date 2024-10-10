using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Repositories {
    public interface IPassengerRepository {

        Task Create(Passenger passenger);
        Task<List<Passenger>> GetAll();
        Task<Passenger> FindByEmail(string email);
    }
}
