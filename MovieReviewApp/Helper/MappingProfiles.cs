﻿using AutoMapper;
using MovieReviewApp.Dto;
using MovieReviewApp.Models;

namespace MovieReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Country, CountryDto>();
            CreateMap<Director, DirectorDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
