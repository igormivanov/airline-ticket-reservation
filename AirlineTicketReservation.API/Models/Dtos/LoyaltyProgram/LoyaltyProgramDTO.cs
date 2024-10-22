using AirlineTicketReservation.API.Models.Enums;

namespace AirlineTicketReservation.API.Models.Dtos.LoyaltyProgram {
    public record LoyaltyProgramDTO(
        Guid Id,
        int PointBalance,
        DateTime CreationDate,
        LoyaltyLevel Level
        ) {
    }
}
