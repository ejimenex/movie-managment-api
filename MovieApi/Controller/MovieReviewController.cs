using Microsoft.AspNetCore.Mvc;
using MovieApi.BussinesLogic.Abstract;
using MovieApi.Common.Dto;

namespace MovieApi.Controller
{
    [Route("api/[controller]")]
    public class MovieReviewController : ControllerBase
    {

        private readonly IMovieReviewService movieService;
        public MovieReviewController(IMovieReviewService movieService)
        {
            this.movieService = movieService;
        }
        [HttpPost]
        public IActionResult Save([FromBody] MovieReviewPostDto dto) => Ok(this.movieService.CreateReviewMovie(dto));
        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id) => Ok(this.movieService.GetReviewByMovie(id));


    }

}
