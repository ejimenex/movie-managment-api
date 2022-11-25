using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MovieApi.Common.Constant;
using MovieApi.Common.Validation;

namespace MovieApi.BussinesLogic.Services
{
    public class MovieReviewService : IMovieReviewService
    {
        private readonly IBaseRepository<MovieReview> movieReviewRepository;
        private readonly IBaseRepository<Movie> movieRepository;
        private readonly IMapper mapper;
        public MovieReviewService(IBaseRepository<MovieReview> movieReviewRepository, IMapper mapper, IBaseRepository<Movie> movieRepository)
        {
            this.movieReviewRepository = movieReviewRepository;
            this.mapper = mapper;
            this.movieRepository = movieRepository;
        }

        public async Task<int> CreateReviewMovie(MovieReviewPostDto movie)
        {
            ValidationGet(movie.MovieId);
            Validation(movie);
            var data = mapper.Map<MovieReview>(movie);
            return await movieReviewRepository.Create(data);
        }

        public IEnumerable<MovieReviewDto> GetReviewByMovie(int id)
        {
            ValidationGet(id);
            var result = movieReviewRepository.FindByCondition(c => c.MovieId == id).AsQueryable().AsNoTracking();
            var dto = mapper.ProjectTo<MovieReviewDto>(result);
            return dto.AsEnumerable();
        }
        private void ValidationGet(int Id)
        {
            if (!movieRepository.Exist(c => c.Id == Id))
                throw new FriendlyException("This movie does not exist");
        }
        private void Validation(MovieReviewPostDto dto)
        {
            MovieReviewValidaton validationRules = new MovieReviewValidaton();
            ValidationResult result = validationRules.Validate(dto);
            if (!result.IsValid)
            {
                var errors = string.Join(" | ", result.Errors);
                throw new FriendlyException(errors);
            }
        }

    }
}
