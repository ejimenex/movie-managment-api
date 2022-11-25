using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Common.Dto
{
    public class MovieReviewDto: BaseDto
    {
        public int MovieId { get; set; }
        public int Ranking { get; set; }
        public string Commentary { get; set; }
    }
}
