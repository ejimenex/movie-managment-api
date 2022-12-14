namespace MovieApi.Domain.Model.Base
{
    public class BaseModel : BaseId
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
