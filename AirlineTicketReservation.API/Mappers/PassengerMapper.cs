using AirlineTicketReservation.API.Dtos.Passenger;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Mappers {
    public static class PassengerMapper {

        public static PassengerDTO toPassengerDTO(this Passenger passenger) {
            return new PassengerDTO(
                passenger.Id,
                passenger.FullName,
                passenger.Email,
                passenger.Phone,
                passenger.IdentityDocument,
                passenger.LoyaltyProgram,
                passenger.Roles.Select(role => role.ToString()).ToList()
                );
        }
    }
}
