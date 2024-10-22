using AirlineTicketReservation.API.Exceptions;
using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Auth;
using AirlineTicketReservation.API.Models.Enums;
using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.API.Services.Security;
using AirlineTicketReservation.Models;
using Azure;

namespace AirlineTicketReservation.API.Services.Auth {

    public class AuthService : IAuthService {

        private readonly IPassengerRepository _passengerRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IPassengerRepository passengerRepository, IPasswordService passwordService, ITokenService tokenService, ILogger<AuthService> logger) {
            _passengerRepository = passengerRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _logger = logger;   
        }

        public async Task<ResponseModel<ResponseDTO>> LoginPassenger(LoginPassengerRequestDTO loginPassengerRequestDTO) {
            var response = new ResponseModel<ResponseDTO>();

            try {
                var passenger = await _passengerRepository.FindByEmail(loginPassengerRequestDTO.Email);

                if (passenger == null) {
                    throw new InvalidCredentialsException("Invalid credentials.");
                }

                var isValidPassword = await _passwordService.VerifyPassword(loginPassengerRequestDTO.Password, passenger);

                if (!isValidPassword) {
                    throw new InvalidCredentialsException("Invalid credentials.");
                }

                var token = _tokenService.GetAccessToken(passenger.FullName, passenger.Roles);
                var expireAt = _tokenService.GetExpirationTimeFromToken(token);

                var responseDTO = new ResponseDTO(passenger.FullName, token, expireAt, passenger.Roles);

                response.Messages.Add("Login sucessfully");
                response.Results.Add(responseDTO);

                return response;

            } catch (Exception ex) {
                response.Status = false;

                if (ex is InvalidCredentialsException) {
                    response.Messages.Add(ex.Message);
                    return response;
                }

                response.Messages.Add("An unexpected error occurred: " + ex.Message);
                return response;
            }
        }

        public async Task<ResponseModel<ResponseDTO>> RegisterPassenger(RegisterPassengerRequestDTO registerPassengerRequestDTO) {
            var response = new ResponseModel<ResponseDTO>();

            try {
                var passenger = await _passengerRepository.FindByEmail(registerPassengerRequestDTO.Email);

                if (passenger != null) {
                    throw new EmailAlreadyExistsException("Email already exists");
                }

                var userRoles = new List<Role>() { Role.USER };

                var newPassenger = new PassengerEntity() {
                    Id = Guid.NewGuid(),
                    Email = registerPassengerRequestDTO.Email,
                    FullName = registerPassengerRequestDTO.FullName,
                    Password = await _passwordService.EncryptPassword(registerPassengerRequestDTO.Password),
                    Phone = registerPassengerRequestDTO.Phone,
                    Roles = userRoles,
                    IdentityDocument = registerPassengerRequestDTO.IdentityDocument,
                };

                await _passengerRepository.Create(newPassenger);


                var token = _tokenService.GetAccessToken(newPassenger.FullName, newPassenger.Roles);
                var tokenExpirationTime = _tokenService.GetExpirationTimeFromToken(token);

                var responseDTO = new ResponseDTO(newPassenger.FullName, token, tokenExpirationTime, newPassenger.Roles);

                response.Messages.Add("Passenger created successfully.");
                response.Results.Add(responseDTO);

                return response;

            } catch (EmailAlreadyExistsException ex) {
                response.Status = false;
                response.Messages.Add(ex.Message);
                return response;
                
            } catch (Exception ex) {
                _logger.LogInformation("An unexpected error occurred: }" + ex.Message);
                response.Messages.Add("An unexpected error occurred. Please try again later");
                return response;
            }
        }
    }
}
