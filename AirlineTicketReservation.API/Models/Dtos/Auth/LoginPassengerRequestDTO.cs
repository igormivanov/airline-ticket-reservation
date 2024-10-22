namespace AirlineTicketReservation.API.Models.Dtos.Auth {
    public record LoginPassengerRequestDTO(
        string Password,
        string Email
        ) {
    }
}
