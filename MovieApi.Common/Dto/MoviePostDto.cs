using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Common.Dto
{
    public class MoviePostDto
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
    }
}
