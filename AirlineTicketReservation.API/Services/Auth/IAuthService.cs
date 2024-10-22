using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Auth;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services.Auth {
    public interface IAuthService {
        Task<ResponseModel<ResponseDTO>> RegisterPassenger(RegisterPassengerRequestDTO registerPassengerRequestDTO);
        Task<ResponseModel<ResponseDTO>> LoginPassenger(LoginPassengerRequestDTO loginPassengerRequestDTO);

        
    }
}
