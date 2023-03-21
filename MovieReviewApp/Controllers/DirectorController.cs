using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReviewApp.Data;
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
    }
}
