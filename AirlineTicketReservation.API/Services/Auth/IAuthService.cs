﻿using AirlineTicketReservation.API.Dtos.Auth;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services.Auth {
    public interface IAuthService {
        Task<ResponseModel<RegisterPassengerResponseDTO>> RegisterPassenger(RegisterPassengerRequestDTO registerPassengerRequestDTO);
        
    }
}