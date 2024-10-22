using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services.Security {
    public interface IPasswordService {

        public Task<bool> ComparePassword(string password, string confirmPassword);
        public Task<bool> VerifyPassword(string password, PassengerEntity passenger);
        public Task<string> EncryptPassword(string password);
    }
}
