namespace MovieApi.DataAccess.Repository.Repositories
{
    public class MovieRepository:BaseRepository<Movie>
    {
        public MovieRepository(MovieApiDataContext context):base(context)
        {

        }
        public override IQueryable<Movie> FindAll()=> base.FindAll().Include(c=> c.Reviews);
            
        
        public override async Task<Movie> GetOne(int Id)
        {
            return await context.Movie.Include(c=> c.Reviews).AsNoTracking().FirstOrDefaultAsync(c=> c.Id==Id);
        }
    }
}
