using AirlineTicketReservation.API.Models.Enums;
using AirlineTicketReservation.Models;
using System.ComponentModel.DataAnnotations;

namespace AirlineTicketReservation.API.Models {
    public class LoyaltyProgramEntity {
        public Guid Id { get; init; }
        public int PointsBalance { get; set; }
        public DateTime CreationDate { get; init; }
        public LoyaltyLevel Level { get; set; }
        public Guid PassengerId { get; set; }
        public PassengerEntity Passenger { get; set; }
        public LoyaltyProgramEntity() { }
        public LoyaltyProgramEntity(PassengerEntity _passenger) {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            Passenger = _passenger;
            Level = LoyaltyLevel.Bronze;
        }
    }
}
