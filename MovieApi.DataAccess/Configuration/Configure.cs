namespace MovieApi.DataAccess.Configuration
{
    public static class Configure
    {
        public static void ConfigureEntities(this ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfiguration(new MovieConfiguration());
            modelBuider.ApplyConfiguration(new MovieReviewConfiguration());
        }
    }
}
