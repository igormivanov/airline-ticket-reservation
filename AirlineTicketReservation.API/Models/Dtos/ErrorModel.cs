namespace AirlineTicketReservation.API.Models.Dtos {
    public class ErrorModel {

        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }

        public ErrorModel(string statusCode, string message, string details) {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
    }
}
