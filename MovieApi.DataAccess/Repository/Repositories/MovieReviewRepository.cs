namespace MovieApi.DataAccess.Repository.Repositories
{
    public class MovieReviewRepository : BaseRepository<MovieReview>

    {
        public MovieReviewRepository(MovieApiDataContext context) : base(context)
        {

        }
        public override Task<int> Create(MovieReview entity)
        {
            entity.Movie = null;
            return base.Create(entity);
        }
    }
}
