using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.DataAccess.Repository.Abstract;
using MovieApi.DataAccess.Repository.Repositories;

namespace MovieApi.DataAccess.DependencyInjection
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieApiDataContext>(m =>
            {
                m.UseSqlServer(configuration.GetConnectionString("MovieConnectionString"));
            });
            services.AddScoped<IBaseRepository<Movie>, MovieRepository>();
            services.AddScoped<IBaseRepository<MovieReview>, MovieReviewRepository>();
        }
    }
}
