using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Models.Dtos;
using AirlineTicketReservation.API.Repositories.LoyaltyProgramRepository;

namespace AirlineTicketReservation.API.Services.LoyaltyProgram {
    public interface ILoyaltyProgramService {
        Task<ResponseModel<LoyaltyProgramEntity>> createLoyaltyProgram(LoyaltyProgramEntity loyaltyProgram);
    }
}
