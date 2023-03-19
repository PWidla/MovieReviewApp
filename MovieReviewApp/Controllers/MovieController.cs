using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        public IActionResult GetMovies() 
        {
            var movies = _movieRepository.GetMovies();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movies);
        }
    }
}
