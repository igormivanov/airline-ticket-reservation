using AirlineTicketReservation.Models;
using BCrypt.Net;

namespace AirlineTicketReservation.API.Services.Security {
    public class PasswordService : IPasswordService {
        public Task<bool> ComparePassword(string password, string confirmPassword) {
            var isEqual = password.Trim().Equals(confirmPassword);
            return Task.FromResult(isEqual);
        }

        public Task<bool> VerifyPassword(string password, PassengerEntity passenger) {
            var validPassword = BCrypt.Net.BCrypt.Verify(password, passenger.Password);
            return Task.FromResult(validPassword);
        }

        public Task<string> EncryptPassword(string password) {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return Task.FromResult(passwordHash);
        }


    }
}
