using AirlineTicketReservation.API.Dtos.Auth;
using AirlineTicketReservation.API.Dtos.Passenger;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Services;
using AirlineTicketReservation.API.Services.Auth;
using AirlineTicketReservation.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketReservation.API.Controllers {
    [Route("api/auth/")]
    [ApiController]
    public class AuthController : Controller {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("passengers/register")]
        public async Task<ActionResult<ResponseModel<RegisterPassengerResponseDTO>>> RegisterPassenger([FromBody] RegisterPassengerRequestDTO registerPassengerRequestDTO) {

            var validator = new RegisterPassengerRequestDTOValidation();
            var result = validator.Validate(registerPassengerRequestDTO);
            var errors = result.Errors.Select(e => e.ErrorMessage);

            if (!result.IsValid) {
                var badResponse = new ResponseModel<RegisterPassengerResponseDTO>();
                badResponse.Status = false;
                badResponse.Messages.AddRange(errors);
                return BadRequest(badResponse);
            }

            var response = await _authService.RegisterPassenger(registerPassengerRequestDTO);
            if (response.Status) {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
