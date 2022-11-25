using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain.Model.Base;
public class BaseId
    {
        [Key]
        public int Id { get; set; }
    }

