using FluentValidation;

namespace AirlineTicketReservation.API.Models.Dtos.Auth {
    public class RegisterPassengerRequestDTOValidation : AbstractValidator<RegisterPassengerRequestDTO> {

        public RegisterPassengerRequestDTOValidation() {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("The name is required.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("The email is required.")
                .EmailAddress().WithMessage("The email format is not valid.");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("The Phone is required.")
                .MinimumLength(10).WithMessage("The phone number must be at least 10 characters long.")
                .MaximumLength(15);

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("The password is required.")
                .MinimumLength(8).WithMessage("The password must be at least 8 characters long.");

            RuleFor(p => p.IdentityDocument)
                .NotEmpty().WithMessage("The identity document is required.");
        }
    }
}
