using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Passenger;
using AirlineTicketReservation.API.Services;
using AirlineTicketReservation.Models;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketReservation.API.Controllers {
    [Route("api/")]
    [ApiController]
    public class PassengerController : Controller {

        private readonly IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService) { 
            _passengerService = passengerService;
        }

        [HttpPost("passengers")]
        public async Task<ActionResult<ResponseModel<PassengerEntity>>> Create([FromBody] PassengerRequestDTO passengerRequestDTO) {

            var validator = new PassengerRequestDTOValidation();
            var result = validator.Validate(passengerRequestDTO);
            var errors = result.Errors.Select(e => e.ErrorMessage);

            if (!result.IsValid) {
                var badResponse = new ResponseModel<PassengerEntity>();
                badResponse.Status = false;
                badResponse.Messages.AddRange(errors);
                return BadRequest(badResponse);
            }

            var response = await _passengerService.CreatePassenger(passengerRequestDTO);
            if (response.Status) {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("passengers")]
        public async Task<ActionResult<ResponseModel<PassengerDTO>>> GetAll() {
            var response = await _passengerService.GetAllPassengers();
            if (response.Status) {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
