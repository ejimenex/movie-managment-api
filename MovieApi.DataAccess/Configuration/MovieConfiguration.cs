using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieApi.DataAccess.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasMany(c => c.Reviews).WithOne(ad => ad.Movie).HasForeignKey(c => c.MovieId);
        }
    
    }
}
