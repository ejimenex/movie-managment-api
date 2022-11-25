using AutoMapper;

namespace MovieApi.BussinesLogic.Profiles
{
    internal class MovieReviewPostProfile : Profile
    {
        public MovieReviewPostProfile()
        {
            CreateMap<MovieReview, MovieReviewPostDto>().ReverseMap();
        }
    }
}
