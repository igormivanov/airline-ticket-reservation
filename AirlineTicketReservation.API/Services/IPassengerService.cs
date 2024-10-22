using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Passenger;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services {
    public interface IPassengerService {

        Task<ResponseModel<PassengerEntity>> CreatePassenger(PassengerRequestDTO passengerRequestDTO);
        Task<ResponseModel<PassengerDTO>> GetAllPassengers();
    }
}
