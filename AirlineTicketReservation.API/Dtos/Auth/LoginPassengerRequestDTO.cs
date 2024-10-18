namespace AirlineTicketReservation.API.Dtos.Auth {
    public record LoginPassengerRequestDTO(
        string Password,
        string Email
        ){
    }
}
