﻿namespace AirlineTicketReservation.API.Dtos.Auth {
    public class RegisterPassengerResponseDTO {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpireAt { get; set; }
        public List<string> Roles { get; set; } = new();

        // Construtor para facilitar a criação de instâncias
        public RegisterPassengerResponseDTO(string userName, string token, DateTime expireAt, List<string> roles) {
            UserName = userName;
            Token = token;
            ExpireAt = expireAt;
            Roles = roles;
        }
    }
}
