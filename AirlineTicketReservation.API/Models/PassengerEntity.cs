using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.API.Models.Enums;

namespace AirlineTicketReservation.Models {
    public class PassengerEntity {

        public Guid Id {  get; init; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string IdentityDocument {  get; set; } = string.Empty;
        public LoyaltyProgramEntity? LoyaltyProgram { get; set; }
        public List<Role> Roles { get; set; }

        

    }
}
