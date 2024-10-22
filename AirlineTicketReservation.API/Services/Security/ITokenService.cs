using System.Security.Claims;
using AirlineTicketReservation.API.Models.Enums;
using AirlineTicketReservation.Models;

namespace AirlineTicketReservation.API.Services.Security {
    public interface ITokenService {
        public string GetAccessToken(string name, List<Role> roles);
        public DateTime GetExpirationTimeFromToken(string token);
    }
}
