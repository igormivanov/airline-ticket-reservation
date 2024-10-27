namespace AirlineTicketReservation.API.Exceptions {
    public class InvalidCredentialsException : HttpException {

        public InvalidCredentialsException(string message) : base(message, StatusCodes.Status409Conflict) { }
    }
}
