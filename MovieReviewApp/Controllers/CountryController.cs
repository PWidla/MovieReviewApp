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
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(
                _countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExist(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(
                _countryRepository.GetCountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("director/{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        [ProducesResponseType(400)]
        public IActionResult GetDirectorsByCountry(int countryId)
        {
            var director = _mapper.Map<List<CountryDto>>(
                _countryRepository.GetDirectorsFromACountry(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }

    }
}
