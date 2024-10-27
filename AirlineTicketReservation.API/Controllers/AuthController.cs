using AirlineTicketReservation.API.Extensions;
using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Auth;
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
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthController(IAuthService authService, IHttpContextAccessor contextAccessor) {
            _authService = authService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("passengers/register")]
        public async Task<ActionResult<ResponseModel<ResponseDTO>>> RegisterPassenger([FromBody] RegisterPassengerRequestDTO registerPassengerRequestDTO) {

            var validator = new RegisterPassengerRequestDTOValidation();
            var result = validator.Validate(registerPassengerRequestDTO);

            if (!result.IsValid) {
                var validationProblemDetails = result.ToValidationProblemDetails(_contextAccessor);

                return BadRequest(validationProblemDetails);
            }

            var response = await _authService.RegisterPassenger(registerPassengerRequestDTO);
            if (response.Status) {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("passengers/login")]
        public async Task<ActionResult<ResponseModel<ResponseDTO>>> LoginPassenger(LoginPassengerRequestDTO loginPassengerRequestDTO) {
            
            var validator = new LoginPassengerRequestDTOValidation();
            var result = validator.Validate(loginPassengerRequestDTO);

            if (!result.IsValid) {
                var validationProblemDetails = result.ToValidationProblemDetails(_contextAccessor);

                return BadRequest(validationProblemDetails);
            }

            var response = await _authService.LoginPassenger(loginPassengerRequestDTO);
            if (response.Status) {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
