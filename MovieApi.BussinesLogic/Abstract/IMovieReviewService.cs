namespace MovieApi.BussinesLogic.Abstract
{
    public interface IMovieReviewService
    {
        Task<int> CreateReviewMovie(MovieReviewPostDto movie);
        IEnumerable<MovieReviewDto> GetReviewByMovie(int id);


    }
}
