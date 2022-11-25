using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MovieApi.DataAccess.Configuration
{
    internal class MovieReviewConfiguration:IEntityTypeConfiguration<MovieReview>
    {
        public void Configure(EntityTypeBuilder<MovieReview> builder)
        {
            builder.HasOne(c => c.Movie).WithMany(ad => ad.Reviews).HasForeignKey(c => c.MovieId);
        }
    }
}
