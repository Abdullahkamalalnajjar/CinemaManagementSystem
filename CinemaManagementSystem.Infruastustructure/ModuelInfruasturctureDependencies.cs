using CinemaManagementSystem.Infruasturcture.Abstracts;
using CinemaManagementSystem.Infruasturcture.Repositories;
using CinemaManagementSystem.infrustructure.InfrustructureBase;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagementSystem.Infrustructure
{
    public static class ModuelInfruasturctureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IShowtimeRepository, ShowtimeRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservedSeatRepository, ReservedSeatRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
