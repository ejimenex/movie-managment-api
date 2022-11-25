using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.DataAccess.Repository.Repositories
{
    public class MovieReviewRepository:BaseRepository<MovieReview>
        
    {
        public MovieReviewRepository(MovieApiDataContext context):base(context)
        {

        }
        public override Task<int> Create(MovieReview entity)
        {
            entity.Movie = null;
            return base.Create(entity);
        }
    }
}
