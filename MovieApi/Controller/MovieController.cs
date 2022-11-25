using Microsoft.AspNetCore.Mvc;
using MovieApi.BussinesLogic.Abstract;
using MovieApi.Common.Dto;
using MovieApi.Common.Pagination.Filter;

namespace MovieApi.Controller
{
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly IPaginator<MovieDto, MovieFilter> pageService;
        private readonly IMovieService movieService;
        public MovieController(IMovieService movieService, IPaginator<MovieDto, MovieFilter> pageService)
        {
            this.movieService = movieService; 
            this.pageService = pageService; 
        }
        [HttpGet]
        public IActionResult GetPaged([FromQuery] MovieFilter filter)=>Ok( this.pageService.GetPaged(filter));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id) => Ok(await this.movieService.GetMovieById(id));

        [Route("{id}")]
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound("Id can not be zero");
            await movieService.DisableMovie(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MoviePostDto dto)
        {
            return Ok(await movieService.CreateMovie(dto));

        }
    }
    
}
