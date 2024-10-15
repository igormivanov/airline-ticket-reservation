using AirlineTicketReservation.API.Dtos.Auth;
using AirlineTicketReservation.API.Enums;
using AirlineTicketReservation.API.Exceptions;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.API.Services.Security;
using AirlineTicketReservation.Models;
using Azure;

namespace AirlineTicketReservation.API.Services.Auth {

    public class AuthService : IAuthService {

        private readonly IPassengerRepository _passengerRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthService(IPassengerRepository passengerRepository, IPasswordService passwordService, ITokenService tokenService) {
            _passengerRepository = passengerRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<ResponseModel<RegisterPassengerResponseDTO>> RegisterPassenger(RegisterPassengerRequestDTO registerPassengerRequestDTO) {
            var response = new ResponseModel<RegisterPassengerResponseDTO>();

            try {
                var passenger = await _passengerRepository.FindByEmail(registerPassengerRequestDTO.Email);

                if (passenger != null) {
                    throw new EmailAlreadyExistsException("Email already exists");
                }

                var roles = new List<string> {
                    Roles.USER.ToString()
                };

                var newPassenger = new Passenger() {
                    Id = Guid.NewGuid(),
                    Email = registerPassengerRequestDTO.Email,
                    FullName = registerPassengerRequestDTO.FullName,
                    Password = await _passwordService.EncryptPassword(registerPassengerRequestDTO.Password),
                    Phone = registerPassengerRequestDTO.Phone,
                    Roles = roles,
                    IdentityDocument = registerPassengerRequestDTO.IdentityDocument,
                };

                await _passengerRepository.Create(newPassenger);


                var token = _tokenService.GetAccessToken(newPassenger.FullName, newPassenger.Roles);
                var tokenExpirationTime = _tokenService.GetExpirationTimeFromToken(token);

                var responseDTO = new RegisterPassengerResponseDTO(newPassenger.FullName, token, tokenExpirationTime, newPassenger.Roles);

                response.Messages.Add("Passenger created successfully.");
                response.Results.Add(responseDTO);

                return response;

            } catch (Exception ex) {
                response.Status = false;

                if (ex is EmailAlreadyExistsException) {
                    response.Messages.Add(ex.Message);
                    return response;
                }

                response.Messages.Add("An unexpected error occurred: " + ex.Message);
                return response;
            }
        }
    }
}
