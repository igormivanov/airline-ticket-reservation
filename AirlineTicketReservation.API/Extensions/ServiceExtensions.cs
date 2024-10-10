using AirlineTicketReservation.API.Repositories;
using AirlineTicketReservation.API.Services;

namespace AirlineTicketReservation.API.Extensions {
    public static class ServiceExtensions {

        public static void AddRepositoryServices(this IServiceCollection services) {
            services.AddScoped<IPassengerRepository, PassengerRepository>();
        }

        public static void AddUseCaseServices(this IServiceCollection services) {
            services.AddScoped<IPassengerService, PassengerService>();
        }
    }
}
