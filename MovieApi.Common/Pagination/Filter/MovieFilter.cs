namespace MovieApi.Common.Pagination.Filter
{
    public class MovieFilter : BaseFilter
    {
        public string Name { get; set; }
        public int? Year { get; set; }
        public string SortBy { get; set; }
    }
}
