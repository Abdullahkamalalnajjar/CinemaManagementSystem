using CinemaManagementSystem.Service.Abstract;
using CinemaManagementSystem.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaManagementSystem.Service
{
    public static class ModuelServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITheaterService, TheaterService>();
            services.AddScoped<IShowtimeService, ShowtimeService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
