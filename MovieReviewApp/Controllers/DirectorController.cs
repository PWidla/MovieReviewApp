using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Data;

namespace MovieReviewApp.Controllers
{
    public class DirectorController : Controller
    {
        private readonly DataContext _context;
        private readonly Mapper _mapper;

        public DirectorController(DataContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
