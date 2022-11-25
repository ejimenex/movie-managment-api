namespace MovieApi.BussinesLogic.Abstract
{
    public interface IMovieService
    {
        Task<int> CreateMovie(MoviePostDto movie);
        Task<MovieDto> GetMovieById(int id);
        Task DisableMovie(int id);


    }
}
