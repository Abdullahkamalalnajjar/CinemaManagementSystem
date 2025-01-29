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

            return services;
        }
    }
}
