using AirlineTicketReservation.API.Models.Enums;

namespace AirlineTicketReservation.API.Models.Dtos.Auth {
    public class ResponseDTO {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireAt { get; set; }
        public List<string> Roles { get; set; } = new();

        public ResponseDTO(string userName, string token, DateTime expireAt, List<Role> roles) {
            UserName = userName;
            Token = token;
            ExpireAt = expireAt;
            Roles = roles.Select(role => role.ToString()).ToList();
        }
    }
}
