using AirlineTicketReservation.API.Models.Dtos.LoyaltyProgram;
using AirlineTicketReservation.API.Models.Enums;
using AirlineTicketReservation.Models;
using System.Text.Json.Serialization;

namespace AirlineTicketReservation.API.Models.Dtos.Passenger {
    public class PassengerDTO {

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentifyDocument { get; set; }
        public LoyaltyProgramDTO? LoyaltyProgram { get; set; }

        public List<Role> Roles { get; set; }

        public PassengerDTO(Guid id, string fullName, string email, string phone, string identifyDocument, LoyaltyProgramDTO? loyaltyProgram, List<Role> roles) {
            Id = id;
            FullName = fullName;
            Email = email;
            Phone = phone;
            IdentifyDocument = identifyDocument;
            LoyaltyProgram = loyaltyProgram;
            Roles = roles;
        }
    }
}
