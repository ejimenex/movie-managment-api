using AutoMapper;
using FluentValidation.Results;
using MovieApi.Common.Constant;
using MovieApi.Common.Pagination;
using MovieApi.Common.Validation;

namespace MovieApi.BussinesLogic.Services
{
    public class MovieService : IMovieService, IPaginator<MovieDto, MovieFilter>
    {
        private readonly IBaseRepository<Movie> movieRepository;
        private readonly IMapper mapper;
        public MovieService(IBaseRepository<Movie> movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateMovie(MoviePostDto movie)
        {
            Validation(movie);
            var data = mapper.Map<Movie>(movie);
            return await movieRepository.Create(data);
        }

        public async Task DisableMovie(int id)
        {
            await this.movieRepository.Delete(id);
        }

        public async Task<MovieDto> GetMovieById(int id)
        {
            var movie = await this.movieRepository.GetOne(id);
            var dto = mapper.Map<MovieDto>(movie);
            return dto;
        }
        private void Validation(MoviePostDto dto)
        {
            MovieValidations validationRules = new MovieValidations();
            ValidationResult result = validationRules.Validate(dto);
            if (!result.IsValid)
            {
                var errors = string.Join(" | ", result.Errors);
                throw new FriendlyException(errors);
            }
        }
        public PagedData<MovieDto> GetPaged(MovieFilter filter)
        {
            if (filter.SortBy is null) filter.SortBy = "Id"; 
            System.Reflection.PropertyInfo prop = typeof(MovieDto).GetProperty(filter.SortBy);
            if (prop is null) throw new FriendlyException("This sort value field does not exist");
            var collection = mapper.ProjectTo<MovieDto>(movieRepository.FindAll());
            collection = filter.Name is not null ? collection = collection.Where(c => c.Name.Contains(filter.Name)) : collection;
            collection = filter.Year is not null ? collection = collection.Where(c => c.YearOfMovie == filter.Year.Value) : collection;
            if (!collection.Any())
            {
                return new PagedData<MovieDto>
                {
                    TotalCount = 0,
                    PageSize = 0,
                    CurrentPage = 0,
                    TotalPage = 0,
                    Data = collection
                };
            }
            var data = PagedList<MovieDto>.Create(collection.AsQueryable(), filter.PageNumber, filter.PageSize);
            var pagination = new PagedData<MovieDto>
            {
                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                CurrentPage = data.CurrentPage,
                TotalPage = data.TotalPages,
                Data = data.OrderBy(c => prop.GetValue(c, null))
            };
            return pagination;
        }
    }
}
