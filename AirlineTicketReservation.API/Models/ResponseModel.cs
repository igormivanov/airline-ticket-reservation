using Newtonsoft.Json;

namespace AirlineTicketReservation.API.Models {
    public class ResponseModel<T> {

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Include)]
        public List<string> Messages { get; set; } = new List<string>();

        [JsonProperty("results", NullValueHandling = NullValueHandling.Include)]
        public List<T> Results { get; set; } = new List<T>();
        public bool Status { get; set; } = true;

        public ResponseModel() {}

        public ResponseModel(IEnumerable<T> body) {
            Results.AddRange(body);
        }

        public ResponseModel(T body) : this() {
            Results.Add(body);
        }

        
    }
}
