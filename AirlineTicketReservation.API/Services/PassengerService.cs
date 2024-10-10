using AirlineTicketReservation.API.Dtos.Passenger;
using AirlineTicketReservation.API.Exceptions;
using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services {
    public class PassengerService : IPassengerService {

        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository) {
            _passengerRepository = passengerRepository;
        }
        public async Task<ResponseModel<Passenger>> CreatePassenger(PassengerRequestDTO passengerRequestDTO) {
            var response = new ResponseModel<Passenger>();

            var passenger = await _passengerRepository.FindByEmail(passengerRequestDTO.Email);

            if (passenger == null) {
                throw new EmailAlreadyExistsException("Email already exists.");
            }

            var newPassenger = new Passenger() {
                Id = Guid.NewGuid(),
                Email = passengerRequestDTO.Email,
                FullName = passengerRequestDTO.FullName,
                IdentityDocument = passengerRequestDTO.IdentityDocument,
                Password = passengerRequestDTO.Password,
                Phone = passengerRequestDTO.Phone,
            };

            try {
                await _passengerRepository.Create(newPassenger);
                var passengers = await _passengerRepository.GetAll();

                response.Results.AddRange(passengers);
                response.Messages.Add("Passenger created with sucess.");

                return response;

            } catch (Exception ex) {
                response.Status = false;
                response.Messages.Add(ex.Message);
                return response;
            }
        }

        public async Task<ResponseModel<Passenger>> GetAllPassengers() {
            var response = new ResponseModel<Passenger>();

            try {
                var passengers = await _passengerRepository.GetAll();

                response.Results.AddRange(passengers);

                if (passengers.Count == 0) {
                    response.Messages.Add("There are no registered passengers");
                    return response;
                }
                response.Messages.Add("All passengers were found");


                return response;
            } catch (Exception ex) {

                response.Status = false;
                response.Messages.Add(ex.Message);

                return response;
            }
        }
    }
}
