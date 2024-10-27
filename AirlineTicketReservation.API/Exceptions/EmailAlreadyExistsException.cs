namespace AirlineTicketReservation.API.Exceptions {
    public class EmailAlreadyExistsException : HttpException{

        public EmailAlreadyExistsException(string message) : base(message, StatusCodes.Status409Conflict) { }
    }
}
