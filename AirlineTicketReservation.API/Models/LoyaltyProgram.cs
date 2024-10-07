using AirlineTicketReservation.Enums;
using System.ComponentModel.DataAnnotations;

namespace AirlineTicketReservation.Models {
    public class LoyaltyProgram {

        [Key]
        public Guid LoyaltyNumber { get; init; }
        public int PointsBalance { get; set; }
        public DateTime CreationDate { get; init; }
        public LoyaltyLevel Level { get; set; } = LoyaltyLevel.Bronze;
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public LoyaltyProgram() { }
        public LoyaltyProgram(Passenger _passenger) {
            LoyaltyNumber = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Passenger = _passenger;
        } 

    }
}
