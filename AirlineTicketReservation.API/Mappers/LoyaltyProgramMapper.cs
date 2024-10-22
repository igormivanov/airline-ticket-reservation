using AirlineTicketReservation.API.Models.Dtos.LoyaltyProgram;
using AirlineTicketReservation.API.Models;

namespace AirlineTicketReservation.API.Mappers {
    public static class LoyaltyProgramMapper {

        public static LoyaltyProgramDTO toLoyaltyProgramDTO(this LoyaltyProgramEntity loyaltyProgram) {
            return new LoyaltyProgramDTO(
                    loyaltyProgram.Id,
                    loyaltyProgram.PointsBalance,
                    loyaltyProgram.CreationDate,
                    loyaltyProgram.Level
                );
        }
    }
}
