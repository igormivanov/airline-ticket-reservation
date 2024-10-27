using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketReservation.API.Extensions {
    public static class ValidationProblemDetailsExtensions {

        public static ValidationProblemDetails ToValidationProblemDetails(this ValidationResult validationResult, IHttpContextAccessor httpContextAccessor) {

            var traceId = httpContextAccessor.HttpContext?.TraceIdentifier;

            var validationProblemDetails = new ValidationProblemDetails {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation failed",
                Detail = "One or more validation errors occurred.",
                Instance = traceId
            };

            var validationResults = new Dictionary<string, string[]>();

            foreach (var error in validationResult.Errors) {
                if (!validationResults.ContainsKey(error.PropertyName)) {
                    validationResults[error.PropertyName] = new string[] { error.ErrorMessage };
                }
                validationResults[error.PropertyName].Append(error.ErrorMessage);
            }

            validationProblemDetails.Errors = validationResults;

            return validationProblemDetails;
        }
    }
}
