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
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        public IActionResult GetMovies()
        {
            var directors = _mapper.Map<List<DirectorDto>>(_directorRepository.GetDirectors());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(directors);
        }

        [HttpGet("{directorId}")]
        [ProducesResponseType(200, Type = typeof(Director))]
        [ProducesResponseType(400)]
        public IActionResult GetDirector(int directorId)
        {
            if (!_directorRepository.DirectorExists(directorId))
                return NotFound();

            var director = _mapper.Map<DirectorDto>(_directorRepository.GetDirector(directorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }

        [HttpGet("{directorId}/movies")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(400)]
        public IActionResult GetMoviesByDirector(int directorId) 
        {
            if(!_directorRepository.DirectorExists(directorId))
                return NotFound();

            var director = _mapper.Map<List<MovieDto>>(
                _directorRepository.GetMoviesByDirector(directorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDirector([FromBody] DirectorDto directorCreate)
        {
            if (directorCreate == null)
                return BadRequest();

            var director = _directorRepository.GetDirectors()
                .Where(c => c.LastName.Trim().ToUpper() == directorCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (director != null)
            {
                ModelState.AddModelError("", "Director already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var directorMap = _mapper.Map<Director>(directorCreate);

            if (!_directorRepository.CreateDirector(directorMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}