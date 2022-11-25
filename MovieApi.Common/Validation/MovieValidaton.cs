using FluentValidation;
using MovieApi.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Common.Validation
{
    public class MovieValidations : AbstractValidator<MoviePostDto>
    {
        public MovieValidations()
        {
            RuleFor(x => x.TotalHourDuration).NotEmpty().WithMessage("Field Hour it is required");
            RuleFor(x => x.TotalMinuteDuration).NotEmpty().NotEqual(0).WithMessage("Field minute it is required");
            RuleFor(x => x.TotalHourDuration).LessThan(5).WithMessage("Field hour can not be major to 5");
            RuleFor(x => x.TotalMinuteDuration).LessThan(59).WithMessage("Field mibute can not be major to 59");
            RuleFor(x => x.Quality).NotEmpty().WithMessage("Quality it is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name it is required");
                  RuleFor(x => x.Description).NotEmpty().WithMessage("Description it is required");
            RuleFor(x => x.YearOfMovie).NotEqual(0).WithMessage("Year it is required");
            RuleFor(x => x.UrlMovie).NotEmpty().WithMessage("Url of movie it is required");
            RuleFor(x => x.YearOfMovie).LessThan(2022).WithMessage("Year it is incorrect");
        }
    }
}
