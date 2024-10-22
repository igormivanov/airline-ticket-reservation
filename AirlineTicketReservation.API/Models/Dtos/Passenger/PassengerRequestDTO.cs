using System.ComponentModel.DataAnnotations;

namespace AirlineTicketReservation.API.Models.Dtos.Passenger {
    public class PassengerRequestDTO {

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string IdentityDocument { get; set; } = string.Empty;
    }
}
