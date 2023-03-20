using AutoMapper;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;
        private readonly Mapper _mapper;

        public DirectorRepository(DataContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool DirectorExists(int id)
        {
            return _context.Directors.Any(d => d.Id == id);
        }

        public Director GetDirector(int id)
        {
            return _context.Directors.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Director> GetDirectories()
        {
            return _context.Directors.ToList();
        }

        public ICollection<Director> GetDirectorOfMovie(int movieId)
        {
            return _context.MovieDirectors.Where(m => m.MovieId == movieId).Select(d => d.Director).ToList();
        }

        public ICollection<Movie> GetMovieByDirector(int directorId)
        {
            return _context.MovieDirectors.Where(d => d.DirectorId == directorId).Select(m => m.Movie).ToList();
        }
    }
}
