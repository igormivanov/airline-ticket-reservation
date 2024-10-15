using System.Security.Claims;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services.Security {
    public interface ITokenService {
        public string GetAccessToken(string name, List<string> roles);
        public DateTime GetExpirationTimeFromToken(string token);
    }
}
