using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.API.Services;
using AirlineTicketReservation.API.Services.Auth;
using AirlineTicketReservation.API.Services.Security;

namespace AirlineTicketReservation.API.Extensions {
    public static class ServiceExtensions {

        public static void AddRepositoryServices(this IServiceCollection services) {
            services.AddScoped<IPassengerRepository, PassengerRepository>();
        }

        public static void AddUseCaseServices(this IServiceCollection services) {
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
