﻿using AutoMapper;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CountryExist(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public Country GetCountryByDirector(int directorId)
        {
            return _context.Directors.Where(d => d.Id == directorId).Select(c => c.Country).FirstOrDefault();
            //var directors = _context.Directors.Where(d => d.Id == directorId);
            //return (Country)_context.Countries.Where(d => d.Directors == director);
        }

        public ICollection<Director> GetDirectorsFromACountry(int countryId)
        {
            return _context.Directors.Where(d => d.Id == countryId).ToList();
        }
    }
}
