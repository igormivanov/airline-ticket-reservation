using AirlineTicketReservation.API.Exceptions;
using AirlineTicketReservation.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
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

            context.Response.StatusCode = exception is HttpException httpEx ? httpEx.StatusCode : StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails {
                Status = (int)context.Response.StatusCode,
                Title = "An error ocurrend",
                Detail = exception.Message,
                Instance = context.Request.Path,
                
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(problem, options);
            return context.Response.WriteAsync(json);
        }
    }
}
