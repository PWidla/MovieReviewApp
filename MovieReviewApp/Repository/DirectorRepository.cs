using AutoMapper;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;

namespace MovieReviewApp.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private DataContext _context;

        public DirectorRepository(DataContext context)
        {
            _context = context;
        }
        public bool DirectorExists(int id)
        {
            return _context.Directors.Any(d => d.Id == id);
        }

        public bool CreateDirector(Director director)
        {
            _context.Add(director);
            return Save();

        }

        public Director GetDirector(int id)
        {
            return _context.Directors.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Director> GetDirectors()
        {
            return _context.Directors.ToList();
        }

        public ICollection<Director> GetDirectorOfMovie(int movieId)
        {
            return _context.MovieDirectors.Where(m => m.MovieId == movieId).Select(d => d.Director).ToList();
        }

        public ICollection<Movie> GetMoviesByDirector(int directorId)
        {
            return _context.MovieDirectors.Where(d => d.DirectorId == directorId).Select(m => m.Movie).ToList();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
