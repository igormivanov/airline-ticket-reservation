using Newtonsoft.Json;

namespace AirlineTicketReservation.API.Models {
    public class ErrorResponseModel {

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; } = string.Empty;

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; } = string.Empty;

        [JsonProperty("details", NullValueHandling = NullValueHandling.Include)]
        public List<string> Details { get; set; } = new List<string>();

        public ErrorResponseModel() { }

        public ErrorResponseModel(string errorCode, string errorMessage, IEnumerable<string> details = null) {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            if (details != null) {
                Details.AddRange(details);
            }
        }
    }
}
