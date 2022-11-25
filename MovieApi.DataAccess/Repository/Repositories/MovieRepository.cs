namespace MovieApi.DataAccess.Repository.Repositories
{
    public class MovieRepository:BaseRepository<Movie>
    {
        public MovieRepository(MovieApiDataContext context):base(context)
        {

        }
        public override IQueryable<Movie> FindAll()
        {
            return base.FindAll().Include(c=> c.Reviews);
        }
    }
}
