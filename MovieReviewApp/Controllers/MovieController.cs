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

        [HttpGet("{movieId}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400)]
        public IActionResult GetMovie(int movieId)
        {
            if(!_movieRepository.MovieExists(movieId))
                return NotFound();

            var movie = _movieRepository.GetMovie(movieId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(movie);
        }

        [HttpGet("{movieId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetMovieRating(int movieId)
        {
            if(!_movieRepository.MovieExists(movieId))
                return NotFound();

            var rating = _movieRepository.GetMovieRating(movieId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }


    }
}
