using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Data;
using MovieReviewApp.Dto;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;
using MovieReviewApp.Repository;

namespace MovieReviewApp.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly Mapper _mapper;

        public DirectorController(IDirectorRepository directorRepository, Mapper mapper)
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
        [ProducesResponseType(200, Type = typeof(Director))]
        [ProducesResponseType(400)]
        public IActionResult GetMovieByDirector(int directorId) 
        {
            if(!_directorRepository.DirectorExists(directorId))
                return NotFound();

            var director = _mapper.Map<List<MovieDto>>(
                _directorRepository.GetMovieByDirector(directorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }

    }
}