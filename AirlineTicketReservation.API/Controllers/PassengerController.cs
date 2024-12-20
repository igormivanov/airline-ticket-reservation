﻿using AirlineTicketReservation.API.Extensions;
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
        private readonly IHttpContextAccessor _contextAccessor;
        public PassengerController(IPassengerService passengerService, IHttpContextAccessor httpContextAccessor) { 
            _passengerService = passengerService;
            _contextAccessor = httpContextAccessor;
        }

        [HttpPost("passengers")]
        public async Task<ActionResult<ResponseModel<PassengerEntity>>> Create([FromBody] PassengerRequestDTO passengerRequestDTO) {

            var validator = new PassengerRequestDTOValidation();
            var result = validator.Validate(passengerRequestDTO);

            if (!result.IsValid) {
                var validationProblemDetails = result.ToValidationProblemDetails(_contextAccessor);

                return BadRequest(validationProblemDetails);
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
