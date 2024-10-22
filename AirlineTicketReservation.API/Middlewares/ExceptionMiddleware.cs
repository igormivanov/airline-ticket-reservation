using AirlineTicketReservation.API.Models.Dtos;
using System.Net;
using System.Text.Json;

namespace AirlineTicketReservation.API.Middlewares {
    public class ExceptionMiddleware {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception ex) {

                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception) {

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // Cria o objeto de resposta com a mensagem de erro
            var response = new ErrorModel(context.Response.StatusCode.ToString(), "Internal server error", exception.Message);

            // Retorna a resposta em formato JSON

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);
            return context.Response.WriteAsync(json);
        }
    }
}
