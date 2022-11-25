using FluentValidation;
using MovieApi.Common.Dto;

namespace MovieApi.Common.Validation
{
    public class MovieReviewValidaton : AbstractValidator<MovieReviewPostDto>
    {
        public MovieReviewValidaton()
        {
            RuleFor(x => x.Commentary).NotEmpty().WithMessage("Field commentary it is required");
            RuleFor(x => x.MovieId).NotEmpty().NotEqual(0).WithMessage("Field movie it is required");
            RuleFor(x => x.Ranking).LessThanOrEqualTo(5).WithMessage("Field ranking could not be 6 or more");
            RuleFor(x => x.Ranking).NotEmpty().WithMessage("Ranking it is required");
        }
    }
}
