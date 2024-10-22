using FluentValidation;

namespace AirlineTicketReservation.API.Models.Dtos.Auth {
    public class LoginPassengerRequestDTOValidation : AbstractValidator<LoginPassengerRequestDTO> {

        public LoginPassengerRequestDTOValidation() {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The email is required.")
                .EmailAddress().WithMessage("The email format is not valid.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("The password is required.")
                .MinimumLength(8).WithMessage("The password must be at least 8 characters long.");
        }
    }
}
