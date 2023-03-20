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
            throw new NotImplementedException();
        }

        public Director GetDirector(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Director> GetDirectories()
        {
            throw new NotImplementedException();
        }

        public ICollection<Director> GetDirectorOfMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Movie> GetMovieByDirector(int directorId)
        {
            throw new NotImplementedException();
        }
    }
}
