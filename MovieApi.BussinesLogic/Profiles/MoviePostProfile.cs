using AutoMapper;

namespace MovieApi.BussinesLogic.Profiles
{
    public class MoviePostProfile:Profile
    {
        public MoviePostProfile()
        {
            CreateMap<Movie, MoviePostDto>().ReverseMap();
        }
    }

}
