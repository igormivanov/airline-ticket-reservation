using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Models.Dtos.LoyaltyProgram;
using AirlineTicketReservation.API.Models.Dtos.Passenger;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Mappers {
    public static class PassengerMapper {

        public static PassengerDTO toPassengerDTO(this PassengerEntity passenger) {

            return new PassengerDTO(
                passenger.Id,
                passenger.FullName,
                passenger.Email,
                passenger.Phone,
                passenger.IdentityDocument,
                passenger.LoyaltyProgram?.toLoyaltyProgramDTO(),
                passenger.Roles
                );
        }
    }
}
