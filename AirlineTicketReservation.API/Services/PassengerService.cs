using AirlineTicketReservation.API.Exceptions;
using AirlineTicketReservation.API.Mappers;
using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Models.Dtos.Passenger;
using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.Models;
using System.Collections.Generic;

namespace AirlineTicketReservation.API.Services {
    public class PassengerService : IPassengerService {

        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository) {
            _passengerRepository = passengerRepository;
        }
        public async Task<ResponseModel<PassengerEntity>> CreatePassenger(PassengerRequestDTO passengerRequestDTO) {
            var response = new ResponseModel<PassengerEntity>();

            var passenger = await _passengerRepository.FindByEmail(passengerRequestDTO.Email);

            if (passenger != null) {
                throw new EmailAlreadyExistsException("Email already exists.");
            }

            var newPassenger = new PassengerEntity() {
                Id = Guid.NewGuid(),
                Email = passengerRequestDTO.Email,
                FullName = passengerRequestDTO.FullName,
                IdentityDocument = passengerRequestDTO.IdentityDocument,
                Password = passengerRequestDTO.Password,
                Phone = passengerRequestDTO.Phone,
            };

            await _passengerRepository.Create(newPassenger);
            var passengers = await _passengerRepository.GetAll();

            response.Results.AddRange(passengers);
            response.Messages.Add("Passenger created with sucess.");

            return response;
        }

        public async Task<ResponseModel<PassengerDTO>> GetAllPassengers() {
            var response = new ResponseModel<PassengerDTO>();

            var passengers = await _passengerRepository.GetAll();

            List<PassengerDTO> passengersDTO = passengers.Select(p => p.toPassengerDTO()).ToList();
                
            response.Results.AddRange(passengersDTO);

            if (passengers.Count == 0) {
                response.Messages.Add("There are no registered passengers");
                return response;
            }
            response.Messages.Add("All passengers were found");


            return response;
        }
    }
}
