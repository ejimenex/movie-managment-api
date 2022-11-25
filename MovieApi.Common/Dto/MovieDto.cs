namespace MovieApi.Common.Dto
{
    public class MovieDto : BaseDto
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
        public double? RankingAvg { get; set; }
        public string Duration { get; set; }
        public IEnumerable<MovieReviewDto> Reviews { get; set; }
    }
}
