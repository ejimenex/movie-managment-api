using AutoMapper;

namespace MovieApi.BussinesLogic.Profiles
{
    internal class MovieReviewProfile : Profile
    {
        public MovieReviewProfile()
        {
            CreateMap<MovieReview, MovieReviewDto>().ReverseMap();
        }
    }
}
