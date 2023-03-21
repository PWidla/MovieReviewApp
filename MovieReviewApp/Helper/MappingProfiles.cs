using AutoMapper;
using MovieReviewApp.Dto;
using MovieReviewApp.Models;

namespace MovieReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Director, DirectorDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Reviewer, ReviewerDto>().ReverseMap();
        }
    }
}
