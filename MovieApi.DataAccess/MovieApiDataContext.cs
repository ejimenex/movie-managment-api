using MovieApi.DataAccess.Configuration;

namespace MovieApi.DataAccess
{
    public class MovieApiDataContext : DbContext
    {
        public MovieApiDataContext(DbContextOptions<MovieApiDataContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieReview> MovieReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureEntities();
            base.OnModelCreating(modelBuilder);
        }
    }
}

