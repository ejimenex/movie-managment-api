using Microsoft.Extensions.DependencyInjection;

namespace MovieApi.BussinesLogic.DependencyInjection;
public static class ServicesConfiguration
{
    public static void ConfigureService(this IServiceCollection service)
    {
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        service.AddScoped<IMovieService, MovieService>();
        service.AddScoped<IMovieReviewService, MovieReviewService>();
        service.AddScoped<IPaginator<MovieDto, MovieFilter>, MovieService>();
    }
}
