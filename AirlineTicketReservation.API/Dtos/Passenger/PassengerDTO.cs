using AirlineTicketReservation.API.Enums;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Dtos.Passenger {
    public record PassengerDTO(
        Guid Id,
        string FullName,
        string Email,
        string Phone,
        string IdentifyDocument,
        LoyaltyProgram? LoyaltyProgram,
        List<String> Roles
        ) {
    }
}
