namespace MovieApi.Domain.Model
{
    public class Movie: BaseId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlMovie { get; set; }
        public int YearOfMovie { get; set; }
        public int MinimalAge { get; set; }
        public string Quality { get; set; }
        public int TotalHourDuration { get; set; }
        public string ImageUrl { get; set; }
        public int TotalMinuteDuration { get; set; }
        public ICollection<MovieReview> Reviews { get; set; }
    }
}
