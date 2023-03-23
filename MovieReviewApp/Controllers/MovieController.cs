using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Dto;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;
using MovieReviewApp.Repository;

namespace MovieReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository,
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        public IActionResult GetMovies() 
        {
            var movies = _mapper.Map<List<MovieDto>>(_movieRepository.GetMovies());

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

            var movie = _mapper.Map<MovieDto>(_movieRepository.GetMovie(movieId));

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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMovie([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] MovieDto movieCreate)
        {
            if (movieCreate == null)
                return BadRequest();

            var movie = _movieRepository.GetMovies()
                .Where(c => c.Title.Trim().ToUpper() == movieCreate.Title.Trim().ToUpper())
                .FirstOrDefault();

            if (movie != null)
            {
                ModelState.AddModelError("", "Movie already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieMap = _mapper.Map<Movie>(movieCreate);

            if (!_movieRepository.CreateMovie(ownerId, catId, movieMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{movieId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMovie(int movieId, 
            [FromQuery] int directorId, 
            [FromQuery] int catId, 
            [FromBody] MovieDto updatedMovie)
        {
            if (updatedMovie == null)
                return BadRequest();

            if (movieId != updatedMovie.Id)
                return BadRequest(ModelState);

            if (!_movieRepository.MovieExists(movieId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieMap = _mapper.Map<Movie>(updatedMovie);
            if (!_movieRepository.UpdateMovie(directorId, catId, movieMap))
            {
                ModelState.AddModelError("", "Something went wrong updating director");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMovie(int movieId)
        {
            if (!_movieRepository.MovieExists(movieId))
                return NotFound();

            var reviewsToDelete = _reviewRepository.GetReviewsOfAMovie(movieId);
            var movieToDelete = _movieRepository.GetMovie(movieId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
                StatusCode(500, ModelState);
            }

            if(!_movieRepository.DeleteMovie(movieToDelete))
            {
                ModelState.AddModelError("", "Something went wrong when deleting movie");
                StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
