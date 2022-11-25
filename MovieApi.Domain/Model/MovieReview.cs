global using MovieApi.Domain.Model.Base;

namespace MovieApi.Domain.Model;
public class MovieReview : BaseModel
{
    public int MovieId { get; set; }
    public int Ranking { get; set; }
    public string Commentary { get; set; }
    public virtual Movie Movie { get; set; }
}

