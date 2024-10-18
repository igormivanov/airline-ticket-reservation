using AirlineTicketReservation.API.Dtos.Passenger;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services {
    public interface IPassengerService {

        Task<ResponseModel<Passenger>> CreatePassenger(PassengerRequestDTO passengerRequestDTO);
        Task<ResponseModel<PassengerDTO>> GetAllPassengers();
    }
}
