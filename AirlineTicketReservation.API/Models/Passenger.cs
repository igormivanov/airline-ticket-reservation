namespace AirlineTicketReservation.Models {
    public class Passenger {

        public Guid Id {  get; init; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string IdentityDocument {  get; set; } = string.Empty;
        public LoyaltyProgram? LoyaltyProgram { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        

    }
}
