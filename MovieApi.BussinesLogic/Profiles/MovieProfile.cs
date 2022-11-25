using AutoMapper;

namespace MovieApi.BussinesLogic.Profiles
{
    internal class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(c => c.RankingAvg, o => o.MapFrom(s => Math.Round(s.Reviews.Average(c => c.Ranking), 1)))
                 .ForMember(c => c.Duration, o => o.MapFrom(s => $"{s.TotalHourDuration} Hours, {s.TotalMinuteDuration} Minutes"))
                .ReverseMap();

        }

    }
}
